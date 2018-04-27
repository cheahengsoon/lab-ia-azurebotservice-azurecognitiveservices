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

QnA Maker offre une interface graphique permettant de créer son service, le peupler avec des Questions/Réponses, l’entrainer en exploitant les services de machine learning de Microsoft et le publier afin de l’utiliser via un bot.  Aucune connaissance en programmation n’est nécessaire pour créer un service.  

![img1][img1]
 
Voyons comment en quelques étapes seulement, nous pouvons créer un chat bot intelligent avec QnA Maker.

# Créer le service

Pour créer votre service, rendez-vous sur https://qnamaker.ai/. Vous devez vous connecter avec votre compte Microsoft. Une fois sur le site, vous devez cliquer dans le menu sur « Create new service » et renseigner les informations. 

![img2][img2] 

Vous avez trois options pour le contenu de votre service :

1 - Vous pouvez directement importer le contenu d’une FAQ existante en ligne. Vous avez juste besoin de renseigner le lien vers cette FAQ, pour que QnA Maker puisse extraire son contenu et l’utiliser. Il faut toutefois que votre FAQ respecte un certain format.

2 - Vous pouvez également fournir des fichiers de FAQ au format .tsv, .pdf, .doc, .docx and .xlsx ou des manuels de produit au format .pdf. Ceux-ci doivent également respecter un certain formatage. Pour notre test, nous allons utiliser le fichier PoutineFAQ.tsv. Vous devez donc le télécharger et l’uploader.

3 - Saisir soit même les questions/reponses

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

#Publier le service

Une fois que vous êtes satisfait des résultats suite à l’entrainement de votre service, vous devez le publier. La publication de votre service va permettre son déploiement en production. À partir de ce moment, toutes les modifications seront désormais accessibles aux clients qui utilisent le service.

La publication se fait en cliquant simplement  sur le bouton Publish. Vous aurez une fenêtre permettant de passer en revue les modifications. La ligne Editorial présente les questions/réponses qui ont été ajoutées suite au test et à l’entrainement de votre service. 
 
![img5][img5]

Vous devez cliquer sur Publish pour démarrer le déploiement du service.  Une fois le service déployé, vous aurez une page de confirmation et les informations essentielles pour appeler votre service à partir du bot.

![img6][img6] 

Ce que nous allons conserver et que nous allons utiliser plus tard dans notre bot est l’ApplicationId (dans la zone No 1) et la SubscriptionKey (dans la zone No 2).

# Fin

[img1]: Media/img1.png
[img2]: Media/img2.png
[img3]: Media/img3.png
[img4]: Media/img4.png
[img5]: Media/img5.png
[img6]: Media/img6.png
[img7]: Media/img7.png
[img8]: Media/img8.png