using APIVisionary.Dto.Conteudo;
using APIVisionary.Dto.PlaylistVideos;
using APIVisionary.Models;

namespace APIVisionary.Services.Playlist
{
    public interface PlaylistInterface
    {

        Task<ResponseModel<List<PlaylistVideos>>> ListarPlaylist();

        Task<ResponseModel<PlaylistVideos>> BuscarPlaylistID(int IDPlaylist);

        Task<ResponseModel<PlaylistVideos>> BuscarPlaylistNome(string NomePlaylist);

        Task<ResponseModel<List<PlaylistVideos>>> BuscarPlaylistPorIDUsuario(int IDUsuario);

        Task<ResponseModel<List<PlaylistVideos>>> CriarPlaylist(CriarPlaylistDto criarPlaylistDto);

        Task<ResponseModel<List<PlaylistVideos>>> EditarPlaylist(EditarPlaylistDto editarPlaylistDto);

        Task<ResponseModel<List<PlaylistVideos>>> ExcluirPlaylist(int IDPlaylist);


    }
}
