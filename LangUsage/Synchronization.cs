using System;
using System.Threading;
using System.Threading.Tasks;
class SyncTest
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");

        /*
        Synchronization can be handled using various methods. These methods are divided into 4 categories in general. These are as follows:

Blocking Methods -- Sleep, Join, Task.Wait
Locking Constructs
No blocking synchronization
Signaling
        */


        /*
        In thread synchronization, join is a blocking mechanism that pauses the calling thread. 
        This is done till the thread whose join method was called has completed its execution.
        */

        LockDisplay obj = new LockDisplay();

        Console.WriteLine("Threading using Lock");
        Thread t1 = new Thread(new ThreadStart(obj.DisplayNum));
        Thread t2 = new Thread(new ThreadStart(obj.DisplayNum));
        t1.Start();
        t2.Start();


        Task task = Task.Run(() =>
        {
            Random randomNumbers = new Random();
            long sum = 0;
            int count = 1000000;
            for (int i = 1; i <= count; i++)
            {
                int randomNumber = randomNumbers.Next(0, 101);
                sum += randomNumber;
            }

            Console.WriteLine("Total:{0}", sum);
            Console.WriteLine("Count: {0}", count);
        });
        task.Wait();

        //The task can return a result.
        // There is no direct mechanism to return the result from a thread.
        /*

        The Thread class is used for creating and manipulating a thread in Windows. 
        A Task represents some asynchronous operation and is part of the Task Parallel Library,
        a set of APIs for running tasks asynchronously and in parallel.

        A task can have multiple processes happening at the same time. 
        Threads can only have one task running at a time.

        A new Thread()is not dealing with Thread pool thread, 
        whereas Task does use thread pool thread.

        A Task is a higher level concept than Thread.

        https://www.c-sharpcorner.com/article/task-and-thread-in-c-sharp/
        */

        /*
        The C# lock keyword is just a notation for using System.Threading.Monitor 
        class type. The lock scope actually resolves to the Monitor class after 
        being processed by the C# compiler.

        A Mutex is like a C# lock, but it can work across multiple processes. 
        In other words, Mutex can be computer-wide as well as application-wide.

        A Mutex can be either named or unnamed. If a Mutex is named, 
        it is eligible to be a system-wide Mutex that can be accessed from 
        multiple processes. If a Mutex is unnamed, it is an anonymous Mutex 
        which can only be accessed within the process in which it is created.
        */

        for (int i = 0; i < numThreads; i++)
        {
            Thread mycorner = new Thread(new ThreadStart(ThreadProcess));
            mycorner.Name = String.Format("Thread{0}", i + 1);
            mycorner.Start();
        }

        // Create a semaphore that can satisfy up to three
        // concurrent requests. Use an initial count of zero,
        // so that the entire semaphore count is initially
        // owned by the main program thread.
        //
        sem = new Semaphore(0, 3);
        // Create and start five numbered threads. 
        //
        for (int i = 1; i <= 5; i++)
        {
            Thread t = new Thread(new ParameterizedThreadStart(Worker));

            // Start the thread, passing the number.
            //
            t.Start(i);
        }
        // Wait for half a second, to allow all the
        // threads to start and to block on the semaphore.
        //
        Thread.Sleep(500);

        // The main thread starts out holding the entire
        // semaphore count. Calling Release(3) brings the 
        // semaphore count back to its maximum value, and
        // allows the waiting threads to enter the semaphore,
        // up to three at a time.
        //
        Console.WriteLine("Main thread calls Release(3).");
        sem.Release(3);

        Console.WriteLine("Main thread exits.");


        Monitor.Enter(locker);
        try

        {
            Console.WriteLine("entered the critical section through monitor");
            Monitor.Pulse(locker); // should only be called from synchronized code,
            Monitor.PulseAll(locker); // not from outside finally below.
            Monitor.Wait(locker);
            Monitor.TryEnter(locker);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Monitor.Exit(locker);
            Console.WriteLine(" releasing monitor C-sharpcorner.com");
        }

    }
    static object locker = new object();
    private static Semaphore sem;
    // A padding interval to make the output more orderly.
    private static int _padding;
    private static Mutex mutex = new Mutex(false, "ashokmutex");
    // indicates whether the calling thread should have initial ownership of the mutex.
    // second param -- named mutex, so works between processes in the OS.
    private const int numhits = 1;
    private const int numThreads = 4;
    private static void ThreadProcess()
    {
        for (int i = 0; i < numhits; i++)
        {
            UseCsharpcorner();
        }
    }
    private static void UseCsharpcorner()
    {
        mutex.WaitOne();   // Wait until it is safe to enter.  
        Console.WriteLine("{0} has entered in the C_sharpcorner.com",
            Thread.CurrentThread.Name);
        // Place code to access non-reentrant resources here.  
        Thread.Sleep(500);    // Wait until it is safe to enter.  
        Console.WriteLine("{0} is leaving the C_sharpcorner.com\r\n",
            Thread.CurrentThread.Name);
        mutex.ReleaseMutex();    // Release the Mutex.  
    }
    private static void Worker(object num)
    {
        // Each worker thread begins by requesting the
        // semaphore.
        Console.WriteLine("Thread {0} begins " +
            "and waits for the semaphore.", num);
        sem.WaitOne();

        // A padding interval to make the output more orderly.
        int padding = Interlocked.Add(ref _padding, 100);

        Console.WriteLine("Thread {0} enters the semaphore.", num);

        // The thread's "work" consists of sleeping for 
        // about a second. Each thread "works" a little 
        // longer, just to make the output more orderly.
        //
        Thread.Sleep(1000 + padding);

        Console.WriteLine("Thread {0} releases the semaphore.", num);
        Console.WriteLine("Thread {0} previous semaphore count: {1}",
            num, sem.Release());
    }
}
class LockDisplay
{
    public void DisplayNum()
    {
        Console.WriteLine("Thread Start");
        lock (this)
        {
            for (int i = 1; i <= 5; i++)
            {
                Thread.Sleep(100);
                Console.WriteLine("i = {0}", i);
            }
        }
        Console.WriteLine("Thread End");
    }
}