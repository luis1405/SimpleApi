using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Interfaces
{
    public interface IListar<TEntidad,TEntidadID>
    {
        Task<List<TEntidad>> Listar();
        Task<TEntidad> SeleccionarPorID(TEntidadID entidadID);
    }
}
