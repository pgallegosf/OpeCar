using System.Collections.Generic;
using OpeCar.BusinessEntities.GestionArchivo;
using OpeCar.ServiceAgent.Repositories.GestionDocumental;

namespace OpeCar.BusinessLogic.Service.GestionDocumental
{
    public class NMenuFooter
    {
        readonly DMenuFooter _filter = new DMenuFooter();
        public List<EMenuFooter> Listar(int mantenimientoId)
        {
            return _filter.Listar(mantenimientoId);
        }

        public bool Guardar(EMenuFooter menuFooter)
        {
            return _filter.Guardar(menuFooter);
        }
    }
}
