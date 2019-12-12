using System;
using Xunit;

namespace dark_place_game.tests
{
    
    /// Cette classe contient tout un ensemble de tests unitaires pour la classe CurrencyHolder
    public class CurrencyHolderTest
    {
        public static readonly int EXEMPLE_CAPACITE_VALIDE = 10;
        public static readonly int EXEMPLE_CONTENANCE_INITIALE_VALIDE = 5;
        public static readonly string EXEMPLE_NOM_MONNAIE_VALIDE = "Brouzouf";

        [Fact]
        public void VraiShouldBeTrue()
        {   
            //c'est corrigé ! La variable vrai prends TRUE au lieu de FALSE  
            var vrai = true;
            Assert.True(vrai, "Erreur, vrai vaut false. Le test est volontairement mal écrit, corrigez le.");
        }

        [Fact]
        public void CurrencyHolderCreatedWithInitialCurrentAmountOf10ShouldContain10Currency()
        {
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE,EXEMPLE_CAPACITE_VALIDE , 10);
            var result = ch.CurrentAmount == 10;
            Assert.True(result);
        }

        [Fact]
        public void CurrencyHolderCreatedWithInitialCurrentAmountOf25ShouldContain25Currency()
        {
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, 25);
            var result = ch.CurrentAmount == 25;
            Assert.True(result);
        }

        [Fact]
        public void CurrencyHolderCreatedWithInitialCurrentAmountOf0ShouldContain0Currency()
        {
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE,EXEMPLE_CAPACITE_VALIDE, 0);
            var result = ch.CurrentAmount == 0;
            Assert.True(result);
        }

        [Fact]
        public void CreatingCurrencyHolderWithNegativeContentThrowExeption()
        {
            // Petite subtilité : pour tester les levées d'exeption en c# on est obligé d'utiliser un concept un peu exotique : les expression lambda.
            // sans entrer dans le détail pour déclarer une lambda respectez la syntaxe ci dessous, pour rédiger des tests unitaires elle devrais vous suffire.
            Action mauvaisAppel = () => new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE,EXEMPLE_CAPACITE_VALIDE , -10);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void CreatingCurrencyHolderWithNullNameThrowExeption()
        {
            // Petite subtilité : pour tester les levées d'exeption en c# on est obligé d'utiliser un concept un peu exotique : les expression lambda.
            // sans entrer dans le détail pour déclarer une lambda respectez la syntaxe ci dessous, pour rédiger des tests unitaires elle devrais vous suffire.
            Action mauvaisAppel = () => new CurrencyHolder(null,EXEMPLE_CAPACITE_VALIDE , EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            
            

            Assert.Throws<ArgumentException>(mauvaisAppel);

        }

        [Fact]
        public void CreatingCurrencyHolderWithEmptyNameThrowExeption()
        {
            // Petite subtilité : pour tester les levées d'exeption en c# on est obligé d'utiliser un concept un peu exotique : les expression lambda.
            // sans entrer dans le détail pour déclarer une lambda respectez la syntaxe ci dessous, pour rédiger des tests unitaires elle devrais vous suffire.
            Action mauvaisAppel = () => new CurrencyHolder("",EXEMPLE_CAPACITE_VALIDE , EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

       
        [Fact]
        public void BrouzoufIsAValidCurrencyName ()
        {
                        // A vous d'écrire un test qui vérife qu'on peut créer un CurrencyHolder contenant une monnaie dont le nom est Brouzouf
             Action mauvaisAppel = () => new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE,EXEMPLE_CAPACITE_VALIDE , EXEMPLE_CONTENANCE_INITIALE_VALIDE);
             Assert.Equal("Brouzouf", EXEMPLE_NOM_MONNAIE_VALIDE);
        }
        
        [Fact]
        public void DollardIsAValidCurrencyName ()
        {
            // A vous d'écrire un test qui vérife qu'on peut créer un CurrencyHolder contenant une monnaie dont le nom est Dollard
            var monai = new CurrencyHolder("Dollard",EXEMPLE_CAPACITE_VALIDE, 0);
            var res = monai.CurrencyName == "Dollard";
            Assert.True(res);
        }

        [Fact]
        public void TestPut10CurrencyInNonFullCurrencyHolder()
        {
            // A vous d'écrire un test qui vérifie que si on ajoute via la 
            //methode Store 10 currency à un sac a moité plein, il contient maintenant la bonne quantité de currency
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE,EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            int addAmount = 10;
            ch.Store(addAmount);
            Assert.True(ch.CurrentAmount == EXEMPLE_CONTENANCE_INITIALE_VALIDE+addAmount);
        }
  
        [Fact]
        public void TestPut10CurrencyInNearlyFullCurrencyHolder()
        {
            // A vous d'écrire un test qui vérifie que si on ajoute via la methode Store 10 currency à un sac quasiement plein, 
            //une exeption NotEnoughtSpaceInCurrencyHolderExeption est levée.
            var monTraitement = () => {
                var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE,EXEMPLE_CAPACITE_VALIDE,EXEMPLE_CONTENANCE_INITIALE_VALIDE);
                int addAmount = 10;
                ch.Store(addAmount);
            };
            Assert.Throws<NotEnoughtSpaceInCurrencyHolderExeption>(monTraitement);
        }


        [Fact]
        public void CreatingCurrencyHolderWithNameShorterThan4CharacterThrowExeption()
        {
            // A vous d'écrire un test qui doit échouer s'il es possible de créer un CurrencyHolder dont Le Nom De monnaie est inférieur a 4 lettres
            var ch = new CurrencyHolder("Doll",EXEMPLE_CAPACITE_VALIDE, 0);
            Assert.True(ch.CurrencyName.Length >= 4, "Invalid CurrencyName Length");

        }
/*

        [Fact]
        public void WithdrawMoreThanCurrentAmountInCurrencyHolderThrowExeption()
        {
            // A vous d'écrire un test qui vérifie que retirer (methode withdraw) une quantité negative de currency leve une exeption CantWithDrawNegativeCurrencyAmountExeption.
            // Asruce : dans ce cas prévu avant même de pouvoir compiler le test, vous allez être obligé de créer la classe CantWithDrawMoreThanCurrentAmountExeption (vous pouvez la mettre dans le meme fichier que CurrencyHolder)
       
       
        }
       
        */
    }
}