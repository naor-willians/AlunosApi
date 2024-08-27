using ApiAlunos.Enum;

namespace ApiAlunos.Model
{
    public class AlunoModel
    {
        public int id { get; set; }

        public string nome { get; set; }

        public string curso { get; set; }

        public TurnoEnum turno { get; set; }

        public SemestreEnum semestre { get; set; }
    }
}
