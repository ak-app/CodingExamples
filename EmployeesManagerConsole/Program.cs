using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLW
{
    class Program
    {
        static void Main(string[] args)
        {
            bool beenden = false;
            string eingabe;
            List<Mitarbeiter> mitarbeiter = new List<Mitarbeiter>
            {
                new Mitarbeiter
                {
                    Personalnummer = 101,
                    Vorname = "Hans",
                    Nachname = "Burtscher"
                },
                new Mitarbeiter
                {
                    Personalnummer = 102,
                    Vorname = "Anna",
                    Nachname = "Tomaselli"
                },
                new Mitarbeiter
                {
                    Personalnummer = 103,
                    Vorname = "Max",
                    Nachname = "Gantner"
                },
                new Mitarbeiter
                {
                    Personalnummer = 104,
                    Vorname = "Maria",
                    Nachname = "Vonbank"
                },
            };

            while (beenden == false)
            {
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("1: Liste anzeigen");
                Console.WriteLine("2: Mitarbeiter hinzufügen");
                Console.WriteLine("3: Mitarbeiter löschen");
                Console.WriteLine("4: Mitarbeiter bearbeiten");
                Console.WriteLine("0: Anwendung beenden");
                Console.WriteLine("");
                Console.Write("Eingabe: ");
                eingabe = Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine("---------------------------------------");

                switch (eingabe)
                {
                    case "1":
                        foreach (Mitarbeiter einMitarbeiter in mitarbeiter)
                        {
                            Console.WriteLine("  " + einMitarbeiter.Personalnummer + " " + einMitarbeiter.Vorname + " " + einMitarbeiter.Nachname);
                        }
                        Console.WriteLine("");
                        break;

                    case "2":
                        Mitarbeiter mitarbeiterNeu = new Mitarbeiter();

                        Console.WriteLine("Bitte Daten des neuen Mitarbeiters eingeben (für Abbruch 'a' eingeben)");
                        
                        Console.Write("  Personalnummer: ");
                        eingabe = Console.ReadLine();

                        if (eingabe == "a")
                            break;

                        mitarbeiterNeu.Personalnummer = int.Parse(eingabe);


                        Console.Write("  Vorname: ");
                        eingabe = Console.ReadLine();

                        if (eingabe == "a")
                            break;

                        mitarbeiterNeu.Vorname = eingabe;

                        Console.Write("  Nachname: ");
                        eingabe = Console.ReadLine();

                        if (eingabe == "a")
                            break;

                        mitarbeiterNeu.Nachname = eingabe;

                        mitarbeiter.Add(mitarbeiterNeu);
                        Console.WriteLine("  Mitarbeiter " + mitarbeiterNeu.Vorname + " " + mitarbeiterNeu.Nachname + " wurde hinzugefügt");
                        break;

                    case "4":
                        // ToDo
                        break;

                    case "3":
                        Console.Write("Personalnummer des zu löschenden Mitarbeiters: ");
                        eingabe = Console.ReadLine();
                        int personalNr = int.Parse(eingabe);
                        int indexToDelete = -1;

                        for (int index = 0; index < mitarbeiter.Count; index++)
                        {
                            if (mitarbeiter[index].Personalnummer == personalNr)
                            {
                                indexToDelete = index;
                            }
                        }

                        if (indexToDelete == -1)
                        {
                            Console.WriteLine("Mitarbeiter mit Personalnummer " + personalNr + " nicht gefunden.");
                        }
                        else
                        {
                            Console.WriteLine("Mitarbeiter " + personalNr + " (" + mitarbeiter[indexToDelete].Vorname + " " + mitarbeiter[indexToDelete].Nachname + ") wird gelöscht.");
                            mitarbeiter.RemoveAt(indexToDelete);
                        }

                        break;

                    case "0":
                        beenden = true;
                        break;
                }
                
                if (eingabe == "a")
                    Console.WriteLine("Abbruch");
            }
        }
    }
}
