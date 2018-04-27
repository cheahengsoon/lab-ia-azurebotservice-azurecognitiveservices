# Créer un bot intelligent avec QnA Maker

# Introduction

Ce laboratoire est indépendant du précédent. Nous verrons comment exploiter le service cognitif QnA Maker dans un bot. À la fin de ce laboratoire, vous serez en mesure de créer un service QnA Maker, l’enrichir avec vos données de FAQ, l’entrainer, le publier et l’utiliser dans un bot.


# Introduction à Qna Maker

La majorité des sites Web disposent d’une page de FAQ (foire aux questions) permettant d’avoir rapidement des réponses aux questions fréquentes sur un sujet donné.  

Prenons, par exemple, le site web d’un restaurant de sandwich. En plus des services offerts en ligne (commande d’un sandwich, etc.), ce dernier doit être en mesure d’offrir des informations pertinentes comme les heures d’ouverture, la localisation, la composition d’un sandwich, etc. Ces informations peuvent être fournies via la FAQ.

Supposons maintenant que nous voulons mettre en place en agent conversationnel (chat bot) capable de guider l’utilisateur dans le processus de commande d’un sandwich. L’objectif de ce bot sera d’offrir une nouvelle expérience utilisateur, qui évitera à ce dernier l’effort dans la navigation sur le site.

Si l’agent conversationnel a pour vocation de faire abstraction du site Web via certains canaux de communication (Skype, web chat, Facebook Messenger, etc.), en plus du service offert, il doit être en mesure de fournir une réponse aux questions fréquentes des utilisateurs : celles qu’on va retrouver dans la section FAQ du site Web.
C’est pour répondre à ce besoin que Microsoft a mis en place QnA Maker. Avec ce service, vous êtes en mesure de mettre en place en quelques minutes un bot capable de répondre aux questions en puisant ses informations dans une FAQ.

Concrètement, QnA Maker est  une API REST et un service web permettant de créer et entrainer une intelligence artificielle qui sera en mesure de répondre aux questions d’un utilisateur à travers une conversation en langage naturel. 

QnA Maker offre une interface graphique permettant de créer son service, le peupler avec des questions/réponses, l’entrainer en exploitant les services de machine learning de Microsoft et le publier afin de l’utiliser via un bot.  Aucune connaissance en programmation n’est nécessaire pour créer un service.  

![img1][img1]
 
Voyons comment en quelques étapes seulement, nous pouvons créer un chat bot intelligent avec QnA Maker.

# Créer le service

Pour créer votre service, rendez-vous sur https://qnamaker.ai/. Vous devez vous connecter avec votre compte Microsoft. Une fois sur le site, vous devez cliquer dans le menu sur « Create new service » et renseigner les informations. 

![img2][img2] 

Vous avez trois options pour le contenu de votre service :

1 - Vous pouvez directement importer le contenu d’une FAQ existante en ligne. Vous avez juste besoin de renseigner le lien vers cette FAQ, pour que QnA Maker puisse extraire son contenu et l’utiliser. Il faut toutefois que votre FAQ respecte un certain format.

2 - Vous pouvez également fournir des fichiers de FAQ au format .tsv, .pdf, .doc, .docx and .xlsx ou des manuels de produit au format .pdf. Ceux-ci doivent également respecter un certain formatage. Pour notre test, nous allons utiliser le fichier PoutineFAQ.tsv. Vous devez donc le télécharger et l’uploader.

3 - Saisir soit même les questions/reponses.

# Créer sa base de connaissance.

Si vous avez importé des données d’une FAQ existante, la fenêtre « Knowledge Base » va vous permettre de passer en revue ce qui a été importé et apporter des modifications si besoin. 

![img3][img3]
 
# Entrainer son service

QnA Maker repose sur des algorithmes de programmation neurolinguistique (PNL). L’objectif est d’être en mesure de répondre avec le plus de précision possible à des questions, quelles que soient les tournures utilisées. Pour y parvenir, il est de votre responsabilité d’entrainer votre service.
QnA Maker offre une interface de chat qui va permettre à l’utilisateur de tester son service, évaluer les réponses retournées, apporter des corrections, ajouter les différentes questions possibles pour une réponse donnée, etc. Pour y accéder, vous devez simplement cliquer sur Test dans le menu vertical à gauche :

![img4][img4] 

L’espace numéro 1 est la fenêtre de chat. Lorsque vous allez saisir une question, la réponse correspondante sera affichée. L’espace No 2 va permettre de saisir les questions alternatives pour cette réponse. Si QnA Maker trouve plusieurs réponses pour une question, les autres propositions de réponses seront affichées dans l’espace No 3. Si la réponse affichée dans la fenêtre de chat ne correspond pas, vous pouvez sélectionner la bonne réponse dans cette zone.

