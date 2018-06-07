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
    public partial class Launcher : Form
    {
        public Launcher()
        {
            InitializeComponent();
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
            Game obj = new Game();
            obj.Show();
        }

        private void Launcher_Load(object sender, EventArgs e)
        {
           
        }

        private void highScore_Click(object sender, EventArgs e)
        {

        }
    }
}
