using AlunoApp.Helpers;
using AlunoApp.Models;
using System.Collections.Generic;

namespace AlunoApp.Services
{
    //implementa o repositorio
    public class AlunoRepository : IAlunoRepository
    {
        DatabaseHelper _databaseHelper;
        public AlunoRepository()
        {
            _databaseHelper = new DatabaseHelper();
        }

        public void DeleteAllAlunos()
        {
            _databaseHelper.DeleteAllAlunos();
        }

        public void DeleteAluno(int AlunoID)
        {
            _databaseHelper.DeleteAluno(AlunoID);
        }

        public List<Aluno> GetAllAlunosData()
        {
            return _databaseHelper.GetAllAlunosData();
        }

        public Aluno GetAlunoData(int AlunoID)
        {
            return _databaseHelper.GetAlunoData(AlunoID);
        }

        public void InsertAluno(Aluno Aluno)
        {
            _databaseHelper.InsertAluno(Aluno);
        }

        public void UpdateAluno(Aluno Aluno)
        {
            _databaseHelper.UpdateAluno(Aluno);
        }
    }
}
