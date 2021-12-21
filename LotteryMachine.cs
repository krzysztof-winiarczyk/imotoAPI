using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI
{
    public class LotteryMachine
    {
        private List<int> pool;
        private List<int> drawn;

        public List<int> Draw(int howManyToDraw, int howManyInPool)
        {
            //initialization
            drawn = new List<int>();
            pool = new List<int>();
            Random rand = new Random();
            for (int i = 0; i < howManyInPool; i++)
                pool.Add(i);

            //draw
            for (int i = 0; i < howManyToDraw; i++)
            {
                int drawnIndex = rand.Next(pool.Count);
                int element = pool.ElementAt(drawnIndex);
                drawn.Add(element);
                pool.RemoveAt(drawnIndex);
            }

            return drawn;
        }
    }
}
