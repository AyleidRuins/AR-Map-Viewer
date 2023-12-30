
namespace AR_Map_Viewer
{
    partial class Main
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labCurrentPosWall = new System.Windows.Forms.Label();
            this.labCurrPosDetails = new System.Windows.Forms.Label();
            this.labInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBox1.Location = new System.Drawing.Point(4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1040, 1040);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1094, 325);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current pos value :";
            // 
            // labCurrentPosWall
            // 
            this.labCurrentPosWall.AutoSize = true;
            this.labCurrentPosWall.Location = new System.Drawing.Point(1183, 325);
            this.labCurrentPosWall.Name = "labCurrentPosWall";
            this.labCurrentPosWall.Size = new System.Drawing.Size(10, 13);
            this.labCurrentPosWall.TabIndex = 2;
            this.labCurrentPosWall.Text = "-";
            // 
            // labCurrPosDetails
            // 
            this.labCurrPosDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labCurrPosDetails.Location = new System.Drawing.Point(1097, 348);
            this.labCurrPosDetails.Name = "labCurrPosDetails";
            this.labCurrPosDetails.Size = new System.Drawing.Size(208, 135);
            this.labCurrPosDetails.TabIndex = 4;
            this.labCurrPosDetails.Text = "-";
            // 
            // labInfo
            // 
            this.labInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labInfo.Location = new System.Drawing.Point(1097, 57);
            this.labInfo.Name = "labInfo";
            this.labInfo.Size = new System.Drawing.Size(208, 227);
            this.labInfo.TabIndex = 5;
            this.labInfo.Text = "Use the cursor keys to navigate:\r\n\r\nUp = North\r\nDown = South\r\nLeft = East\r\nRight " +
    "= West\r\n\r\nThe map design and original game\r\n\'Alternate Reality - The City\'\r\nwas " +
    "written by Philip Price.\r\n";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1452, 1049);
            this.Controls.Add(this.labInfo);
            this.Controls.Add(this.labCurrPosDetails);
            this.Controls.Add(this.labCurrentPosWall);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(425, -1);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Map Viewer for Alternate Reality - The City";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labCurrentPosWall;
        private System.Windows.Forms.Label labCurrPosDetails;
        private System.Windows.Forms.Label labInfo;
    }
}

