using System.Text.Json.Serialization;

namespace APIVisionary.Models
{
    public class PlaylistVideos
    {
        public int Id { get; set; }
        public string PlaylistTittle { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public UsuariosModel Creator { get; set; }

        [JsonIgnore]
        public ICollection<PlaylistItem> PlaylistItems { get; set; }
        public ICollection<ConteudoModel> VideosContidos { get; set; }
    }
}
