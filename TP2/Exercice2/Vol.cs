using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Exercice2
{
    class Vol
    {
        // attributs 
        private string numeroVol;
        private string destination;
        private Date dateDepart; 
        private int nbReservation;

        static private int nombreVols = 0;

        public Vol(string numeroVol, string destination, Date dateDepart, int nbReservation) // constructeur par défaut
        {
            
            nombreVols++;
            this.numeroVol = numeroVol;
            this.destination = destination;
            this.dateDepart = dateDepart;
            this.nbReservation = nbReservation;
            
        }

       

        public string NumeroVol
        {
            get { return numeroVol; }
        }

        public string Destination 
        {
            get { return destination; }
        }
        public int NbReservation
        {
            get { return nbReservation; }
            set
            {
                if (value <= 340)
                    { 
                        nbReservation = value; 
                    }
            }
        }

        public Date DateDepart
        {
            get { return dateDepart; }
            set { dateDepart = value; }
        }

        public int NombreVols
        {
            get { return nombreVols; }
        }

        public override string ToString()
        {
            string chaineVol = NumeroVol + "\t" + Destination + "\t" + NbReservation + "\t" + DateDepart;
            return chaineVol;
        }





    }
}
