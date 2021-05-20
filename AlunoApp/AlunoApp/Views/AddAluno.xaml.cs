using AlunoApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AlunoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddAluno : ContentPage
	{
		public AddAluno ()
		{
			InitializeComponent ();
            BindingContext = new AddAlunoViewModel();
        }
	}
}