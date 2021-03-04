var tabEntrees=[ // premier tableau d'objet
    {'nom':'Salade','prix':5.95,'image':'image/salade.jpg'}, // objet indice 0
    {'nom':'Escargot','prix':4.95,'image':'image/fruit.jpg'}]; // objet indice 1

var tabPlat=[     
    {'nom':'Spaghetti','prix':8.95,'image':'image/spaghetti.jpg'},
    {'nom':'Lasagne', 'prix':9.95, 'image': 'image/lasagne.jpg'}];

var entreeChoisi; // var doivent être à l'extérieur afin de les appeler dans la fonction
var platChoisi;

function remplirSelEntrees() // fonction relié au HTML pour remplir le select avec les données du tableau
{
    var selEntrees = document.querySelector('#selEntrees'); // on va chercher l'élément avec son id (#)
    selEntrees.options[selEntrees.options.length] = new Option("Choisir..."); // on crée un objet "bidon" , va à l'indice 2 
    for(uneEntree of tabEntrees) // uneEntree = un objet du tableau tabEntrees
        {
            selEntrees.options[selEntrees.options.length] = new Option(uneEntree.nom); // selEntrees.options = les options du select
        } // selEntrees.options.length = la longueur du select, à chaque fois qu'on arrive à une option, on crée une nouvelle option avec 
        // la propriété nom de l'objet uneEntree
}

function infosEntreeChoisi(selEntrees) // pour afficher l'option choisi 
{
    var posEntreeChoisi = selEntrees.selectedIndex-1; // la position de du repas choisi devient l'index choisi dans le select selEntree (-1 pour enlever "Choisir...")
    entreeChoisi=tabEntrees[posEntreeChoisi]; // l'entree choisi est l'indice de la position dans le tabEntrees
    document.getElementById('prixEntree').innerHTML="<strong>"+entreeChoisi.prix+"$"+"</strong>"; // on va chercher dans l'élément et on le remplace dans le html par ce qu'on veut
    document.getElementById('imageEntree').src=entreeChoisi.image; // on ajoute l'image
    document.getElementById('imageEntree').style.display='block'; // on met l'image en display block pour qu'elle puisse aparaître 
    calculFacture(1); // on met notre fonction calculFacture dans notre fonction afin d'avoir les infos
}


function remplirSelPlat()
{
    var selPlat = document.querySelector('#selPlat');
    selPlat.options[selPlat.options.length] = new Option("Choisir...");
    for(unPlat of tabPlat)
    {
        selPlat.options[selPlat.options.length] = new Option(unPlat.nom);
    }
}

function infosPlatChoisi(selPlat)
{
    var posPlatChoisi = selPlat.selectedIndex-1;
    platChoisi=tabPlat[posPlatChoisi];
    document.getElementById('prixPlat').innerHTML="<strong>"+platChoisi.prix+"$"+"</strong>";
    document.getElementById('imagePlat').src=platChoisi.image;
    document.getElementById('imagePlat').style.display='block';
    calculFacture(2);
}

var sousTotalEntree=0, sousTotalRepas=0, taxesEntree=0, taxesRepas=0, totalEntree=0, totalRepas=0;

function calculFacture(type) // type vaut le repas choisi
{
    if(type==1){
        sousTotalEntree=sousTotalEntree + entreeChoisi.prix;
        taxesEntree=sousTotalEntree*0.14975;
        totalEntree=sousTotalEntree+taxesEntree; 
    }
    else{
        sousTotalRepas=sousTotalRepas + platChoisi.prix;
        taxesRepas=sousTotalRepas*0.14975;
        totalRepas=sousTotalRepas+taxesRepas;
    }
    sousTotal=sousTotalEntree+sousTotalRepas;
    taxes=taxesEntree+taxesRepas;
    totalFacture=totalEntree+totalRepas;

    document.getElementById('sousTotal').innerHTML="Sous-total: "+sousTotal.toFixed(2)+"$";
    document.getElementById('taxes').innerHTML="Taxes: "+taxes.toFixed(2)+"$";
    document.getElementById('totalFacture').innerHTML="Total: "+totalFacture.toFixed(2)+"$";
}
