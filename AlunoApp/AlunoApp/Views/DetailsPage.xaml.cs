using AlunoApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AlunoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailsPage : ContentPage
	{
		public DetailsPage (int AlunoID)
		{
			InitializeComponent ();
            this.BindingContext = new DetailsViewModel(AlunoID);
        }
	}
}