/* Fichier 
   Auteurs : Clémence Guillou-Ouellette
   Cours : IFT1810 section C
   Trimestre : Automne 2020
   But : Le programme nous permet d'extraire des sous-chaînes et de les afficher, de compter, déterminenr et d'ensuite afficher certains caractères.
   Derniere mise a jour : 07-12-2020

*/


public class TP3NumeroB {
	
	static int compterAfficher(char carVoulu, String chaine) // Fonction pour compter et afficher les chiffres des numéros de téléphones
	{
		int n = 0,
			nbCars = chaine.length();
		for (int i = 0; i < nbCars; i++) 
			if(chaine.charAt(i) == carVoulu)
				n++;
		return n;
	}
	
	static int compterImpairs(String chaine) // Fonction pour compter et afficher les chiffres impairs
	{
		int n = 0;
		String impairs = "13579";
		
		for(int i = 0; i < chaine.length(); i++)
			if(impairs.indexOf(chaine.charAt(i)) >= 0)
				n++;
		return n;
	}
	
	static int compterPairs(String chaine) // Fonction pour compter et afficher les chiffres pairs
	{
		int n = 0;
		String pairs = "02468";
		
		for(int i = 0; i < chaine.length(); i++)
			if(pairs.indexOf(chaine.charAt(i)) >= 0)
				n++;
		return n;
	}
	
	static void afficherImpairsCommuns(String chaine1, String chaine2)
	{
		System.out.printf("\n-->Les chiffres impairs communs de ces 2 numeros de telephone sont:\n");
		for(char c = '1'; c <= '9'; c+=2)
			if(chaine1.indexOf(c) >= 0 && chaine2.indexOf(c) >= 0)
				System.out.printf("%c ", c);
		System.out.printf("\n");
	}

	public static void main(String[] args)
	{
	String telUDM ="5143436111", 
		   telJean ="4501897654";
	
	// Numéro B.1)Extraire les sous-chaînes et afficher
	System.out.printf("Numero B.\n");
	System.out.printf("Numero 1)\n");
	System.out.printf("-->Le telephone de l'UdM est: (%s) %s-%s\n", telUDM.substring(0,3), telUDM.substring(3,6), telUDM.substring(6));
	System.out.printf("-->Le telephone de l'UdM est: (%s) %s-%s\n", telJean.substring(0,3), telJean.substring(3,6), telJean.substring(6));
	
	// Numéro B.2)
	System.out.printf("\n\nNumero 2)");
	System.out.printf("\n-->Il y a %d fois le chiffre '3' dans le numero de telephone de l'UdM", compterAfficher('3', telUDM));
	System.out.printf("\n-->Il y a %d fois le chiffre '1' dans le numero de telephone de l'UdM", compterAfficher('1', telUDM));
	System.out.printf("\n-->Il y a %d fois le chiffre '2' dans le numero de telephone de Jean", compterAfficher('2', telJean));
	
	// Numéro B.3) 
	System.out.printf("\n\nNumero 3)");
	System.out.printf("\n-->Il y a %d fois les chiffres impairs dans le numero de telephone d'UdM", compterImpairs(telUDM));
	System.out.printf("\n-->Il y a %d fois les chiffres pairs dans le numero de telephone de Jean", compterPairs(telJean));
	
	// Numéro B.4)
	System.out.printf("\n\nNumero 4)");
	afficherImpairsCommuns(telUDM, telJean);
	}
	
	
}

/* Execution:
 *
	 --------------------Configuration: <Default>--------------------
	Numero B.
	Numero 1)
	-->Le telephone de l'UdM est: (514) 343-6111
	-->Le telephone de l'UdM est: (450) 189-7654
	
	
	Numero 2)
	-->Il y a 2 fois le chiffre '3' dans le numero de telephone de l'UdM
	-->Il y a 4 fois le chiffre '1' dans le numero de telephone de l'UdM
	-->Il y a 0 fois le chiffre '2' dans le numero de telephone de Jean
	
	Numero 3)
	-->Il y a 7 fois les chiffres impairs dans le numero de telephone d'UdM
	-->Il y a 5 fois les chiffres pairs dans le numero de telephone de Jean
	
	Numero 4)
	-->Les chiffres impairs communs de ces 2 numeros de telephone sont:
	1 5 
	
	Process completed.

 */