
/* Fichier 
   Auteurs : Clémence Guillou-Ouellette
   Cours : IFT1170
   Trimestre : Hiver 2021
   But : La première méthode permet de retranscrire les chaînes trouvé dans le main.
         La deuxième méthode permet de démonter les nombres pairs et impairs qui se retrouvent dans les chaînes et de les afficher.
   Derniere mise a jour : 29-01-2021

*/
public class numeroB
{
   // Méthode: afficher
   // Description: 
   //   Cette méthode affiche les différents numéros de téléphone
   // IN:
   //   String chaine1 : le paramètre envoyé par le main afin de pouvoir afficher correctement le nom du numréo (Jean ou UdeM)
   //   String chaine2: le paramètre envoyé par le main afin de pouvoir afficher le numéro de téléphone correspondant au nom
    static void afficher(String chaine1, String chaine2) // chaine1 = nom du téléphone(Jean ou UdeM), chaine2 = numéro de téléphone
    {
        System.out.printf("Téléphone %s est: (%s)%s-%s", chaine1, chaine2.substring(0,3), chaine2.substring(3,6), chaine2.substring(6));
        
    }
    
   // Méthode: compterImpairs
   // Description: 
   //   Cette méthode compte et affiche les chiffres impairs du numéro de téléphone
   // IN:
   //   String chaine1 : le paramètre du nom du numéro de téléphone envoyé par le main (soit Jean ou UdeM)
   //   String chaine2: le paramètre du numéro de téléphone correspondant envoyé par le main afin de pouvoir compter les chiffres impairs 
    static void compterImpairs(String chaine1, String chaine2)
    {
        
        // la première boucle for compte le nombre de chiffres impairs dans le paramètre envoyé à la méthode
        int n = 0;
    String impairs = "13579";
    
    for(int i = 0; i < chaine2.length(); i++){
        if(impairs.indexOf(chaine2.charAt(i)) >= 0){ // indexOf renvoie -1 si le nombre n'est pas trouvé
            n++;    
        }  
    }
        System.out.printf("Il y a %d chiffres impairs dans le numéro de téléphone %s\n", n, chaine1);
        // la deuxième boucle affiche les chiffres trouvés
        System.out.printf("Ce sont: "); 
        for(int i = 0; i < chaine2.length(); i++){
            if(chaine2.charAt(i) % 2 != 0){
                System.out.printf("%c ", chaine2.charAt(i));
            }
        }
    }
    
   // Méthode: compterPairs
   // Description: 
   //   Cette méthode compte et affiche les chiffres pairs du numéro de téléphone
   // IN:
   //   String chaine1 : le paramètre du nom du numéro de téléphone envoyé par le main (soit Jean ou UdeM)
   //   String chaine2: le paramètre du numéro de téléphone correspondant envoyé par le main afin de pouvoir compter les chiffres pairs
    static void compterPairs(String chaine1, String chaine2)
    {
        
        // la première boucle for compte le nombre de chiffres pairs dans le paramètre envoyé à la méthode
        int n = 0;
    String pairs = "02468";
    
    for(int i = 0; i < chaine2.length(); i++){
       if(pairs.indexOf(chaine2.charAt(i)) >= 0){
        n++;
           }
        }
    System.out.printf("Il y a %d chiffres pairs dans le numéro de téléphone %s\n", n, chaine1);
     // la deuxième boucle affiche les chiffres trouvés
    System.out.printf("Ce sont: "); 
        for(int i = 0; i < chaine2.length(); i++){
            if(chaine2.charAt(i) % 2 == 0){
                System.out.printf("%c ", chaine2.charAt(i));
            }
        }  
        
    }
    
   // Méthode: mini
   // Description: 
   //   Cette méthode trouve et affiche le plus petit caractère de la chaine envoyé par le main
   // IN:
   //   String chaine1 : le paramètre du nom du numéro de téléphone envoyé par le main (soit Jean ou UdeM)
   //   String chaine2: le paramètre du numéro de téléphone correspondant envoyé par le main afin de pouvoir compter les chiffres pairs
    static void mini(String chaine1, String chaine2)
    {
        char plusPetit = '9';
        for(int i = 0; i < chaine2.length(); i++){
            if(chaine2.charAt(i) < plusPetit){
                plusPetit = chaine2.charAt(i);
            }
        }
        System.out.printf("Le chiffre %c est le plus petit dans le numéro de téléphone %s", plusPetit, chaine1);
    }
       
    
    public static void main(String[] args)
    {
        String telUdeM = "5143436111",
               telJean = "4501897654",
               udeM = "d'UdeM",
               jean = "de Jean";
         
        // numéro B.1)       
        afficher(udeM, telUdeM);
        System.out.printf("\n");
        afficher(jean, telJean);
        
        System.out.printf("\n");
        System.out.printf("\n");
        
        // numéro B.2)
        compterImpairs(udeM, telUdeM);
        System.out.printf("\n");
        compterImpairs(jean, telJean);
        System.out.printf("\n");
        
        System.out.printf("\n");
        compterPairs(udeM, telUdeM);
        System.out.printf("\n");
        compterPairs(jean, telJean);
        
        System.out.printf("\n");
        System.out.printf("\n");
        
        // numéro B.3)
        mini(udeM, telUdeM);
        System.out.printf("\n");
        mini(jean, telJean);
    }
}

/* Exécution
 * 
    Téléphone d'UdeM est: (514)343-6111
    Téléphone de Jean est: (450)189-7654
    
    Il y a 7 chiffres impairs dans le numéro de téléphone d'UdeM
    Ce sont: 5 1 3 3 1 1 1 
    Il y a 5 chiffres impairs dans le numéro de téléphone de Jean
    Ce sont: 5 1 9 7 5 
    
    Il y a 3 chiffres pairs dans le numéro de téléphone d'UdeM
    Ce sont: 4 4 6 
    Il y a 5 chiffres pairs dans le numéro de téléphone de Jean
    Ce sont: 4 0 8 6 4 
    
    Le chiffre 1 est le plus petit dans le numéro de téléphone d'UdeM
    Le chiffre 0 est le plus petit dans le numéro de téléphone de Jean
 */
