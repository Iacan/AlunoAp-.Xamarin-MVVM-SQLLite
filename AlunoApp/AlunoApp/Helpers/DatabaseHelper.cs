using PCLExt.FileStorage;
using PCLExt.FileStorage.Folders;
using AlunoApp.Models;
using SQLite;
using System.Collections.Generic;
using System.Linq;

namespace AlunoApp.Helpers
{
    public class DatabaseHelper
    {
        //defina uma conexao e o  nome do banco de dados
        static SQLiteConnection sqliteconnection;
        public const string DbFileName = "AlunosDB.db";

        public DatabaseHelper()
        {
            //cria uma pasta base local para o dispositivo
            var pasta = new LocalRootFolder();
            //cria o arquivo
            var arquivo = pasta.CreateFile(DbFileName, CreationCollisionOption.OpenIfExists);
            //abre o BD
            sqliteconnection = new SQLiteConnection(arquivo.Path);
            //cria a tabela no BD
            sqliteconnection.CreateTable<Aluno>();
        }

        //Pegar todos os dados  
        public List<Aluno> GetAllAlunosData()
        {
            return (from data in sqliteconnection.Table<Aluno>()
                    select data).ToList();
        }

        //Pegar dados especifico por id
        public Aluno GetAlunoData(int id)
        {
            return sqliteconnection.Table<Aluno>().FirstOrDefault(t => t.Id == id);
        }

        // Deletar todos os dados
        public void DeleteAllAlunos()
        {
            sqliteconnection.DeleteAll<Aluno>();
        }

        // Deletar um dado especifico por id
        public void DeleteAluno(int id)
        {
            sqliteconnection.Delete<Aluno>(id);
        }

        // Inserir dados
        public void InsertAluno(Aluno Aluno)
        {
            sqliteconnection.Insert(Aluno);
        }

        // Atualizar dados
        public void UpdateAluno(Aluno Aluno)
        {
            sqliteconnection.Update(Aluno);
        }
    }
}
