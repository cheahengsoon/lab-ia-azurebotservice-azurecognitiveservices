# Introduction

Cette étape du laboratoire permettra de modifier son bot pour intégrer un service de commande. Ce service de commande va permettre au bot de guider l’utilisateur dans un processus de commande d’une poutine. A la fin de cette étape, vous serez en mesure d’utiliser l’éditeur en ligne et FormFlow pour mettre en place une conversation guidée dans votre bot.

# Qu’est-ce que FormFlow 

Imaginez que vous devez mettre en place un bot qui va guider un client dans la commande d’une Pizza à partir d’un large catalogue de choix avec des options : quelles questions doivent être posées, quelles questions ne doivent pas être posées en fonction des réponses du client, quelle doit être la prochaine question en fonction du choix du client, quand revenir en arrière, comment permettre au client de modifier ses choix, quand est-ce que la conversation doit être interrompue, etc. La mise sur pied d’un algorithme qui permettra de guider l’utilisateur de façon optimale en utilisant Dialogs peut s’avérer assez complexe.

C’est pour fournir une solution à cette problématique que Microsoft a mis en place FormFlow. Il s’agit d’une fonctionnalité disponible avec le SDK Bot Builder pour .NET, qui permet de générer automatiquement « les dialogues » qui sont nécessaires pour mettre en place une conversation guidée.

Selon Microsoft, le recours à FormFlow peut réduire de façon significative le temps nécessaire à la création d’un Bot. Par ailleurs, FormFlow peut s’intégrer facilement avec les autres types de dialogues disponibles.

# Accès à l’éditeur en ligne

Un éditeur en ligne est offert avec les Web App Bot, pour permettre de modifier le code de votre bot, sans avoir besoin d’installer un environnement de développement sur votre PC.

Pour accéder à l’éditeur en ligne, dans l’interface de gestion de votre bot, vous devez cliquer sur « Build », ensuite sur « Open online code editor » :

 ![img1][img1] 

Un nouvel onglet va s’afficher dans votre navigateur. Vous venez d’accéder à l’éditeur en ligne. Ce dernier va afficher par défaut les fichiers du code source de votre bot.

![img2][img2] 

Vous pouvez commencer par explorer les fichiers qui sont disponibles. Vous devez accorder une attention particulière aux fichiers Dialogs/EchoDialog.cs et Controllers/MessagesController.cs.

# Création du formulaire de commande

La première chose à faire sera la création d’un nouveau dossier « Forms ». Pour le faire, il suffit de faire un clic droit dans l’explorateur de fichier, puis cliquer New Folder et donner un nom au nouveau dossier.

Une fois le dossier créé, vous devez le sélectionner, ensuite faire un clic droit et cliquer sur New File et donner le nom « OrderForm.cs » au nouveau fichier.

Vous devez ensuite copier/coller le code ci-dessous dans le fichier :

```cs
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
```

# Création du dialogue pour la commande

Dans le dossier Dialogs, vous allez également créer le fichier OrderFormDialog.cs. Vous devez ensuite copier/coller le code ci-dessous dans ce fichier :

```cs
using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Bot.Builder.FormFlow;

namespace Microsoft.Bot.Sample.SimpleEchoBot
{
    [Serializable]
    public class OrderFormDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {

            await context.PostAsync("Bienvenue au service de commande. Notre assistant vous guidera.");
            //Initialisation du formulaire de commande
            var orderForm =  new FormDialog<OrderForm>(new OrderForm(), OrderForm.BuildForm, FormOptions.PromptInStart);
           
            context.Call<OrderForm>(orderForm, OrderFormComplete);

        }
        //Traitement de la commande, une fois le processus finalisé
        private async Task OrderFormComplete(IDialogContext context, IAwaitable<OrderForm> result)
        {
            OrderForm order = null;
            try
            {
                order = await result;
            }
            catch (OperationCanceledException)
            {
                //En cas d'exception, le processus est annulée
                await context.PostAsync("Opération annulée!");
                return;
            }

            if (order != null)
            {
                //Génération du recu si les informations ont été remplies
                var message = context.MakeMessage();

                message.Text = "Commande en cours... \n\n Ci-dessous votre reçu!";
                message.Attachments.Add(GetReceiptCard(order));


                await context.PostAsync(message);
            }
            else
            {
                await context.PostAsync("Opération annulée!");
            }
            context.Done(true);
        }

        //Fonction pour générer le recu
        private static Attachment GetReceiptCard(OrderForm order)
        {
            var receiptCard = new ReceiptCard
            {
                Title = "Mr/Mme " + order.Name,
                Facts = new List<Fact> { new Fact("Commande No", "xxxxxxx"), new Fact("Méthode de paiement", "Carte") },

            };

            var receiptItems = new List<ReceiptItem>();

            int price = 0;

            double tax;

            switch (order.Size)
            {
                case SizeOptions.Petite:
                    price = order.Type == TypeOptions.Classique ? 5 : 7;
                    break;

                case SizeOptions.Moyenne:
                    price = order.Type == TypeOptions.Classique ? 7 : 9;
                    break;
                case SizeOptions.Grande:
                    price = order.Type == TypeOptions.Classique ? 9 : 11;
                    break;
            }


            receiptItems.Add(new ReceiptItem("Poutine " + order.Type.ToString() + " " + order.Size.ToString(), price: price.ToString() + "$", quantity: "1"));

            if (order.Extras != null)
            {
                order.Extras.ForEach(x => {
                    receiptItems.Add(new ReceiptItem("Extra " + x.ToString(), price: "1$", quantity: "1"));
                });

                price = price + order.Extras.Count();
            }
            tax = price * 0.15;
            receiptCard.Tax = tax.ToString("###.##") + "$";
            receiptCard.Total = (price + tax).ToString("###.##") + "$";
            receiptCard.Items = receiptItems;


            return receiptCard.ToAttachment();
        }



    }
}
```

