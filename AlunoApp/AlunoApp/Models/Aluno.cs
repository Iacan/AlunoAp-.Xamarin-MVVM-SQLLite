using SQLite;

namespace AlunoApp.Models
{
    [Table("Alunos")]
    public class Aluno
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public decimal RM { get; set; }
        public string Link { get; set; }
        public string Descricao { get; set; }
    }
}
