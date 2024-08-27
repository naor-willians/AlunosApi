using ApiAlunos.Model;

namespace ApiAlunos.Service.AlunoService
{
    public interface IAluno
    {
        Task<ServiceResponse<List<AlunoModel>>> GetAlunos();

        Task<ServiceResponse<List<AlunoModel>>> CreateAluno(AlunoModel aluno);

        Task<ServiceResponse<List<AlunoModel>>> UpdateAluno(AlunoModel aluno);

        Task<ServiceResponse<AlunoModel>> GetAlunoById(int id);

        Task<ServiceResponse<List<AlunoModel>>> DeleteAluno(AlunoModel aluno);

        
    }
}
