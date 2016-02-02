// AUTHOR: Colin Brinton
// FILENAME: P3.cs
// DATE: 2/1/2016
// REVISION HISTORY: 1.0

/* DESCRIPTION:
 * The purpose of the driver is to demonstrate the differing functionality between the base class
 * imageCollage and the two derived classes, cyclicCollage and bitCollage. To accomplish this
 * a heterogeneous array is used. It is allocated using the method allocateCollageArray() which
 * randomly assigns one of the the three classes to the first 10 indices. The last three index
 * slots are reserved for one of each class. The random portion of the array demonstrates the
 * proper functioning of the heterogenous array and the three constant end spots are used for
 * demonstrating the differing behavior of each class. The output is organized into four pages,
 * requiring a key press (input) to clear the screen and move on to the next. The first page
 * demonstrates the heterogenous array working with a randomly distributed assortment of class
 * objects. Pages two through four each demonstrate a class's unique behavior. Each class uses
 * it's own "test suite" method within main along with two helper methods.
 */

/* ASSUMPTIONS:
 * For the driver to function as intended the user only needs to press a key once between each
 * page and once at the end to exit the program. The four page tests the behavior of bitCollage.
 * One distinguishing feature of bitCollage is that the replaceImage() method will only succeed
 * on images with odd ID's. The test object is allocated with randomly generated numbers
 * and accessing the data within a bitCollage object is done through the display method which
 * randomly omits 1-3 image ID's. Because of this there is a very small chance (<.01) that
 * every call to replaceImage() will succeed (or fail). If this happens please run the program
 * again. If this happens more than once please consider buying a lottery ticket. 
 * 
 * Random() is used generate random sizes of data sets stored within each object (between 5
 * and 10 image ID's). It is also used to randomly distrubute the objects among the first
 * 10 spots of the array used for testing. The Console is used to display output and accept
 * key presses. 
 */

using System;

namespace P3
{
    class P3Driver
    {
        const int H_ARRAY_SIZE = 13; //Complete size of the testing array (10 random slots +3)
        const int NUM_COL = 3; //Used for random distribution in hetero array
        const int IMAGE = 0;   //  |
        const int CYCLIC = 1;  //  |
        const int BIT = 2;     //  V
        const int MIN_IMG = 5; // Size range for the number of images
        const int MAX_IMG = 11;//     each test object should hold
        const int TEST_SIZE = 10; // Used for the non-random test objects in index 10-12
        const int REPEAT = 5;  //Number of times repeatDisplay() should call imageCollage.display()
        const int COLLAGE_PORTION = 2; // Used in 

        const int RANDOM_SIZE = H_ARRAY_SIZE - NUM_COL; //These allow the amount of random objects in
        const int BIT_INDEX = H_ARRAY_SIZE - 3;         // H_ARRAY_SIZE to change without breaking
        const int CYCLIC_INDEX = H_ARRAY_SIZE - 2;      //   the driver. |
        const int IMAGE_INDEX = H_ARRAY_SIZE - 1;       //               v

        static Random rnd = new Random();

        static void Main()
        {
            //**Page One***
            Console.Write("Creating a heterogeneous array to test the three collage classes... ");
            imageCollage[] heteroCollageArray = new imageCollage[H_ARRAY_SIZE];
            allocateCollageArray(ref heteroCollageArray);
            Console.Write("Done.");
            Console.WriteLine();
            Console.WriteLine();

            Console.Write("Displaying all collages in random portion of array: ");
            Console.WriteLine();
            displayAll(heteroCollageArray);
            Console.WriteLine();
            Console.Write("Press any key to clear screen and test imageCollage object...");
            Console.ReadKey(); //Input needed to continue

            //***Page Two***
            Console.Clear();
            Console.Write("Testing imageCollage functionality: ");
            Console.WriteLine();
            imageCollageTestSuite(heteroCollageArray[IMAGE_INDEX]);
            Console.WriteLine();
            Console.Write("Press any key to clear screen and test cyclicCollage object...");
            Console.ReadKey(); //Input
            
            //**Page Three***
            Console.Clear();
            Console.Write("Testing cyclicCollage functionality: ");
            Console.WriteLine();
            cyclicCollageTestSuite(heteroCollageArray[CYCLIC_INDEX]);
            Console.WriteLine();
            Console.Write("Press any key to clear screen and test bitCollage object...");
            Console.ReadKey(); //Input

            //***Page Four***
            Console.Clear();
            Console.Write("Testing bitCollage functionality: ");
            Console.WriteLine();
            bitCollageTestSuite(heteroCollageArray[BIT_INDEX]);
            Console.WriteLine();

            Console.Write("Press any key to exit...");
            Console.ReadKey(); //Input
        }

        // Description - accepts a reference to an array of the base class imageCollage.
        //               randomly allocates 10 slots of collage objects followed by one
        //               of each object.
        static void allocateCollageArray(ref imageCollage[] colArray)
        {
            int collageSelector;
            int collageSize;

            for (int index = 0; index < colArray.Length; index++)
            {
                collageSelector = rnd.Next(NUM_COL);
                collageSize = rnd.Next(MIN_IMG, MAX_IMG);
                if (index < RANDOM_SIZE) //Random portion of array
                {
                    if (collageSelector == IMAGE)
                        colArray[index] = new imageCollage(collageSize);
                    if (collageSelector == CYCLIC)
                        colArray[index] = new cyclicCollage(collageSize);
                    if (collageSelector == BIT)
                        colArray[index] = new bitCollage(collageSize);
                }
                if (index >= RANDOM_SIZE) // Constant portion of array used in test suites
                {
                    colArray[index] = new bitCollage(TEST_SIZE);
                    ++index;
                    colArray[index] = new cyclicCollage(TEST_SIZE);
                    ++index;
                    colArray[index] = new imageCollage(TEST_SIZE);
                }
            }
        }

