namespace Suwak
{
    partial class Form1
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
            this.suwak1 = new Suwak();
            this.SuspendLayout();
            // 
            // suwak1
            // 
            this.suwak1.BackColor = System.Drawing.Color.Lavender;
            this.suwak1.IsHorizontal = false;
            this.suwak1.Location = new System.Drawing.Point(144, 66);
            this.suwak1.Max = 150;
            this.suwak1.Min = 0;
            this.suwak1.MyBackColor = System.Drawing.Color.Lavender;
            this.suwak1.MyLineColor = System.Drawing.Color.Maroon;
            this.suwak1.MyRectColor = System.Drawing.Color.SaddleBrown;
            this.suwak1.Name = "suwak1";
            this.suwak1.Size = new System.Drawing.Size(54, 162);
            this.suwak1.TabIndex = 0;
            this.suwak1.Value = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.suwak1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Suwak suwak1;
    }
}

