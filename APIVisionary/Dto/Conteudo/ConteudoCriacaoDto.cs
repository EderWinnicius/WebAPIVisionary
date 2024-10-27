using APIVisionary.Models;

namespace APIVisionary.Dto.Conteudo
{
    public class ConteudoCriacaoDto
    {
        public string TituloVideo { get; set; }
        public string DescricaoVideo { get; set; }
        public int Autor { get; set; }
        public int PlaylistId { get; set; }

    }
}
