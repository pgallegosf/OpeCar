namespace OpeCar.BusinessEntities
{
    public class Base<T>
    {
        public virtual T Codigo { get; set; }
        public virtual string Descripcion { get; set; }
    }
}
