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
        string highScoreName;
        public Launcher()
        {
            InitializeComponent();
            hsTable = new HighScoreTable();
            pcDoc = new PicturesDoc();

            DirectoryInfo d = new DirectoryInfo(@"..\\..\\Pictures\\");
            FileInfo[] Files = d.GetFiles("*.jpg");
            foreach (FileInfo file in Files)
            {
                pcDoc.addPicture(file);
            }

            System.IO.Directory.CreateDirectory(System.IO.Path.GetFullPath(@"..\\..\\") + "High Scores");

            highScoreName = Path.GetFullPath(@"..\\..\\High Scores\\") + "hs.hst";
 
            players = new List<Player>();
 
            try
            {
                using (FileStream fileStream = new FileStream(highScoreName, FileMode.Open))
                {
                    IFormatter formater = new BinaryFormatter();
                    hsTable = (HighScoreTable)formater.Deserialize(fileStream);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Could not read file: " + highScoreName);
                
                using (FileStream fileStream = new FileStream(highScoreName, FileMode.Create))
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fileStream, hsTable);
                }
            }
        }

        private void adminLogin_Click(object sender, EventArgs e)
        {
            AdminAuthentication AA = new AdminAuthentication();
            if (AA.ShowDialog()==DialogResult.OK)
                pcDoc.pictures.Add(AA.pictureName);

            //MessageBox.Show(pcDoc.pictures.Count.ToString());
        }

        private void startGame_Click(object sender, EventArgs e)
        {
            Game obj = new Game(hsTable, pcDoc);
            obj.ShowDialog();
            //while (obj.ShowDialog()==DialogResult.Yes)
            //{
            // obj = new Game(hsTable, pcDoc);
            // hsTable.listaHS.Add(obj.player);

            //}

            if (obj.player.Name!=null && obj.DialogResult!=DialogResult.Abort)
                hsTable.listaHS.Add(obj.player);

            using (FileStream fileStream = new FileStream(highScoreName, FileMode.Create))
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, hsTable);
            }
 
        }

        private void highScore_Click(object sender, EventArgs e)
        {
            players = hsTable.listaHS.OrderBy(p => -p.Score).ToList();
            HighScore HS = new HighScore(players);
            HS.ShowDialog();
        }
    }
}
