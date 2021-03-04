

/* Fichier numeroA.java
 * 
   Auteurs : Clémence Guillou-Ouellette
   Matricule: 20195276
   Cours : IFT1170
   Trimestre : Hiver 2021
   But : Le programme permet de calculer les deux sommes présentées ci-dessous en appelant deux fois trois méthodes utilisant des boucles différentes
   Derniere mise a jour : 29-01-2021

*/
public class numeroA
{
   // Méthode: calculer
   // Description:
   //   Cette méthode calcule  avec la boucle for 
   // RETOUR: int, la méthode retourne la somme de l'équation
   // IN:
   //   int borne : le paramètre envoyé par le main afin de savoir la borne maximale de l'équation à calculer
    static double calculer(int borne)
    {
        double somme = 0.0,
               num = 1; // numérateur
        for(int deno = 1; deno <= borne; deno++) // deno est le dénominateur
        {
            somme += num / deno;
        }
        
        return somme;
    }
    
   // méthode pour calculer avec la boucle Do While
   // Méthode: calculerDoWhile
   // Description: 
   //   Cette méthode calcule  avec la boucle Do While
   // RETOUR: int, la méthode retourne la somme de l'équation
   // IN:
   //   int borne : le paramètre envoyer par le main afin de savoir la borne maximale de l'équation à calculer
    static double calculerDoWhile(int borne)
    {
        double somme = 0.0,
               num = 1,
               deno = 1;
       do
       {
           somme += num / deno;
           deno++;
       
        } while (deno <= borne);
        
        return somme;
    }
    
    
   // Méthode: calculerWhile
   // Description: 
   //   Cette méthode calcule  avec la boucle While
   // RETOUR: int, la méthode retourne la somme de l'équation
   // IN:
   //   int borne : le paramètre envoyer par le main afin de savoir la borne maximale de l'équation à calculer
    static double calculerWhile(int borne)
    {
        double somme = 0.0,
               num = 1,
               deno = 1;
        
        while (deno <= borne)
        {
           somme += num / deno;
           deno++;
        }
        
        return somme;
    }
    
    public static void main(String[] args)
    {
        final int MAX1 = 99, // dernière valeur de la première équation
                  MAX2 = 999; // dernière valeur de la deuxième équation
        
        // on appel la méthode calculer
        System.out.printf("La somme de 1 + 1/2 + 1/3 + ... 1/%d est:\n%.2f\n", MAX1, calculer(MAX1)); 
        System.out.printf("La somme de 1 + 1/2 + 1/3 + ... 1/%d est:\n%.2f\n", MAX2, calculer(MAX2)); 
        
        System.out.printf("\n\n"); 
        
        // on appel la méthode calculerDoWhile
        System.out.printf("La somme de 1 + 1/2 + 1/3 + ... 1/%d est:\n%.2f\n", MAX1, calculerDoWhile(MAX1));
        System.out.printf("La somme de 1 + 1/2 + 1/3 + ... 1/%d est:\n%.2f\n", MAX2, calculerDoWhile(MAX2));
        
        System.out.printf("\n\n"); 
        
        // on appel la méthode calculerWhile
        System.out.printf("La somme de 1 + 1/2 + 1/3 + ... 1/%d est:\n%.2f\n", MAX1, calculerWhile(MAX1));
        System.out.printf("La somme de 1 + 1/2 + 1/3 + ... 1/%d est:\n%.2f\n", MAX2, calculerWhile(MAX2));
        
        System.out.printf("\n\n"); 
        
}
}

/* Exécution
 * 
    La somme de 1 + 1/2 + 1/3 + ... 1/99 est:
    5,18
    La somme de 1 + 1/2 + 1/3 + ... 1/999 est:
    7,48
    
    
    La somme de 1 + 1/2 + 1/3 + ... 1/99 est:
    5,18
    La somme de 1 + 1/2 + 1/3 + ... 1/999 est:
    7,48
    
    
    La somme de 1 + 1/2 + 1/3 + ... 1/99 est:
    5,18
    La somme de 1 + 1/2 + 1/3 + ... 1/999 est:
    7,48
*/


