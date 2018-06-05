namespace skribble
{
    partial class Launcher
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
            this.startGame = new System.Windows.Forms.Button();
            this.highScore = new System.Windows.Forms.Button();
            this.adminLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startGame
            // 
            this.startGame.BackColor = System.Drawing.Color.Transparent;
            this.startGame.Location = new System.Drawing.Point(48, 35);
            this.startGame.Name = "startGame";
            this.startGame.Size = new System.Drawing.Size(138, 50);
            this.startGame.TabIndex = 0;
            this.startGame.Text = "Start Game";
            this.startGame.UseVisualStyleBackColor = false;
            this.startGame.Click += new System.EventHandler(this.startGame_Click);
            // 
            // highScore
            // 
            this.highScore.Location = new System.Drawing.Point(48, 131);
            this.highScore.Name = "highScore";
            this.highScore.Size = new System.Drawing.Size(138, 50);
            this.highScore.TabIndex = 1;
            this.highScore.Text = "High Score";
            this.highScore.UseVisualStyleBackColor = true;
            this.highScore.Click += new System.EventHandler(this.highScore_Click);
            // 
            // adminLogin
            // 
            this.adminLogin.Location = new System.Drawing.Point(48, 228);
            this.adminLogin.Name = "adminLogin";
            this.adminLogin.Size = new System.Drawing.Size(138, 50);
            this.adminLogin.TabIndex = 2;
            this.adminLogin.Text = "Admin Login";
            this.adminLogin.UseVisualStyleBackColor = true;
            this.adminLogin.Click += new System.EventHandler(this.adminLogin_Click);
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 311);
            this.Controls.Add(this.adminLogin);
            this.Controls.Add(this.highScore);
            this.Controls.Add(this.startGame);
            this.Name = "Launcher";
            this.Text = "Skribble";
            this.Load += new System.EventHandler(this.Launcher_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button highScore;
        private System.Windows.Forms.Button adminLogin;
        private System.Windows.Forms.Button startGame;
    }
}

