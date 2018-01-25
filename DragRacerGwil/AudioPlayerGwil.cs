using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DragRacerGwil
{
    /// <summary>
    /// A audio player based on NAudio
    /// </summary>
    public static class csAudioPlayerGwil
    {
        #region Fields

        //generic variables
        public static bool shouldEndOrRestartGwil = true;
        private static MeteringSampleProvider obPostVolumeMeterGwil = null;
        private static WaveFileReader obReaderGwil = null;

        //providers for wave data
        private static SampleChannel obSampleChannelGwil = null;
        private static List<WaveFileReader> obStreamsToPlayGwil = new List<WaveFileReader>();

        //variables for play list
        private static bool playFromStreamListGwil = false;

        //the minimum for the wave player(the play and reader)
        private static IWavePlayer waveOutGwil = new WaveOut();

        #endregion Fields

        #region Delegates

        public delegate void PreVolumeMeterEventGwil(StreamVolumeEventArgs eGwil);

        public delegate void StartPlayNewSongDelegateGwil(EventArgs argsGwil);

        public delegate void VolumeMeterEventGwil(StreamVolumeEventArgs eGwil);

        #endregion Delegates

        #region Events
        public static event PreVolumeMeterEventGwil PreVolumeMeterGwil;
        //custom event for handling audio data
        public static event StartPlayNewSongDelegateGwil StartPlayNewSongGwil;
        public static event VolumeMeterEventGwil StreamVolumeGwil;

        #endregion Events

        #region Enums

        /// <summary>
        /// The enum for the overide of the current playing stream(if there is)
        /// </summary>
        public enum OverrideTypeGwil
        {
            pauseCurrentStreamAndContinueAfterEnded,
            dontPlayNewStream,
            endCurrentStreamAndStartNew,
            addToWaitList
        }

        #endregion Enums

        #region Methods

        /// <summary>
        /// Tell all functions to close and reset to default values
        /// </summary>
        public static void CloseGwil()
        {
            csMessageHelperGwil.LogMessage("Stopping audio play", true);
            //clean variables and set the shoud end or resart var to false
            obStreamsToPlayGwil.Clear();
            playFromStreamListGwil = false;
            shouldEndOrRestartGwil = false;
            if (waveOutGwil != null && waveOutGwil.PlaybackState != PlaybackState.Stopped)
            {
                waveOutGwil.Pause();
                obReaderGwil.CurrentTime = obReaderGwil.TotalTime - new TimeSpan(0, 0, 0, 0, 1); //set the play position to milisecond before end
                waveOutGwil.PlaybackStopped += (sGwil, eGwil) =>
                {
                    //stop auto play
                    CloseWaveOutGwil();
                    obSampleChannelGwil = null;
                    obPostVolumeMeterGwil = null;
                };
                //start play
                waveOutGwil.Play();
            }
            else
            {
                CloseWaveOutGwil();//just close the waveout and filereader
            }
        }

        /// <summary>
        /// Play the wave file sended in the stream(based on a example in NAudio
        /// </summary>
        /// <param name="obWaveDataLocationGwil">The file to play as wave data</param>
        /// <param name="overideReturnWhenPlayingGwil">
        /// The wave to handle when there is already a song playing
        /// </param>
        public static Exception PlayGwil(string obWaveDataLocationGwil, OverrideTypeGwil overideReturnWhenPlayingGwil = OverrideTypeGwil.addToWaitList)
        {
            try
            {
                //play the song
                PlayGwil(new WaveFileReader(obWaveDataLocationGwil), overideReturnWhenPlayingGwil);//create an new wavefilereader from the data stream
            }
            catch (Exception exGwil)
            {
                //write error to debug
                csMessageHelperGwil.LogMessage("Error at playing audio: " + exGwil.Message, false);
                csMessageHelperGwil.LogMessage(exGwil.ToString(), true);
                return exGwil;
            }
            return null;
        }

        /// <summary>
        /// Play the wave file sended in the stream(based on a example in NAudio
        /// </summary>
        /// <param name="obWaveDataGwil">The io stream to play as wave data</param>
        /// <param name="overideReturnWhenPlayingGwil">
        /// The wave to handle when there is already a song playing
        /// </param>
        public static Exception PlayGwil(System.IO.Stream obWaveDataGwil, OverrideTypeGwil overideReturnWhenPlayingGwil = OverrideTypeGwil.addToWaitList)
        {
            try
            {
                //play the song
                PlayGwil(new WaveFileReader(obWaveDataGwil), overideReturnWhenPlayingGwil);//create an new wavefilereader from the data stream
            }
            catch (Exception exGwil)
            {
                //write error to debug
                csMessageHelperGwil.LogMessage("Error at playing audio: " + exGwil.Message, false);
                csMessageHelperGwil.LogMessage(exGwil.ToString(), true);
                return exGwil;
            }
            return null;
        }

        /// <summary>
        /// Play the wave file sended in the stream(based on a example in NAudio
        /// </summary>
        /// <param name="obWaveReaderGwil">The base class for wave data</param>
        /// <param name="overideReturnWhenPlayingGwil">
        /// The wave to handle when there is already a song playing
        /// </param>
        public static Exception PlayGwil(WaveFileReader obWaveReaderGwil, OverrideTypeGwil overideReturnWhenPlayingGwil = OverrideTypeGwil.addToWaitList)
        {
            csMessageHelperGwil.LogMessage("Starting play of audio");
            //if we should not continue starting to play this file
            if (shouldEndOrRestartGwil == false && overideReturnWhenPlayingGwil == OverrideTypeGwil.dontPlayNewStream)
            {
                return null;
            }

            //if we need to pause current and play after the new one
            if (shouldEndOrRestartGwil == false && overideReturnWhenPlayingGwil == OverrideTypeGwil.pauseCurrentStreamAndContinueAfterEnded)
            {
                //set play from playlist to true and add to to the list
                obStreamsToPlayGwil.Add(obReaderGwil);
                playFromStreamListGwil = true;
            }

            //if we need to add to list to play after the current (in line) ones
            if (shouldEndOrRestartGwil == false && overideReturnWhenPlayingGwil == OverrideTypeGwil.addToWaitList)
            {
                //set play from playlist to true and add to the list and leave this function
                playFromStreamListGwil = true;
                obStreamsToPlayGwil.Add(obWaveReaderGwil);
                return null;
            }
            csMessageHelperGwil.LogMessage("Creating new waveOut etc", true);
            try
            {
                //create a new wave reader and player
                CreateWaveOutGwil();
                obReaderGwil = obWaveReaderGwil;
                waveOutGwil.Init(CreateSampleProvider(obReaderGwil));
                //set to false so they you are playing
                shouldEndOrRestartGwil = false;
                csMessageHelperGwil.LogMessage("Starting actually playing audio", true);
                waveOutGwil.Play();

                csMessageHelperGwil.LogMessage("Raising events and adding handlers", true);
                //raise events
                waveOutGwil.PlaybackStopped += WaveOutGwil_PlaybackStopped;
                StartPlayNewSongGwil?.Invoke(new SongsStartedEventArgsGwil(obReaderGwil.WaveFormat, obReaderGwil.TotalTime));
                obPostVolumeMeterGwil.StreamVolume += (senderGwil, eventGwil) => { StreamVolumeGwil?.Invoke(eventGwil); };
                obSampleChannelGwil.PreVolumeMeter += (senderGwil, eventGwil) => { PreVolumeMeterGwil?.Invoke(eventGwil); };
                csMessageHelperGwil.LogMessage("Successfully started audio play");
            }
            catch (Exception exGwil)
            {
                //write error to debug
                csMessageHelperGwil.LogMessage("Error at playing audio: " + exGwil.Message, false);
                csMessageHelperGwil.LogMessage(exGwil.ToString(), true);
                return exGwil;
            }
            return null;
        }

        /// <summary>
        /// Close the waveOut object for the audio play(also stolen(not the comment) from NAudio sample)
        /// </summary>
        private static void CloseWaveOutGwil()
        {
            csMessageHelperGwil.LogMessage("Closing audio play from waveout", true);
            try
            {
                //waveout errors when you try to finalize it so suppress it and only dispose it.
                GC.SuppressFinalize(waveOutGwil);
            }
            catch { }

            //check if waveout is set because cant stop an audio stream that does not exists
            if (waveOutGwil != null)
            {
                waveOutGwil.Stop();
            }
            if (obReaderGwil != null)
            {
                // this one really closes the file and ACM(raw audio) conversion
                obReaderGwil.Dispose();
                obReaderGwil = null;
                obReaderGwil = null;
            }

            if (waveOutGwil != null)
            {
                //dispose the waveout so it does not use resources anymore
                waveOutGwil.Dispose();
                waveOutGwil = null;
            }
            GC.Collect();
        }

        /// <summary>
        /// Create a new sample provider from the waveFileReader with samplechannel and Metering
        /// sample channel
        /// </summary>
        /// <param name="obReaderGwil">The file to base the provider on</param>
        /// <returns>The sample provider for the waveOut player</returns>
        private static ISampleProvider CreateSampleProvider(WaveFileReader obReaderGwil)
        {
            csMessageHelperGwil.LogMessage("Creating new sample provider for audio", true);
            //create the new provider and sample channel
            obSampleChannelGwil = new SampleChannel(obReaderGwil, false);
            obPostVolumeMeterGwil = new MeteringSampleProvider(obSampleChannelGwil);
            return obPostVolumeMeterGwil;
        }

        /// <summary>
        /// Create an new waveOut object for audio play(stolen(not the comment) from NAudio sample)
        /// </summary>
        private static void CreateWaveOutGwil()
        {
            csMessageHelperGwil.LogMessage("Destroying waveout to create an new one", true);
            //first close all other player audio
            CloseWaveOutGwil();

            //create the new waveout
            waveOutGwil = new WaveOut();
            GC.SuppressFinalize(waveOutGwil);
        }

        /// <summary>
        /// Event handler for when the audio stop playing
        /// </summary>
        /// <param name="obSenderGwil">the sender from wich the call originated</param>
        /// <param name="eGwil">Extra info about why stopped</param>
        private static void WaveOutGwil_PlaybackStopped(object obSenderGwil, StoppedEventArgs eGwil)
        {
            CloseWaveOutGwil();//close the last audio stream
            if (playFromStreamListGwil == true && obStreamsToPlayGwil.Count > 0)
            {
                //start next song from playlist
                PlayGwil(obStreamsToPlayGwil[0], OverrideTypeGwil.endCurrentStreamAndStartNew);
                obStreamsToPlayGwil.RemoveAt(0);
                csMessageHelperGwil.LogMessage("Playback of audio stopped starting next song on playlist");
            }
            else
            {
                //reset data varaiables
                shouldEndOrRestartGwil = true;
                playFromStreamListGwil = false;
                obStreamsToPlayGwil.Clear();
                csMessageHelperGwil.LogMessage("Playback of audio stopped and no songs from playlist");
            }
        }

        #endregion Methods
    }

    /// <summary>
    /// A class that contains data about a song start event
    /// </summary>
    public class SongsStartedEventArgsGwil : EventArgs
    {
        #region Fields
        private TimeSpan totalLenghtSongGwil;
        private WaveFormat wavFormatGwil;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Create a new Start song event argument list
        /// </summary>
        /// <param name="waveFormatGwil">The format of the wave data</param>
        /// <param name="totalLenghtGwil">Teh lenght of the song</param>
        public SongsStartedEventArgsGwil(WaveFormat waveFormatGwil, TimeSpan totalLenghtGwil)
        {
            this.wavFormatGwil = waveFormatGwil;
            this.totalLenghtSongGwil = totalLenghtGwil;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// The total lenght of the song
        /// </summary>
        public TimeSpan TotalLenghtGwil
        {
            get => totalLenghtSongGwil;
        }

        /// <summary>
        /// The wave format of the internal data
        /// </summary>
        public WaveFormat WaveFormatGwil
        {
            get => wavFormatGwil;
        }

        #endregion Properties
    }

}