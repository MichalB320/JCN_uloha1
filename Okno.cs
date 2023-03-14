using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix3
{
    internal class Okno
    {
        private const int vyska = 25;
        private const int sirka = 30;
        private Linia[] stlpce;

        public Okno() 
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Green;
            this.stlpce = new Linia[sirka];
            Random rand = new Random();
            
            bool jeViditelna = false;
           
            for (int i = 0; i < sirka; i++)
            {
                int nahoda = rand.Next(0, 2);
                if (nahoda == 1)
                    jeViditelna = true;
                else
                    jeViditelna = false;
                Linia line = new Linia(2, jeViditelna);
                this.stlpce[i] = line;
            }
        }

        public void chod()
        {
            int curColl = 0;
            int curRow = 0;
            bool jePrvy = true;
            while (true)
            {
                
                if (this.stlpce[curColl].JeViditelna())
                {
                    this.stlpce[curColl].PridajKvapku();
                    nastavKurzor(curRow, curColl);
                    Console.Write(this.stlpce[curColl].DajKvapku(curRow, jePrvy).Drop);
                } else
                {
                    nastavKurzor(curRow, curColl);
                    Console.Write(" ");
                }
                /*
                this.stlpce[curColl].PridajKvapku();
                nastavKurzor(curRow, curColl);
                Console.Write(this.stlpce[curColl].DajKvapku(curRow, jePrvy).Drop);
                */

                if (this.stlpce[curColl].VelkostLin() >= this.stlpce[curColl].DlzkaLinie)
                {
                    this.stlpce[curColl].ZursKvapku();
                    nastavKurzor(curRow - 4, curColl);
                    Console.Write(" ");
                    jePrvy = false;
                }

                if (curColl >= 29)
                {
                    curRow++;
                    curColl = -1;
                    Thread.Sleep(100);
                }

                if (curRow >= 24)
                {
                    Console.Clear();
                    for (int i = 0; i < this.stlpce.Length; i++)
                    {
                        this.stlpce[i].ClearKvapkaList();
                    }
                    curRow = 0;
                    curColl = -1;
                    jePrvy = true;

                    Random rand = new Random();

                    bool jeViditelna = false;

                    for (int i = 0; i < sirka; i++)
                    {
                        int nahoda = rand.Next(0, 2);
                        if (nahoda == 1)
                            jeViditelna = true;
                        else
                            jeViditelna = false;
                        Linia line = new Linia(2, jeViditelna);
                        this.stlpce[i] = line;
                    }
                }

                curColl++;
                //Thread.Sleep(50);
            }
        }

        private void nastavKurzor(int riadok, int stlpec)
        {
            Console.SetCursorPosition(stlpec, riadok);
        }


    }
}
