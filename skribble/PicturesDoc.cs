using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skribble
{
    public class PicturesDoc
    {
        public List<String> pictures;
        public HashSet<int> visited;
        public PicturesDoc()
        {
            pictures = new List<String>();
            visited = new HashSet<int>();
        }

        public String getRandomPicture(Random rand)
        {
            int next = rand.Next(pictures.Count);
            

            if (visited.Count == pictures.Count)
                visited.Clear();

            while (visited.Contains(next))
            {
                next = rand.Next(pictures.Count);
                
            }
            visited.Add(next);
            return pictures[next];
            
        }

        public void addPicture(FileInfo file)
        {
            String tmp = file.Name.Split('.')[0];
            pictures.Add(tmp);
        }
    }
}
