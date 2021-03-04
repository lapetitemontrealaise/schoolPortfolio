    
    /* Fichier
       Auteurs : Clémence Guillou-Ouellette
       Cours : IFT1170
       Trimestre : Hiver 2021
       But : La première méthode permet de calculer le nombre d'enfants, d'adolescents et la consommantion de café de certaines personnes. 
             La deuxième méthodes permet de déterminer l'âge de la personne la plus vieille et sa consommation de café. Elle permet aussi
             de trouver la consommation de café la plus élevée.
       Derniere mise a jour : 29-01-2021
    
    */
    public class numeroC
    {
   // Méthode: nombre
   // Description: 
   //   Cette méthode calcule  avec la boucle for le nombre demandé par la question 
   // RETOUR: int, la méthode retourne le nombre à calculer (nombre de personne, nombre de cafés)
   // IN:
   //   int[] tab : le tableau envoyé par le main(âge ou café)
   //   int min : le chiffre minimum envoyé par le main (selon le numréo du TP)
   //   int max : le chiffre maximum envoyé par le main (selon le numéro du TP)
    static int  nombre(int[] tab, int min, int max)
    {
        int numero = 0;
        for(int i = 0; i < tab.length; i++)
            {
                if((tab[i] >= min) && (tab[i] <= max))
                    numero++;
            }
            return numero;
    }
    
   // Méthode: max
   // Description: 
   //   Cette méthode trouve avec la boucle for  le nombre le plus grand
   // RETOUR: int, la méthode retourne le nombre le plus grand (la personne la plus âgée, le nombre le plus élevé de café consommé)
   // IN:
   //   int[] tab : le tableau envoyé par le main(âge ou café)
    static int indiceMax(int[] tab)
    {
        int indiceMax = 0;
        for(int i = 1; i < tab.length; i++)
        {
            if(tab[i] > tab[indiceMax])
                indiceMax = i;
        }
        return indiceMax;
    }
             
    
    public static void main(String[] args)
    {
        int[] age = {30, 11, 14, 32, 17, 19, 35, 8, 15},
              cafe = {3, 0, 1, 1, 4, 2, 1, 0, 1};
              
        int indiceMaxAge = indiceMax(age);
        int indiceMaxCafe = indiceMax(cafe);
              
        final int ENFANT1 = 0,
                  ENFANT2 = 11,
                  ADO1 = 12,
                  ADO2 = 17,
                  CAFE1 = 2,
                  CAFE2 = 4;
         
         // numéro C.a)
         System.out.printf("Il y a %d adolescents\n", nombre(age, ADO1, ADO2));
         System.out.printf("Il y a %d enfants\n", nombre(age, ENFANT1, ENFANT2));
         System.out.printf("Il y a %d personnes consommant entre 2 et 4 tasses de café par jour\n", nombre(cafe, CAFE1, CAFE2));   
         
         System.out.printf("\n\n");
         
         // numéro C.b)
         System.out.printf("La personne la plus âgée a %d ans et elle consomme %d tasse(s) de café\n", age[indiceMaxAge], cafe[indiceMaxAge]);
         System.out.printf("La personne buvant le plus de café: %d tasse(s) et a %d ans\n", cafe[indiceMaxCafe], age[indiceMaxCafe]); // cet ado devrait diminuer sa consommation de café :) 
    }
}

/* Exécution

    Il y a 3 adolescents
    Il y a 2 enfants
    Il y a 3 personnes consommant entre 2 et 4 tasses de café par jour
    
    La personne la plus âgée a 35 ans et elle consomme 1 tasse(s) de café
    La personne buvant le plus de café: 4 tasse(s) et a 17 ans

*/
 
