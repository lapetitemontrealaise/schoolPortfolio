using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Exercice2
{
    class Date
    {
        // attributs 
        private int jour;
        private int mois;
        private int annee;

        public Date() // constructeur par défaut
        {

        }

        public Date(int jour, int mois, int annee) // constructeur avec paramètres
        {
            this.jour = jour;
            this.mois = mois;
            this.annee = annee;
        }

        public int Jour // propriété pour le jour
        {
            get { return jour; }
            set { 
                if(value >=1 || value <= 31)
                    {
                        jour = value;

                    }
                else { Console.WriteLine("ERREUR : journée invalide"); }
            }
        }

        public int Mois // propriété pour le mois
        {
            get { return mois; }
            set {
                if (value >= 1 || value <= 12)
                    {

                        mois = value;
                    }
                else { Console.WriteLine("ERREUR : mois invalide"); }
            }
        }
        public int Annee // propriété année
        {
            get { return annee; }
            set
            {
                if (value >= 2021)
                {
                    annee = value;
                }
                else { Console.WriteLine("ERREUR : année invalide"); }

            }
        }

        public override string ToString()
        {
            string dateDepart = Jour + "/" + Mois + "/" + Annee;
            return dateDepart;
        }





    }
}
