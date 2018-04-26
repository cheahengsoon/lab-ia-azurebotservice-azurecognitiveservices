Introduction

Cette étape du laboratoire permettra de modifier son bot pour intégrer un service de commande. Ce service de commande va permettre de bot de guider l’utilisateur dans un processus de commande d’une poutine. A la fin de cette étape, vous serez en mesure d’utiliser l’éditeur en ligne et FormFlow pour mettre en place une conversation guidée dans votre bot.

Qu’est-ce que FormFlow 

Imaginez que vous devez mettre en place un bot qui va guider un client dans la commande d’une Pizza à partir d’un large catalogue de choix avec des options : quelles questions doivent être posées, quelles questions ne doivent pas être posées en fonction des réponses du client, quel doit être la prochaine question en fonction du choix du client, quand revenir en arrière, comment permettre au client de modifier ses choix, quand est-ce que la conversation doit être interrompue, etc. La mise sur pied d’un algorithme qui permettra de guider l’utilisateur de façon optimale en utilisant Dialogs peut s’avérer assez complexe.

C’est pour fournir une solution à cette problématique que Microsoft a mis en place FormFlow. Il s’agit d’une fonctionnalité disponible avec le SDK Bot Builder pour .NET, qui permet de générer automatiquement « les dialogues » qui sont nécessaires pour mettre en place une conversation guidée.

Selon Microsoft, le recours à FormFlow peut réduire de façon significative le temps nécessaire à la création d’un Bot. Par ailleurs, FormFlow peut s’intégrer facilement avec les autres types de dialogues disponibles.

Accès à l’éditeur en ligne

Un éditeur en ligne est offert avec les Web App Bot, pour permettre de modifier le code de votre bot, sans avoir besoin d’installer un environnement de développement sur votre PC.

Pour accéder à l’éditeur en ligne, dans l’interface de gestion de votre bot, vous devez cliquer sur « Build », ensuite sur « Open online code editor » :

  

Un nouvel onglet va s’afficher dans votre navigateur. Vous venez d’accéder à l’éditeur en ligne. Ce dernier va afficher par défaut les fichiers du code source de votre bot.

 

Vous pouvez commencer par explorer les fichiers qui sont disponibles. Vous devez accorder une attention particulière aux fichiers Dialogs/EchoDialog.cs et Controllers/MessagesController.cs.



Création du formulaire de commande

La première chose à faire sera la création d’un nouveau dossier « Forms ». Pour le faire, il suffit de faire un clic droit dans l’explorateur de fichier, puis cliquer New Folder et donner un nom au nouveau dossier.

Une fois le dossier créé, vous devez le sélectionner, ensuite faire un clic droit et cliquer sur New File et donner le nom « OrderForm.cs » au nouveau fichier.

Vous devez ensuite copier/coller le code ci-dessous dans le fichier :

Création du dialogue pour la commande

Dans le dossier Dialogs, vous allez également créer le fichier OrderFormDialog.cs. Vous devez ensuite copier/coller le code ci-dessous dans ce fichier :


Mise à jour du fichier EchoDialog.cs

Éditez le fichier EchoDialog.cs. Remplacez son contenu par ce qui suit :


Édition du fichier .csproj

Éditez le fichier Microsoft.Bot.Sample.SimpleEchoBot.csprj. Recherchez « <Compile Include="Dialogs\EchoDialog.cs" /> » en utilisant le raccourci clavier « Ctrl + f ».

Ajoute à la suite de cette ligne, les deux lignes de code suivantes, afin que nos nouveaux fichiers soient pris en compte pendant la génération du bot :


Génération de du bot

Vous allez cliquer dans le menu vertical à gauche sur le bouton « Open Console » :

 

Dans la console qui va s’afficher, vous allez saisir « Build.cmd » 

 
Si tout est Ok, après quelques minutes, vous obtiendrez le message « Finished successfully ».

Test du Bot

Revenez dans le portail Azure.
 Actualisez la page.
Accédez à la fenêtre de chat et testez votre bot.


 


Utilisation du Channels Skype

Vous pouvez permettre l’accès à votre bot à travers divers canaux de communication. Nous verrons comment le faire pour Skype.

Dans l’interface de gestion de votre bot, cliquez sur Channels.  Dans la fenêtre qui va s’afficher, cliquez sur le bouton de configuration pour Skype :

 

C’est tout. Vous venez de configurer Skype. Facile!

Cliquez sur Cancel pour revenir en arrière. Vous verrez Skype en cours d’exécution dans vos Channels :

Pour utiliser votre Bot avec votre compte Skype, vous devez simplement l’enregistrer dans vos contacts en cliquant sur « Skype » dans le portail Azure.  Un nouvel onglet va s’afficher dans votre navigateur. Un simple clic sur « Add to Contacts » va permettre de l’ajouter à vos contacts Skype et d’échanger avec ce dernier.



Conclusion

Vous êtes désormais en mesure de mettre en place un agent conversationnel en utilisant FormFlow. Nous verrons comment utiliser le Cognitive Service QnA Maker à la prochaine étape.

