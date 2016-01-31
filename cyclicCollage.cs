// AUTHOR: Colin Brinton
// FILENAME: cyclicCollage.cs
// DATE: 2/1/2016
// REVISION HISTORY: 1.0
using System;
using System.Collections.Generic;

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

        public override bool replaceImage(int imgID) { return false; }

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
