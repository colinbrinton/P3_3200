using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3
{
    class bitCollage : imageCollage
    {
        const int MIN_OMIT = 1;
        const int MAX_OMIT = 4;
        public bitCollage(int size = DEFAULT_SIZE)
        {
            active = true;
            collage = new List<int>();
            for (int index = 0; index < size; index++)
            {
                collage.Add(rnd.Next(COL_MIN, COL_MAX));
            }
            displaySize = collage.Count;
        }

        public override int[] getDisplay()
        {
            if (active)
            {
                ++displayCount;
                int omit = rnd.Next(MIN_OMIT, MAX_OMIT);
                List<int> omitList = new List<int>();
                int[] display = new int[collage.Count - omit];
                int randomIndex;
                while (omit > 0)
                {
                    randomIndex = rnd.Next(0, (collage.Count - 1));
                    while(omitList.Contains(randomIndex))
                        randomIndex = rnd.Next(0, (collage.Count - 1));
                    omitList.Add(randomIndex);
                    --omit;
                }

                int displayIndex = 0;
                for (int index = 0; index < collage.Count; ++index)
                {
                    if (!omitList.Contains(index))
                    {
                        display[displayIndex] = collage[index];
                        ++displayIndex;
                    }
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
