using APIVisionary.Dto.Conteudo;
using APIVisionary.Dto.Usuario;
using APIVisionary.Models;
using APIVisionary.Services.Conteudo;
using APIVisionary.Services.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIVisionary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConteudoController : ControllerBase
    {
        private readonly ConteudoInterface _ConteudoInterface;

        public ConteudoController(ConteudoInterface conteudoInterface)
        {
            _ConteudoInterface = conteudoInterface;
        }

        [HttpGet("ListarConteudo")]

        public async Task<ActionResult<ResponseModel<List<ConteudoModel>>>> ListarConteudo()
        {
            var conteudo = await _ConteudoInterface.ListarConteudo();
            return conteudo;
        }

        [HttpGet("BuscarConteudoNome")]
        public async Task<ActionResult<ResponseModel<ConteudoModel>>> BuscarConteudoNome(string Titulo)
        {
            var conteudo = await _ConteudoInterface.BuscarConteudoNome(Titulo);
            return conteudo;
        }

        [HttpGet("BuscarConteudoID/{IDConteudo}")]
        public async Task<ActionResult<ResponseModel<ConteudoModel>>> BuscarConteudoID(int IDConteudo)
        {
            var conteudo = await _ConteudoInterface.BuscarConteudoID(IDConteudo);
            return conteudo;
        }

        [HttpGet("BuscarConteudoPorIDUsuario/{IDUsuario}")]
        public async Task<ActionResult<ResponseModel<List<ConteudoModel>>>> BuscarConteudoPorIDUsuario(int IDUsuario)
        {
            var conteudo = await _ConteudoInterface.BuscarConteudoPorIDUsuario(IDUsuario);
            return conteudo;
        }

        [HttpPost("CriarConteudo")]
        public async Task<ActionResult<ResponseModel<List<ConteudoModel>>>> CriarConteudo(ConteudoCriacaoDto conteudoCriacaoDto)
        {
            var conteudo = await _ConteudoInterface.CriarConteudo(conteudoCriacaoDto);
            return conteudo;
        }

        [HttpPut("EditarConteudo")]
        public async Task<ActionResult<ResponseModel<List<ConteudoModel>>>> EditarConteudo(EditarConteudoDto editarConteudoDto)
        {
            var Conteudo = await _ConteudoInterface.EditarConteudo(editarConteudoDto);
            return Ok(Conteudo);
        }

        [HttpDelete("ExcluirConteudo/{ConteudoID}")]
        public async Task<ActionResult<ResponseModel<List<ConteudoModel>>>> ExcluirConteudo(int ConteudoID)
        {
            var Conteudo = await _ConteudoInterface.ExcluirConteudo(ConteudoID);
            return Ok(Conteudo);
        }

        

    }
}
