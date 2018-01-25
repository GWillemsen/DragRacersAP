namespace DragRacerGwil
{
    partial class frmSerialMonitor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtbSimpleLogGwil = new System.Windows.Forms.RichTextBox();
            this.cbkAdvancedLogGwil = new System.Windows.Forms.CheckBox();
            this.rtbAdvancedLogGwil = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbSimpleLogGwil
            // 
            this.rtbSimpleLogGwil.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbSimpleLogGwil.Location = new System.Drawing.Point(0, 21);
            this.rtbSimpleLogGwil.Margin = new System.Windows.Forms.Padding(10, 10, 5, 10);
            this.rtbSimpleLogGwil.Name = "rtbSimpleLogGwil";
            this.rtbSimpleLogGwil.Size = new System.Drawing.Size(713, 240);
            this.rtbSimpleLogGwil.TabIndex = 0;
            this.rtbSimpleLogGwil.Text = "";
            // 
            // cbkAdvancedLogGwil
            // 
            this.cbkAdvancedLogGwil.AutoSize = true;
            this.cbkAdvancedLogGwil.Checked = true;
            this.cbkAdvancedLogGwil.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbkAdvancedLogGwil.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbkAdvancedLogGwil.Location = new System.Drawing.Point(0, 0);
            this.cbkAdvancedLogGwil.Name = "cbkAdvancedLogGwil";
            this.cbkAdvancedLogGwil.Size = new System.Drawing.Size(713, 21);
            this.cbkAdvancedLogGwil.TabIndex = 1;
            this.cbkAdvancedLogGwil.Text = "Advanced log";
            this.cbkAdvancedLogGwil.UseVisualStyleBackColor = true;
            this.cbkAdvancedLogGwil.CheckedChanged += new System.EventHandler(this.cbkAdvancedLogGwil_CheckedChanged);
            // 
            // rtbAdvancedLogGwil
            // 
            this.rtbAdvancedLogGwil.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbAdvancedLogGwil.Location = new System.Drawing.Point(0, 21);
            this.rtbAdvancedLogGwil.Margin = new System.Windows.Forms.Padding(10, 10, 5, 10);
            this.rtbAdvancedLogGwil.Name = "rtbAdvancedLogGwil";
            this.rtbAdvancedLogGwil.Size = new System.Drawing.Size(713, 240);
            this.rtbAdvancedLogGwil.TabIndex = 2;
            this.rtbAdvancedLogGwil.Text = "";
            // 
            // frmSerialMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 261);
            this.Controls.Add(this.rtbAdvancedLogGwil);
            this.Controls.Add(this.rtbSimpleLogGwil);
            this.Controls.Add(this.cbkAdvancedLogGwil);
            this.Name = "frmSerialMonitor";
            this.ShowIcon = false;
            this.Text = "frmSerialMonitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSerialMonitor_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbSimpleLogGwil;
        private System.Windows.Forms.CheckBox cbkAdvancedLogGwil;
        private System.Windows.Forms.RichTextBox rtbAdvancedLogGwil;
    }
}