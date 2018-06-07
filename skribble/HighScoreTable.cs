using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skribble
{
    class HighScoreTable
    {
        public List<Player> listaHS = new List<Player>();
        public void addHS(Player player)
        {
            listaHS.Add(player);
        }
    }
}
