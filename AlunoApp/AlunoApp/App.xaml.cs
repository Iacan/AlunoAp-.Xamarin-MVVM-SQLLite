using AlunoApp.Services;
using AlunoApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AlunoApp
{
    public partial class App : Application
	{
        IAlunoRepository _AlunoRepository;
        public App ()
		{
            InitializeComponent();

            //aplica a injeção de dependência nos serviços implementados
            DependencyService.Register<IMessageService, MessageService>();
            DependencyService.Register<INavigationService, NavigationService>();
            //cria uma instância do repositorio
            _AlunoRepository = new AlunoRepository();
            //invoca o evento 
            OnAppStart();
		}

        private void OnAppStart()
        {
            //obtem todos os dados 
            var getLocalDB = _AlunoRepository.GetAllAlunosData();

            //se existir dados então exibe a lista senão inclui dados
            if (getLocalDB.Count > 0)
            {
                MainPage = new NavigationPage(new AlunoLista());
            }
            else
            {
                MainPage = new NavigationPage(new AddAluno());
            }
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
