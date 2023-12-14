using CadastroPessoaApi.Data;
using CadastroPessoaApi.Service;
using CadastroPessoaApi.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CadastroPessoaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        [HttpGet("GetAll")]
        public IEnumerable<PessoaViewModel> GetAll()
        {
            var service = new ServicePessoa();
            return service.GetAll();
        }
        [HttpGet("GetById/{PessoaId}")]
        public PessoaViewModel GetById(int PessoaId)
        {
            var service = new ServicePessoa();
            return service.GetById(PessoaId);
        }

        [HttpGet("GetFirstName/{PrimeiroNome}")]
        public PessoaViewModel GetFirstName(string PrimeiroNome)
        {
            var service = new ServicePessoa();
            return service.GetFirstName(PrimeiroNome);
        }
        [HttpPut("update/{PessoaId}/{PrimeiroNome}")]
        public void update(int PessoaId, string PrimeiroNome) 
        {
            var service = new Repository();
            service.update(PessoaId, PrimeiroNome);
        }
        [HttpPost("Create")]
        public IActionResult Create(PessoaViewModel pessoa) 
        {
            var service = new ServicePessoa();
            var resultado = service.Create(pessoa);

            var result = new
            {
                Sucess = true,
                Data = "Cadastro Realizado com Sucesso ",

            };

            return Ok(result);
        }
    }
}
