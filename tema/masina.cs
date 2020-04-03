﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
2. La un târg de mașini trebuie înregistrate toate mașinile care au fost vândute (cumpărate).
    Pentru fiecare mașină se vor indica: nume vânzător, nume cumpărător, tip mașină (nume
firmă + model, exp.: Firma: Opel, Model: Astra 1.4), an fabricație, culoare, optiuni, data
tranzacție, preț. Pe lângă operațiile de introducere, editare și ștergere, aplicația trebuie să
afișeze următoarele rapoarte:
    • cea mai căutată mașină ca și firmă sau ca model, într-o anumită perioadă;
    • un grafic al prețului pentru un anumit model, pe o anumită perioadă de timp;
    • afișarea tranzacțiilor dintr-o anumită zi.
    Observație: la introducerea unei noi tranzacții, se va avertiza printr-un mesaj dacă există o
persoană care cumpără mai multe mașini în aceeași zi sau dacă o persoană vinde mai multe
mașini în aceeași zi.
*/


namespace tema
{
    class masina
    {
        public string nume_vanzator { get; set; }
        public string nume_cumparator { get; set; }
        public string firma { get; set; }
        public string model { get; set; }
        public int an_fabricatie { get; set; }
        public color culoare { get; set; }
        public string optiuni { get; set; }
        public int pret { get; set; }

        public enum color
        {
            necunoscut=-1, rosu, galben, verde, albastru, argintiu, alb, negru, mov
        }

        //constructor  fara parametri
        public masina()
        {
            nume_vanzator = "necunoscut";
            nume_cumparator = "necunoscut";
            firma = "necunoscut";
            model = "necunoscut";
            an_fabricatie = 0;
            culoare = color.necunoscut;
            optiuni = "necunoscut";
            pret = 0;
        }

        //constructor cu parametri pentru masina pusa spre vanzare
        public masina(string _nume_vanzator,string _firma,string _model,int _an_fabricatie,color _culoare,string _optiuni,int _pret)
        {
            nume_vanzator = _nume_vanzator;
            nume_cumparator = "nevanduta";
            firma = _firma;
            model = _model;
            an_fabricatie = _an_fabricatie;
            culoare = _culoare;
            optiuni = _optiuni;
            pret = _pret;
        }

        //constructor cu parametri pentru masina vanduta
        public masina(string _nume_vanzator,string _nume_cumparator, string _firma, string _model, int _an_fabricatie, color _culoare, string _optiuni,int _pret)
        {
            nume_vanzator = _nume_vanzator;
            nume_cumparator = _nume_cumparator;
            firma = _firma;
            model = _model;
            an_fabricatie = _an_fabricatie;
            culoare = _culoare;
            optiuni = _optiuni;
            pret = _pret;
        }
        
        public string conversie_sir_tranzactii()
        {
            return string.Format("Numele cumparatorului: {0}\nNume vanzator: {1}\nModel masina: {2} {3}\nAnul fabricatiei: {4}\nCuloare: {5}\nOptiuni: {6}\nPret: {7}", nume_vanzator, nume_cumparator, firma, model, an_fabricatie, culoare, optiuni, pret);
        }
    }
}
