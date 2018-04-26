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