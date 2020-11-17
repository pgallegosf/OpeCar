namespace OpeCar.BusinessEntities.Restauracion
{
    public class ERestauracionBDRequest
    {
        public int IDBaseDatos { get; set; }
        public int IDTipoRestauracion { get; set; }
        public short Anio { get; set; }
        public short Mes { get; set; }
        public short? Dia { get; set; }
        public string Usuario { get; set; }
    }
}
