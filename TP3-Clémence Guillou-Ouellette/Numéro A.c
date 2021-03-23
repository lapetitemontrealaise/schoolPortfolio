/* Fichier 
   Auteurs : Clémence Guillou-Ouellette
   Cours : IFT1810 section C
   Trimestre : Automne 2020
   But : Traitement et affichage de trois tableaux en utilisant des fonctions différentes. 
   Derniere mise a jour : 16-11-2020

*/
#include <stdio.h>
#include <limits.h>


void afficher( int nbCafe[], int age[], char poste[], char nbPers, char quand_tri[])
{
	int i;
	printf("\nVoici le contenu de ces trois tableaux %s le tri:\n", quand_tri);
	printf("Indice    Cafe    Age    Poste\n");
	
	for(i = 0; i < nbPers; i++)
	{
		printf("%3d)    %5d    %3d    ", i, nbCafe[i], age[i]);
		switch(poste[i]) 
		{
			case 'P' : printf("Programmeur"); 
			break;
			case 'O' : printf("Operateur");
			break;
			case 'A' : printf("Analyste");
			break;
			default: printf("Invalide");
		}
		printf("\n");
		printf("\n");
	}
}
// Fonction pour calculer le nombre d'employé par poste
int compter(char posteVoulu, char poste[], char nbPers)
{
	int n = 0,
		i;
	for (i = 0; i < nbPers; i ++) 
		if (poste [i] == posteVoulu) 
				n++; 
	return n;
}

// Fonction pour calculer combien d'employés de 30 ans et plus et combien d'employés consomment 3 tasses de café et plus par jour
int calculer(int tab[], int nbElem, int borne)
{
	int n = 0,
		i;
	for(i = 0; i < nbElem; i++)
		if(tab[i] >= borne) 
				n++;
	return n;
}

// Fonction pour calculer le maximum
int max(int tab[], int nbElem)
{
	int i;
	int plusGrand = INT_MIN;
	for(i = 0; i < nbElem; i++)
		if(tab[i] > plusGrand) 
			plusGrand = tab[i];
	return plusGrand; 
}

// Fonction void pour trier, aucun calcul à faire, pas de valeur à retourner
void trier(int nbCafe[], int age[], char poste[], char nbPers)
{
	int i;
	for (i = 0; i < nbPers-1; i++)
	{ int indMin = i,
		  j;
	  for(j = i + 1; j < nbPers; j++)
			if(age [j] < age[indMin])
				indMin = j;
	  if(indMin != i)
	  { 
		int tempo = age[i];
		age[i] = age[indMin];
		age[indMin] = tempo;
		
		tempo = nbCafe[i];
		nbCafe[i] = nbCafe[indMin];
		nbCafe[indMin] = tempo;
		
		char tempo2 = poste[i];
		poste[i] = poste[indMin];
		poste[indMin] = tempo2;
		}
	}
}

int main()
{
	int nbCafe [] = {3, 1, 5, 0, 3, 4, 0, 3},
		age [] = {25, 19, 27, 30, 65, 24, 56, 29};
	char poste [] = {'P', 'P', 'O', 'A', 'P', 'A', 'P', 'P'}, // P : Programmeur, O : Opérateur, A : Analyste
		 nbPers = sizeof(poste)/sizeof(char);
	
	printf("Numero A.\n");
	printf("1.");
	//1. Afficher les trois tableaux avant le tri
	afficher(nbCafe, age, poste, nbPers, "avant");
	
	
	//2.a) Afficher le nombre de programmeurs
	printf("2.a)");
	printf("Le nombre de programmeurs est:\n%2d",
			compter('P', poste, nbPers));
			
	printf("\n\n");		
			
	//2.b) Afficher le nombre d'analystes
	printf("2.b)");
	printf("Le nombre d'analystes est:\n%2d",
			compter('A', poste, nbPers));
			
	printf("\n\n");
					
	//2.c) Afficher le nombre d'opérateurs
	printf("2.c)");
	printf("Le nombre d'operateurs est:\n%2d",
			compter('O', poste, nbPers));		
			
	printf("\n\n");
	
	//3.a) Afficher le nombre d'employés ayant 30 ans ou plus
	printf("3.a)");
	printf("Le nombre d'employes ayant 30 ans et plus est:\n%2d",
			calculer(age, nbPers, 30)); 
	
	printf("\n\n");
	
	//3.b) Afficher le nombre d'employés buvant 3 tasses de café ou plus par jour
	printf("3.b)");
	printf("Le nombre d'employes buvant 3 tasses de cafe ou plus par jour est:\n%2d",
			calculer(nbCafe, nbPers, 3)); 
			
	printf("\n\n");
			
	//4.a) Déterminer par une fonction et afficher la consomation maximale de café de tous les employés
	printf("4.a)");
	printf("La consommation maximale de cafe de tous les employes est de:\n%2d",
			max(nbCafe, nbPers));
			
	printf("\n\n");
			
	//4.b) Déterminer par une fonction et afficher l'âge maximal de tous les employés
	printf("4.b)");
	printf("L'age maximale de tous les employes est:\n%d",
			max(age, nbPers));	
	
	printf("\n\n");		
			
	//5. Trier les trois tableaux 
	trier(nbCafe, age, poste, nbPers);
	// Afficher après le tri
	printf("5.");
	afficher(nbCafe, age, poste, nbPers, "apres");
	
		return 0;
}
/* Execution:
	
		Numero A.
		1.
		Voici le contenu de ces trois tableaux avant le tri:
		Indice    Cafe    Age    Poste
		  0)        3     25    Programmeur
		
		  1)        1     19    Programmeur
		
		  2)        5     27    Operateur
		
		  3)        0     30    Analyste
		
		  4)        3     65    Programmeur
		
		  5)        4     24    Analyste
		
		  6)        0     56    Programmeur
		
		  7)        3     29    Programmeur
		
		2.a)Le nombre de programmeurs est:
		 5
		
		2.b)Le nombre d'analystes est:
		 2
		
		2.c)Le nombre d'operateurs est:
		 1
		
		3.a)Le nombre d'employes ayant 30 ans et plus est:
		 3
		
		3.b)Le nombre d'employes buvant 3 tasses de cafe ou plus par jour est:
		 5
		
		4.a)La consommation maximale de cafe de tous les employes est de:
		 5
		
		4.b)L'age maximale de tous les employes est:
		65
		
		5.
		Voici le contenu de ces trois tableaux apres le tri:
		Indice    Cafe    Age    Poste
		  0)        1     19    Programmeur
		
		  1)        4     24    Analyste
		
		  2)        3     25    Programmeur
		
		  3)        5     27    Operateur
		
		  4)        3     29    Programmeur
		
		  5)        0     30    Analyste
		
		  6)        0     56    Programmeur
		
		  7)        3     65    Programmeur
		
		
		--------------------------------
		Process exited after 0.04329 seconds with return value 0
		Appuyez sur une touche pour continuer...
*/

