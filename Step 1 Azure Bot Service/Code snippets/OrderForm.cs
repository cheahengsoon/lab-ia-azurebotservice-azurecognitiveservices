using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.FormFlow.Advanced;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.Bot.Sample.SimpleEchoBot
{
    /// <summary>
    /// Formulaire de commade d'une poutine en utilisant FormFlow
    /// </summary>
    [Serializable]
    public class OrderForm
    {
        #region questions
        //Différentes questions qui seront posées à l'utilisateur
        [Prompt("Veuillez selectionner votre type de poutine ? {||}")]
        public TypeOptions Type;
        [Prompt("Veuillez choisir la taille ? {||}")]
        public SizeOptions Size;
        [Prompt("Voulez-vous des extras ? {||}")]
        public Boolean AddExtra { get; set; }
        [Prompt("Veuillez choisir les extras ? {||}")]
        public List<ExtraOptions> Extras;
        [Prompt("Veuillez saisir votre nom ? {||}")]
        public string Name { get; set; }
        #endregion

        //Constuction du formulaire de commade
        public static IForm<OrderForm> BuildForm()
        {

            return new FormBuilder<OrderForm>()
                    .Field(nameof(Type))
                    .Field(nameof(Size))
                    .Field(nameof(AddExtra))
                    .Field(nameof(Extras), state => state.AddExtra)
                    .Field(nameof(Name))
                    .Confirm("Vos choix sont-ils corrects ? {*}")
                    .Build();
        }

        //Définition de la prochaine question en fonction du choix de l'utilisateur pour les extras
        private static NextStep SetNextAfterAddExtra(object value, OrderForm state)
        {
           
            if ((bool)value == true)
            {
                return new NextStep(new[] { nameof(Extras) });
            }
            else
            {

                return new NextStep();
            }
        }


    }

    #region options 
    //Options qui seront proposées pour chaque question
    public enum TypeOptions {
        [Describe(title:"Specialité de la maison", subTitle: "Fromage en grains, mozzarella, boeuf braisé et sauce au vin rouge.", 
            image: "http://rdonfack.developpez.com/images/maison.PNG",message:"Maison")]
        Maison=1,
        [Describe(title: "Classique", subTitle: "Fromage en grains, frites et sauce maison",
            image: "http://rdonfack.developpez.com/images/classique.PNG", message: "Classique")]
        Classique,
        [Describe(title: "Le fermier", subTitle: "Saucisses italiennes, poivrons rouges, augergines marinées, grains frais, sauce à la viande et mozzarella gratiné.", 
            image: "http://rdonfack.developpez.com/images/fermier.PNG", message: "Fermier")]
        Fermier,
        [Describe(title: "Le parrain", subTitle: "Poulet grillé, bacon, tomates en dés et fromage en grain.", 
            image: "http://rdonfack.developpez.com/images/parrain.PNG", message: "Parrain")]
        Parrain
        }
    public enum SizeOptions {
        Petite =1,
        [Terms("Moyen", "Moyenne")]
        Moyenne,
        Grande };
    public enum ExtraOptions {
        Bacon=1,
        Viande_haché,
        Jambon,
        Pepperoni,
        Oeuf,
        Porc_effiloché,
        Steak
    }
#endregion

}