using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3
{
    class cyclicCollage : imageCollage
    {
        const int DEFAUL_SHIFT = 2;
        private int shift;

        public cyclicCollage(int size = DEFAULT_SIZE)
        {
            active = true;
            shift = DEFAUL_SHIFT;
            collage = new List<int>();
            for (int index = 0; index < size; index++)
            {
                int randomImg = rnd.Next(COL_MIN, COL_MAX);
                while (collage.Contains(randomImg))
                    randomImg = rnd.Next(COL_MIN, COL_MAX);
                collage.Add(randomImg);
            }
            displaySize = collage.Count;
        }

        public override void replaceImage(int imgID) { }

        public override int[] getDisplay()
        {
            if (active)
            {
                ++displayCount;
                int[] display = new int[collage.Count];
                for (int index = 0; index < collage.Count; ++index)
                {
                    int shiftIndex = (index + (shift * displayCount)) % displaySize;
                    display[shiftIndex] = collage[index];
                }
                return display;
            }
            else
            {
                int[] nullDisplay = new int[] { 0 };
                return nullDisplay;
            }
        }
    }
}
