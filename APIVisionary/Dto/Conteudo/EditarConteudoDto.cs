using APIVisionary.Models;

namespace APIVisionary.Dto.Conteudo
{
    public class EditarConteudoDto
    {
        public int Id { get; set; }
        public string TituloVideo { get; set; }
        public string DescricaoVideo { get; set; }
        public ICollection<PlaylistItem> PlaylistItems { get; set; }
    }
}
