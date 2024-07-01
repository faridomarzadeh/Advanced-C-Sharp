using System;

namespace ThresholdReachedEventApplication
{
    class ProgramThree
    {
        static void Main(string[] args)
        {
            Counter c = new Counter(new Random().Next(10));
            c.ThresholdReachedHandler += c_ThresholdReached;
            c.ThresholdAlreadyReached += c_ThresholdReached;

            Console.WriteLine("press 'a' key to increase total");
            while (Console.ReadKey(true).KeyChar == 'a')
            {
                if (c.ThresholdNotReached())
                {
                    Console.WriteLine("adding one");
                    c.Add(1);
                }
                else
                {
                    c.Stop();
                }
            }
        }

        static void c_ThresholdReached(object sender, ThresholdReachedEventArgs e)
        {
            Console.WriteLine("The threshold of {0} was reached at {1}.", e.Threshold, e.TimeReached);
            //Environment.Exit(0);
        }
        static void c_ThresholdReached(object sender,ThresholdAlreadyReachedEventArgs e)
        {
            var counter = (Counter)sender;
            Console.WriteLine(counter);
            Console.WriteLine("The threshold was already reached at {0}.", e.TimeReached);
        }
    }

    class Counter
    {
        private int threshold;
        private int total;
        private DateTime timeReached;

        public Counter(int passedThreshold)
        {
            threshold = passedThreshold;
        }
        public bool ThresholdNotReached()
        {
            return total < threshold;
        }
        public void Add(int x)
        {
            total += x;
            if (total == threshold)
            {
                timeReached = DateTime.Now;
                ThresholdReachedEventArgs args = new ThresholdReachedEventArgs();
                args.Threshold = threshold;
                args.TimeReached = timeReached;
                OnThresholdReached(args);
            }
        }
        public void Stop()
        {
            ThresholdAlreadyReachedEventArgs args = new ThresholdAlreadyReachedEventArgs();
            args.TimeReached = timeReached;
            OnThresholdReached(args);
        }

        protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
        {
            EventHandler<ThresholdReachedEventArgs> handler = ThresholdReachedHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        protected virtual void OnThresholdReached(ThresholdAlreadyReachedEventArgs e)
        {
            EventHandler<ThresholdAlreadyReachedEventArgs> handler = ThresholdAlreadyReached;
            if(handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<ThresholdReachedEventArgs> ThresholdReachedHandler;
        public event EventHandler<ThresholdAlreadyReachedEventArgs> ThresholdAlreadyReached;

        public override string ToString()
        {
            return $"{GetType()} Current Status: hreshold: {threshold} - Total: {total}";
        }
    }

    public class ThresholdReachedEventArgs : EventArgs
    {
        public int Threshold { get; set; }
        public DateTime TimeReached { get; set; }
    }

    public class ThresholdAlreadyReachedEventArgs : EventArgs
    {
        public DateTime TimeReached { get; set; }

    }
}