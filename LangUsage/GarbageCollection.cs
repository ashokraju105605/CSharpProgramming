using System;
class GarbageCollection
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");

        Console.WriteLine("The number of generations are: " + GC.MaxGeneration);

        Console.WriteLine("Total Memory:" + GC.GetTotalMemory(false));

        GarbageCollection obj = new GarbageCollection();
        Console.WriteLine("The generation number of object obj is: " + GC.GetGeneration(obj));
        Console.WriteLine("Total Memory:" + GC.GetTotalMemory(false));
        //returns the number of bytes that are allocated in the system. 
        //It requires a single boolean parameter where true means that the method 
        //waits for the occurrence of garbage collection before returning and 
        //false means the opposite. 


        GC.Collect(0);
        //Garbage collection can be forced in the system using the GC.Collect() method. 
        //This method requires a single parameter i.e. 
        //number of the oldest generation for which garbage collection occurs.
        Console.WriteLine("Garbage Collection in Generation 0 is: "
                                          + GC.CollectionCount(0));

        //The constructors of newly created objects do not have to 
        //initialize all the data fields
        // as garbage collection clears the memory of objects that were previously released.


        /*
        Generation 0 : All the short-lived objects such as temporary variables are contained in the generation 0 
        of the heap memory. All the newly allocated objects are also generation 0 objects implicitly unless they are 
        large objects. In general, the frequency of garbage collection is the highest in generation 0.

        Generation 1 : If space occupied by some generation 0 objects that are not released in a garbage collection run,
         then these objects get moved to generation 1. The objects in this generation are a sort of buffer between 
         the short-lived objects in generation 0 and the long-lived objects in generation 2.

        Generation 2 : If space occupied by some generation 1 objects that are not released in the next garbage collection run,
         then these objects get moved to generation 2. The objects in generation 2 are long lived such as static objects 
         as they remain in the heap memory for the whole process duration.

        Note: Garbage collection of a generation implies the garbage collection of all its younger generations. 
        This means that all the objects in that particular generation and its younger generations are released. 
        Because of this reason, the garbage collection of generation 2 is called a full garbage collection 
        as all the objects in the heap memory are.released. Also, the memory allocated to the Generation 2 will be 
        greater than Generation 1’s memory and similarly the memory of Generation 1 will be greater than 
        Generation 0’s memory(Generation 2 > Generation 1 > Generation 0).
        */
    }
}