using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        internal class Elem<T>
        {
            T ertek;
            Elem<T> kovetkezo;
            internal Elem(T ertek, Elem<T> kovetkezo)
            {
                this.ertek = ertek;
                this.kovetkezo = kovetkezo;
            }

            public T Ertek
            {
                get { return ertek; }
                set { ertek = value; }
            }

            internal Elem<T> Kovetkezo
            {
                get { return kovetkezo; }
                set { kovetkezo = value; }
            }
        }

            internal class Verem<T>
        {
            Elem<T> top;

            public Verem()
            {
                this.top = null;
            }

            internal T pop()
            {

                if (top != null)
                {
                    T ertek = top.Ertek;
                    top = top.Kovetkezo;
                    return ertek;
                }
                else throw new InvalidOperationException();
            }

            internal void push(T ertek)
            {
                Elem<T> elem = new Elem<T>(ertek, top);
                top = elem;
            }

            internal String toString()
            {
                String s = "";
                Elem<T> elem = top;
                while (elem != null)
                {
                    s = s + " " + elem.Ertek.ToString();

                    elem = elem.Kovetkezo;
                }
                return s;
            }
        }

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
        }
    }
}
