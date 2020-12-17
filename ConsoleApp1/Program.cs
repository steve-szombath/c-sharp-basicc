using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Elem<T>
    {
        public T Ertek { get; private set; }
        public Elem<T> Kovetkezo { get; private set; }

        public Elem(T ertek, Elem<T> kovetkezo)
        {
            Ertek = ertek;
            Kovetkezo = kovetkezo;
        }
    }
    class Verem<T>
    {
        private Elem<T> top;

        public Verem()
        {
            this.top = null;
        }

        public T pop()
        {

            if (top != null)
            {
                T ertek = top.Ertek;
                top = top.Kovetkezo;
                return ertek;
            }
            else throw new InvalidOperationException();
        }

        public void push(T ertek)
        {
            Elem<T> elem = new Elem<T>(ertek, top);
            this.top = elem;
        }

        public String toString()
        {
            StringBuilder builder = new StringBuilder();
            for(Elem<T> elem = top; elem != null; elem = elem.Kovetkezo)
            {
                builder.Append(elem.Ertek.ToString()).Append(" ");

                
            }
            return builder.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Verem<int> verem = new Verem<int>();
            for (int i = 1; i<100 ;i++) {
                verem.push(i*2);
            }

            Console.WriteLine(verem.toString());

            for (int i = 1; i < 100; i++)
            {
                Console.Write(verem.pop() + " ");
            }

            Console.WriteLine(verem.toString());
        }
    }
}
