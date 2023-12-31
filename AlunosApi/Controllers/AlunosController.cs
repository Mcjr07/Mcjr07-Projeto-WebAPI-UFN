using AlunosApi.Models;
using AlunosApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlunosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private IAlunoService _alunoService;

        public AlunosController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }
        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAlunos() 
        {
            try
            {
                var alunos = await _alunoService.GetAlunos();
                return Ok(alunos);
            }
            catch 
            {
                //return BadRequest("Request inválido");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error ao obter alunos");
            }
        }

        [HttpGet("AlunoPorNome")]
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAlunosByName([FromQuery] string nome)
        {
            try
            {
                var alunos = await _alunoService.GetAlunosByNome(nome);

                if (alunos.Count() == 0)
                    return NotFound($"Não Existem alunos com o critério{nome}");
                
                return Ok(alunos);
            }
            catch
            {
                //return BadRequest("Request inválido");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error ao obter alunos");
            }
        }

        [HttpGet("{id:int}", Name="GetAluno")]
        public async Task<ActionResult<Aluno>> GetAluno(int id) 
        {
            try
            {
                var aluno = await _alunoService.GetAluno(id);

                if (aluno == null)
                    return NotFound($"Não Existe aluno com esse ID = {id}");

                return Ok(aluno);
            }
            catch
            {
                //return BadRequest("Request inválido");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error ao obter ID do aluno");
            }
        }
       
        [HttpPost]
        public async Task<ActionResult> Greate(Aluno aluno) 
        {
            try
            {
                await _alunoService.CreateAluno(aluno);
                return CreatedAtRoute(nameof(GetAluno), new { id = aluno.Id }, aluno);
            }
            catch
            {
                return BadRequest("Request inválido");
                
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult>Edit(int id,[FromBody] Aluno aluno) 
        {
            try
            {
               if (aluno.Id == id)
               {
                    await _alunoService.UpdateAluno(aluno);
                    return Ok($"Aluno do id = {id} foi atualizado com sucesso");
               }
                else 
                { 
                    return BadRequest("Dados inconsistentes");
                }
            }
            catch
            {
                return BadRequest("Request inválido");

            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult>Delete(int id)
        {
            try
            {
                var aluno = await _alunoService.GetAluno(id);
                if (aluno!= null)
                {
                    await _alunoService.DeleteAluno(aluno);
                    return Ok($"Aluno do id {id} foi excluido com sucesso!");
                }
                else
                {
                  return NotFound($"Aluno do id {id} não foi encontrado!");
                }
            }
            catch
            {
                return BadRequest("Request inválido");

            }
        }




    }
}
