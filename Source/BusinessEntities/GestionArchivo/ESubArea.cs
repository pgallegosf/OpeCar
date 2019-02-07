namespace OpeCar.BusinessEntities.GestionArchivo
{
    public class ESubArea
    {
        public int IdSubArea { get; set; }
        public int IdArea { get; set; }
        public int? IdPadre { get; set; }
        public string Descripcion { get; set; }
        public bool EsUltimo { get; set; }

    }
}
