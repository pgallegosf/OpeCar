namespace OpeCar.BusinessEntities.GestionArchivo
{
    public class EMenuFooter
    {
        public int? MenuFooterId { get; set; }
        public int MantenimientoId { get; set; }
        public string MenuFooterName { get; set; }
        public string MenuFooterUrl { get; set; }
        public int MenuFooterPosition { get; set; }
        public bool MenuFooterIsSuperAdmin { get; set; }
        public bool MenuFooterStatus { get; set; }

        public virtual EMantenimiento Mantenimiento { get; set; }
    }
}
