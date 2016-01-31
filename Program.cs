using System;
using System.Collections.Generic;

namespace P3
{
    class P3Driver
    {
        const int H_ARRAY_SIZE = 10;
        const int NUM_COL = 3;
        const int IMAGE = 0;
        const int CYCLIC = 1;
        const int BIT = 2;
        const int MIN_IMG = 5;
        const int MAX_IMG = 11;

        static Random rnd = new Random();

        static void Main()
        {

            Console.Write("Creating a heterogeneous array to test the three collage classes... ");
            imageCollage[] heteroCollageArray = new imageCollage[H_ARRAY_SIZE];
            allocateCollageArray(ref heteroCollageArray);
            Console.Write("Done.");
            Console.WriteLine();
            Console.WriteLine();

            Console.Write("Displaying all collages in array: ");
            Console.WriteLine();
            displayAll(heteroCollageArray);
            Console.WriteLine();

            Console.Write("Displaying all collages in array: ");
            Console.WriteLine();
            displayAll(heteroCollageArray);
            Console.WriteLine();

            /*imageCollage testCollage = new imageCollage();
            displayCollage(testCollage.getDisplay());


            Console.WriteLine();
            if (testCollage.imgQuery(testCollage.getDisplay()[0]))
                Console.Write("Image is in the collage.");
            else
                Console.Write("Image is NOT in the collage.");

            Console.WriteLine();
            testCollage.replaceImage(testCollage.getDisplay()[0]);
            displayCollage(testCollage.getDisplay());

            testCollage.toggleActive();
            Console.WriteLine();
            displayCollage(testCollage.getDisplay());


            Console.WriteLine();
            Console.WriteLine();
            imageCollage testCyclic = new cyclicCollage();
            displayCollage(testCyclic.getDisplay());
            Console.WriteLine();
            displayCollage(testCyclic.getDisplay());
            Console.WriteLine();
            displayCollage(testCyclic.getDisplay());
            Console.WriteLine();
            displayCollage(testCyclic.getDisplay());

            Console.WriteLine();
            Console.WriteLine();
            imageCollage testBit = new bitCollage();
            displayCollage(testBit.getDisplay());
            Console.WriteLine();
            displayCollage(testBit.getDisplay());
            Console.WriteLine();
            displayCollage(testBit.getDisplay());
            Console.WriteLine();
            displayCollage(testBit.getDisplay());
            Console.WriteLine();*/

            Console.ReadKey();
        }

        static void allocateCollageArray(ref imageCollage[] colArray)
        {
            int collageSelector;
            int collageSize;
            int index = 0;

            foreach(imageCollage element in colArray)
            {
                collageSelector = rnd.Next(NUM_COL);
                collageSize = rnd.Next(MIN_IMG, MAX_IMG);
                if(collageSelector == IMAGE)
                    colArray[index] = new imageCollage(collageSize);
                if(collageSelector == CYCLIC)
                    colArray[index] = new cyclicCollage(collageSize);
                if(collageSelector == BIT)
                    colArray[index] = new bitCollage(collageSize);
                ++index;
            }
        }

        static void displayCollage(int[] imgCol)
        {
            int index = 0;
            Console.Write(imgCol[index]);
            foreach(int element in imgCol)
            {
                if(index != 0)
                {
                    Console.Write(", ");
                    Console.Write(imgCol[index]);
                }
                ++index;
            }
            
        }

        static void displayAll(imageCollage[] collageArray)
        {
            int index = 0;
            foreach (imageCollage element in collageArray)
            {
                Console.Write("Collage ");
                Console.Write(index + 1);
                Console.Write(": ");
                displayCollage(collageArray[index].getDisplay());
                Console.WriteLine();
                ++index;
            }
        }


    }
}
