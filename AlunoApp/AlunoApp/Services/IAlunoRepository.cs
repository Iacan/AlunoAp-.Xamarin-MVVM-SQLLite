using AlunoApp.Models;
using System.Collections.Generic;

namespace AlunoApp.Services
{
    public interface IAlunoRepository
    {
        List<Aluno> GetAllAlunosData();

        //Obtem um dado especifico por id
        Aluno GetAlunoData(int AlunoID);

        // deleta todos os dados
        void DeleteAllAlunos();

        // Deleta um dado especifico
        void DeleteAluno(int AlunoID);

        // Insere um novo dado no BD
        void InsertAluno(Aluno Aluno);

        // Atualiza os dados
        void UpdateAluno(Aluno Aluno);
    }
}
