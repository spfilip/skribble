using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
        Thread plThread;
        

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
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            plThread = new Thread(new ThreadStart(bfsCall));
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
                    plThread.Abort();
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

            //pictureBox1.Image = new Bitmap(pictureFolder + nextImg + ".jpg");
            //pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            plThread = new Thread(new ThreadStart(bfsCall));
            plThread.Start();
            //label7.Text = "";
        }

       

        void bfs(Bitmap b1)
        {

            Size size = new Size(b1.Width, b1.Height);
            Bitmap b2 = new Bitmap(pictureFolder + "Untitled.jpg");
            Bitmap b3 = new Bitmap(b2, size);
            //pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
 
            int sum = 0;

            bool[,] visited = new bool[b1.Height, b1.Width];

            HashSet<Pair> toVisit = new HashSet<Pair>();
            for (int i = 0; i < b1.Height; i++)
            {
                for (int j = 0; j < b1.Width; j++)
                {
                    //b3.SetPixel(j, i, b1.GetPixel(j, i));
                    toVisit.Add(new Pair(i, j));
                    visited[i, j] = false;
                    //MessageBox.Show(b1.GetPixel(j, i).ToString());
                }
            }

            int startI = b1.Height / 2;
            int startJ = b1.Width / 2;
            Pair start = new Pair(startI, startJ);
            Queue<Pair> q = new Queue<Pair>();

            q.Enqueue(start);

            int[] niza1 = { 0, 0, -1, 1 };
            int[] niza2 = { -1, 1, 0, 0 };
            bool flag = false;
            int brojac = 0;
            int del = 1;
            while (toVisit.Count != 0)
            {
                if (flag)
                {
                    Pair tV = toVisit.ToList()[0];
                    //MessageBox.Show("tvI=" + tV.i + ", tvJ=" + tV.j);
                    toVisit.Remove(tV);
                    q.Enqueue(tV);
                }
                flag = true;
                while (q.Count != 0)
                {
                    Pair curr = q.Dequeue();

                    int currI = curr.i;
                    int currJ = curr.j;
                    Color currColor = b1.GetPixel(currJ, currI);
                    visited[currI, currJ] = true;

                    toVisit.Remove(curr);
                    b3.SetPixel(currJ, currI, b1.GetPixel(currJ, currI));

                    for (int i = 0; i < 4; i++)
                    {
                        int nextI = currI + niza1[i];
                        int nextJ = currJ + niza2[i];
                        //MessageBox.Show("nextI=" + nextI + ", nextJ=" + nextJ);
                        if (nextI >= 0 && nextI < b1.Height && nextJ >= 0 && nextJ < b1.Width)
                        {
                            Color nextColor = b1.GetPixel(nextJ, nextI);
                            
                            if (isValidColor(currColor, nextColor) && !visited[nextI, nextJ])
                            {
                                Pair nextPair = new Pair(nextI, nextJ);
                                q.Enqueue(nextPair);
                                toVisit.Remove(nextPair);
                                visited[nextI, nextJ] = true;
                                //b3.SetPixel(currJ, currI, b1.GetPixel(nextJ, nextI));
                            }

                        }
                    }

                    if (brojac % del == 0)
                    {
                        //pictureBox1.Image = b3;
                        //pictureBox1.Refresh();
                        setImage(b3);
                        del += 1;
                        brojac = 0;
                    }
                    brojac++;
                }
            }

        }
        delegate void SetImageCallback(Bitmap bm);
        private void setImage(Bitmap bm)
        {
            if (this.pictureBox1.InvokeRequired)
            {
                SetImageCallback sic = new SetImageCallback(setImage);
                this.Invoke(sic, new object[] { bm });
            }
            else
            {
                pictureBox1.Image = bm;
                pictureBox1.Refresh();
            }
                
        }

        bool isValidColor(Color c1, Color c2)
        {
            int c1R = c1.R;
            int c1G = c1.G;
            int c1B = c1.B;

            int c2R = c2.R;
            int c2G = c2.G;
            int c2B = c2.B;

            if ((Math.Abs(c1R - c2R) <= 50) && (Math.Abs(c1G - c2G) <= 50) && (Math.Abs(c2B - c2B) <= 50))
                return true;
            return false;
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
                plThread.Abort();
                pictureBox1.Image = null;
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
            plThread.Abort();
            if (timeLeft != 0)
                DialogResult = DialogResult.Abort;
        }

        

        void bfsCall()
        {
            bfs(new Bitmap(pictureFolder + nextImg + ".jpg"));
        }
    }
}
