using System;
using System.Collections.Generic;

namespace P3
{
    class P3Driver
    {
        const int H_ARRAY_SIZE = 13;
        const int NUM_COL = 3;
        const int IMAGE = 0;
        const int CYCLIC = 1;
        const int BIT = 2;
        const int MIN_IMG = 5;
        const int MAX_IMG = 11;
        const int TEST_SIZE = 10;
        const int REPEAT = 5;

        const int RANDOM_SIZE = H_ARRAY_SIZE - NUM_COL;
        const int BIT_INDEX = H_ARRAY_SIZE - 3;
        const int CYCLIC_INDEX = H_ARRAY_SIZE - 2;
        const int IMAGE_INDEX = H_ARRAY_SIZE - 1;

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

            Console.Write("Testing bitCollage functionality: ");
            Console.WriteLine();
            bitCollageTestSuite(heteroCollageArray[BIT_INDEX]);

            Console.ReadKey();
        }

        static void allocateCollageArray(ref imageCollage[] colArray)
        {
            int collageSelector;
            int collageSize;

            for (int index = 0; index < colArray.Length; index++)
            {
                collageSelector = rnd.Next(NUM_COL);
                collageSize = rnd.Next(MIN_IMG, MAX_IMG);
                if (index < RANDOM_SIZE)
                {
                    if (collageSelector == IMAGE)
                        colArray[index] = new imageCollage(collageSize);
                    if (collageSelector == CYCLIC)
                        colArray[index] = new cyclicCollage(collageSize);
                    if (collageSelector == BIT)
                        colArray[index] = new bitCollage(collageSize);
                }
                if (index >= RANDOM_SIZE)
                {
                    colArray[index] = new bitCollage(TEST_SIZE);
                    ++index;
                    colArray[index] = new cyclicCollage(TEST_SIZE);
                    ++index;
                    colArray[index] = new imageCollage(TEST_SIZE);
                }
            }
        }

        static void bitCollageTestSuite(imageCollage bitCollage)
        {
            Console.Write("Calling getDisplay() on bitCollage object 5 times: ");
            Console.WriteLine();
            repeatDisplay(bitCollage);
            Console.WriteLine();

            Console.Write("Testing replaceImage() bitCollage method: ");
            Console.WriteLine();
            Console.Write("Calling getDisplay() to fill an array of images to replace...");
            int[] replace = bitCollage.getDisplay();
            Console.Write("Done.");
            Console.WriteLine();
            foreach (int element in replace)
            {
                Console.Write("Attempting to replace ");
                Console.Write(element);
                Console.Write("...");
                if (bitCollage.replaceImage(element))
                    Console.Write("Success!");
                else
                    Console.Write("Failed!");
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.Write("Calling getDisplay() on bitCollage object 5 more times: ");
            Console.WriteLine();
            repeatDisplay(bitCollage);

            Console.WriteLine();
            Console.Write("getDisplay() has been called ");
            Console.Write(bitCollage.getDisplayCount());
            Console.Write(" times.");
            Console.WriteLine();

            Console.Write(bitCollage.getReplaceCount());
            Console.Write(" images have been replaced.");
            Console.WriteLine();

            Console.WriteLine();
            Console.Write("Calling toggleActive()...");
            bitCollage.toggleActive();
            Console.Write("Done.");
            Console.WriteLine();
            Console.Write("Attempting to display collage: ");
            displayCollage(bitCollage.getDisplay());
            Console.WriteLine();

            Console.Write("Calling toggleActive()...");
            bitCollage.toggleActive();
            Console.Write("Done.");
            Console.WriteLine();
            Console.Write("Attempting to display collage: ");
            displayCollage(bitCollage.getDisplay());
            Console.WriteLine();
        }

        static void repeatDisplay(imageCollage item, int rep = REPEAT)
        {
            for (int count = 0; count < rep; ++count)
            {
                displayCollage(item.getDisplay());
                Console.WriteLine();
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
            for (int index = 0; index < collageArray.Length; index++)
            {
                if (index < RANDOM_SIZE)
                {
                    Console.Write("Collage ");
                    Console.Write(index + 1);
                    Console.Write(": ");
                    displayCollage(collageArray[index].getDisplay());
                    Console.WriteLine();
                }
                /*if (index >= RANDOM_SIZE)
                {
                    if ((collageArray.Length - (index + 1)) == BIT)
                    {
                        Console.WriteLine();
                        Console.Write("Test bitCollage: ");
                        Console.WriteLine();
                    }
                    if ((collageArray.Length - (index + 1)) == CYCLIC)
                    {
                        Console.Write("Test cyclicCollage: "); 
                        Console.WriteLine();
                    }
                    if ((collageArray.Length - (index + 1)) == IMAGE)
                    {
                        Console.Write("Test imageCollage: ");
                        Console.WriteLine();
                    }
                   
                }*/
                //displayCollage(collageArray[index].getDisplay());
                //Console.WriteLine();
            }
        }


    }
}
