namespace APIVisionary.Models
{
    public class ConteudoModel
    {
        public int Id { get; set; }
        public string TituloVideo { get; set; }
        public string DescricaoVideo { get; set; }
        public DateTime PostDate { get; set; } = DateTime.Now;
        public string CategoriaVideo { get; set; }
        public UsuariosModel Autor { get; set; }
    }
}
