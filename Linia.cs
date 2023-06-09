﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix3
{
    internal class Linia
    {
        private Kvapka[] kvapky;
        private int dlzkaLinie { get; }
        private List<Kvapka> kvapkaList;
        private bool jeViditelna;
        private int riadokStart { get; }

        public Linia(int c, bool jeVid) // 0 = chars, 1 = numbers, 2 = alfanumeric
        {
            this.VytvorKvapky(c);
            this.kvapkaList = new List<Kvapka>();

            Random rand = new Random();
            this.dlzkaLinie = rand.Next(2, Console.WindowHeight);
            this.jeViditelna = jeVid;
            this.riadokStart = rand.Next(20);
        }

        public void PridajKvapku()
        {
            Random rand = new Random();
            int i = rand.Next(this.kvapky.Length);
            Kvapka kvapka = this.kvapky[i];
            this.kvapkaList.Add(kvapka);
        }

        public void ZursKvapku()
        {
            this.kvapkaList.RemoveAt(0);
        }

        public void ClearKvapkaList()
        {
            this.kvapkaList.Clear();
        }

        public Kvapka DajKvapku(int index, bool jePrvy)
        {
             if (jePrvy)
                return this.kvapkaList.ElementAt(index);  
             else
                return this.kvapkaList.ElementAt((index - (this.dlzkaLinie - 1)) % this.dlzkaLinie);
        }

        public int VelkostLin()
        {
            return this.kvapkaList.Count;
        }

        public int DlzkaLinie 
        {
            get { return this.dlzkaLinie;} 
        }

        public int RiadokStart 
        { 
            get { return this.riadokStart; } 
        }

        public Boolean JeViditelna() 
        {
            if (this.jeViditelna)
                return true;
            else
                return false;
        } 

        private void VytvorKvapky(int c)
        {
            switch (c)
            {
                case 0:
                    char[] pole = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P' };
                    this.kvapky = new Kvapka[16];

                    for (int i = 0; i < pole.Length; i++)
                    {
                        this.kvapky[i] = new Kvapka(pole[i]);
                    }
                    break;
                case 1:
                    char[] poleN = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                    this.kvapky = new Kvapka[10];

                    for (int i = 0; i < poleN.Length; i++)
                    {
                        this.kvapky[i] = new Kvapka(poleN[i]);
                    }
                    break;
                case 2:
                    char[] poleB = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P' };
                    this.kvapky = new Kvapka[26];

                    for (int i = 0; i < this.kvapky.Length; i++)
                    {
                        this.kvapky[i] = new Kvapka(poleB[i]);
                    }
                    break;
                default:
                    Console.WriteLine("zvol len 0-2");
                    break;
            }
        }
    }
}
