using AlunoApp.Models;
using AlunoApp.Services;
using AlunoApp.Validator;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AlunoApp.ViewModels
{
    public class DetailsViewModel : BaseAlunoViewModel
    {
        public ICommand UpdateAlunoCommand { get; private set; }
        public ICommand DeleteAlunoCommand { get; private set; }

        public DetailsViewModel(int selectedAlunoID)
        {
            _AlunoValidator = new AlunoValidator();
            _Aluno = new Aluno();
            _Aluno.Id = selectedAlunoID;
            _AlunoRepository = new AlunoRepository();

            UpdateAlunoCommand = new Command(async () => await UpdateAluno());
            DeleteAlunoCommand = new Command(async () => await DeleteAluno());

            EncontrarDetalhesDoAluno();
        }

        void EncontrarDetalhesDoAluno()
        {
            _Aluno = _AlunoRepository.GetAlunoData(_Aluno.Id);
        }

        async Task UpdateAluno()
        {
            var resultadoValidacao = _AlunoValidator.Validate(_Aluno);

            if (resultadoValidacao.IsValid)
            {
                bool isUserAccept = await _messageService.ShowAsyncBool("Detalhes do Aluno", "Atualiza detalhes do Aluno ?", "OK", "Cancelar");
                if (isUserAccept)
                {
                    _AlunoRepository.UpdateAluno(_Aluno);
                    _navigationService.PopAsyncService();
                }
            }
            else
            {
                await _messageService.ShowAsync("Detalhes do Aluno", resultadoValidacao.Errors[0].ErrorMessage, "OK");
            }
        }

        async Task DeleteAluno()
        {
            bool respostaUsuario = await _messageService.ShowAsyncBool("Detalhes do Aluno", "Deletar detalhes do Aluno", "OK", "Cancelar");
            if (respostaUsuario)
            {
                _AlunoRepository.DeleteAluno(_Aluno.Id);
                _navigationService.PopAsyncService();
            }
        }
    }
}
