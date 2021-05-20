using AlunoApp.Models;
using AlunoApp.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AlunoApp.ViewModels
{
    public class AlunoListaViewModel : BaseAlunoViewModel
    {
        public ICommand AddCommand { get; private set; }
        public ICommand DeleteAllAlunosCommand { get; private set; }

        public AlunoListaViewModel()
        {
            _AlunoRepository = new AlunoRepository();

            AddCommand = new Command(async () => await ExibirAddAluno());
            DeleteAllAlunosCommand = new Command(async () => await DeleteAllAlunos());

            EncontrarAlunos();
        }

        void EncontrarAlunos()
        {
            AlunoLista = _AlunoRepository.GetAllAlunosData();
        }

        async Task ExibirAddAluno()
        {
            await _navigationService.NavigateToAddAluno();
        }

        async Task DeleteAllAlunos()
        {
            bool respostaUsuario = await _messageService.ShowAsyncBool("Lista de Alunos", "Deletar todos os detalhes de Alunos ?", "OK", "Cancelar");
            if (respostaUsuario)
            {
                _AlunoRepository.DeleteAllAlunos();
                await _navigationService.NavigateToAddAluno();
            }
        }

        async void ExibirAlunoDetails(int selectedAlunoID)
        {
            await _navigationService.NavigateToDetailsPage(selectedAlunoID);
        }

        Aluno _selectedAlunoItem;
        public Aluno SelectedAlunoItem
        {
            get => _selectedAlunoItem;
            set
            {
                if (value != null)
                {
                    _selectedAlunoItem = value;
                    NotifyPropertyChanged("SelectedAlunoItem");
                    ExibirAlunoDetails(value.Id);
                }
            }
        }
    }
}
