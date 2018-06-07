using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace skribble
{
    public partial class Game : Form
    {
        
        int timeLeft;
        int currentScore;
        String playerName;
        public Game()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLeft = timeLeft - 1;
            if (timeLeft == 0)
            {
                timer1.Stop();
                
            }
            timeLabel.Text = "00:" + timeLeft.ToString();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            playerName = nameTextBox.Text;
            timeLeft = 60;
            timer1.Start();
            //Treba funkcija za dodavanje na sliki
            pictureBox1.Image = new Bitmap("C:\\Users\\Fico\\Desktop\\Skribble\\skribble\\skribble\\Pictures\\dv.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Game_Load(object sender, EventArgs e)
        {
           
            
        }

        private void textBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            //Proveri dali vneseniot tekst e ist so imeto na slikata
            //zgolemi score za 1
            if (e.KeyCode == Keys.Enter)
            {
                csLabel.Text = "1";
            }
        }
    }
}
