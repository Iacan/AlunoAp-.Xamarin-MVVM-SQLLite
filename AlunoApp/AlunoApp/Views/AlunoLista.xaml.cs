using AlunoApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AlunoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AlunoLista : ContentPage
	{
		public AlunoLista ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            this.BindingContext = new AlunoListaViewModel();
        }
    }
}