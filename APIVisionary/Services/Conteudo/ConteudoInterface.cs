using APIVisionary.Dto.Conteudo;
using APIVisionary.Dto.Usuario;
using APIVisionary.Models;

namespace APIVisionary.Services.Conteudo
{
    public interface ConteudoInterface
    {
        Task<ResponseModel<List<ConteudoModel>>> ListarConteudo();
        Task<ResponseModel<ConteudoModel>> BuscarConteudoNome(string Titulo);
        Task<ResponseModel<ConteudoModel>> BuscarConteudoID(int IDConteudo);
        Task<ResponseModel<List<ConteudoModel>>> BuscarConteudoPorIDUsuario(int IDUsuario);

        Task<ResponseModel<List<ConteudoModel>>> CriarConteudo(ConteudoCriacaoDto conteudoCriacaoDto);

        Task<ResponseModel<List<ConteudoModel>>> EditarConteudo(EditarConteudoDto editarConteudoDto);

        Task<ResponseModel<List<ConteudoModel>>> ExcluirConteudo(int IDConteudo);
    }
}
