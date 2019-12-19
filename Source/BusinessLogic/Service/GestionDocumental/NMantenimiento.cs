using System.Collections.Generic;
using OpeCar.BusinessEntities.GestionArchivo;
using OpeCar.ServiceAgent.Repositories.GestionDocumental;

namespace OpeCar.BusinessLogic.Service.GestionDocumental
{
    public class NMantenimiento
    {
        readonly DMantenimiento _filter = new DMantenimiento();
        public List<EMantenimiento> Listar()
        {
            return _filter.Listar();
        }

        public bool Guardar(EMantenimiento mantenimiento)
        {
            return _filter.Guardar(mantenimiento);
        }
    }
}
