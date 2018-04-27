# LUIS

Ce laboratoire va nous permettre de découvrir le service d’intelligence artificielle LUIS. À la fin de ce laboratoire, vous devez être en mesure de créer une application LUIS et utiliser cette dernière dans un bot.

# Introduction à LUIS

Un agent conversationnel doit être en mesure d’échanger avec un tiers, comme si ce dernier s’adressait à un humain.  Imaginez 50 personnes se présentant devant une caisse pour commander, par exemple, un sandwich. Chacun va exprimer le besoin en sa façon, en utilisant ces propres termes. Le même besoin (qui est de commandé un sandwich) sera exprimé en utilisant diverses expressions.

Comment un bot sera-t-il capable de déceler les intentions des utilisateurs en analysant ce qu’ils ont écrit. C’est à ce niveau qu’intervient LUIS (Language Understanding Service). LUIS permet à votre application de comprendre ce que l’utilisateur veut en ses propres mots.

LUIS utilise l’apprentissage machine pour permettre aux développeurs de créer des applications en mesure de comprendre le langage naturel, ainsi que les besoins d’un utilisateur.

Pour utiliser LUIS, vous devez créer une application LUIS sur la plateforme https://www.luis.ai/. Vous devez utiliser votre compte Microsoft pour vous connecter à la plateforme.

Une application LUIS est un modèle de langage conçu par vous pour répondre à vos besoins. Pour mettre en place votre modèle de langage, vous devez définir des intentions, des énoncés et des entités. 

# Comprendre qu’est-ce qu’une intention, un énoncé et une entité

Les intentions : Une intention représente le besoin de l’utilisateur, le service qu’il aimerait recevoir. Exemple : rechercher un vol, réserver un hôtel, commander une pizza, etc. L’intention sera donc le besoin que l’utilisateur veut exprimer à travers le texte qu’il transmet au bot. Dans votre application LUIS, vous devez donc définir des intentions qui représentent ces différents besoins/services. Pour une application de commande de repas, par exemple, une intention sera par exemple CommanderPizza.

Les énoncés :  appelés « Utterance » dans une application LUIS, il s’agit du texte de l’utilisateur que votre application doit comprendre. Ça peut être par exemple « je veux commander une pizza » ou « j’aimerais avoir une pizza ». Aillez à l’esprit qu’un énoncé ne sera pas toujours structuré comme il faut et que pour une intention, vous pouvez avoir un grand nombre d’énoncés.

Les entités : il s’agit des indicateurs clés qui peuvent être extraits d’un énoncé. Par exemple, « j’aimerais avoir 2 sandwichs juniors ». Les indicateurs clés qui peuvent aider à offrir un meilleur service sont la quantité de sandwichs voulus (2) et la taille du sandwich (junior). Pour permettre à LUIS d’extraire et ces données clés, vous devez définir des entités dans votre application LUIS.


LUIS dispose de plusieurs modèles préconçus que vous pouvez utiliser pour démarrer facilement. Chaque modèle dispose des intentions, des entités et des énoncés par rapport à un domaine d’affaire spécifique : gestion d’un calendrier, caméra, évènements, taxi, etc. Il n’existe pas, pour l’instant, des modèles préconçus en français.

Une fois votre modèle conçu, vous devez entrainer et publier celui-ci. Une fois la publication faite, votre application est prête à recevoir et traiter les phrases des utilisateurs. Les interactions avec une application LUIS se font via des requêtes HTTP.  Les informations retournées par LUIS sont au format JSON.

![img1][img1] 

# Création de l’application LUIS

Pour créer l’application LUIS, connectez-vous sur https://www.luis.ai/ avec votre compte Microsoft.  Cliquez sur le bouton « Create new app » et remplissez les informations :

![img2][img2] 

Votre application va s’afficher et l’interface de conception (Build) de votre application sera affichée par défaut :

![img3][img3] 

Le bouton Dashboard va vous permettre d’accéder au tableau de bord de votre bot. Vous aurez une vue générale de votre bot : nombre d’intentions, nombre d’entités, nombre d’énoncés, état de l’application, etc.

Le bouton Build va donner l’accès à l’interface de construction de votre application. C’est à partir de cette interface que vous allez créer vos intentions, les entités et les énoncés.
Une fois votre application conçue, vous devez l’entrainer via le bouton Train.

Le bouton Test va permettre de tester votre application, évaluer les résultats retournés et apporter des ajustements en conséquence.

Le Bouton Publish sera utilisé pour publier votre application. C’est à partir du moment que l’application est publiée que vous pouvez exploiter les modifications apportées dans votre bot.

Le bouton Settings va ouvrir l’interface de configuration de votre application : modification du nom, de la description, ajouter des collaborateurs, supprimer votre application, etc.

# Création des intentions

Nous allons commencer par créer l’intention de commande d’une Poutine. Cette intention va s’appeler « Order.Poutine ». Nous allons donc cliquer sur « Create new intent » et donner un nom à l’intention.

Une fois l’intention créée, on va accéder à une interface qui permettra de saisir des exemples d’énoncés permettant de commander une poutine.
 
 ![img4][img4]

