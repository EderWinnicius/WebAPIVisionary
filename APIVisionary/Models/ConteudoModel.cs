using System.Text.Json.Serialization;

namespace APIVisionary.Models
{
    public class ConteudoModel
    {
        public int Id { get; set; }
        public string TituloVideo { get; set; }
        public string DescricaoVideo { get; set; }
        public DateTime PostDate { get; set; } = DateTime.Now;
        public UsuariosModel Autor { get; set; }

        [JsonIgnore]
        public ICollection<PlaylistItem> PlaylistItems { get; set; }
    }
}
