using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Exercice2
{
    class GestionVols
    {
        static string nomFichier = "Cie_Air_relax.txt";
        static List<Vol> tabVols = new List<Vol>();
        public static int listLength = tabVols.Count;
        public static int nombreVols = 0;


        public static int ChargerVol(List<Vol> tabVols, string nomFichier)
        {

            string ligne;
            int nombreVols = 0;
            
            StreamReader ficRead;
           
            try 
            { 
                ficRead = new StreamReader(nomFichier); 
            } catch(FileNotFoundException erreur)
            {
                if (erreur.Source != null)
                    Console.Write("Problème d'ouverture");
                    throw; 
                
            }
            
            while ((ligne = ficRead.ReadLine()) != null)
            {
                
                var resultSplit = ligne.Split(';');
                var splitDate = resultSplit[2].Split(' ');
                tabVols.Add(new Vol(resultSplit[0], resultSplit[1], new Date(int.Parse(splitDate[0]), int.Parse(splitDate[1]), int.Parse(splitDate[2])), int.Parse(resultSplit[3])));
                
                nombreVols++;
            }
            ficRead.Close();
            return nombreVols;
        }

        public static void ListerVols()
        {
            Console.WriteLine("Compagnie de voyage Les Voyages de Clémence");
                Console.WriteLine("Voici les réservations des vols:");
                foreach (Vol unVol in tabVols)
                {
                Console.WriteLine("#Vol      Destination       Date de départ   Nb de réservation");
                Console.WriteLine($"{unVol.NumeroVol,-10}{unVol.Destination,-20}{unVol.DateDepart,-16}{unVol.NbReservation}");
                Console.WriteLine("***********************************************************************************************");
                }
            Console.ReadKey();
        }

       public static void InsererVol() // Puisque j'utilise une List dynamique, je n'ai pas besoin de vérifier s'il reste de la place dans ma liste, elle s'ajuste par elle-même
        {
            char choix;
            string nouvNumero, nouvDestination; 
            int    nouvJour, nouvMois, nouvAnnee, nouvReservation;

            do
            {

                // Saisir les informations d'un vol
                Console.WriteLine("Numero du vol: ");
                nouvNumero = Console.ReadLine();
                bool nouveauVol = RechercherVol(nouvNumero);
                if (nouveauVol == false)
                {
                    Console.WriteLine("Le numéro du vol est accepté!");
                    Console.WriteLine("SAISIE D'UN NOUVEAU VOL");
                    Console.WriteLine("Veuillez entrer la destination:");
                    nouvDestination = Console.ReadLine();
                    Console.WriteLine("Veuillez entrer la date de départ en commencant par la journée:");
                    nouvJour = int.Parse(Console.ReadLine());
                    if (nouvJour < 0 || nouvJour > 31)
                    {
                        Console.WriteLine("ERREUR : jour invalide");
                        Console.ReadKey();
                        break;
                    }
                    Console.WriteLine("Veuillez maintenant entrer le mois de départ (en chiffres):");
                    nouvMois = int.Parse(Console.ReadLine());
                    if (nouvMois < 0 || nouvMois > 12)
                    {
                        Console.WriteLine("ERREUR : mois invalide");
                        Console.ReadKey();
                        break;
                    }
                    Console.WriteLine("Veuillez finalement entrer l'année de départ:");
                    nouvAnnee = int.Parse(Console.ReadLine());
                    if (nouvAnnee < 2021)
                    {
                        Console.WriteLine("ERREUR : année invalide");
                        Console.ReadKey();
                        break;
                    }
                    Console.WriteLine("Veuillez entrer le nombre de réservation pour ce nouveau vol:");
                    nouvReservation = int.Parse(Console.ReadLine());
                    if (nouvReservation > 340)
                    {
                        Console.WriteLine("Il n'y a pas assez de places dans l'avion. Veuillez recommencer");
                        Console.ReadKey();
                    }
                    else
                    {
                        tabVols.Add(new Vol(nouvNumero, nouvDestination, new Date(nouvJour, nouvMois, nouvAnnee), nouvReservation));
                        Console.WriteLine("#Vol      Destination       Date de départ   Nb de réservation");
                        Console.WriteLine($"{nouvNumero,-10}{nouvDestination,-10}{nouvJour + "/" + nouvMois + "/" + nouvAnnee,-30}{nouvReservation,-16}");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Le numéro de vol est déjà existant");
                }

                do
                {
                    Console.Write("Voulez-vous continuer (O/N) ? ");
                    choix = Console.ReadLine().ToUpper()[0];
                } while (choix != 'O' && choix != 'N');
            } while (choix != 'N');     
        }

        public static bool RechercherVol(string nouvNumero)
        {
            foreach(Vol unVol in tabVols)
            {
                    if (unVol.NumeroVol == nouvNumero)
                    {
                       return true;
                    }
            }
            return false;       
        }

      public static void RetirerVol()
        {
            string numeroDelete, choix;
            bool reponse;

            Console.WriteLine("Veuillez entrer le numéro du vol à retirer");
            numeroDelete = Console.ReadLine();
            reponse = RechercherVol(numeroDelete);
            if (reponse == false)
            {
                Console.WriteLine("Ce vol n'existe pas.");
                Console.ReadKey();
            }
            else
            {
                // afficher informations du vol
                var vol = tabVols.Where(vol => vol.NumeroVol == numeroDelete).FirstOrDefault();
                // requête Linq --> condition : parcours la list si on trouve vol, on regarde le num du vol et si c'est le même que le num à delete, on retourne les infos de vol
                Console.WriteLine("#Vol      Destination       Date de départ   Nb de réservation");
                Console.WriteLine($"{vol.NumeroVol,-10}{vol.Destination,-20}{vol.DateDepart,-16}{vol.NbReservation,-16}");
                Console.WriteLine("Voulez-vous supprimer ce vol? Mettre 'O' pour oui et 'N' pour non");
                choix = Console.ReadLine().ToUpper();
                if (choix == "O") 
                {
                    tabVols.Remove(vol);
                    nombreVols--;
                }
                else
                {
                    Console.WriteLine("Le vol n'a pas été supprimé.");
                    Console.ReadKey();
                }
            }

        }

        public static void ModifierDate()
        {
            string nouvVol, choix;
            char choix1;
            int nouvJour, nouvMois, nouvAnnee;
            bool reponse;

            Console.WriteLine("Saisir le numéro du vol désiré afin de changer la date:");
            nouvVol = Console.ReadLine();
            reponse = RechercherVol(nouvVol);
            if (reponse == false)
            {
                Console.WriteLine("Ce vol n'existe pas.");
                Console.ReadKey();
            }
            else
            {
                var vol = tabVols.Where(vol => vol.NumeroVol == nouvVol).FirstOrDefault();
                Console.WriteLine("#Vol      Destination       Date de départ   Nb de réservation");
                Console.WriteLine($"{vol.NumeroVol,-10}{vol.Destination,-20}{vol.DateDepart,-16}{vol.NbReservation}");
                Console.WriteLine("Voulez-vous changer la date de ce vol? Mettre 'O' pour oui et 'N' pour non");
                choix = Console.ReadLine().ToUpper();
                do
                {
                    if (choix == "O")
                    {
                        Console.WriteLine("Veuillez entrer la nouvelle date de départ en commencant par la journée:");
                        nouvJour = int.Parse(Console.ReadLine());
                        if (nouvJour < 0 || nouvJour > 31)
                        {
                            Console.WriteLine("ERREUR : jour invalide");
                            Console.ReadKey();
                            break;
                        }
                        Console.WriteLine("Veuillez maintenant entrer le mois de départ (en chiffres):");
                        nouvMois = int.Parse(Console.ReadLine());
                        if (nouvMois < 0 || nouvMois > 12)
                        {
                            Console.WriteLine("ERREUR : mois invalide");
                            Console.ReadKey();
                            break;
                        }
                        Console.WriteLine("Veuillez finalement entrer l'année de départ:");
                        nouvAnnee = int.Parse(Console.ReadLine());
                        if (nouvAnnee < 2021)
                        {
                            Console.WriteLine("ERREUR : année invalide");
                            Console.ReadKey();
                            break;
                        }
                        Date nouvDate = new Date(nouvJour, nouvMois, nouvAnnee);
                        vol.DateDepart = nouvDate;
                        Console.WriteLine("Voici les informations du vol avec la nouvelle date:");
                        Console.WriteLine("#Vol      Destination       Date de départ   Nb de réservation");
                        Console.WriteLine($"{vol.NumeroVol,-10}{vol.Destination,-20}{vol.DateDepart,-16}{vol.NbReservation}");
                        Console.ReadKey();
                    }
                    do
                    {
                        Console.Write("Voulez-vous continuer (O/N) ? ");
                        choix1 = Console.ReadLine().ToUpper()[0];
                    } while (choix1 != 'O' && choix1 != 'N');

                } while (choix1 != 'N');

            }
        }

       public static void ReserverVol()
        {
            string nouvVolReserve;
            int nouvPlace;
            bool reponse;

            Console.WriteLine("Veuillez inscrire le numéro du vol que vous souhaitez réserver:");
            nouvVolReserve = Console.ReadLine();
            reponse = RechercherVol(nouvVolReserve);
            if(reponse == false)
            {
                Console.WriteLine("Ce vol n'existe pas.");
                Console.ReadKey();
            }
            else
            {
                var vol = tabVols.Where(vol => vol.NumeroVol == nouvVolReserve).FirstOrDefault();
                Console.WriteLine("#Vol      Destination       Date de départ   Nb de réservation");
                Console.WriteLine($"{vol.NumeroVol,-10}{vol.Destination,-20}{vol.DateDepart,-16}{vol.NbReservation}");
                if (vol.NbReservation > 340)
                {
                    Console.WriteLine("Il n'y a pas de places disponible dans ce vol");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Combien de places désirez-vous réserver?");
                    nouvPlace = int.Parse(Console.ReadLine());
                    if ((vol.NbReservation + nouvPlace) > 340)
                    {
                        Console.WriteLine("Il n'y a pas assez de place dans ce vol");
                    }
                    else if ((vol.NbReservation + nouvPlace) <= 340)
                    {
                        Console.WriteLine("Préparez vos valises! Il reste de la place dans l'avion!");
                        foreach(var element in tabVols)
                        {
                            if(element.NumeroVol == nouvVolReserve)
                            {
                                element.NbReservation = element.NbReservation + nouvPlace;
                                break;
                            }
                        }
                    }

                } Console.ReadKey();
            }
        }

       public static void EcrireFichier(List<Vol> tabVols, string nomFichier)
        {
            StreamWriter ficWrite;
            ficWrite = new StreamWriter(nomFichier);
            string ligne=" ", message=" ";

            message = "Voici le tableau des vols mise à jour:\n";
            message+= "#Vol      Destination       Date de départ   Nb de réservation\n";
            foreach (Vol unVol in tabVols)
            {
                //ligne +=  unVol.NumeroVol+"        "+unVol.Destination+"        "+unVol.DateDepart+"       "+unVol.NbReservation+"\n";
                ligne += $"{unVol.NumeroVol,-10}{unVol.Destination,-20}{unVol.DateDepart,-16}{unVol.NbReservation}\n";
            }

            ficWrite.WriteLine(message+ligne);
            ficWrite.Close();
            ListerVols();

        }
   
        public static int Menu()
        {
            int choix;

            Console.WriteLine("         Cie Air Relax");
            Console.WriteLine("     GESTION DES VOLS");
            Console.WriteLine("1. Liste des vols");
            Console.WriteLine("2. Ajout d'un vol");
            Console.WriteLine("3. Retrait d'un vol");
            Console.WriteLine("4. Modification de la date de départ");
            Console.WriteLine("5. Réservation d'un vol");
            Console.WriteLine("0. Terminer");
            Console.WriteLine("");
            Console.WriteLine("Faites votre choix:");
            
                return choix = int.Parse(Console.ReadLine());
        }
       


        static void Main(string[] args)
        {
            int choix;

            nombreVols = ChargerVol(tabVols, nomFichier);
           

            do
            {
                choix = Menu();
                switch (choix)
                {
                    case 1:
                        ListerVols();
                        break;
                    case 2:
                        InsererVol();
                        break;
                    case 3:
                        RetirerVol();
                        break;
                    case 4:
                        ModifierDate();
                        break;
                    case 5:
                        ReserverVol();
                        break;
                   case 0:
                        EcrireFichier(tabVols, nomFichier);
                        break;
                }
                Console.Clear();
            } while (choix != 0);
             
            
        }
    }
}
