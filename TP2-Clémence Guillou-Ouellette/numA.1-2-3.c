/* Fichier 
   Auteurs : Clémence Guillou-Ouellette
   Cours : IFT1810 section C
   Trimestre : Automne 2020
   But : Ce programme permet de calculer des sommes avec différentes boucles.
   Derniere mise a jour : 07 10 2020

*/
#include <stdio.h>

int main()
{	
	const int BORNE1 = 20, // première valeur du numéro 1.a) et 3.a)
		      BORNE2 = 150, // dernière valeur du numéro 1.a) et 3.a)
		      BORNE3 = 1280, // dernière valeur du numéro 1.b)
		      BORNE4 = 5, // première valeur du numéro 2.a) et 3.b)
		      BORNE5 = 1, // première valeur du numéro 2.b)
		      BORNE6 = 103, // dernière valeur du numéro 2.b)
		      LIMITE = 27, // dernière valeur du numéro 2.a) et 3.b)
		      LE_PAS = 10, // le bond entre les valeurs du numéro 1.a) et 3.a)
		      LE_PAS_B = 2; // le bond entre les valeurs du numéro 2. a) et b) et 3.b)
		      
	int terme, 	// les valeurs à calculer ( ex: 20, 30, 40...)
		somme1, // la somme des valeurs à calculer pour le numéro 1.a)
		somme2,	// la somme des valeurs à calculer pour le numéro 1.b)
		somme4, // la somme des valeurs à calculer pour le numéro 2.b)
		somme5, // la somme des valeurs à calculer pour le numéro 3.a) avec la boucle for
		denominateur; 
		
		
	float somme3 = 0.0, // la somme des valeurs à calculer pour le numéro 2.a)
		  somme6 = 0.0; // la somme des valeurs à calculer pour le numéro 3.b) avec la boucle for
		 
	
	// Numéro 1.a), avec la boucle while
	terme = BORNE1; // la première valeur est 20 
	somme1 = 0; 
	printf("Numero 1.a) On veut calculer la somme de:\n");
	while (terme <= BORNE2) { // on continue tant que le terme est plus petit ou égal à 150
		printf("%3d%s", terme, terme == BORNE2 ? " " : " + "); // est-ce que terme est arrivé à BORNE2? Si oui, on met rien (if...?), si non on continue (else...:)
		
		somme1 += terme; // somme = somme + terme, afin de calculer la nouvelle somme des valeurs
		terme += LE_PAS; // terme = terme + le pas, afin de continuer à augmenter dans les valeurs, jusqu'à 150
		
	}
	printf("\nLa somme calculee est de:\n");
	printf("%d", somme1);
	
	printf("\n\n\n");
	
	
	// Numéro 1.b), avec la boucle while
	terme = BORNE1; // la première valeur est 20
	somme2 = 0;
	printf("Numero 1.b) On veut calculer la somme de:\n");
	while (terme <= BORNE3) { // on continue tant que le terme est plus petit ou égal à 1280
		printf("%3d%s", terme, terme == BORNE3 ? " " : " + ");
		somme2 += terme; // somme = somme + terme, afin de calculer la nouvelle somme des valeurs
		terme *= 2; // terme = terme * deux, afin de continuer à augmenter dans les valeurs, jusqu'à 1280
		
	}
	printf("\nLa somme calculee est de:\n");
	printf("%d", somme2);
	
	printf("\n\n\n");
	
	
	// Numéro 2. a), avec la boucle do...while
	denominateur = BORNE4;
	somme3 = 0.0;
	printf("Numero 2.a) On veut calculer la somme de:\n");
	do {
		printf("1/%d%s", denominateur, denominateur == LIMITE ? " " : " + ");
		somme3 += 1.0 / denominateur; // somme = somme + (1 / denominateur)
		denominateur += LE_PAS_B; // denominateur = denominateur + 2
		
	} while (denominateur <= LIMITE); // on continue tant que le dénominateur est plus petit ou égal à 27
	printf("\nLa somme calculee est de:\n");
	printf("%.2f", somme3);
	
	printf("\n\n\n");
	
	
	// Numéro 2.b), avec la boucle do...while
	
	terme = BORNE5;
	somme4 = 0;
	printf("Numero 2.b) On veut calculer la somme de:\n");
	do {
		printf("%3d%s", terme, terme == BORNE6 ? " " : " + ");
		somme4 += terme;
		terme += LE_PAS_B;		
		
	} while (terme <= BORNE6);
	printf("\nLa somme calculee est de:\n");
	printf("%d", somme4);

	printf("\n\n\n");
	
	
	// Numéro 3. a) Recalculer et afficher la somme1 avec la boucle for
	somme5 = 0;
	printf("Numero 3.a) On veut calculer en utilisant la boucle for la somme de:\n");
	for (terme = BORNE1; terme <= BORNE2; terme+=LE_PAS){ 
		printf("%3d%s", terme, terme == BORNE2 ? " " : " + ");
		somme5 += terme;
	};
		printf("\nLa somme calculee est de:\n");
		printf("%d", somme5);
		
	printf("\n\n\n");
	
	
	// Numéro 3. b) Recalculer et afficher la somme3 avec la boucle for
	somme6 = 0.0;
	printf("Numero 3.b) On veut calculer en utilisant la boucle for la somme de:\n");
	for (denominateur = 5; denominateur <= LIMITE; denominateur+= LE_PAS_B){
		printf("1/%d%s", denominateur, denominateur == LIMITE ? " " : " + ");
		somme6 += 1.0 / denominateur; 
	};
		printf("\nLa somme calculee est de:\n");
		printf("%.2f", somme6);

		return 0;
}
/* Execution:

		Numero 1.a) On veut calculer la somme de:
		 20 +  30 +  40 +  50 +  60 +  70 +  80 +  90 + 100 + 110 + 120 + 130 + 140 + 150
		La somme calculee est de:
		1190
		
		
		Numero 1.b) On veut calculer la somme de:
		 20 +  40 +  80 + 160 + 320 + 640 + 1280
		La somme calculee est de:
		2540
		
		
		Numero 2.a) On veut calculer la somme de:
		1/5 + 1/7 + 1/9 + 1/11 + 1/13 + 1/15 + 1/17 + 1/19 + 1/21 + 1/23 + 1/25 + 1/27
		La somme calculee est de:
		0.97
		
		
		Numero 2.b) On veut calculer la somme de:
		  1 +   3 +   5 +   7 +   9 +  11 +  13 +  15 +  17 +  19 +  21 +  23 +  25 +  27 +  29 +  31 +  33 +  35 +  37 +  39 +  41 +  43 +  45 +  47 +  49 +  51 +  53 +  55 +  57 +  59 +  61 +  63 +  65 +  67 +  69 +  71 +  73 +  75 +  77 +  79 +  81 +  83 +  85 +  87 +  89 +  91 +  93 +  95 +  97 +  99 + 101 + 103
		La somme calculee est de:
		2704
		
		
		Numero 3.a) On veut calculer en utilisant la boucle for la somme de:
		 20 +  30 +  40 +  50 +  60 +  70 +  80 +  90 + 100 + 110 + 120 + 130 + 140 + 150
		La somme calculee est de:
		1190
		
		
		Numero 3.b) On veut calculer en utilisant la boucle for la somme de:
		1/5 + 1/7 + 1/9 + 1/11 + 1/13 + 1/15 + 1/17 + 1/19 + 1/21 + 1/23 + 1/25 + 1/27
		La somme calculee est de:
		0.97
		--------------------------------
		Process exited after 0.04436 seconds with return value 0
		Appuyez sur une touche pour continuer...
	
*/

