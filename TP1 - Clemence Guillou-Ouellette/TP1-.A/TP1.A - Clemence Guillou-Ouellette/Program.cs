using System;

namespace TP1.A___Clemence_Guillou_Ouellette
{
    class Program
    {
        static void AfficherPrimeBase(double primeBase) // méthode pour afficher la prime de base
        {
            AfficherEspace(' ', 30);
            Console.Write("prime de base :{0,10}", primeBase.ToString("00.00") + "$");
        }

        static void AfficherTaxes(double taxes) // méthode pour afficher les taxes
        {
            AfficherEspace(' ', 30);
            Console.WriteLine("taxes         :{0,10}", taxes.ToString("00.00") + "$");
        }
        static void AfficherTotal(double total) // méthode pour afficher le total
        {
            AfficherEspace(' ', 50);
            AfficherEspace('-', 9);
            Console.WriteLine("");
            AfficherEspace(' ', 30);
            Console.WriteLine("total         :{0,10}", total.ToString("00.00") + "$");

        }
        static void AfficherInfo(int max, int[] tab1, double[] tab2) // mtéhode pour receuillir les informations et les afficher
        {
            // déclaration des variables
            int ageClient;
            int sexeClient;
            int numClient;
            double total, valeurVoiture, primeBase, rabais, surprime, taxes, versements;


            for (int i = 0; i < max; i++) // on fait une boucle qu'on parcours le nombre de fois max envoyé en paramètres
            {

                // variables qu'on utilise dans le code, important de les initialiser à l'extérieur de la boucle
                valeurVoiture = primeBase = rabais = surprime = taxes = versements = 0;


                Console.Write("Numéro du client      : ");// on demande le numéro du client
                numClient = int.Parse(Console.ReadLine()); // on le met dans la variable
                tab1[i] = numClient; // on met le numéro du client dans le tableau
                if (numClient != 0) // si le numéro est différent de 0, on fait les instructions ci-dessous
                {

                    do
                    {
                        Console.Write("Age du client         : ");
                        ageClient = int.Parse(Console.ReadLine());
                    } while (ageClient <= 0);
                    do
                    {
                        Console.Write("Sexe (1 = fém 2 = mas): ");
                        sexeClient = int.Parse(Console.ReadLine());
                    } while (sexeClient != 1 && sexeClient != 2);
                    Console.Write("Valeur voiture        : ");
                    valeurVoiture = double.Parse(Console.ReadLine()); // on converti le string en double 
                    Console.WriteLine("");
                    AfficherEspace(' ', 30);
                    Console.Write("ASSURANCES TOURIX");
                    Console.WriteLine("");


                    if (sexeClient == 1 && ageClient < 25) // si le sexe vaut 1 et que l'âge est plus petit que 25
                    {
                        primeBase = 600.00;
                        AfficherPrimeBase(primeBase);
                    }
                    else if (sexeClient == 2 && ageClient < 25) // si le sexe vaut 2 et que l'âge est plus petit que 25
                    {
                        primeBase = 1500.00;
                        AfficherPrimeBase(primeBase);
                    }
                    else
                    {
                        primeBase = 400.00;
                        AfficherPrimeBase(primeBase);
                    }

                    Console.WriteLine("");

                    if (valeurVoiture >= 15000.00) // si la valeur de la voiture est plus grande que 25 000
                    {
                        surprime = primeBase * 0.25;
                        AfficherEspace(' ', 30);
                        Console.WriteLine("surprime      :{0,10}", surprime.ToString("00.00") + "$");
                        taxes = (primeBase + surprime) * 0.05;
                        AfficherTaxes(taxes);
                        total = primeBase + surprime + taxes;
                        tab2[i] = total; // on met les informations du prix total dans le deuxième tableau
                        AfficherTotal(total);

                    }
                    else if (valeurVoiture < 5000.00)
                    {
                        rabais = primeBase * 0.10;
                        AfficherEspace(' ', 30);
                        Console.WriteLine("rabais        :{0,9}$", rabais.ToString("00.00"));
                        taxes = (primeBase - rabais) * 0.05;
                        AfficherTaxes(taxes);
                        total = primeBase - rabais + taxes;
                        tab2[i] = total;
                        AfficherTotal(total);
                    }
                    else
                    {
                        taxes = primeBase * 0.05;
                        AfficherTaxes(taxes);
                        total = primeBase + taxes;
                        tab2[i] = total;
                        AfficherTotal(total);
                    }

                    Console.WriteLine("");

                    if (total > 700.00)
                    {
                        versements = total / 3;
                        Console.WriteLine("Vous pouvez également payer en trois versements de {0,5}$ chacun", versements.ToString("00.00"));
                    }



                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.Write("Clémence Guillou-Ouellette, groupe A");
                    AfficherEspace(' ', 30);
                    Console.Write("Appuyer sur <Entrée pour terminer");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.ReadKey();


                }
                else
                    Console.WriteLine("Veuillez entrer un bon numéro de client");
            }
            // quand on sort de la boucle, on appel les méthodes et on y envoie les informations receuillis dans la boucle
              
            AfficherMoyenne(tab2);
            AfficherNumero(tab1, tab2);
            AfficherClient(tab2);
            Console.Write("Clémence Guillou-Ouellette, groupe A");
            AfficherEspace(' ', 30);
            Console.Write("Appuyer sur <Entrée pour terminer");
            Console.ReadKey();
            Console.Clear();

        }

        static void AfficherEspace(char carac, int nbFois)
        {
            for (int i = 1; i <= nbFois; i++)
            {
                Console.Write(carac);
            }
        }

        static void AfficherMoyenne(double[] tab2)
        {
            double somme = 0;
            double moyenneMontant = 0;

            for (int i = 0; i < tab2.Length; i++)
            {
                somme += tab2[i];
                moyenneMontant = somme / tab2.Length;
            }
            
            Console.WriteLine("La moyenne des montants des clients à payer est: {0,5}$", moyenneMontant.ToString("00.00"));
        }

        static void AfficherNumero(int[] tab1, double[] tab2)
        {
            double maxNum = 0;
            double numeroClient = 0;

            for (int i = 0; i < tab2.Length; i++)
            {
                if (tab2[i] > maxNum) // si l'indice i du tab est plus grand que le maxNum
                {
                    maxNum = tab2[i]; // le maxNum devient l'indice i du tab
                    numeroClient = tab1[i]; // et le numero du client qui paie le plus est le même indice mais dans le tab1
                }
            }

            Console.WriteLine("Le numéro du client ayant le plus grand montant à payer est: {0,5}", numeroClient);
        }

        static void AfficherClient(double[] tab2)
        {
            int nbClient = 0;
            double montant = 500.00;

            for (int i = 0; i < tab2.Length; i++)
            {
                if (tab2[i] < montant)
                    nbClient++;
            }

            Console.WriteLine("Le nombre de clients qui payent un montant inférieur à 500.00$ est: {0,5}", nbClient);

        }



        static void Main(string[] args)
        {
            const int MAX = 3; // pour la taille maximum du tableau
            int[] tabClient = new int[MAX];
            double[] montantClient = new double[MAX];

            AfficherInfo(MAX, tabClient, montantClient);
            Console.Write("À LA PROCHAINE...");
        }
    }
}
