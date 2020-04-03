namespace BibliotecaSebasez.Models
{
    public class Libro : Entity
    {
        public string NombreLibro { get; set; }
        public string ISBN { get; set; }
        //Referencia a autor
        public int AutorId { get; set; }
        public Autor Autor { get; set; }
        //Referencia a Categoria
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
