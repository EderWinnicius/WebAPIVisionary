using System.ComponentModel.DataAnnotations.Schema;

namespace APIVisionary.Models
{
    public class PlaylistItem
    {
        public int Id { get; set; }

        [ForeignKey("ConteudoId")]
        public int ConteudoIdId { get; set; }

        [ForeignKey("PlaylistId")]
        public int PlaylistIdId { get; set; }
    }
}
