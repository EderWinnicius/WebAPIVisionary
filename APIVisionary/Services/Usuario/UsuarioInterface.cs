using APIVisionary.Models;

namespace APIVisionary.Services.Usuario
{
    public interface UsuarioInterface
    {
        Task<ResponseModel<List<UsuariosModel>>> ListarUsuarios();
        Task<ResponseModel<UsuariosModel>> BuscarUsuarioNome(string Nome);
        Task<ResponseModel<UsuariosModel>> BuscarUsuarioID(int IDUsuario);
        Task<ResponseModel<UsuariosModel>> BuscarUsuariosVideos(string TituloVideo);
    }
}
