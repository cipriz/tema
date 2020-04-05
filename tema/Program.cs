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

namespace tema
{
    class Program
    {
        static void Main(string[] args)
        {
            masina[] masini=new masina[10];
            string nume_vanzator,nume_cumparator, firma, model, culoare_string, optiuni;
            int nr_masini = 0, an_fabricatie, pret, id;
            masina.Color culoare;
            //masina.options optiuni;

            /*TO DO LIST
            X - cautare cu functie de comparare in clasa
            enum with flags
            citire/afisare fisier
            validari
            */
            string optiune;
            do
            {
                Console.WriteLine("L - Lista masini de vanzare");
                Console.WriteLine("T - Tranzactii efectuate");
                Console.WriteLine("S - Cauta masina dupa firma");
                Console.WriteLine("M - Cea mai cautata masina - TO DO");
                Console.WriteLine("A - Adaugare masina de vanzare");
                Console.WriteLine("V - Adaugare masina Vanduta");
                Console.WriteLine("E - Editare masina de vanzare");
                Console.WriteLine("R - Sterge tranzactie");
                Console.WriteLine("D - Lista tranzactii intr-o anumita zi - TO DO");
                Console.WriteLine("G - Grafic pentru model - TO DO");
                optiune = Console.ReadLine();
                switch (optiune.ToUpper())
                {
                    case "L":
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        for (int i=0;i<nr_masini;i++)
                        {
                            if (masini[i].nume_cumparator=="nevanduta")
                            {
                                Console.WriteLine("ID: " + i);
                                Console.WriteLine(masini[i].conversie_sir_tranzactii());
                                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            }
                        }

                        break;
                    case "T":
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        for (int i = 0; i < nr_masini; i++)
                        {
                            if (masini[i].nume_cumparator != "nevanduta")
                            {
                                Console.WriteLine("ID: "+i);
                                Console.WriteLine(masini[i].conversie_sir_tranzactii());
                                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            }
                        }

                        break;
                    case "S":
                        string search = Console.ReadLine();
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        for (int i = 0; i < nr_masini; i++)
                        {
                            if (masini[i] == search)
                            {
                                Console.WriteLine("ID: " + i);
                                Console.WriteLine(masini[i].conversie_sir_tranzactii());
                                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            }
                        }

                        break;
                    case "M":
                        //TO DO

                        break;
                    case "A":
                        Console.WriteLine("Nume vanzator: ");
                        nume_vanzator = Console.ReadLine();
                        Console.WriteLine("Firma masinii: ");
                        firma = Console.ReadLine();
                        Console.WriteLine("Modelul masinii: ");
                        model = Console.ReadLine();
                        Console.WriteLine("an_fabricatie: ");
                        an_fabricatie = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Culoare: ");
                        culoare_string = Console.ReadLine();
                        culoare = masina.Color.necunoscut;
                        foreach (masina.Color color in Enum.GetValues(typeof(masina.Color)))//enum.parse,        enum.tryparse
                            if (culoare_string == color.ToString())
                                culoare = color;
                        Console.WriteLine("Optiuni: ");
                        optiuni = Console.ReadLine();




                        Console.WriteLine("pret: ");
                        pret = Int32.Parse(Console.ReadLine());
                        masini[nr_masini] = new masina(nume_vanzator,firma,model,an_fabricatie,culoare,optiuni,pret) ;
                        nr_masini++;
                        Console.WriteLine("\n");

                        break;
                    case "V":
                        Console.WriteLine("Nume vanzator: ");
                        nume_vanzator = Console.ReadLine();
                        Console.WriteLine("Nume cumparator: ");
                        nume_cumparator = Console.ReadLine();
                        Console.WriteLine("Firma masinii: ");
                        firma = Console.ReadLine();
                        Console.WriteLine("Modelul masinii: ");
                        model = Console.ReadLine();
                        Console.WriteLine("an_fabricatie: ");
                        an_fabricatie = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Culoare: ");
                        culoare_string = Console.ReadLine();
                        culoare = masina.Color.necunoscut;
                        foreach (masina.Color color in Enum.GetValues(typeof(masina.Color)))
                            if (culoare_string == color.ToString())
                                culoare = color;
                        Console.WriteLine("Optiuni: ");
                        optiuni = Console.ReadLine();




                        Console.WriteLine("pret: ");
                        pret = Int32.Parse(Console.ReadLine());
                        masini[nr_masini] = new masina(nume_vanzator,nume_cumparator, firma, model, an_fabricatie, culoare, optiuni, pret);
                        nr_masini++;
                        Console.WriteLine("\n");

                        break;
                    case "E":
                        Console.WriteLine("EDITOR TRANZACTIE");
                        Console.WriteLine("Introduceti id-ul tranzactiei.");
                        id = Int32.Parse(Console.ReadLine());
                        Console.WriteLine(masini[id].conversie_sir_tranzactii());
                        Console.WriteLine("1 - Nume vanzator");
                        Console.WriteLine("2 - Nume cumparator");
                        Console.WriteLine("3 - Tip masina");
                        Console.WriteLine("4 - An fabricatie");
                        Console.WriteLine("5 - Culoare");
                        Console.WriteLine("6 - Optiuni");
                        Console.WriteLine("7 - Anulare");
                        optiune = Console.ReadLine();
                        switch (optiune)
                        {
                            case "1":
                                masini[id].nume_vanzator = Console.ReadLine();
                                break;
                            case "2":
                                masini[id].nume_cumparator = Console.ReadLine();
                                break;
                            case "3":
                                Console.WriteLine("Firma:");
                                masini[id].firma = Console.ReadLine();
                                Console.WriteLine("Model:");
                                masini[id].model = Console.ReadLine();
                                break;
                            case "4":
                                masini[id].an_fabricatie = Int32.Parse(Console.ReadLine());
                                break;
                            case "5":
                                culoare_string = Console.ReadLine();
                                culoare = masina.Color.necunoscut;
                                foreach (masina.Color color in Enum.GetValues(typeof(masina.Color)))
                                    if (culoare_string == color.ToString())
                                        culoare = color;
                                masini[id].culoare = culoare;
                                break;
                            case "6":
                                masini[id].optiuni = Console.ReadLine();
                                break;
                            case "7":
                                break;
                        }



                        break;
                    case "R":
                        Console.WriteLine("STERGERE TRANZACTIE:");
                        Console.WriteLine("Introduceti id-ul tranzactiei.");
                        id = Int32.Parse(Console.ReadLine());
                        Console.WriteLine(masini[id].conversie_sir_tranzactii());
                        Console.WriteLine("Introduceti 'y' daca sunteti sigur de alegerea facuta");
                        if (Console.ReadLine() == "y")
                        {
                            for (int i=id;i<nr_masini-1;i++)
                            {
                                masini[i] = masini[i + 1];
                            }
                            masini[id] = new masina();
                            nr_masini--;
                        }


                        break;
                    case "D":
                        //TO DO

                        break;
                    case "G":
                        //TO DO

                        break;
                    default:
                        Console.WriteLine("Optiune inexistenta");
                        break;
                }
            } while (optiune.ToUpper() != "X");


        }
    }
}
