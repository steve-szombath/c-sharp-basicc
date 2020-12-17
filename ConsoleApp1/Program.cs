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
            //ha üres a verem
            if (top == null) throw new InvalidOperationException();

            T ertek = top.Ertek;
            top = top.Kovetkezo;
             return ertek;
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

    class KetiranyuLancoltListaElem<T>
    {
        public T Ertek { get; private set; }
        public KetiranyuLancoltListaElem<T> Kovetkezo { get; set; }
        public KetiranyuLancoltListaElem<T> Elozo { get; private set; }

        public KetiranyuLancoltListaElem(T ertek, KetiranyuLancoltListaElem<T> kovetkezo, KetiranyuLancoltListaElem<T> elozo)
        {
            Ertek = ertek;
            Kovetkezo = kovetkezo;
            Elozo = elozo;
        }
    }

    class Sor<T>
    {
        private KetiranyuLancoltListaElem<T> eleje;

        public Sor()
        {
            this.eleje = null;
        }

        public T pop()
        {
            // ha üres a sor
            if (eleje == null) throw new InvalidOperationException();
            
            T ertek = eleje.Ertek;
            eleje = eleje.Kovetkezo;
            return ertek;
        }

        private KetiranyuLancoltListaElem<T> Utolso()
        {
            KetiranyuLancoltListaElem<T> utolso = eleje;

            // ha üres a lista vagy az aktuális elem után már nincs elem
            while (utolso != null && utolso.Kovetkezo != null)
            {
                utolso = utolso.Kovetkezo;
            }

            return utolso;
        }

        public void push(T ertek)
        {
            KetiranyuLancoltListaElem<T> utolso = Utolso();
            KetiranyuLancoltListaElem<T> elem = new KetiranyuLancoltListaElem<T>(ertek, null, utolso);
            if (utolso == null)
            {
                // üres a sor
                eleje = elem;
            } else
            {
                // az utolsó az utolsó előtti lesz
                utolso.Kovetkezo = elem;
            }

        }
        public String toString()
        {
            StringBuilder builder = new StringBuilder();
            for (KetiranyuLancoltListaElem<T> elem = eleje; elem != null; elem = elem.Kovetkezo)
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
            Console.WriteLine("Verem");

            Verem<int> verem = new Verem<int>();
            for (int i = 1; i<10 ;i++) {
                verem.push(i);
            }

            Console.WriteLine("A verem tartalma: " + verem.toString());
            Console.WriteLine("Most sorban kiszedjük: ");

            for (int i = 1; i < 10; i++)
            {
                Console.Write(verem.pop() + " ");
            }

            Console.WriteLine("");
            Console.WriteLine("Sor");

            Sor<int> sor = new Sor<int>();
            for (int i = 1; i < 10; i++)
            {
                sor.push(i);
            }

            Console.WriteLine("A sor tartalma: " + sor.toString());
            Console.WriteLine("Most sorban kiszedjük: ");

            for (int i = 1; i < 10; i++)
            {
                Console.Write(sor.pop() + " ");
            }


        }
    }
}
