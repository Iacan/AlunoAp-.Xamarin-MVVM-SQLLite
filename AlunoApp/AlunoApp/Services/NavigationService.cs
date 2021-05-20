using AlunoApp.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AlunoApp.Services
{
    public class NavigationService : INavigationService
    {
        public async Task NavigateToAddAluno()
        {
            await AlunoApp.App.Current.MainPage.Navigation.PushAsync(new AddAluno());
        }

        public async Task NavigateToDetailsPage(int ID)
        {
            await AlunoApp.App.Current.MainPage.Navigation.PushAsync(new DetailsPage(ID));
        }

        public async Task NavigateToAlunoLista()
        {
            await AlunoApp.App.Current.MainPage.Navigation.PushAsync(new AlunoLista());
        }

        public async void PopAsyncService()
        {
            await AlunoApp.App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
