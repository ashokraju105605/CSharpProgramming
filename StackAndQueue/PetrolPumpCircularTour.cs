using System;
class CircularTour
{
    // A petrol pump has petrol and  
    // distance to next petrol pump  
    public class petrolPump
    {
        public int petrol;
        public int distance;

        // constructor  
        public petrolPump(int petrol,
                          int distance)
        {
            this.petrol = petrol;
            this.distance = distance;
        }
    }
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");
        petrolPump[] arr = new petrolPump[]
        {
            new petrolPump(6, 4),
            new petrolPump(3, 6),
            new petrolPump(7, 3)
        };

        int start = printTour(arr);

        Console.WriteLine(start == -1 ? "No Solution" :
                                   "Start = " + start);
    }
    static int printTour(petrolPump[] arr)
    {
        int start = 0;
        int end = 1;
        int current_petrol = arr[start].petrol - arr[start].distance;
        while (start != end || current_petrol < 0)
        {
            while (current_petrol < 0 && start != end)
            {
                current_petrol -= (arr[start].petrol - arr[start].distance);
                start = (start + 1) % arr.Length;  // without % you will get index out of bound exception

                if (start == 0) // if circular tour has gone one full round around. there will be no point searcing further.
                    return -1;
            }
            current_petrol += (arr[end].petrol - arr[end].distance);
            end = (end + 1) % arr.Length;
        }


        return start;
    }
}