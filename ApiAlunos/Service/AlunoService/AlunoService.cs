using ApiAlunos.DataContext;
using ApiAlunos.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiAlunos.Service.AlunoService
{
    public class AlunoService : IAluno
    {
        private readonly ApplicationDbContext _context;
        public AlunoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<AlunoModel>>> CreateAluno(AlunoModel novoAluno)
        {
            ServiceResponse<List<AlunoModel>> serviceResponse = new ServiceResponse<List<AlunoModel>>();

            try
            {
                if(novoAluno == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Preencha os dados";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Alunos.Add(novoAluno);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Alunos.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public Task<ServiceResponse<List<AlunoModel>>> DeleteAluno(AlunoModel aluno)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<AlunoModel>> GetAlunoById(int id)
        {
            ServiceResponse<AlunoModel> serviceResponse = new ServiceResponse<AlunoModel>();

            try
            {
               AlunoModel aluno = _context.Alunos.FirstOrDefault(x => x.id == id);
               
                if(aluno == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Aluno não encontrado!";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = aluno;
            }
            catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<AlunoModel>>> GetAlunos()
        {
            ServiceResponse<List<AlunoModel>> serviceResponse = new ServiceResponse<List<AlunoModel>>();

            try
            {
                serviceResponse.Dados = _context.Alunos.ToList();

                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Dados não encontrados";
                }
            }
            catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<AlunoModel>>> UpdateAluno(AlunoModel alunoEditado)
        {
            ServiceResponse<List<AlunoModel>> serviceResponse = new ServiceResponse<List<AlunoModel>>();

            try
            {
                AlunoModel aluno = _context.Alunos.AsNoTracking().FirstOrDefault(x => x.id == alunoEditado.id);

                if(aluno == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informe os Dados";
                    serviceResponse.Sucesso = false;
                }

                _context.Alunos.Update(alunoEditado);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Alunos.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
    }
}
