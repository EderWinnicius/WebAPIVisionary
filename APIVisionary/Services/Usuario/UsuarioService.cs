using APIVisionary.Data;
using APIVisionary.Models;
using Microsoft.EntityFrameworkCore;

namespace APIVisionary.Services.Usuario
{
    public class UsuarioService : UsuarioInterface
    {
        private readonly ApplicationDbContext _context;
        public UsuarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<UsuariosModel>> BuscarUsuarioNome(string Nome)
        {
            ResponseModel<UsuariosModel> resposta = new ResponseModel<UsuariosModel>();
            try
            {
                var Usuario = await _context.UsuariosTableContent.FirstOrDefaultAsync(UsuarioBanco => UsuarioBanco.NameUser == Nome);
                if (Usuario == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado";
                    return resposta;
                }
                resposta.Dados = Usuario;
                resposta.Mensagem = "Usuário encontrado";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<UsuariosModel>> BuscarUsuarioID(int IDUsuario)
        {
            ResponseModel<UsuariosModel> resposta = new ResponseModel<UsuariosModel>();

            try
            {
                var Usuario = await _context.UsuariosTableContent.FirstOrDefaultAsync(UsuarioBanco => UsuarioBanco.Id == IDUsuario);
                if (Usuario == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado";
                    return resposta;
                }
                resposta.Dados = Usuario;
                resposta.Mensagem = "Usuário encontrado";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public Task<ResponseModel<UsuariosModel>> BuscarUsuariosVideos(string TituloVideo)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<UsuariosModel>>> ListarUsuarios()
        {
            ResponseModel<List<UsuariosModel>> resposta = new ResponseModel<List<UsuariosModel>>();

            try
            {

                var Usuarios = await _context.UsuariosTableContent.ToListAsync();

                resposta.Dados = Usuarios;
                resposta.Mensagem = "Todos os Usuários encontrados";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
