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
            await context.PostAsync("J'ai detecté que vous voullez commander.");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Restaurant.Information")]
        public async Task RestaurantInformationIntent(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("J'ai detecté que vous voullez obtenir des informations sur notre restaurant.");
            context.Wait(MessageReceived);
        }
    
    }
}