Une fois les tests achevés, cliquez sur « Save and retrain », pour que QnA Maker applique ses algorithmes de machines learning pour entrainer votre service et améliorer sa précision.
Gardez à l’esprit que vous devez entrainer votre service chaque fois que vous effectuez des modifications.

# Publier le service

Une fois que vous êtes satisfait des résultats suite à l’entrainement de votre service, vous devez le publier. La publication de votre service va permettre son déploiement en production. À partir de ce moment, toutes les modifications seront désormais accessibles aux clients qui utilisent le service.

La publication se fait en cliquant simplement  sur le bouton Publish. Vous aurez une fenêtre permettant de passer en revue les modifications. La ligne Editorial présente les questions/réponses qui ont été ajoutées suite au test et à l’entrainement de votre service. 
 
![img5][img5]

Vous devez cliquer sur Publish pour démarrer le déploiement du service.  Une fois le service déployé, vous aurez une page de confirmation et les informations essentielles pour appeler votre service à partir du bot.

![img6][img6] 

Ce que nous allons conserver et que nous allons utiliser plus tard dans notre bot est l’ApplicationId (dans la zone No 1) et la SubscriptionKey (dans la zone No 2).

# Création du bot

Nous allons maintenant créer notre bot et utiliser le service que nous venons de mettre en place. Rendez-vous dans le portail Azure pour créer le bot.

Vous allez cliquer sur créer une nouvelle ressource. Vous allez sélectionner « AI + Cognitive
Services », ensuite « Web App Bot ».

Le formulaire de création du Bot va s’afficher. Remplissez les informations. 

Vous devez cliquer sur le champ Bot template, ensuite sélectionner le template « Question and Answer » dans la liste des modèles de bot.

![img7][img7]  

Cliquez ensuite sur Select et enfin sur Create. Azure va procéder à la création et au déploiement des ressources nécessaires au fonctionnement de votre bot. 

Une fois que vous aurez la notification annonçant la fin du déploiement, cliquez sur le bouton pour épingler la nouvelle ressource sur votre tableau de bord et cliquez ensuite sur le bouton pour afficher la ressource.

# Configuration du bot pour se connecter au service QnA Maker.

Si vous accédez à la fenêtre de chat permettant de tester votre bot, vous serez invité à configurer le bot pour se connecter à QnA Maker.

![img8][img8] 
 
Pour cela, vous devez modifier les paramètres de configuration de votre application. Il s’agit plus précisément des paramètres QnAKnowledgebaseId et QnASubscriptionKey.

Pour modifier ces paramètres, vous allez saisir dans la fenêtre de recherche au-dessus du menu vertical à gauche « App », ensuite sélectionner Application Settings. Vous allez scroller vers le bas pour retrouver les champs QnAKnowledgebaseId et QnASubscriptionKey.

![img9][img9]  

Vous devez copier et coller les informations précédentes dans les champs correspondants. 
 
Cliquez ensuite sur enregistrer pour que les modifications soient prises en compte.

![img10][img10] 

Une fois votre application mise à jour, revenez dans l’interface de chat et testez votre bot :

![img11][img11]  

C’est aussi simple que ça l’intégration de QnA Maker avec un bot.

Nous allons jeter un coup d’œil au code du bot. Accédez à l’éditeur de code en ligne pour votre bot. Ouvrez le fichier BasicQnAMakerDialog.cs. Il se trouve dans le dossier Dialogs.

Voici le code permettant d’appeler votre service QnA Maker.

```cs
// For more information about this template visit http://aka.ms/azurebots-csharp-qnamaker
    [Serializable]
    public class BasicQnAMakerDialog : QnAMakerDialog
    {
        // Go to https://qnamaker.ai and feed data, train & publish your QnA Knowledgebase.        
        // Parameters to QnAMakerService are:
        // Required: subscriptionKey, knowledgebaseId, 
        // Optional: defaultMessage, scoreThreshold[Range 0.0 – 1.0]
        public BasicQnAMakerDialog() : base(new QnAMakerService(new QnAMakerAttribute(Utils.GetAppSetting("QnASubscriptionKey"), Utils.GetAppSetting("QnAKnowledgebaseId"), "No good match in FAQ.", 0.5)))
        {}
    
    }
```


Conclusion

Vous venez de mettre en place un service QnA Maker et l’utiliser dans votre bot. Avec ce service il est assez simple de mettre en place un agent conversationnel capable de répondre aux questions des utilisateurs.


# Fin

[img1]: Media/img1.png
[img2]: Media/img2.PNG
[img3]: Media/img3.PNG
[img4]: Media/img4.PNG
[img5]: Media/img5.PNG
[img6]: Media/img6.PNG
[img7]: Media/img7.png
[img8]: Media/img8.png
[img9]: Media/img9.png
[img10]: Media/img10.png
[img11]: Media/img11.png
