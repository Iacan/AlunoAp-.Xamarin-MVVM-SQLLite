using System.Threading.Tasks;

namespace AlunoApp.Services
{
    public class MessageService : IMessageService
    {
        public async Task ShowAsync(string message)
        {
            await AlunoApp.App.Current.MainPage.DisplayAlert("Alunos",message,"Ok");
        }

        public async Task ShowAsync(string title, string message, string text)
        {
            await AlunoApp.App.Current.MainPage.DisplayAlert(title, message, text);
        }

        public async Task ShowAsync(string title, string message, string text1, string text2)
        {
            await AlunoApp.App.Current.MainPage.DisplayAlert(title, message, text1, text2);
        }

        public async Task<bool> ShowAsyncBool(string title, string message, string text1, string text2)
        {
            return await AlunoApp.App.Current.MainPage.DisplayAlert(title, message, text1, text2);
        }
    }
}
