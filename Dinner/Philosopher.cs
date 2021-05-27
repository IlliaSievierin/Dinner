using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dinner
{
    class Philosopher
    {
        private int number;
        public int eaten;

        public Philosopher(int number)
        {
            this.number = number;
            eaten = 0;
        }

       private void GetFork(List<Fork> forks)
       {
            
                int firstFork = number;
                int secondFork;
                if (number + 1 == forks.Count())
                {
                    secondFork = 0;
                }
                else
                {
                    secondFork = number + 1;
                }
                if (!forks[firstFork].IsBusy && !forks[secondFork].IsBusy)
                {
                    forks[firstFork].IsBusy = true;

                    Thread.Sleep(1);
                    forks[secondFork].IsBusy = true;
                    Thread.Sleep(10);
                    forks[firstFork].IsBusy = false;
                    Thread.Sleep(1);
                    forks[secondFork].IsBusy = false;
                    eaten++;

                }
            
               
       }
        public void StartWork(List<Fork> forks)
        {
            while(true)
            {
                Think();
                Eat(forks);
            }

        }
        private void Eat(List<Fork> forks)
        {
            //Если 4 вилки из 5 заняты, не забираем 5
           if (forks.Where(f => f.IsBusy).Count() < forks.Count())
            {
                GetFork(forks);
                Thread.Sleep(1);
            }
        }
                
            
        

        private void Think()
        {
            Thread.Sleep(1);
        }
    }
}