        // Description - Tests the functionality of imageCollage. Calls every method in
        //                in imageCollage under different conditions.
        static void imageCollageTestSuite(imageCollage imageCollage)
        {
            Console.Write("Calling getDisplay() on imageCollage object: ");
            Console.WriteLine();
            displayCollage(imageCollage.getDisplay());
            Console.WriteLine();

            Console.WriteLine();
            Console.Write("Testing replaceImage() imageCollage method: "); 
            Console.WriteLine();
            Console.Write("Calling getDisplay() to fill an array of images to replace...");
            int[] replace = imageCollage.getDisplay();
            Console.Write("Done.");
            Console.WriteLine();
            for (int index = 0; index < (TEST_SIZE / COLLAGE_PORTION); ++index)
            {
                Console.Write("Attempting to replace ");
                Console.Write(replace[index]);
                Console.Write("...");
                if (imageCollage.replaceImage(replace[index])) //Each call will succeed becuase
                    Console.Write("Success!");                 //   each ID is in the object
                else
                    Console.Write("Failed!");
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.Write("Calling getDisplay() on imageCollage object: ");
            Console.WriteLine();
            displayCollage(imageCollage.getDisplay());
            Console.WriteLine();

            Console.WriteLine();
            Console.Write("Testing imgQuery(): ");
            Console.WriteLine();
            Console.Write("Is ");
            Console.Write(replace[TEST_SIZE - 1]);
            Console.Write(" in the collage: ");
            if (imageCollage.imgQuery(replace[TEST_SIZE - 1]))
                Console.Write("Yes!");
            else
                Console.Write("No!");
            Console.WriteLine();
            Console.Write("Is ");
            Console.Write(replace[IMAGE]);
            Console.Write(" in the collage: ");
            if (imageCollage.imgQuery(replace[IMAGE]))
                Console.Write("Yes!");
            else
                Console.Write("No!");
            Console.WriteLine();

            Console.WriteLine();
            Console.Write("getDisplay() has been called ");
            Console.Write(imageCollage.getDisplayCount());
            Console.Write(" times.");
            Console.WriteLine();

            Console.Write(imageCollage.getReplaceCount());
            Console.Write(" images have been replaced.");
            Console.WriteLine();

            Console.WriteLine();
            Console.Write("Calling toggleActive()...");
            imageCollage.toggleActive();
            Console.Write("Done.");
            Console.WriteLine();
            Console.Write("Attempting to replace ");
            Console.Write(replace[TEST_SIZE - 1]); //This call will fail, already replaced above
            Console.Write("...");
            if (imageCollage.replaceImage(replace[TEST_SIZE - 1]))
                Console.Write("Success!");
            else
                Console.Write("Failed!");
            Console.WriteLine();
            Console.Write("Attempting to display collage: ");
            displayCollage(imageCollage.getDisplay());
            Console.WriteLine();

            Console.Write("Calling toggleActive()...");
            imageCollage.toggleActive();
            Console.Write("Done.");
            Console.WriteLine();
            Console.Write("Attempting to replace ");
            Console.Write(replace[TEST_SIZE - 1]);
            Console.Write("...");
            if (imageCollage.replaceImage(replace[TEST_SIZE - 1]))
                Console.Write("Success!");
            else
                Console.Write("Failed!");
            Console.WriteLine();
            Console.Write("Attempting to display collage: ");
            Console.WriteLine();
            displayCollage(imageCollage.getDisplay());
            Console.WriteLine();


        }

        // Description - Tests the functionality of cyclicCollage. Calls every
        //               overridden method except for replaceImage(). 
        //               replaceImage() is not intended to be used with
        //               cyclicCollage and will always return false when called.
        static void cyclicCollageTestSuite(imageCollage cyclicCollage)
        {
            Console.Write("Calling getDisplay() on cyclicCollage object 5 times: ");
            Console.WriteLine();
            repeatDisplay(cyclicCollage);
            Console.WriteLine();

            Console.Write("getDisplay() has been called ");
            Console.Write(cyclicCollage.getDisplayCount());
            Console.Write(" times.");
            Console.WriteLine();

            Console.WriteLine();
            Console.Write("Calling toggleActive()...");
            cyclicCollage.toggleActive();
            Console.Write("Done.");
            Console.WriteLine();
            Console.Write("Attempting to display collage: ");
            displayCollage(cyclicCollage.getDisplay());
            Console.WriteLine();

            Console.Write("Calling toggleActive()...");
            cyclicCollage.toggleActive();
            Console.Write("Done.");
            Console.WriteLine();
            Console.Write("Attempting to display collage: ");
            Console.WriteLine();
            displayCollage(cyclicCollage.getDisplay());
            Console.WriteLine();
        }

        // Description - Tests the functionality of bitCollage. Calls every
        //                overridden method.
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
            Console.WriteLine();
            displayCollage(bitCollage.getDisplay());
            Console.WriteLine();
        }

        //Description - Helper method used in test suite methods
        static void repeatDisplay(imageCollage item, int rep = REPEAT)
        {
            for (int count = 0; count < rep; ++count)
            {
                displayCollage(item.getDisplay());
                Console.WriteLine();
            }
        }

        //Discription - Helper method used above and in test suite methods
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

        //Description - Used in main() to display the random portion of the hetero array
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
            }
        }
    }
}
