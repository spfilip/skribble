namespace skribble
{
    partial class AdminAuthentication
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminAuthentication));
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.signIn = new System.Windows.Forms.Label();
            this.userTextBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.browsePcButton = new System.Windows.Forms.Button();
            this.pictureNameTextBox = new System.Windows.Forms.TextBox();
            this.addPictureButton = new System.Windows.Forms.Button();
            this.epUsername = new System.Windows.Forms.ErrorProvider(this.components);
            this.epPassword = new System.Windows.Forms.ErrorProvider(this.components);
            this.loginLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.epUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextBox.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.passwordTextBox.Location = new System.Drawing.Point(41, 130);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(300, 38);
            this.passwordTextBox.TabIndex = 1;
            this.passwordTextBox.Text = "Password :";
            this.passwordTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.passwordTextBox.Click += new System.EventHandler(this.passwordTextBox_Click);
            this.passwordTextBox.TextChanged += new System.EventHandler(this.passwordTextBox_TextChanged);
            this.passwordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordTextBox_KeyDown);
            this.passwordTextBox.Leave += new System.EventHandler(this.passwordTextBox_Leave);
            // 
            // signIn
            // 
            this.signIn.AutoSize = true;
            this.signIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signIn.Location = new System.Drawing.Point(136, 9);
            this.signIn.Name = "signIn";
            this.signIn.Size = new System.Drawing.Size(116, 31);
            this.signIn.TabIndex = 4;
            this.signIn.Text = "SIGN IN";
            // 
            // userTextBox
            // 
            this.userTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.userTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userTextBox.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.userTextBox.Location = new System.Drawing.Point(41, 77);
            this.userTextBox.Name = "userTextBox";
            this.userTextBox.Size = new System.Drawing.Size(300, 38);
            this.userTextBox.TabIndex = 0;
            this.userTextBox.Text = "Username :";
            this.userTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.userTextBox.Click += new System.EventHandler(this.userTextBox_Click);
            this.userTextBox.TextChanged += new System.EventHandler(this.userTextBox_TextChanged);
            this.userTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.userTextBox_KeyDown);
            this.userTextBox.Leave += new System.EventHandler(this.userTextBox_Leave);
            // 
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.SystemColors.Window;
            this.loginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginButton.ForeColor = System.Drawing.SystemColors.WindowText;
            this.loginButton.Location = new System.Drawing.Point(41, 184);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(300, 40);
            this.loginButton.TabIndex = 5;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // browsePcButton
            // 
            this.browsePcButton.Enabled = false;
            this.browsePcButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browsePcButton.Location = new System.Drawing.Point(41, 269);
            this.browsePcButton.Name = "browsePcButton";
            this.browsePcButton.Size = new System.Drawing.Size(300, 40);
            this.browsePcButton.TabIndex = 6;
            this.browsePcButton.Text = "Browse a picture from PC";
            this.browsePcButton.UseVisualStyleBackColor = true;
            this.browsePcButton.Click += new System.EventHandler(this.browsePcButton_Click);
            // 
            // pictureNameTextBox
            // 
            this.pictureNameTextBox.Enabled = false;
            this.pictureNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.pictureNameTextBox.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.pictureNameTextBox.Location = new System.Drawing.Point(41, 315);
            this.pictureNameTextBox.Name = "pictureNameTextBox";
            this.pictureNameTextBox.Size = new System.Drawing.Size(300, 38);
            this.pictureNameTextBox.TabIndex = 7;
            this.pictureNameTextBox.Text = "Enter picture name here";
            this.pictureNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pictureNameTextBox.Click += new System.EventHandler(this.pictureNameTextBox_Click);
            this.pictureNameTextBox.TextChanged += new System.EventHandler(this.pictureNameTextBox_TextChanged);
            this.pictureNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pictureNameTextBox_KeyDown);
            // 
            // addPictureButton
            // 
            this.addPictureButton.Enabled = false;
            this.addPictureButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addPictureButton.Location = new System.Drawing.Point(41, 359);
            this.addPictureButton.Name = "addPictureButton";
            this.addPictureButton.Size = new System.Drawing.Size(300, 40);
            this.addPictureButton.TabIndex = 8;
            this.addPictureButton.Text = "Add picture";
            this.addPictureButton.UseVisualStyleBackColor = true;
            this.addPictureButton.Click += new System.EventHandler(this.addPictureButton_Click);
            // 
            // epUsername
            // 
            this.epUsername.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.epUsername.ContainerControl = this;
            this.epUsername.Icon = ((System.Drawing.Icon)(resources.GetObject("epUsername.Icon")));
            // 
            // epPassword
            // 
            this.epPassword.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.epPassword.ContainerControl = this;
            this.epPassword.Icon = ((System.Drawing.Icon)(resources.GetObject("epPassword.Icon")));
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginLabel.Location = new System.Drawing.Point(112, 241);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.loginLabel.Size = new System.Drawing.Size(64, 25);
            this.loginLabel.TabIndex = 9;
            this.loginLabel.Text = "label1";
            // 
            // AdminAuthentication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 411);
            this.Controls.Add(this.loginLabel);
            this.Controls.Add(this.addPictureButton);
            this.Controls.Add(this.pictureNameTextBox);
            this.Controls.Add(this.browsePcButton);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.signIn);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.userTextBox);
            this.Name = "AdminAuthentication";
            this.Text = "Admin Authentication";
            this.Load += new System.EventHandler(this.AdminAuthentication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label signIn;
        private System.Windows.Forms.TextBox userTextBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button browsePcButton;
        private System.Windows.Forms.TextBox pictureNameTextBox;
        private System.Windows.Forms.Button addPictureButton;
        private System.Windows.Forms.ErrorProvider epUsername;
        private System.Windows.Forms.ErrorProvider epPassword;
        private System.Windows.Forms.Label loginLabel;
    }
}