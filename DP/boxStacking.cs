using System;
using System.Linq;
class boxStacking
{
    class Box : IComparable<Box>
    {

        // h --> height, w --> width, 
        // d --> depth 
        public int h, w, d, area;

        // for simplicity of solution, 
        // always keep w <= d 

        /*Constructor to initialise object*/
        public Box(int h, int w, int d)
        {
            this.h = h;
            this.w = w;
            this.d = d;
            this.area = w * d;
        }

        /*To sort the box array on the basis 
        of area in decreasing order of area */
        public int CompareTo(Box o)
        {
            return o.area - area;
        }
    }

    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");

        Box[] arr = new Box[4];
        arr[0] = new Box(4, 6, 7);
        arr[1] = new Box(1, 2, 3);
        arr[2] = new Box(4, 5, 6);
        arr[3] = new Box(10, 12, 32);

        Console.WriteLine("The maximum possible " +
                           "height of stack is " +
                           maxStackHeight(arr));
    }
    static int maxStackHeight(Box[] arr)
    {
        Box[] rot = new Box[3 * arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            Box box = arr[i];

            /* Orignal Box*/
            rot[3 * i] = new Box(box.h, Math.Max(box.w, box.d),
                                    Math.Min(box.w, box.d));

            /* First rotation of box*/
            rot[3 * i + 1] = new Box(box.w, Math.Max(box.h, box.d),
                                       Math.Min(box.h, box.d));

            /* Second rotation of box*/
            rot[3 * i + 2] = new Box(box.d, Math.Max(box.w, box.h),
                                       Math.Min(box.w, box.h));
        }

        Array.Sort(rot); // we need sorting because there are 2 conditions, area of top needs to be lesser and the dimensions w,d also should fit.
                         // as we cannot sort based on w, d , we sorted based on area and then we are checking for proper dimensional fit.

        int[] msh = new int[rot.Length];


        for (int i = 0; i < rot.Length; i++)
        {
            msh[i] = rot[i].h;
            for (int j = 0; j < i; j++)
            {
                if (rot[j].w > rot[i].w && rot[j].d > rot[i].d && msh[j] + rot[i].h > msh[i]) // mistakenly added rot[j].h > rot[i].h instead of rot[j].d > rot[j].d
                {
                    msh[i] = msh[j] + rot[i].h;
                }
            }
        }

        return msh.Max();
    }
}