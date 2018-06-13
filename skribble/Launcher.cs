using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace skribble
{
    public partial class Launcher : Form
    {
        public HighScoreTable hsTable;
        public PicturesDoc pcDoc;
        public List<Player> players;
        public Launcher()
        {
            InitializeComponent();
            hsTable = new HighScoreTable();
            pcDoc = new PicturesDoc();
            players = new List<Player>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void adminLogin_Click(object sender, EventArgs e)
        {
            AdminAuthentication AA = new AdminAuthentication();
            AA.ShowDialog();
            
        }

        private void startGame_Click(object sender, EventArgs e)
        {
            //String fileName = System.IO.Path.GetFullPath(@"..\\..\\Pictures\\");
            Game obj = new Game();
            obj.ShowDialog();
            hsTable.listaHS.Add(obj.newPlayer);
            //***************SAVE SCORE****************
            //System.Runtime.Serialization.IFormatter fmt = 
            //    new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            //FileStream strm = new FileStream("HighScore", FileMode.Create, FileAccess.Write, FileShare.None);
            //fmt.Serialize(strm, hsTable);
            //strm.Close();
          }

        private void Launcher_Load(object sender, EventArgs e)
        {
           
        }

        private void highScore_Click(object sender, EventArgs e)
        {
            players = hsTable.listaHS;
            HighScore HS = new HighScore(players);
            HS.ShowDialog();
        }
    }
}
