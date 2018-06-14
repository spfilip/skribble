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
        //String playerName;
        public Player player { get; set; }
        string pictureFolder = System.IO.Path.GetFullPath(@"..\\..\\Pictures\\");
        HighScoreTable hst;
        PicturesDoc pcDoc;
        Random rand;
        String nextImg;

        public Game(HighScoreTable hst, PicturesDoc pcDoc)
        {
            InitializeComponent();
            currentScore = 0;
            this.hst = hst;
            this.pcDoc = pcDoc;
            rand = new Random();
            startButton.Enabled = false;
            guessBtn.Enabled = false;
            guessTb.ReadOnly = true;
            player = new Player();
            nextImg = null;
            label7.Text = "";
            DialogResult = DialogResult.No;
            timePb.Maximum = 60;
            timePb.Step = 1;
        }

     
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (timeLeft == 0)
            {
                timer1.Stop();
                guessBtn.Enabled = false;
                guessTb.ReadOnly = true;
                player.Score = currentScore;
                MessageBox.Show(player.ToString());
                if (MessageBox.Show("New Game?", "New Game", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //DialogResult = DialogResult.Yes;
                    //this.Close();
                    currentScore = 0;
                    //startButton.Enabled = false;
                    //nextImg = null;
                    label7.Text = "";
                    timeLabel.Text = "00:60";
                    csLabel.Text = "0";
                    timePb.Value = 0;
                    pictureBox1.Image = null;
                    startButton.Enabled = true;
                }
                else
                {
                    
                    this.Close();
                }
                    
                    
            }
            timeLeft = timeLeft - 1;
            if (timeLeft!=-1)
                timeLabel.Text = "00:" + timeLeft.ToString();
            if (!startButton.Enabled)
                timePb.PerformStep();

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            //playerName = nameTextBox.Text;
            player.Name = nameTextBox.Text.Trim();
            loadPicture();
            startButton.Enabled = false;
        }

        void loadPicture()
        {
            timeLeft = 60;
            timePb.Value = 0;
            timer1.Start();
            guessBtn.Enabled = true;
            guessTb.ReadOnly = false;
            //Treba funkcija za dodavanje na sliki
            nextImg = pcDoc.getRandomPicture(rand);

            pictureBox1.Image = new Bitmap(pictureFolder + nextImg + ".jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            //label7.Text = "";
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (nameTextBox.Text.Trim().Length == 0)
            {
                nameEp.SetError(nameTextBox, "Mora da se vnese ime!");
                startButton.Enabled = false;
            }
            else
            {
                nameEp.SetError(nameTextBox, null);
                startButton.Enabled = true;
            }
        }

        private void guessBtn_Click(object sender, EventArgs e)
        {
            String guessed = guessTb.Text.Trim();
            //MessageBox.Show("nextImg=" + nextImg);
            if (guessed.ToLower().Equals(nextImg.ToLower()))
            {
                currentScore++;
                csLabel.Text = currentScore.ToString();
                label7.Text = "TOCNO!!!";
                loadPicture();
                guessTb.Text = "";
                
            }
            else
            {
                label7.Text = "GRESNO!!!";
                guessTb.Text = "";
                
            }
 
        }

        private void guessTb_KeyDown(object sender, KeyEventArgs e)
        {

            //Proveri dali vneseniot tekst e ist so imeto na slikata
            //zgolemi score za 1
            //currentScore++;
            if (e.KeyCode == Keys.Enter)
            {
                guessBtn_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }  
        }

        

        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            if (timeLeft != 0)
                DialogResult = DialogResult.Abort;
        }

        
    }
}
