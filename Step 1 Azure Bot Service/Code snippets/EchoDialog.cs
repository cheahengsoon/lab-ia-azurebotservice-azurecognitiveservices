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