using System;
using System.Collections.Generic;

namespace P3
{
    class P3Driver
    {
        static void Main()
        {
            imageCollage testCollage = new imageCollage();
            displayCollage(testCollage.getDisplay());
            //int[] testDisplay = new int[testCollage.displaySize];
            //testDisplay = testCollage.getDisplay();


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
            Console.WriteLine();

            Console.ReadKey();
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


    }
}
