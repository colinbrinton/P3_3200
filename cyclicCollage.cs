// AUTHOR: Colin Brinton
// FILENAME: cyclicCollage.cs
// DATE: 2/1/2016
// REVISION HISTORY: 1.0

/* DESCRIPTION:
 * Extends the functionality of imagCollage. It uses an overridden getDisplay()
 * to cycle through its image IDs based on the given shift value during construction.
 * Defaults to 2 in this example. replaceImage is overridden to always return false 
 * and will not modify any cyclicCollage data.
 */

/* ASSUMPTIONS:
 * User will only want to set shift value once at construction. replaceImage() will 
 * not be used. 
 */
using System;
using System.Collections.Generic;

namespace P3
{
    class cyclicCollage : imageCollage
    {
        const int DEFAUL_SHIFT = 2;
        private int shift;

        //Description - Public default constructor, accepts the desired number of image
        //              ID's with a default value of 5. Assumes used wants a random
        //              selection of images within their database. Will not allow for
        //              duplicate images. Also allows for the object's display shift
        //              value to be set during construction. (Default to 2).
        //postconditions: valid cyclicCollage object ready to use
        public cyclicCollage(int size = DEFAULT_SIZE, int shft = DEFAUL_SHIFT)
        {
            active = true;
            shift = shft;
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

        //Description - Never intended to be used, will not modify any data
        //              and always returns false.
        public override bool replaceImage(int imgID) { return false; }

        //Description: returns the stored array of image ID's shifted by "shift"
        //             for the first and each additional call
        //preconditions: called on an active cyclicCollage object, must be called
        //               less than the upper limit of int or overflow will happen
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
                int[] nullDisplay = new int[] { NULL };
                return nullDisplay;
            }
        }
    }
}
