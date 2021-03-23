/* Fichier 
   Auteurs : Clémence Guillou-Ouellette
   Cours : IFT1810 section C
   Trimestre : Automne 2020
   But : 	Ce programme nous permet d'afficher le contenu de trois tableaux différents (poste, nombre de café et âge).
   			Il nous permet de compter, de déterminer et d'afficher plusieurs éléments en effectuant des opérations différentes.
   			Les mêmes trois tableaux sont ensuite triés et réaffichés. 
   Derniere mise a jour : 07 10 2020

*/
#include <stdio.h>
#include <limits.h> // pour inclure les constantes INT_MIN et INT_MAX

int main()
{
	char poste [] = {'P', 'P', 'O', 'A', 'P', 'A', 'O', 'P'}, // P: programmeur, O: opérateur, A: analyste
		 tempoPoste;
	int age[] = {25, 19, 27, 26, 69, 24, 56, 29}, // âge des employés
		nbCafe [] = {3, 1, 6, 0, 5, 4, 0, 3}, // consommation de café
		ageMin = INT_MAX, // âge minimal des employés
		ageMoyen, // âge moyen des employés
		cafeMax = INT_MIN, // nombre de café maximal consomés
		sommeCafeOp = 0, 
		cafeOp,
		nbProg = 0, // pour calculer le nombre de programmeur traité
		nbSec = 0,
		nbOp = 0,
		sommeAge = 0, // pour calculer le nombre de secrétaire traité
		i,
		j,
		indMin,
		tempo,
		tempoCafe,
		nbPers = sizeof(poste)/sizeof(char);
		
	// Numéro 1. On affiche le contenu de ces trois tableaux avant le tri	
	printf("1. Contenu des trois tableaux selon l'orde des postes:\n");
	printf("Indice	Age	Nombre de cafe	Poste\n");
	
	for(i = 0; i < nbPers ; i++)
	{
		printf("%3d) %6d %12d	", i, age[i], nbCafe[i]);
		switch(poste[i])
		{
			case 'P' : printf("Programmeur"); 
			break;
			case 'O' : printf("Operateur"); 
			break;
			case 'A' : printf("Analyste"); 
			break;
		}
	printf("\n");
	
	}
	
	// Numéro 2. On compte et affiche le nombre de programmeurs traités
	for(i = 0; i < nbPers; i++)
		if(poste[i] == 'P')
		nbProg++;
	
	printf("\n2. Le nombre de programmeur traite est de:\n");
	printf("%d\n", nbProg);
	
	printf("\n");
	
	// Numéro 3. On compte et affiche le nombre de secrétaire traités
	for( i = 0; i < nbPers ; i++)
		if(poste [i] == 'S')
		nbSec++;
	
	printf("3. Le nombre de secretaire traite est de:\n");
	printf("%d\n", nbSec);
	
	printf("\n");
	
	// Numéro 4. On détermine et affiche la consommation maximale de café des analystes
	cafeMax = INT_MIN;
	for( i = 0; i < nbPers ; i++) {
		if(poste[i] == 'A') 
			if (nbCafe[i] > cafeMax)
				cafeMax = nbCafe[i];	
		}
	printf("4. Le nombre de cafe maximal consomme par les analystes est de:\n");
	printf("%d\n", cafeMax);
	
	printf("\n");
	
	// Numéro 5. On détermine et affiche l'âge minimal des programmeurs
	ageMin = INT_MAX;
	for(i = 0; i < nbPers ; i++) {
		if(poste[i] == 'P') 
			if (age[i] < ageMin)
				ageMin = age[i];
 	}		
 	printf("5. L'age minimal des programmeurs est de:\n");
 	printf("%d\n", ageMin);
 	
 	printf("\n");
 	
 	// Numéro 6. On calcule et affiche la consommation moyenne de café des opérateurs
 	// On calcule d'abord le nombre total d'opérateur du tableau
 	for(i = 0; i < nbPers; i++)
		if(poste[i] == 'O')
		nbOp++;
	
	if( nbOp > 0)
 		{
		for( i = 0; i < nbPers ; i++) 
			if(poste[i] == 'O') 
			sommeCafeOp += nbCafe[i]; 
			printf("\n6. Il y a %d operateur(s) traite(s) et la moyenne de leur consommation de cafe est de:\n", nbOp);
 			printf("%d\n", sommeCafeOp/nbOp);
		}
	else // À afficher sur l'écran s'il n'y a pas d'opérateurs
		printf("\n6. Il n'y a pas d'operateurs.\n");
	
	printf("\n");
	 
	// Numéro 7. On calcule et affiche l'âge moyen de tous les employés
	for(i = 0 ; i < nbPers ; i++) 
		sommeAge += age[i];
		
	printf("7. L'age moyen de tous les employes est:\n");
	printf("%d\n", sommeAge / nbPers); 
	
	printf("\n");
	
	// Numéro 8. On tri selon les âges et on réaffiche les trois tableaux
	for(i = 0 ; i < nbPers-1 ; i++)
	{
		indMin = i;
		for(j = i + 1; j < nbPers ; j++)
		if(age[j] < age[indMin])
			indMin = j;
		if(indMin != i)
			{ tempo = age[i];
				age[i] = age[indMin];
				age[indMin] = tempo;
				
			tempoPoste = poste[i];
				poste[i] = poste[indMin];
				poste[indMin] = tempoPoste;
				
			tempoCafe = nbCafe[i];
				nbCafe[i] = nbCafe[indMin];
				nbCafe[indMin] = tempoCafe;
			}
	}
	
	printf("\n8. Voici le resultat des tableaux tries selon les ages:\n");
	printf("\nIndice	Age	Nombre de cafe	Poste\n");
	for( i = 0 ; i < nbPers ; i++)
			{
		printf("%3d) %6d %12d	", i, age[i], nbCafe[i]);
		switch(poste[i])
		{
			case 'P' : printf("Programmeur"); 
			break;
			case 'O' : printf("Operateur"); 
			break;
			case 'A' : printf("Analyste"); 
			break;
		}
	printf("\n");
	
	}
	
	return 0;
	
}

/* Execution:

		1. Contenu des trois tableaux selon l'orde des postes:
		Indice  Age     Nombre de cafe  Poste
		  0)     25            3        Programmeur
		  1)     19            1        Programmeur
		  2)     27            6        Operateur
		  3)     26            0        Analyste
		  4)     69            5        Programmeur
		  5)     24            4        Analyste
		  6)     56            0        Operateur
		  7)     29            3        Programmeur
		
		2. Le nombre de programmeur traite est de:
		4
		
		3. Le nombre de secretaire traite est de:
		0
		
		4. Le nombre de cafe maximal consomme par les analystes est de:
		4
		
		5. L'age minimal des programmeurs est de:
		19
		
		
		6. Il y a 2 operateur(s) traite(s) et la moyenne de leur consommation de cafe est de:
		3
		
		7. L'age moyen de tous les employes est:
		34
		
		
		8. Voici le resultat des tableaux tries selon les ages:
		
		Indice  Age     Nombre de cafe  Poste
		  0)     19            1        Programmeur
		  1)     24            4        Analyste
		  2)     25            3        Programmeur
		  3)     26            0        Analyste
		  4)     27            6        Operateur
		  5)     29            3        Programmeur
		  6)     56            0        Operateur
		  7)     69            5        Programmeur
		
		--------------------------------
		Process exited after 0.03448 seconds with return value 0
		Appuyez sur une touche pour continuer...
			
*/

