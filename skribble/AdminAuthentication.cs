using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace skribble
{
    public partial class AdminAuthentication : Form
    {
        bool f1 = true;
        bool f2 = true;
        bool f3 = true;
        string picturePath = "";

        string pictureFolder = System.IO.Path.GetFullPath(@"..\\..\\Pictures\\");
        public AdminAuthentication()
        {
            InitializeComponent();
        }

        private void AdminAuthentication_Load(object sender, EventArgs e)
        {

        }

        private void userTextBox_Click(object sender, EventArgs e)
        {
            if (f1)
            {
                userTextBox.Clear();
                f1 = false;
            }
            userTextBox.ForeColor = Color.Black;
        }

        private void passwordTextBox_Click(object sender, EventArgs e)
        {
            if (f2)
            {
                passwordTextBox.Clear();
                f2 = false;
            }
            passwordTextBox.ForeColor = Color.Black;
        }

        private void userTextBox_TextChanged(object sender, EventArgs e)
        {
            userTextBox.ForeColor = Color.Black;
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.ForeColor = Color.Black;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if(userTextBox.Text=="admin" && passwordTextBox.Text=="finkiVP")
            {
                browsePcButton.Enabled = true;
                pictureNameTextBox.Enabled = true;
            }
        }

        private void browsePcButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Filter = "images | *.png;*.jpg;*.jpeg;*.gif";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                picturePath = theDialog.FileName;
                addPictureButton.Enabled = true;
            }
        }

        private void userTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                loginButton.PerformClick();
            }
        }

        private void passwordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginButton.PerformClick();
                if (passwordTextBox.Text == "finkiVP")
                {
                    epPassword.Icon = Properties.Resources.if_f_check_256_282474;
                    epPassword.SetError(passwordTextBox, " Username error");
                }
                else
                {
                    epPassword.Icon = Properties.Resources.if_f_cross_256_282471;
                    epPassword.SetError(passwordTextBox, " Ok");
                }
            }
        }

        private void addPictureButton_Click(object sender, EventArgs e)
        {
            string dest = pictureFolder + pictureNameTextBox.Text + ".jpg";
            if (pictureNameTextBox.Text == "")
            {
                MessageBox.Show("Enter valid name");
            }
            else
            {
                System.IO.File.Copy(picturePath, dest, true);
            }
            Launcher obj = Parent as Launcher;
            obj.pcDoc.pictures.Add(pictureNameTextBox.Text);
        }

        private void pictureNameTextBox_TextChanged(object sender, EventArgs e)
        {
            pictureNameTextBox.ForeColor = Color.Black;
        }

        private void pictureNameTextBox_Click(object sender, EventArgs e)
        {
            if (f3)
            {
                pictureNameTextBox.Clear();
                f3 = false;
            }
            pictureNameTextBox.ForeColor = Color.Black;
        }

        private void pictureNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addPictureButton.PerformClick();
            }
        }

        private void userTextBox_Leave(object sender, EventArgs e)
        {
            if (userTextBox.Text == "admin")
            {
                epUsername.Icon = Properties.Resources.if_f_check_256_282474;
                epUsername.SetError(userTextBox, " Username error");
            }
            else
            {
                epUsername.Icon = Properties.Resources.if_f_cross_256_282471;
                epUsername.SetError(userTextBox, " Ok");
            }
        }

        private void passwordTextBox_Leave(object sender, EventArgs e)
        {
            if (passwordTextBox.Text == "finkiVP")
            {
                epPassword.Icon = Properties.Resources.if_f_check_256_282474;
                epPassword.SetError(passwordTextBox, " Username error");
            }
            else
            {
                epPassword.Icon = Properties.Resources.if_f_cross_256_282471;
                epPassword.SetError(passwordTextBox, " Ok");
            }
        }
    }
}
