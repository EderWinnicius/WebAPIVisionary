using APIVisionary.Models;

namespace APIVisionary.Dto.PlaylistVideos
{
    public class CriarPlaylistDto
    {
        public string PlaylistTittle { get; set; }
        public UsuariosModel Creator { get; set; }
    }
}
