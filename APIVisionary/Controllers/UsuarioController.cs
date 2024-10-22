using APIVisionary.Models;
using APIVisionary.Services.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace APIVisionary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioInterface _usuarioInterface;
        public UsuarioController(UsuarioInterface usuarioInterface)
        {
            _usuarioInterface = usuarioInterface;
        }

        [HttpGet("ListarUsuarios")]
        public async Task<ActionResult<ResponseModel<List<UsuariosModel>>>> ListarUsuarios()
        {
            var usuarios = await _usuarioInterface.ListarUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("BuscarUsuarioNome/{NameUser}")]
        public async Task<ActionResult<ResponseModel<UsuariosModel>>> BuscarUsuarioNome(string NameUser)
        {
            var usuario = await _usuarioInterface.BuscarUsuarioNome(NameUser);
            return Ok(usuario);
        }

        [HttpGet("BuscarUsuarioID/{IDUsuario}")]
        public async Task<ActionResult<ResponseModel<UsuariosModel>>> BuscarUsuarioID(int IDUsuario)
        {
            var usuario = await _usuarioInterface.BuscarUsuarioID(IDUsuario);
            return Ok(usuario);
        }

        [HttpGet("BuscarUsuariosVideos/{TituloVideo}")]
        public async Task<ActionResult<ResponseModel<UsuariosModel>>> BuscarUsuariosVideos(string TituloVideo)
        {
            var usuario = await _usuarioInterface.BuscarUsuariosVideos(TituloVideo);
            return Ok(usuario);
        }



    }
}
