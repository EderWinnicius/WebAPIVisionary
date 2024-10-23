using APIVisionary.Dto.Usuario;
using APIVisionary.Models;

namespace APIVisionary.Services.Usuario
{
    public interface UsuarioInterface
    {
        Task<ResponseModel<List<UsuariosModel>>> ListarUsuarios();
        Task<ResponseModel<UsuariosModel>> BuscarUsuarioNome(string Nome);
        Task<ResponseModel<UsuariosModel>> BuscarUsuarioID(int IDUsuario);
        Task<ResponseModel<UsuariosModel>> BuscarUsuariosVideos(string TituloVideo);

        Task<ResponseModel<List<UsuariosModel>>> CriarUsuario(UsuarioCreateDto usuarioCreateDto);

        Task<ResponseModel<List<UsuariosModel>>> EditarUsuario(EditarUsuarioDto editarUsuarioDto);

        Task<ResponseModel<List<UsuariosModel>>> ExcluirAutor(int IDUsuario);
    }
}
