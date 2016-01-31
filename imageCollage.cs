using System;
using System.Collections.Generic;

namespace P3
{
    class imageCollage
    {
        protected static Random rnd = new Random();
        protected const int DEFAULT_SIZE = 5;
        protected const int COL_MIN = 10000;
        protected const int COL_MAX = 99999;
        protected List<int> collage;
        protected bool active;
        public int displaySize;
        protected int displayCount = 0;

        public imageCollage(int size = DEFAULT_SIZE)
        {
            active = true;
            collage = new List<int>();
            for (int index = 0; index < size; index++)
            {
                collage.Add(rnd.Next(COL_MIN, COL_MAX));
            }
            displaySize = collage.Count;
        }

        public void toggleActive()
        {
            if (active)
                active = false;
            else
                active = true;
        }

        public virtual void replaceImage(int imgID)
        {
            if (active)
            {
                int index = 0;
                foreach (int element in collage)
                {
                    int replacement;
                    if (imgID == collage[index])
                    {
                        replacement = rnd.Next(COL_MIN, COL_MAX);
                        while (replacement == collage[index])
                            replacement = rnd.Next(COL_MIN, COL_MAX);
                        collage[index] = replacement;
                    }
                    ++index;
                }
            }
        }

        public virtual int[] getDisplay()
        {
            if (active)
            {
                int[] display = new int[collage.Count];
                for (int index = 0; index < collage.Count; ++index)
                {
                    display[index] = collage[index];
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
