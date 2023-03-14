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

        private int curRow;
        private int curColl;
        private bool jePrvy;

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
            this.curColl = 0;
            this.curRow = 0;
            this.jePrvy = true;
            while (true)
            {
                this.Zapis();
                this.CheckJeDlhy();
                this.CheckJeDole();
                this.Resetuj();
                
                curColl++;
            }
        }

        private void Zapis()
        {
            if (this.stlpce[this.curColl].JeViditelna())
            {
                this.stlpce[this.curColl].PridajKvapku();
                nastavKurzor(this.curRow, this.curColl);
                Console.Write(this.stlpce[this.curColl].DajKvapku(this.curRow, this.jePrvy).Drop);
            }
            else
            {
                nastavKurzor(this.curRow, this.curColl);
                Console.Write(" ");
            }
            /*
            this.stlpce[curColl].PridajKvapku();
            nastavKurzor(curRow, curColl);
            Console.Write(this.stlpce[curColl].DajKvapku(curRow, jePrvy).Drop);
            */
        }

        private void CheckJeDlhy()
        {
            if (this.stlpce[this.curColl].VelkostLin() >= this.stlpce[this.curColl].DlzkaLinie)
            {
                this.stlpce[this.curColl].ZursKvapku();
                nastavKurzor(curRow - (this.stlpce[this.curColl].DlzkaLinie - 1), this.curColl);
                Console.Write(" ");
                this.jePrvy = false;
            }
        }

        private void CheckJeDole()
        {
            if (this.curColl >= this.sirka - 2)
            {
                this.curRow++;
                this.curColl = -1;
                Thread.Sleep(50);
            }
        }

        private void Resetuj()
        {
            Random rand = new Random();

            if (this.curRow >= this.vyska - 2)
            {
                Console.Clear();
                for (int i = 0; i < this.stlpce.Length; i++)
                    this.stlpce[i].ClearKvapkaList();

                this.curRow = 0;
                this.curColl = -1;
                this.jePrvy = true;

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
        }

        private void nastavKurzor(int riadok, int stlpec)
        {
            Console.SetCursorPosition(stlpec, riadok);
        }
    }
}
