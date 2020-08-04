namespace PongUI
{
    partial class MainForm
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
            this.firstPlayerScore = new System.Windows.Forms.Label();
            this.secondPlayerScore = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // firstPlayerScore
            // 
            this.firstPlayerScore.AutoSize = true;
            this.firstPlayerScore.Font = new System.Drawing.Font("Lucida Sans", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstPlayerScore.ForeColor = System.Drawing.Color.Black;
            this.firstPlayerScore.Location = new System.Drawing.Point(300, 10);
            this.firstPlayerScore.Name = "firstPlayerScore";
            this.firstPlayerScore.Size = new System.Drawing.Size(54, 55);
            this.firstPlayerScore.TabIndex = 0;
            this.firstPlayerScore.Text = "0";
            // 
            // secondPlayerScore
            // 
            this.secondPlayerScore.AutoSize = true;
            this.secondPlayerScore.Font = new System.Drawing.Font("Lucida Sans", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secondPlayerScore.ForeColor = System.Drawing.Color.Black;
            this.secondPlayerScore.Location = new System.Drawing.Point(645, 10);
            this.secondPlayerScore.Name = "secondPlayerScore";
            this.secondPlayerScore.Size = new System.Drawing.Size(54, 55);
            this.secondPlayerScore.TabIndex = 0;
            this.secondPlayerScore.Text = "0";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(214)))), ((int)(((byte)(251)))));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(375, 300);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(250, 100);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(22F, 42F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this.ClientSize = new System.Drawing.Size(984, 711);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.secondPlayerScore);
            this.Controls.Add(this.firstPlayerScore);
            this.Font = new System.Drawing.Font("Lucida Sans", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(9);
            this.MaximumSize = new System.Drawing.Size(1000, 750);
            this.MinimumSize = new System.Drawing.Size(1000, 750);
            this.Name = "MainForm";
            this.Text = "PONG";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label firstPlayerScore;
        private System.Windows.Forms.Label secondPlayerScore;
        private System.Windows.Forms.Button button1;
    }
}

