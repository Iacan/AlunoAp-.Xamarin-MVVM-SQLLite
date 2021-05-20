using FluentValidation;
using AlunoApp.Models;
using AlunoApp.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace AlunoApp.ViewModels
{
    public class BaseAlunoViewModel : INotifyPropertyChanged
    {
        public Aluno _Aluno;
        public IValidator _AlunoValidator;
        public IAlunoRepository _AlunoRepository;

        protected IMessageService _messageService;
        protected INavigationService _navigationService;

        public BaseAlunoViewModel()
        {
            _messageService = DependencyService.Get<IMessageService>();
            _navigationService = DependencyService.Get<INavigationService>();
        }

        public string Titulo
        {
            get => _Aluno.Titulo;
            set
            {
                _Aluno.Titulo = value;
                NotifyPropertyChanged(nameof(Titulo));
            }
        }

        public string Link
        {
            get => _Aluno.Link;
            set
            {
                _Aluno.Link = value;
                NotifyPropertyChanged(nameof(Link));
            }
        }

        public decimal RM
        {
            get => _Aluno.RM;
            set
            {
                _Aluno.RM = value;
                NotifyPropertyChanged(nameof(RM));
            }
        }

        public string Descricao
        {
            get => _Aluno.Descricao;
            set
            {
                _Aluno.Descricao = value;
                NotifyPropertyChanged(nameof(Descricao));
            }
        }

        List<Aluno> _AlunoLista;
        public List<Aluno> AlunoLista
        {
            get => _AlunoLista;
            set
            {
                _AlunoLista = value;
                NotifyPropertyChanged(nameof(AlunoLista));
            }
        }

        #region INotifyPropertyChanged      
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
