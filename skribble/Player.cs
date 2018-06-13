using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skribble
{
    public class Player
    {
        public String Name { get; set; }
        public int Score { get; set; }
        public Player(String name,int score)
        {
            this.Name = name;
            this.Score = score;
        }
        public override string ToString()
        {
            return Name + " - " + Score; 
        }
    }
}
