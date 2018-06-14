using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skribble
{
    [Serializable]
    public class HighScoreTable
    {
        public List<Player> listaHS;
        public HighScoreTable()
        {
            listaHS = new List<Player>();
        }
        
    }
}
