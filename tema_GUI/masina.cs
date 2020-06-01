using System;
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


namespace tema_GUI
{
    class Masina
    {
        public int ID { get; }
        public string Nume_vanzator { get; set; }
        public string Nume_cumparator { get; set; }
        public string Firma { get; set; }
        public string Model { get; set; }
        public int An_fabricatie { get; set; }
        public Color Culoare { get; set; }
        public Options Optiuni { get; set; }
        public int Pret { get; set; }

        public enum Color
        {
            necunoscut = -1, rosu, galben, verde, albastru, argintiu, alb, negru, mov
        }

        [Flags]
        public enum Options
        {
            none = 0b_0000_0000,                  //0
            AC = 0b_0000_0001,                    //1
            abs = 0b_0000_0010,                   //2
            esp = 0b_0000_0100,                   //4
            cutie_automata = 0b_0000_1000,        //8
            navigatie = 0b_0001_0000,             //16
            jante_aluminiu = 0b_0010_0000,        //32
            tapiterie_piele = 0b_0100_0000,       //64
            geamuri_electrice = 0b_1000_0000      //128
        }

        //constructor  fara parametri
        public Masina()
        {
            ID = -1;
            Nume_vanzator = "necunoscut";
            Nume_cumparator = "necunoscut";
            Firma = "necunoscut";
            Model = "necunoscut";
            An_fabricatie = 0;
            Culoare = Color.necunoscut;
            Optiuni = 0;
            Pret = 0;
        }

        //constructor cu parametri pentru masina pusa spre vanzare
        public Masina(int _ID,string _nume_vanzator, string _firma, string _model, int _an_fabricatie, Color _culoare, Options _optiuni, int _pret)
        {
            ID = _ID;
            Nume_vanzator = _nume_vanzator;
            Nume_cumparator = "nevanduta";
            Firma = _firma;
            Model = _model;
            An_fabricatie = _an_fabricatie;
            Culoare = _culoare;
            Optiuni = _optiuni;
            Pret = _pret;
        }

        //constructor cu parametri pentru masina vanduta
        public Masina(int _ID,string _nume_vanzator, string _nume_cumparator, string _firma, string _model, int _an_fabricatie, Color _culoare, Options _optiuni, int _pret)
        {
            ID = _ID;
            Nume_vanzator = _nume_vanzator;
            Nume_cumparator = _nume_cumparator;
            Firma = _firma;
            Model = _model;
            An_fabricatie = _an_fabricatie;
            Culoare = _culoare;
            Optiuni = _optiuni;
            Pret = _pret;
        }

        public string Conversie_sir_tranzactii()
        {


            return string.Format("Numele cumparatorului: {0}\nNume vanzator: {1}\nModel masina: {2} {3}\nAnul fabricatiei: {4}\nCuloare: {5}\nOptiuni: {6}\nPret: {7}", Nume_vanzator, Nume_cumparator, Firma, Model, An_fabricatie, Culoare, Optiuni, Pret);
        }

        public static Boolean operator ==(Masina masina, string marca)
        {
            if (masina.Firma == marca)
                return true;
            return false;
        }
        public static Boolean operator !=(Masina masina, string marca)
        {
            if (masina.Firma != marca)
                return true;
            return false;
        }
    }
}
