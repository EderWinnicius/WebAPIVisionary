using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIVisionary.Models
{
    [PrimaryKey("ConteudoId", "PlaylistId")]
    public class PlaylistItem
    {

        [ForeignKey("ConteudoId")]
        public int ConteudoId { get; set; }

        [ForeignKey("PlaylistId")]
        public int PlaylistId { get; set; }
    }
}
