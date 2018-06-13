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
    [Serializable] public partial class HighScore : Form
    {
        
        public HighScore(List<Player> players)
        {
            InitializeComponent();
            foreach(Player player in players)
            {
                listBox1.Items.Add(player);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
