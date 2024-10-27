using APIVisionary.Dto.Conteudo;
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

        public async Task<ResponseModel<List<ConteudoModel>>> ListarConteudo()
        {
            var conteudo = await _ConteudoInterface.ListarConteudo();
            return conteudo;
        }

        [HttpGet("BuscarConteudoNome")]
        public async Task<ResponseModel<ConteudoModel>> BuscarConteudoNome(string Titulo)
        {
            var conteudo = await _ConteudoInterface.BuscarConteudoNome(Titulo);
            return conteudo;
        }

        [HttpGet("BuscarConteudoID/{IDConteudo}")]
        public async Task<ResponseModel<ConteudoModel>> BuscarConteudoID(int IDConteudo)
        {
            var conteudo = await _ConteudoInterface.BuscarConteudoID(IDConteudo);
            return conteudo;
        }

        [HttpGet("BuscarConteudoPorIDUsuario/{IDUsuario}")]
        public async Task<ResponseModel<List<ConteudoModel>>> BuscarConteudoPorIDUsuario(int IDUsuario)
        {
            var conteudo = await _ConteudoInterface.BuscarConteudoPorIDUsuario(IDUsuario);
            return conteudo;
        }

        [HttpPost("CriarConteudo")]
        public async Task<ResponseModel<List<ConteudoModel>>> CriarConteudo(ConteudoCriacaoDto conteudoCriacaoDto)
        {
            var conteudo = await _ConteudoInterface.CriarConteudo(conteudoCriacaoDto);
            return conteudo;
        }

        [HttpDelete("ExcluirConteudo/{UsuarioID}")]
        public async Task<ActionResult<ResponseModel<List<ConteudoModel>>>> ExcluirConteudo(int UsuarioID)
        {
            var Conteudo = await _ConteudoInterface.ExcluirConteudo(UsuarioID);
            return Ok(Conteudo);
        }



    }
}