Saisissez au moins cinq énoncés qui vous viennent en tête.

Créez une autre intention ayant pour nom « Restaurant.Information ». Cette intention permettra de fournir une réponse aux utilisateurs qui veulent des informations sur l’activité du restaurant. Les énoncés peuvent être :
-	Quelles sont vos heures d’ouverture ?
-	Où êtes-vous situé ?
-	Quelle est la composition d’une poutine ?
-	Comment vous joindre ?
-	Comment se rendre dans votre restaurant ?
-	C’est quoi une poutine ?

Saisissez au moins cinq énoncés en utilisant ceux ci-dessus ou de votre choix.

Il n’est pas recommandé de laisser l’intention None qui existe par défaut sans aucun énoncé.  Cette intention a pour objectif de permettre de traiter les entrées de l’utilisateur qui n’entrent pas dans votre domaine d’affaires.  Vous pouvez saisir les phrases suivantes comme énoncés pour cette intention :
-	Quitter;
-	Au revoir;
-	Fin de la conversation, etc.

# Entrainer votre application

Vous pouvez maintenant entrainer votre application en cliquant sur Train.

Une fois l’entrainement finalisé, vous aurez une barre verte avec le statut de l’opération.

# Test de l’application

Vous pouvez tester votre application LUIS pour évaluer la qualité des résultats retournés. Les tests se font via le bouton « Test »

 ![img5][img5]

# Publication de l’application 

Vous devez maintenant publier votre application.  Fermez l’interface de Test. Cliquez ensuite sur Publish dans le menu, puis sur « Publish to production slot ».

![img6][img6] 

# Informations de connexion pour le bot

Dans l’interface de publication du bot, vous avez plus bas, dans la zone « Resources and Keys » les informations que vous allez utiliser dans votre bot pour vous connecter à l’application LUIS :

![img7][img7] 

1-	Représente la région. Cette information doit être renseignée dans le paramètre LuisAPIHostName ;
2-	Représente l’identification de l’application. Vous devez fournir cette information au niveau du paramètre LuisAppId ;
3-	Il s’agit de la clé de l’application. Elle doit être renseignée dans le paramètre LuisAPIKey.

# Création du bot.

Nous allons revenir dans Azure et créer un nouveau « Web App Bot ». Cette fois, au niveau du template, vous allez sélectionner « Language understanding »

Modifier les paramètres pour communiquer avec l’application LUIS

Une fois le bot créé, accédez à ce dernier.  Ouvrez la fenêtre contenant les paramètres de votre bot. Modifiez les valeurs des champs LuisAPIKey, LuisAppId, LuisAPIHostName et renseignez les informations obtenues depuis l’application LUIS et enregistrez.

![img8][img8]

# Mise à jour du bot

Vous allez maintenant mettre à jour votre bot pour traiter les intentions qui seront retournées par l’application LUIS.

Accédez à l’éditeur de code en ligne. Éditez le fichier BasicLuisDialog.cs et remplacez son contenu par ce qui suit :

```cs
using System;
using System.Configuration;
using System.Threading.Tasks;

using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

namespace Microsoft.Bot.Sample.LuisBot
{
    // For more information about this template visit http://aka.ms/azurebots-csharp-luis
    [Serializable]
    public class BasicLuisDialog : LuisDialog<object>
    {
        public BasicLuisDialog() : base(new LuisService(new LuisModelAttribute(
            ConfigurationManager.AppSettings["LuisAppId"], 
            ConfigurationManager.AppSettings["LuisAPIKey"], 
            domain: ConfigurationManager.AppSettings["LuisAPIHostName"])))
        {
        }

        [LuisIntent("None")]
        public async Task NoneIntent(IDialogContext context, LuisResult result)
        {
             await context.PostAsync("Désolé, je ne suis pas en mesure de vous fournir une réponse.");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Order.Poutine")]
        public async Task OrderPoutineIntent(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("J’ai détecté que vous voulez commander.");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Restaurant.Information")]
        public async Task RestaurantInformationIntent(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("J'ai détecté que vous voulez obtenir des informations sur notre restaurant.");
            context.Wait(MessageReceived);
        }
    
    }
}
```

Ouvrez ensuite la console et exécutez la commande Build.cmd.

![img9][img9] 

Une fois l’application générée, revenez dans le portail Azure, actualisez la page et testez votre bot :

![img10][img10] 

Utilisez des termes que vous n’avez pas définis dans les énoncés de l’application LUIS pour voir si vous êtes dirigé vers la bonne intention.

# Conclusion

Vous venez de voir comment doter votre robot d’une intelligence artificielle capable d’interpréter le langage naturel. 
 
# Fin

[img1]: Media/img1.png
[img2]: Media/img2.png
[img3]: Media/img3.png
[img4]: Media/img4.png
[img5]: Media/img5.png
[img6]: Media/img6.png
[img7]: Media/img7.png
[img8]: Media/img8.png
[img9]: Media/img9.png
[img10]: Media/img10.png