# Mise à jour du fichier EchoDialog.cs

Éditez le fichier EchoDialog.cs. Remplacez son contenu par ce qui suit :

```cs
using System;
using System.Threading.Tasks;

using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Dialogs;
using System.Net.Http;


namespace Microsoft.Bot.Sample.SimpleEchoBot
{
    [Serializable]
    public class EchoDialog : IDialog<object>
    {
       
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var message = await argument;
             //Si l'utilisateur saisie Commander, on appelle le dialogue de commande
             if (message.Text.Contains("Commander"))
            {
                
                context.Call(new OrderFormDialog(), ResumeAfterDialog);
            }
            else
            {
                await context.PostAsync("Ecrivez Commander pour débuter le processus de commande");
                context.Wait(MessageReceivedAsync);
            }
        }

        public async Task ResumeAfterDialog(IDialogContext context, IAwaitable<object> result)
        {
            context.Wait(MessageReceivedAsync);
        }

    }
}
```

Édition du fichier .csproj

Éditez le fichier Microsoft.Bot.Sample.SimpleEchoBot.csprj. Recherchez « <Compile Include="Dialogs\EchoDialog.cs" /> » en utilisant le raccourci clavier « Ctrl + f ».

Ajoute à la suite de cette ligne, les deux lignes de code suivantes, afin que nos nouveaux fichiers soient pris en compte pendant la génération du bot :

```cs
  <Compile Include="Dialogs\OrderFormDialog.cs" />
  <Compile Include="Forms\OrderForm.cs" />
```

# Génération de du bot

Vous allez cliquer dans le menu vertical à gauche sur le bouton « Open Console » :

![img3][img3]
 
Dans la console qui va s’afficher, vous allez saisir « Build.cmd » 

Si tout est Ok, après quelques minutes, vous obtiendrez le message « Finished successfully ».

![img4][img4]

# Test du Bot

Revenez dans le portail Azure.

Actualisez la page.

Accédez à la fenêtre de chat et testez votre bot.

![img5][img5]
 
# Utilisation du Channel Skype

Vous pouvez permettre l’accès à votre bot à travers divers canaux de communication. Nous verrons comment le faire pour Skype.

Dans l’interface de gestion de votre bot, cliquez sur Channels.  Dans la fenêtre qui va s’afficher, cliquez sur le bouton de configuration pour Skype :

![img6][img6]
 
C’est tout. Vous venez de configurer Skype. Facile!

Cliquez sur Cancel pour revenir en arrière. Vous verrez Skype en cours d’exécution dans vos Channels :

![img7][img7]

Pour utiliser votre Bot avec votre compte Skype, vous devez simplement l’enregistrer dans vos contacts en cliquant sur « Skype » dans le portail Azure.  Un nouvel onglet va s’afficher dans votre navigateur. Un simple clic sur « Add to Contacts » va permettre de l’ajouter à vos contacts Skype et d’échanger avec ce dernier.

![img8][img8]

# Conclusion

Vous êtes désormais en mesure de mettre en place un agent conversationnel en utilisant FormFlow. Nous verrons comment utiliser le Cognitive Service QnA Maker à la prochaine étape.


# Fin

[img1]: Media/img1.png
[img2]: Media/img2.png
[img3]: Media/img3.png
[img4]: Media/img4.png
[img5]: Media/img5.png
[img6]: Media/img6.png
[img7]: Media/img7.png
[img8]: Media/img8.png


