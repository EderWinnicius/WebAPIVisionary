using APIVisionary.Data;
using APIVisionary.Dto.Conteudo;
using APIVisionary.Dto.PlaylistVideos;
using APIVisionary.Dto.Usuario;
using APIVisionary.Models;
using Microsoft.EntityFrameworkCore;

namespace APIVisionary.Services.Conteudo
{
    public class ConteudoService : ConteudoInterface
    {
        private readonly ApplicationDbContext _context;
        public ConteudoService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<ConteudoModel>> BuscarConteudoID(int IDConteudo)
        {
            ResponseModel<ConteudoModel> resposta = new ResponseModel<ConteudoModel>();

            try
            {
                var Conteudo = await _context.ConteudoTableContent.FirstOrDefaultAsync(ConteudoBanco => ConteudoBanco.Id == IDConteudo);
                if (Conteudo == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado";
                    return resposta;
                }
                resposta.Dados = Conteudo;
                resposta.Mensagem = "Conteudo encontrado";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<ConteudoModel>> BuscarConteudoNome(string Titulo)
        {
            ResponseModel<ConteudoModel> resposta = new ResponseModel<ConteudoModel>();
            try
            {
                var Conteudo = await _context.ConteudoTableContent.FirstOrDefaultAsync(ConteudoBanco => ConteudoBanco.TituloVideo == Titulo);
                if (Conteudo == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado";
                    return resposta;
                }
                resposta.Dados = Conteudo;
                resposta.Mensagem = "Conteudo encontrado";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ConteudoModel>>> BuscarConteudoPorIDUsuario(int IDUsuario)
        {
            ResponseModel<List<ConteudoModel>> resposta = new ResponseModel<List<ConteudoModel>>();

            try
            {
                var Conteudo = await _context.ConteudoTableContent
                    .Include(a => a.Autor).Where(ConteudoBanco => ConteudoBanco.Autor.Id == IDUsuario)
                    .ToListAsync();
                if

                    (Conteudo == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado";
                    return resposta;
                }
                resposta.Dados = Conteudo;
                resposta.Mensagem = "Conteudos Localizados";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ConteudoModel>>> CriarConteudo(ConteudoCriacaoDto conteudoCriacaoDto)
        {
            ResponseModel<List<ConteudoModel>> resposta = new ResponseModel<List<ConteudoModel>>();

            try
            {
                var Usuario = await _context.UsuariosTableContent.FirstOrDefaultAsync(UsuarioBanco => UsuarioBanco.Id == conteudoCriacaoDto.Autor);
                if (Usuario == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado";
                    return resposta;
                }

                var playlist = await _context.PlaylistItemsTableContent.FirstOrDefaultAsync(p => p.PlaylistIdId == conteudoCriacaoDto.PlaylistId);
                if (playlist == null)
                {
                    resposta.Mensagem = "Nenhuma playlist localizado";
                    return resposta;
                }




                var conteudo = new ConteudoModel()
                {
                    TituloVideo = conteudoCriacaoDto.TituloVideo,
                    DescricaoVideo = conteudoCriacaoDto.DescricaoVideo,
                    Autor = Usuario,
                    PlaylistItems = (ICollection<PlaylistItem>)playlist

                };

                _context.Add(conteudo);
                await _context.SaveChangesAsync();



                resposta.Dados = await _context.ConteudoTableContent.Include(a =>  a.Autor).ToListAsync();
                resposta.Mensagem = "Conteudo Criado Com sucesso";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ConteudoModel>>> EditarConteudo(EditarConteudoDto editarConteudoDto)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<ConteudoModel>>> ExcluirConteudo(int IDConteudo)
        {
            ResponseModel<List<ConteudoModel>> resposta = new ResponseModel<List<ConteudoModel>>();
            try
            {
                var conteudo = await _context.ConteudoTableContent
                    .FirstOrDefaultAsync(conteudoBanco => conteudoBanco.Id == IDConteudo);

                if (conteudo == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado";
                    return resposta;
                }

                _context.Remove(conteudo);

                resposta.Mensagem = $"Conteúdo {conteudo.TituloVideo} Excluido Permanentemente";
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.ConteudoTableContent.ToListAsync();
                return resposta;



            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ConteudoModel>>> ListarConteudo()
        {
            ResponseModel<List<ConteudoModel>> resposta = new ResponseModel<List<ConteudoModel>>();

            try
            {

                var Conteudo = await _context.ConteudoTableContent.ToListAsync();

                resposta.Dados = Conteudo;
                resposta.Mensagem = "Todos os Conteudos encontrados";

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
