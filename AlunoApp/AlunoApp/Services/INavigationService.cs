using System.Threading.Tasks;

namespace AlunoApp.Services
{
    public interface INavigationService 
    {
        Task NavigateToAddAluno();
        Task NavigateToDetailsPage(int ID);
        Task NavigateToAlunoLista();
        void PopAsyncService();
    }
}
