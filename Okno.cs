using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix3
{
    internal class Okno
    {
        private int hustotaPrazdneho = 5;
        private int vyska = Console.WindowHeight;//25;
        private int sirka = Console.WindowWidth;//30;
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
                int nahoda = rand.Next(0, this.hustotaPrazdneho);
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
            Random rand = new Random();
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
                    nastavKurzor(curRow - (this.stlpce[curColl].DlzkaLinie - 1), curColl);
                    Console.Write(" ");
                    jePrvy = false;
                }

                if (curColl >= this.sirka - 2)
                {
                    curRow++;
                    curColl = -1;
                    Thread.Sleep(50);
                }

                if (curRow >= this.vyska - 2)
                {
                    Console.Clear();
                    for (int i = 0; i < this.stlpce.Length; i++)
                    {
                        this.stlpce[i].ClearKvapkaList();
                    }
                    curRow = 0;
                    curColl = -1;
                    jePrvy = true;

                    //Random rand = new Random();

                    bool jeViditelna = false;

                    for (int i = 0; i < sirka; i++)
                    {
                        int nahoda = rand.Next(0, this.hustotaPrazdneho);
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
