
namespace ALERT_AI
{
    partial class Alert_AI
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
            this.Speak_Button = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Speak_Button
            // 
            this.Speak_Button.AutoSize = true;
            this.Speak_Button.BackColor = System.Drawing.Color.Red;
            this.Speak_Button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Speak_Button.Location = new System.Drawing.Point(145, 440);
            this.Speak_Button.Name = "Speak_Button";
            this.Speak_Button.Size = new System.Drawing.Size(130, 52);
            this.Speak_Button.TabIndex = 1;
            this.Speak_Button.Text = "Activate";
            this.Speak_Button.UseVisualStyleBackColor = false;
            this.Speak_Button.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::ALERT_AI.Properties.Resources.open_graph;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 400);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Alert_AI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(422, 516);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Speak_Button);
            this.Name = "Alert_AI";
            this.Text = "ALERT AI";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Speak_Button;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

