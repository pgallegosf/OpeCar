namespace OpeCar.BusinessEntities.Seguridad
{
    public class UserDto
    {
        public int? IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string NombreCompleto { get; set; }
        public string Token { get; set; }
        public string Compania { get; set; }
        public string Correo { get; set; }
    }
}
