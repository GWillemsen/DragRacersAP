﻿namespace DragRacerGwil
{
    partial class frmMainGwil
    {

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tmrKeepDrawingGwil = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tmrKeepDrawingGwil
            // 
            this.tmrKeepDrawingGwil.Interval = 1000;
            this.tmrKeepDrawingGwil.Tick += new System.EventHandler(this.tmrKeepDrawingGwil_Tick);
            // 
            // frmMainGwil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 394);
            this.DoubleBuffered = true;
            this.Name = "frmMainGwil";
            this.Load += new System.EventHandler(this.frmMainGwil_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.frmMainGwil_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmMainGwil_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmMainGwil_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmMainGwil_MouseUp);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Timer tmrKeepDrawingGwil;
        private System.ComponentModel.IContainer components;
    }
}

