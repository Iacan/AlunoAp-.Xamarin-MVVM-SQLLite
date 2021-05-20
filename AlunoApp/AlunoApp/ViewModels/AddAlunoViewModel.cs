using AlunoApp.Models;
using AlunoApp.Services;
using AlunoApp.Validator;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AlunoApp.ViewModels
{
    public class AddAlunoViewModel : BaseAlunoViewModel
    {
        public ICommand AddAlunoCommand { get; private set; }
        public ICommand ViewAllAlunosCommand { get; private set; }

        public AddAlunoViewModel()
        {
            _AlunoValidator = new AlunoValidator();
            _Aluno = new Aluno();
            _AlunoRepository = new AlunoRepository();

            AddAlunoCommand = new Command(async () => await AddAluno());
            ViewAllAlunosCommand = new Command(async () => await ExibirAlunoLista());
        }

        async Task AddAluno()
        {
            var resultadoValidacao = _AlunoValidator.Validate(_Aluno);

            if (resultadoValidacao.IsValid)
            {
                bool respostaUsuario = await _messageService.ShowAsyncBool("Adicionar Aluno","Deseja salvar os detalhes do Aluno?", "OK", "Cancela");
                if (respostaUsuario)
                {
                    _AlunoRepository.InsertAluno(_Aluno);
                    await _navigationService.NavigateToAlunoLista();
                }
            }
            else
            {
                await _messageService.ShowAsync("Adicionar Aluno", resultadoValidacao.Errors[0].ErrorMessage, "OK");
            }
        }

        async Task ExibirAlunoLista()
        {
            await _navigationService.NavigateToAlunoLista();
        }

        public bool IsViewAll => _AlunoRepository.GetAllAlunosData().Count > 0 ? true : false;
    }
}
