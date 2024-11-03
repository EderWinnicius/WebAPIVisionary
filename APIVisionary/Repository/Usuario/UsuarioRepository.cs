using APIVisionary.Data;
using APIVisionary.Dto.Usuario;
using APIVisionary.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace APIVisionary.Services.Usuario
{
    public class UsuarioRepository : UsuarioInterface
    {
        private readonly ApplicationDbContext _context;
        public UsuarioRepository(ApplicationDbContext context)
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

        public async Task<ResponseModel<UsuariosModel>> BuscarUsuariosVideos(string TituloVideo)
        {
            ResponseModel<UsuariosModel> resposta = new ResponseModel<UsuariosModel>();

            try
            {
                var Conteudo = await _context.ConteudoTableContent
                    .Include(a => a.Autor)
                    .FirstOrDefaultAsync(ConteudoBanco => ConteudoBanco.TituloVideo == TituloVideo);
                if 
                    
                    (Conteudo == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado";
                    return resposta;
                }
                resposta.Dados = Conteudo.Autor;
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

        public async Task<ResponseModel<List<UsuariosModel>>> ListarUsuarios()
        {
            ResponseModel<List<UsuariosModel>> resposta = new ResponseModel<List<UsuariosModel>>();

            try
            {

                var Usuarios = await _context.UsuariosTableContent.Include(c => c.VideosPublicados).ToListAsync();

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

        public async Task<ResponseModel<List<UsuariosModel>>> CriarUsuario(UsuarioCreateDto usuarioCreateDto)
        {
            ResponseModel<List<UsuariosModel>> resposta = new ResponseModel<List<UsuariosModel>>();

                try
            {
                var usuario = new UsuariosModel()
                {
                    NameUser = usuarioCreateDto.NameUser,
                    EmailUser = usuarioCreateDto.EmailUser,
                    NascDate = usuarioCreateDto.NascDate,
                };

                _context.Add(usuario);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.UsuariosTableContent.ToListAsync();
                resposta.Mensagem = "Usuário Criado Com sucesso";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<UsuariosModel>>> EditarUsuario(EditarUsuarioDto editarUsuarioDto)
        {
            ResponseModel<List<UsuariosModel>> resposta = new ResponseModel<List<UsuariosModel>>();

            try
            {

                var usuario = await _context.UsuariosTableContent.FirstOrDefaultAsync(usuarioBanco => usuarioBanco.Id == editarUsuarioDto.Id);
                if (usuario == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado";
                    return resposta;
                }

                usuario.NameUser = editarUsuarioDto.NameUser;
                usuario.EmailUser = editarUsuarioDto.EmailUser;
                usuario.NascDate = editarUsuarioDto.NascDate;

                _context.Update(usuario);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.UsuariosTableContent.ToListAsync();
                resposta.Mensagem = "Usuario Editado com sucesso";
                return resposta;



            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }

        public async Task<ResponseModel<List<UsuariosModel>>> ExcluirAutor(int IDUsuario)
        {
            ResponseModel<List<UsuariosModel>> resposta = new ResponseModel<List<UsuariosModel>>();
            try
            {
                var usuario = await _context.UsuariosTableContent
                    .FirstOrDefaultAsync(usuarioBanco => usuarioBanco.Id == IDUsuario);

                if (usuario == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado";
                    return resposta;
                }

                _context.Remove(usuario);

                resposta.Mensagem = $"Usuario {usuario.NameUser} Excluido Permanentemente";
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.UsuariosTableContent.ToListAsync();
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
