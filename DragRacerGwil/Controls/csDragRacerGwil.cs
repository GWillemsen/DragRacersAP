namespace DragRacerGwil.Controls
{
    public class csDragRacerGwil : csBasicControlGwil
    {
        #region Fields

        private string racerNameGwil;

        #endregion Fields

        #region Constructors

        public csDragRacerGwil()
        {
        }

        #endregion Constructors

        #region Properties

        public string RacerNameGwil
        {
            get => racerNameGwil;
            set => racerNameGwil = value;
        }

        #endregion Properties

        #region Methods

        public void AddExtraMovement()
        {
            throw new System.NotImplementedException();
        }

        public void CreateRandomSpeed()
        {
            throw new System.NotImplementedException();
        }

        public void StartMovement()
        {
            throw new System.NotImplementedException();
        }

        public void StopMovement()
        {
            throw new System.NotImplementedException();
        }

        #endregion Methods
    }
}