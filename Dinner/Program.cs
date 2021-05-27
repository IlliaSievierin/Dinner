using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dinner
{
    class Program
    {
        static List<Fork> forks = new List<Fork>();
        static List<Philosopher> philosophers = new List<Philosopher>();

        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                forks.Add(new Fork());
                philosophers.Add(new Philosopher(i));
            }
            Thread thread1 = new Thread(()=>philosophers[0].StartWork(forks));
            Thread thread2 = new Thread(() => philosophers[1].StartWork(forks));
            Thread thread3 = new Thread(() => philosophers[2].StartWork(forks));
            Thread thread4 = new Thread(() => philosophers[3].StartWork(forks));
            Thread thread5 = new Thread(() => philosophers[4].StartWork(forks));

            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();
            thread5.Start();

            while(true)
            {
                Thread.Sleep(5000);
                double sum = 0;
                for (int i = 0; i < 5; i++)
                {
                    sum += philosophers[i].eaten;
                }

                Console.WriteLine(philosophers[0].eaten.ToString() + "|" + philosophers[1].eaten.ToString() + "|" + philosophers[2].eaten.ToString() + "|" + philosophers[3].eaten.ToString() + "|" + philosophers[4].eaten.ToString());
                Console.WriteLine(philosophers[0].eaten / sum * 100 + "|" + philosophers[1].eaten / sum * 100 + "|" + philosophers[2].eaten / sum * 100 + "|" + philosophers[3].eaten / sum * 100 + "|" + philosophers[4].eaten / sum * 100);
                Console.WriteLine("-------------------------------------------------");
            }
            
        }
    }


}
