using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.B
{
    class Program
    {
        static string fichier = "../../voitures.txt"; // le nom du fichier qu'on veut lire et receuillir les informations

        static int RemplirTab(int[] tabSerieV, int[] tabSorteV, int[] tabAnneeV, int[] tabPrixV) // la méthode va lire le fichier et remplir les tableaux, on envoie en paramètre les 4 tab
        {
            int nbVoiture = 0; // au début on a 0 voiture car on a pas encore commencé à calculer

            string ligne; // on initialise une string afin de pouvoir lire chaque ligne du fichier et la mettre dans un string

            StreamReader fic = new StreamReader(fichier); // fichier = voitures.txt, on crée une variable et on met le nom de notre fichier dedans
            while ((ligne = fic.ReadLine()) != null) // tant qu'il y a des lignes, on rempli le tableau
            {
                // on doit transformer les int en String afin qu'ils soient lu
                tabSerieV[nbVoiture] = int.Parse(ligne.Substring(0, 3)); // je pars de la pos 0, je veux 3 char
                tabSorteV[nbVoiture] = int.Parse(ligne.Substring(4, 1)); // je pars de la pos 4, je veux 1 char 
                tabAnneeV[nbVoiture] = int.Parse(ligne.Substring(6, 4)); // je pars de la pos 6, je veux 4 char
                tabPrixV[nbVoiture] = int.Parse(ligne.Substring(11)); // indice 11 jusqu'à la fin*/
                nbVoiture++; // on incrémente le nombre de voiture à chaque tour de la boucle
            }
            fic.Close(); // on ferme le fichier
            return nbVoiture; // on retourne le nombre de voiture total du fichier
            
        }

        static void AfficherTableaux(int[] tabSerieV, int[] tabSorteV, int[] tabAnneeV, int[] tabPrixV, int nbVoiture) // on affiche les tableaux dans le terminal
        {
            Console.WriteLine("LISTE DES VOITURES VENDUES: ");
            Console.WriteLine("NUM    SORTE         ANNÉE   PRIX");
            for (int i = 0; i < nbVoiture; i++) // on fait une boucle for pour parcourir tous les éléments du tableau et les afficher
            {
                Console.Write(tabSerieV[i] + "    "); // on affiche le tab des num de série

                // on doit déterminer quelle sorte est la voiture afin d'afficher le bon pays et on affiche le pays 
                if (tabSorteV[i] == 1) 
                    Console.Write("américaine" + "    ");
                else if (tabSorteV[i] == 2)
                    Console.Write("japonaise" + "     ");
                else
                    Console.Write("autre" + "         ");

                Console.Write(tabAnneeV[i]); // on affiche le tab annee
                Console.Write("{0,8}", tabPrixV[i]); // on affiche le tab prix
                //   {0,8} = 0 vaut le tabPrixV[i] (comme un genre de %d) et le 8 est le nombre d'espace pour que tous les éléments soient enlignés à droite
                Console.WriteLine();

            }
        }

        
        static void AfficherVentes(int[] tabPrixV, int nbVoiture) // Méthode pour afficher les voitures totales et les ventes totales
        {
            int ventesTotal = 0; // au début on a 0 vente

            for (int i = 0; i < nbVoiture; i++) // on parcours la boucle pour calculer le nombre de ventes totales
            {
                ventesTotal += tabPrixV[i]; // à chaque boucle on fait ventes = ventes + prix à l'indice i
            }
            Console.WriteLine("TOTAL: {0} voitures pour un montant de: {1} ", nbVoiture, ventesTotal.ToString("00.00$"));
        }

        static void VoitureAmericaine(int[] tabSorteV, int[] tabPrixV, int nbVoiture) // Méthode pour trouver et afficher les voitures américaines de + de 20 000.00$
        {
            int totalAm = 0; // au début on a 0 voiture américaine
            for (int i = 0; i < nbVoiture; i++) // on parcours le tableau avec la boucle
            {
                if ((tabSorteV[i] == 1) && (tabPrixV[i] >= 20000)) // si la sorte vaut 1 et que le prix au même indice est plus élevé que 20000, on incrémente les voitures américaines
                    totalAm++;
            }
            Console.WriteLine("nb de voitures américaines de 20000$ ou plus: {0} ", totalAm);
            
        }

        static void VoitureRecente(int[] tabAnneeV, int nbVoiture) // Méthode pour déterminer et afficher les voitures récentes
        {
            int totalRecente = 0; // au début on a 0 voiture
            for (int i = 0; i < nbVoiture; i++) // on fait le tour du tableau des années
            {
                if (tabAnneeV[i] > 1990) // si l'année à l'indice i est plus grand que 1990, on incrémente le nombre de voiture récente
                    totalRecente++;
            }
            Console.WriteLine("nb de voitures récentes (1991 et +) : {0}", totalRecente);
        }

        static void VentesJapon(int[] tabPrixV, int[] tabSorteV, int nbVoiture) // Méthode pour déterminer et afficher la moyennes des prix de ventes des voitures japonaises
        {
            int moyenneVentesJ = 0; // au début notre moyenne est à 0
            int somme = 0; // au début notre somme des prix est à 0
            int nbVoitureJ = 0; // 0 voiture jap au début

            for (int i = 0; i < nbVoiture; i++)
            {
                if (tabSorteV[i] == 2) // si la sorte de l'indice i vaut 2 elle est japonaise
                {
                    nbVoitureJ++; // on incrémente le nombre de voiture jap
                    somme += tabPrixV[i]; // la somme devient alors la somme + le prix de la voiture au même indice
                }
                  
            }
            moyenneVentesJ = somme / nbVoitureJ; // quand on sort de la boucle, on fait la moyenne vaut la somme totale des ventes / le nombre total de voiture jap

            Console.WriteLine("prix moyen d'une auto japonaise: {0}", moyenneVentesJ.ToString("00.00$"));
        }

        static void MeilleureAM(int[] tabPrixV, int[] tabSorteV, int[] tabSerieV, int nbVoiture) // Méthode pour déterminer et afficher le meilleur prix d'une voiture américaine et le num de série de celle-ci
        {
            int prixBestAm = 50000; // cu qu'on veut le plus petit prix, on initialise notre meilleur prix à un GROS prix
            int numSerie = 0; // au début, on a pas le num de série, on ne le connaît pas
            for (int i = 0; i < nbVoiture; i++)
            {
                if ((tabPrixV[i] < prixBestAm && tabSorteV[i] == 1)) // si le prix à l'indice i est plus petit que 50000 ET que la sorte est américaine (1)
                {
                    prixBestAm = tabPrixV[i]; // le meilleur prix devient le prix de l'invide i
                    numSerie = tabSerieV[i]; // le num de série devient le numéro de serie au même indice
                }
            }
            Console.WriteLine("{0} est la voiture américaine la moins chère ({1})", numSerie, prixBestAm.ToString("00.00$"));
        }
        static void AfficherEspace(char carac, int nbFois) // méthode pour afficher des charactères, des espaces, etc. 
        {
            for (int i = 1; i <= nbFois; i++)
            {
                Console.Write(carac);
            }
        }

        static void Main(string[] args)
        {
            const int MAX = 50; // on peut mettre au maximum 50 string, donc max 50 lignes dans notre tableau
            // On crée quatre tableaux qui correspondent aux différentes colonnes de notre fichier
            int[] tabSerieV = new int[MAX];
            int[] tabSorteV = new int[MAX];
            int[] tabAnneeV = new int[MAX];
            int[] tabPrixV = new int[MAX];;
            
            // Pour connaître le nombre de voitures dans notre tableau
            int nbVoiture = RemplirTab(tabSerieV, tabSorteV, tabAnneeV, tabPrixV);

            // Une fois qu'on a le nombre de voiture de notre fichier, on veut l'afficher dans notre terminal
            // on envoie en paramètre les 4 tabs
            AfficherTableaux(tabSerieV, tabSorteV, tabAnneeV, tabPrixV, nbVoiture);
            Console.WriteLine("");

            // on veut afficher les ventes totales des voitures
            AfficherVentes(tabPrixV, nbVoiture);
            Console.WriteLine("");

            // on veut afficher les voitures américaines de 20000$ et plus
            VoitureAmericaine(tabSorteV, tabPrixV, nbVoiture);
            Console.WriteLine("");

            // on veut afficher les voitures récentes (1991 et +)
            VoitureRecente(tabAnneeV, nbVoiture);
            Console.WriteLine("");

            // on veut la moyenne des prix de vente des voitures japonaises
            VentesJapon(tabPrixV, tabSorteV, nbVoiture);
            Console.WriteLine("");

            // on veut afficher le numéro de série de la voiture la moins cher et son prix 
            MeilleureAM(tabPrixV, tabSorteV, tabSerieV, nbVoiture);
            Console.WriteLine("");


            Console.WriteLine("");

            Console.Write("Clémence Guillou-Ouellette, groupe A");
            AfficherEspace(' ', 30);
            Console.Write("Appuyer sur <Entrée pour terminer");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }
    }
}
