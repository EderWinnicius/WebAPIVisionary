using APIVisionary.Dto.PlaylistVideos;
using APIVisionary.Models;
using APIVisionary.Services.Playlist;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIVisionary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly PlaylistInterface _PlaylistRepository;

        public PlaylistController(PlaylistInterface playlistService)
        {
            _PlaylistRepository = playlistService;
        }

        [HttpGet("ListarPlaylist")]
        public async Task<ActionResult<ResponseModel<List<PlaylistVideos>>>> ListarPlaylist()
        {
            var Playlist = await _PlaylistRepository.ListarPlaylist();
            return Playlist;
        }

        [HttpGet("BuscarPlaylistID/{IDPlaylist}")]
        public async Task<ActionResult<ResponseModel<PlaylistVideos>>> BuscarPlaylistID(int IDPlaylist)
        {
            var Playlist = await _PlaylistRepository.BuscarPlaylistID(IDPlaylist);
            return Playlist;
        }

        [HttpGet("BuscarPlaylistNome")]
        public async Task<ActionResult<ResponseModel<PlaylistVideos>>> BuscarPlaylistNome(string NomePlaylist)
        {
            var Playlist = await _PlaylistRepository.BuscarPlaylistNome(NomePlaylist);
            return Playlist;
        }

        [HttpGet("BuscarPlaylistPorIDUsuario/{IDUsuario}")]
        public async Task<ActionResult<ResponseModel<List<PlaylistVideos>>>> BuscarPlaylistPorIDUsuario(int IDUsuario)
        {
            var Playlist = await _PlaylistRepository.BuscarPlaylistPorIDUsuario(IDUsuario);
            return Playlist;
        }

        [HttpPost("CriarPlaylist")]
        public async Task<ActionResult<ResponseModel<List<PlaylistVideos>>>> CriarPlaylist(CriarPlaylistDto criarPlaylistDto)
        {
            var Playlist = await _PlaylistRepository.CriarPlaylist(criarPlaylistDto);
            return Playlist;
        }

        [HttpPut("EditarPlaylist")]
        public async Task<ActionResult<ResponseModel<List<PlaylistVideos>>>> EditarPlaylist(EditarPlaylistDto editarPlaylistDto)
        {
            var Playlist = await _PlaylistRepository.EditarPlaylist(editarPlaylistDto);
            return Playlist;
        }


        [HttpDelete("ExcluirPlaylist/{PlaylistID}")]
        public async Task<ActionResult<ResponseModel<List<PlaylistVideos>>>> ExcluirPlaylist(int IDPlaylist)
        {
            var Playlist = await _PlaylistRepository.ExcluirPlaylist(IDPlaylist);
            return Playlist;
        }

        [HttpPost("AdicionarConteudo")]
        public async Task<ActionResult<ResponseModel<object>>> AdicionarConteudo(AdicionarVideoPlaylistDto adicionarVideoPlaylistDto)
        {
            var Playlist = await _PlaylistRepository.AdicionarConteudo(adicionarVideoPlaylistDto);
            return Playlist;
        }

        [HttpDelete("ExcluirConteudoPlaylist")]
        public async Task<ResponseModel<object>> ExcluirConteudo(AdicionarVideoPlaylistDto ExcluirVideoPlaylistDto)
        {
            var Playlist = await _PlaylistRepository.ExcluirConteudo(ExcluirVideoPlaylistDto);
            return Playlist;
        }






    }
}
