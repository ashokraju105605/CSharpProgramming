using System;
using System.Threading;
class Threadusage
{
    public static void main(String[] args)
    {
        Console.WriteLine("Jai Shree Ram");

        //ForeGround Threds -- thread will keep running even when main thread exits till threads completion.
        Thread t1 = new Thread(func1); // system.Threading
        t1.Start();


        // background thread.
        Thread t2 = new Thread(func2);
        t2.IsBackground = true;

        t2.Priority = ThreadPriority.Lowest; // System.Threading Object.
                                             //t2.Start();

        ThreadPool.QueueUserWorkItem(BackgroundTask); // if no worker in pool
        // this waits until the thread becomes available. runs methods on background threads
        int workers, ports;
        ThreadPool.GetAvailableThreads(out workers, out ports);

        Console.WriteLine($"{workers}, {ports}");

        Thread t3 = new Thread(new ThreadStart(Work.DoWork)); // static thread procedure
        t3.Start();

        t3.Interrupt();
        //Interrupts a thread that is in the WaitSleepJoin thread state.

        Work w = new Work();
        w.Data = 42;

        Thread t4 = new Thread(new ThreadStart(w.DoMoreWork)); // instance thread procedure.
        t4.Start();

        //t4.Suspend(); // old method. -- Suspends the newly created thread
        //t4.Resume(); // old method -- Resumes the suspended thread

        t4.Join(); // Blocks the calling thread until a thread terminates, 
        //while continuing to perform standard COM and SendMessage pumping.

        Console.WriteLine(t4.IsAlive);

        Thread tm = Thread.CurrentThread;
        Console.WriteLine(tm.ThreadState);


        Thread newThread = new Thread(new ThreadStart(TestMethod));
        newThread.Start();
        Thread.Sleep(1000);


        //newThread.Join(2000);
        // Abort newThread.
        Console.WriteLine("Main aborting new thread.");
        //newThread.Abort("Information from Main."); //old way not supported in .net 5.0
        // runtime exception -- thread abort is not supported on this platform.

        // Wait for the thread to terminate.
        //newThread.Join();

        Thread.Yield();
        //Causes the calling thread to yield execution to another thread that is ready to run on the current processor. 
        //The operating system selects the thread to yield to.

        Console.WriteLine("main thread exit");
    }


    static void TestMethod()
    {
        try
        {


            Console.WriteLine("while 1 New thread running.");
            Thread.Sleep(1000);


        }
        catch (ThreadAbortException abortException)
        {
            Console.WriteLine((string)abortException.ExceptionState);
        }
        finally
        {
            Console.WriteLine("couldn't catch the exception");
        }
    }
    // Background task   
    static void BackgroundTask(Object stateInfo)
    {
        Console.WriteLine("Hello! I'm a worker from ThreadPool");
        Thread.Sleep(1000);
    }
    static void func1()
    {
        Console.WriteLine();
        Console.WriteLine("start from thread1");
        Thread.Sleep(4000);
        Console.WriteLine("Thread1 exit");
    }

    static void func2()
    {
        Console.WriteLine("start from thread2");
        Thread.Sleep(4000);
        Console.WriteLine("Thread2 exit");
    }
}

class Work
{
    public static void DoWork()
    {
        Console.WriteLine("Static thread procedure.");
    }
    public int Data;
    public void DoMoreWork()
    {
        //Console.WriteLine(s);
        Console.WriteLine("Instance thread procedure. Data={0}", Data);
    }
}

