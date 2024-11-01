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
        private readonly PlaylistInterface _PlaylistService;

        public PlaylistController(PlaylistInterface playlistService)
        {
            _PlaylistService = playlistService;
        }

        [HttpGet("ListarPlaylist")]
        public async Task<ActionResult<ResponseModel<List<PlaylistVideos>>>> ListarPlaylist()
        {
            var Playlist = await _PlaylistService.ListarPlaylist();
            return Playlist;
        }

        [HttpGet("BuscarPlaylistID/{IDPlaylist}")]
        public async Task<ActionResult<ResponseModel<PlaylistVideos>>> BuscarPlaylistID(int IDPlaylist)
        {
            var Playlist = await _PlaylistService.BuscarPlaylistID(IDPlaylist);
            return Playlist;
        }

        [HttpGet("BuscarPlaylistNome")]
        public async Task<ActionResult<ResponseModel<PlaylistVideos>>> BuscarPlaylistNome(string NomePlaylist)
        {
            var Playlist = await _PlaylistService.BuscarPlaylistNome(NomePlaylist);
            return Playlist;
        }

        [HttpGet("BuscarPlaylistPorIDUsuario/{IDUsuario}")]
        public async Task<ActionResult<ResponseModel<List<PlaylistVideos>>>> BuscarPlaylistPorIDUsuario(int IDUsuario)
        {
            var Playlist = await _PlaylistService.BuscarPlaylistPorIDUsuario(IDUsuario);
            return Playlist;
        }

        [HttpPost("CriarPlaylist")]
        public async Task<ActionResult<ResponseModel<List<PlaylistVideos>>>> CriarPlaylist(CriarPlaylistDto criarPlaylistDto)
        {
            var Playlist = await _PlaylistService.CriarPlaylist(criarPlaylistDto);
            return Playlist;
        }

        [HttpPut("EditarPlaylist")]
        public async Task<ActionResult<ResponseModel<List<PlaylistVideos>>>> EditarPlaylist(EditarPlaylistDto editarPlaylistDto)
        {
            var Playlist = await _PlaylistService.EditarPlaylist(editarPlaylistDto);
            return Playlist;
        }


        [HttpDelete("ExcluirPlaylist/{PlaylistID}")]
        public async Task<ActionResult<ResponseModel<List<PlaylistVideos>>>> ExcluirPlaylist(int IDPlaylist)
        {
            var Playlist = await _PlaylistService.ExcluirPlaylist(IDPlaylist);
            return Playlist;
        }





    }
}
