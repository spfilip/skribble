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
        Bitmap b2;
        float currWidth;
        float currHeight;

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
            b2 = new Bitmap(pictureFolder + "Untitled.jpg");
            currWidth = this.Width;
            currHeight = this.Height;
            
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
                    plThread.Abort();
                    pictureBox1.Image = null;
                    pictureBox1.Refresh();
                    nameTextBox.ReadOnly = false;
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
            nameTextBox.ReadOnly = true;
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
            plThread.Abort();
            
            plThread = new Thread(new ThreadStart(bfsCall));
            plThread.Start();
            //label7.Text = "";
        }

       

        void bfs(Bitmap b1)
        {

            Size size = new Size(b1.Width, b1.Height);
            
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
            int vkupno = b1.Width * b1.Height;
            //MessageBox.Show("pq_width=" + pictureBox1.Width + ", p1_height=" + pictureBox1.Height);

            // int startI = b1.Height / 2;
            //int startJ = b1.Width / 2;
            int startI = rand.Next(b1.Height);
            int startJ = rand.Next(b1.Width);
            Pair start = new Pair(startI, startJ);
            Queue<Pair> q = new Queue<Pair>();

            q.Enqueue(start);

            int[] niza1 = { 0, 0, -1, 1 };
            int[] niza2 = { -1, 1, 0, 0 };
            bool flag = false;
            int brojac = 0;
            int del = 1;

            bool stepsChange = true;
            int steps = 50;
            
            int[] remainders = { 0, 0, 0, 0, 0, 0 };

            while (toVisit.Count != 0)
            {
                if (flag)
                {
                    int randInt = rand.Next(3);
                    int idx = 0;
                    if (randInt == 0)
                        idx = 0;
                    else if (randInt == 1)
                        idx = toVisit.Count / 2;
                    else
                        idx = toVisit.Count - 1;

                    
                    Pair tV = toVisit.ToList()[idx];
                    //MessageBox.Show("tvI=" + tV.i + ", tvJ=" + tV.j);
                    toVisit.Remove(tV);
                    q.Enqueue(tV);
                }
                flag = true;
                Pair compareColorPair = q.Peek();
                int ccpI = compareColorPair.i;
                int ccpJ = compareColorPair.j;
                Color compareColor = b1.GetPixel(ccpJ, ccpI);
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

                            if (isValidColor(compareColor, nextColor) && !visited[nextI, nextJ])
                            {
                                Pair nextPair = new Pair(nextI, nextJ);
                                q.Enqueue(nextPair);
                                toVisit.Remove(nextPair);
                                visited[nextI, nextJ] = true;
                                //b3.SetPixel(currJ, currI, b1.GetPixel(nextJ, nextI));
                            }

                        }
                    }

                    int notVisited = toVisit.Count;
                    if (notVisited == 0)
                        notVisited = 1;

                    if (stepsChange)
                    {
                        //steps = 50;
                        
                        if (timeLeft % 10 == 0)
                        {
                            //steps += 1*increaseTimes;
                            int idx = timeLeft / 10 - 1;
                            if (idx < 0)
                                idx = 0;
                            if (remainders[idx] <= (6 - timeLeft / 10))
                            {
                                //steps += 6 - timeLeft / 10;
                                steps++;
                                remainders[idx]++;
                            }

                            //MessageBox.Show("se zgolemuva za" + (6 - (timeLeft / 10)).ToString());
                        }
                            
                    }
                    //if (stepsChange)
                    //steps = 60*3000 - timeLeft * 3000;
                    int steps2 = 0;
                    int divide = getNumber(this.pictureBox1);
                    
                    if (stepsChange)
                        steps2 = 10 + notVisited / divide;

                    if (stepsChange)
                    {
                        steps = (steps + steps2) / 2;
                    }

                    if (timeLeft <= 17)
                        steps = 100;

                    if (timeLeft <= 16)
                        steps = 200;

                    if (timeLeft <= 15)
                        steps = 300;

                    if (timeLeft <= 14)
                        steps = 400;

                    if (timeLeft <= 13)
                        steps = toVisit.Count/2;

                    if (timeLeft <= 12)
                        steps = toVisit.Count;

                    //if (timeLeft > 30 && (toVisit.Count < (vkupno / 2)))
                        //steps = 10;

                    if (timeLeft > 40 && (toVisit.Count < (vkupno / 6)*2))
                        steps = 10;

                    if (timeLeft > 50 && (toVisit.Count < (vkupno / 6)))
                        steps = 1;

                    

                    if (steps == 0)
                        steps = 100;

                    //int steps3 = steps * 2;

                    if (brojac % steps == 0)
                    {
                        //pictureBox1.Image = b3;
                        //pictureBox1.Refresh();
                        setImage(b3);
                        del += 1;
                        brojac = 0;
                        stepsChange = true;
                    }
                    else
                        stepsChange = false;

                    brojac++;
                }
                //MessageBox.Show("steps=" + steps);
            }
            setImage(b3);

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

        int getNumber(PictureBox pb)
        {
            int oldWidth = pictureBox1.Width;
            int oldHeight = pictureBox1.Height;

            int currVkupno = oldWidth * oldHeight;
            int newWidth = pb.Width;
            int newHeight = pb.Height;

            int newVkupno = newWidth * oldWidth;

            return (5000 * newVkupno) / currVkupno;

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
                if (!plThread.IsAlive)
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
                pictureBox1.Refresh();
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

        private void Game_Resize(object sender, EventArgs e)
        {
            

            float newWidht = this.Width;
            float newHeight = this.Height;

            float ratioWidth = 1;
            float ratioHeight = 1;

            if (newWidht > currWidth && newHeight > currHeight)
            {
                ratioWidth = newWidht / currWidth;
                ratioHeight = newHeight / currHeight;
            }
            else if (newWidht > currWidth)
            {
                ratioWidth = newWidht / currWidth;
                ratioHeight = currHeight / newHeight;
            }
            else if (newHeight > currHeight)
            {
                ratioWidth = currWidth / newWidht;
                ratioHeight = newHeight / currHeight;
            }
            else
            {
                ratioWidth = currWidth / newWidht;
                ratioHeight = currHeight / newHeight;
            }

            ratioWidth = newWidht / currWidth;
            ratioHeight = newHeight / currHeight;

            SizeF sf = new SizeF(ratioWidth, ratioHeight);

            currWidth = this.Width;
            currHeight = this.Height;

            //this.Scale(sf);
            //this.Refresh();
            //this.PerformAutoScale();
            foreach (Control c in this.Controls)
            {
                
                c.Scale(sf);
            }

        }
    }
}
