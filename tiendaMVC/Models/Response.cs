namespace tiendaMVC.Models
{
    public class Response <T>
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public T Data { get; set; }
    }
}