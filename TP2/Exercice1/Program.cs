using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice1
{
    public class Vin
    {   // attributs des objets
        private String nom;
        private char type;
        private String origine;
        private double prix;
        // constantes 
        public const char ROUGE = '1',
                          BLANC = '2',
                          ROSE = '3';
        // attributs de classe 
        public static int nbVin = 0;
        public static double prixVin = 0.0;

        // un constructeur qui reçoit trois paramètres
        public Vin (string nom, string origine, double prix)
        {
            nbVin++;
            prixVin += prix;
            this.Nom = nom;
            this.Type = '1'; // rouge
            this.Origine = origine;
            this.Prix = prix;
            

        }
        
        // un constructeur qui reçoit quatre paramètres
        public Vin(string nom, char type, string origine, double prix)
        {
            nbVin++;
            prixVin += prix;
            this.Nom = nom;
            this.Type = type;
            this.Origine = origine;
            this.Prix = prix;
            
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        
        public char Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Origine
        {
            get { return origine; }
            set { origine = value; }
        }

        public double Prix
        {
            get { return prix; }
            set { if (prix < 0)
                    Console.WriteLine("Le prix est inexacte!");
                else
                {
                    prix = value; 
                }
            }
        }

       public static int NbVin
        {
            get { return nbVin; }
            set
            {
                if (nbVin < 0)
                    Console.WriteLine("Il n'y a pas de vin.");
                else
                {
                    nbVin = value;
                }
            }
        }
       
       

        public static double getPrixVin()
        {
            return prixVin;
        }
        public static void setPrixVin(double value)
        {
            if (prixVin < 0)
            {
                Console.WriteLine("Le prix est inexacte!");
            }
            else
            {
                prixVin = value;
            }
        }

        public override string ToString()
        {
            return this.nom + " est un vin " + typeVin() + " " + this.origine + " et son prix est de " + this.prix.ToString("0.00$");
        }
        private string typeVin()
        {
            string couleurVin = "vin de type inconnu";
            switch (type)
            {
                case ROUGE:
                    couleurVin = "rouge";
                    break;
                case BLANC:
                    couleurVin = "blanc";
                    break;
                case ROSE:
                    couleurVin = "rosé";
                    break;
            }
            return couleurVin;
        }

    }

    class TestVin
    {
        static void Main(string[] args)
        {
            Vin vin1 = new Vin("MiamMiam", Vin.BLANC, "d'Espagne", 8.95);
            Vin vin2 = new Vin("Délicieux", Vin.ROUGE, "de France", 14.50);
            Vin vin3 = new Vin("Mystère", Vin.ROSE, "de Californie", 10.00);

            Console.WriteLine("Voici les {0} vins:", Vin.nbVin);
            Console.WriteLine("Le prix total des vins est de {0}", Vin.prixVin.ToString("00.00$"));
            Console.WriteLine(vin1);
            Console.WriteLine(vin2);
            Console.WriteLine(vin3);

            
            vin1.Prix+=2.00;
            vin2.Prix = 23.00;
            vin2.Origine = "d'Italie";
            vin3.Nom = "Vino verde";
            vin3.Type = Vin.BLANC;
            vin3.Origine = vin1.Origine;
            Vin vin4 = new Vin("L'érablière", "de Québec", 15.00);
            Vin.setPrixVin(vin1.Prix+vin2.Prix+vin3.Prix+vin4.Prix);

            Console.WriteLine("");

            Console.WriteLine("Voici les {0} vins:", Vin.nbVin);
            Console.WriteLine("Le prix total des vins est de {0}", Vin.getPrixVin().ToString("00.00$")); // ne compte pas les bons montants de vin
            Console.WriteLine(vin1);
            Console.WriteLine(vin2);
            Console.WriteLine(vin3);
            Console.WriteLine(vin4);

            Console.WriteLine("");

            Console.Write("Clémence Guillou-Ouellette, groupe A");
            Console.WriteLine("");
            Console.WriteLine("");

        }
    }
}
