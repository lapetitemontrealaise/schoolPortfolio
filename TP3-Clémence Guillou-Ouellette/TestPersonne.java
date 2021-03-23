/* Fichier 
   Auteurs : Clémence Guillou-Ouellette
   Cours : IFT1810 section C
   Trimestre : Automne 2020
   But : 	Le programme nous permet d'écrire des constructeurs afin d'instancier trois personnes et d'afficher des informations sur celle-ci. 
   			Ce programme nous permet ensuite instancier un tableau pers, d'afficher le contenu, de recalculer des informations et de réafficher le tableau avec les nouvelles informations.
   Derniere mise a jour : 07-12-2020

*/

// TP3 Numéro C
	
class Personne 
{	
	private String naissance;
	
	private int nbCafe;
		
		public Personne(String dateN, int cafe)
		{
			naissance = dateN;
			nbCafe = cafe;
		}
		
		// le nombre de café par défaut est 1
		public Personne(String dateN)
		{
			naissance = dateN;
			nbCafe = 1;
		}
			
		public int getCafe()
		{
			return nbCafe;
		}
		
		/* une date de naissance : "19/05/1997"
		   les indices :			0123456789
		   naissance.substring(3,5) vaut "05"
		   Integer.parseInt("05") vaut 5
		*/
		
		public int rangMois()
		{
			return Integer.parseInt( naissance.substring(3,5));
		}
		
		public String getMois()
		{
			String [] nomMois = {"Janvier", "Février", "Mars", "Avril", "Mai", 
								"Juin", "Juillet", "Août", "Septembre", "Octobre",
								"Novembre", "Décembre"};
			// si rangMois() vaut 5, nomMois[5-1] vaut "Mai"
			return nomMois[rangMois()-1];
		}
		
		public int getJour()
		{
			return Integer.parseInt( naissance.substring(0,2));
		}
		
		public int getAnnee()
		{
			return Integer.parseInt( naissance.substring(6));
		}
		
		public void afficher()
		{
			System.out.printf("\nNaissance : %d %s %d\n", getJour(), getMois(), getAnnee());
			System.out.printf("Café 	  : %d tasse(s) de café par jour\n", getCafe());
		}
		
		public String getNaissance()
		{
			return naissance;
		}
		
		public int getNbCafe()
		{
			return nbCafe;
		}
		
		public void afficherMax(String message)
		{
			System.out.printf("%s", message);
			System.out.printf("Sa date de naissance est: %2s\n", getNaissance());
			System.out.printf("Sa consommation de café par jour est de:%2d tasse(s)\n", getNbCafe());
		}
		
		public void setCafe(int nouvCafe)
		{
			nbCafe = nouvCafe;
		}
			
		public void afficherCafe(String message)
		{
			System.out.printf("%s", message);
			System.out.printf("%2d tasse(s)\n", getNbCafe());
		}		
}	
	
public class TestPersonne 
{
	static void afficher(Personne[] pers, int nbPers)
	{
		for(int i = 0; i < nbPers; i++)
			System.out.printf("%d) %20s %2d tasse(s)\n", i, pers[i].getNaissance(), pers[i].getNbCafe());
	}
	
	static int indMax(Personne[] pers, int nbPers)
	{
		int ind = 0;
		for (int i = 1; i < nbPers; i++)
			if(pers[i].getNbCafe() > pers[ind].getNbCafe())
				ind = i;
		return ind;
	}
	
	static int nombre(Personne [] pers, int nbPers, String moisDonne)
	{
		int n = 0;
		for(int i = 0; i < nbPers; i++)
			if(pers[i].getMois() == moisDonne)
				n++;
		return n;
	}
		
	
	public static void main(String [] args)
	{
		System.out.printf("TP3 Numéro C\n");
		// On veut construire trois personnes
		Personne pers1 = new Personne("19/05/1997", 4),
			     pers2 = new Personne("31/12/1990"), // par défaut nbCafe = 1
			     pers3 = new Personne("08/05/1994", 2);
			
		System.out.printf("Informations de la deuxième personne:");
		pers2.afficher();
		
		System.out.printf("\n");
		
		System.out.printf("Le contenu du tableau pers au début\n");
		System.out.printf("Indice		Tableau pers\n");
		Personne [] pers = { new Personne("16/05/1992", 2),
							 new Personne("02/05/1990", 1),
							 new Personne("23/05/1996", 5),
							 new Personne("19/02/1985", 0),
							 new Personne("30/05/1991", 2)};
		
		int nbPers = pers.length;					 	
		
		afficher(pers, nbPers);	 
			
		System.out.printf("\n");
		int indice = indMax(pers, nbPers);
		pers[indice].afficherMax("Voici les informations de la personnes qui consomme le plus de café:\n");	
			
	    System.out.printf("\n");
		pers[0].setCafe(pers[0].getCafe() - 1);
		pers[0].afficherCafe("La nouvelle consommation de café de pers0 par jour est de:\n");
		pers[1].setCafe(pers[1].getCafe() - 1);
		pers[1].afficherCafe("La nouvelle consommation de café de pers1 par jour est de:\n");
		pers[2].setCafe(pers[2].getCafe() - 1);
		pers[2].afficherCafe("La nouvelle consommation de café de pers2 par jour est de:\n");
		pers[4].setCafe(pers[4].getCafe() - 1);
		pers[4].afficherCafe("La nouvelle consommation de café de pers4 par jour est de:\n");
		
		
		System.out.printf("\n");
		
		System.out.printf("Voici le tableau réaffiché avec la nouvelle consommation de café:\n");
		System.out.printf("Indice		Tableau pers\n");					 	
		afficher(pers, nbPers);	
			
		System.out.printf("\n");
		
		System.out.printf("Le nombre de personnes nées en mai est: %d\n", nombre(pers, nbPers, "Mai"));
		
	}
}

/* Execution:
	 *--------------------Configuration: <Default>--------------------
	TP3 Numéro C
	Informations de la deuxième personne:
	Naissance : 31 Décembre 1990
	Café      : 1 tasse(s) de café par jour
	
	Le contenu du tableau pers au début
	Indice      Tableau pers
	0)           16/05/1992  2 tasse(s)
	1)           02/05/1990  1 tasse(s)
	2)           23/05/1996  5 tasse(s)
	3)           19/02/1985  0 tasse(s)
	4)           30/05/1991  2 tasse(s)
	
	Voici les informations de la personnes qui consomme le plus de café:
	Sa date de naissance est: 23/05/1996
	Sa consommation de café par jour est de: 5 tasse(s)
	
	La nouvelle consommation de café de pers0 par jour est de:
	 1 tasse(s)
	La nouvelle consommation de café de pers1 par jour est de:
	 0 tasse(s)
	La nouvelle consommation de café de pers2 par jour est de:
	 4 tasse(s)
	La nouvelle consommation de café de pers4 par jour est de:
	 1 tasse(s)
	
	Voici le tableau réaffiché avec la nouvelle consommation de café:
	Indice      Tableau pers
	0)           16/05/1992  1 tasse(s)
	1)           02/05/1990  0 tasse(s)
	2)           23/05/1996  4 tasse(s)
	3)           19/02/1985  0 tasse(s)
	4)           30/05/1991  1 tasse(s)
	
	Le nombre de personnes nées en mai est: 4
	
	Process completed.
*/