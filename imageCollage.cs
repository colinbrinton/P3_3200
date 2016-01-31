using System;
using System.Collections.Generic;

namespace P3
{
    class imageCollage
    {
        protected static Random rnd = new Random();
        protected const int DEFAULT_SIZE = 5;
        protected const int COL_MIN = 10000;
        protected const int COL_MAX = 100000;
        protected List<int> collage;
        protected bool active;
        protected int displaySize;
        protected int displayCount = 0;
        protected int replaceCount = 0;


        public imageCollage(int size = DEFAULT_SIZE)
        {
            active = true;
            collage = new List<int>();
            for (int index = 0; index < size; index++)
            {
                int randomImg = rnd.Next(COL_MIN, COL_MAX);
                while(collage.Contains(randomImg))
                    randomImg = rnd.Next(COL_MIN, COL_MAX);
                collage.Add(randomImg);
            }
            displaySize = collage.Count;
        }

        public int getDisplayCount()
        {
            return displayCount;
        }

        public int getReplaceCount()
        {
            return replaceCount;
        }

        public void toggleActive()
        {
            if (active)
                active = false;
            else
                active = true;
        }

        public bool imgQuery(int imgID)
        {
            if (active)
            {
                if (collage.Contains(imgID))
                    return true;
            }
            return false;
        }

        public virtual bool replaceImage(int imgID)
        {
            if (active)
            {
                if(collage.Contains(imgID))
                {
                    int replacement = rnd.Next(COL_MIN, COL_MAX);
                    while (collage.Contains(replacement))
                        replacement = rnd.Next(COL_MIN, COL_MAX);
                    collage[collage.IndexOf(imgID)] = replacement;
                    ++replaceCount;
                    return true;
                }
            }
            return false;
        }

        public virtual int[] getDisplay()
        {
            if (active)
            {
                ++displayCount;
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
