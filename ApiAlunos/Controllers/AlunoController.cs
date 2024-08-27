using ApiAlunos.Model;
using ApiAlunos.Service.AlunoService;
using Microsoft.AspNetCore.Mvc;

namespace ApiAlunos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : Controller
    {
        private readonly IAluno _alunoInterface;

        public AlunoController(IAluno alunoInterface)
        {
            _alunoInterface = alunoInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<AlunoModel>>>> GetAlunos()
        {
            return Ok(await _alunoInterface.GetAlunos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<List<AlunoModel>>>> GetAlunoById(int id)
        {
            return Ok(await _alunoInterface.GetAlunoById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<AlunoModel>>>> CreateAluno(AlunoModel novoAluno)
        {
            return Ok(await _alunoInterface.CreateAluno(novoAluno));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<AlunoModel>>>> UpdateAluno(AlunoModel alunoEditado)
        {
            return Ok(await _alunoInterface.UpdateAluno(alunoEditado));
        }
    }
}
