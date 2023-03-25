using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Interfaces
{
    public interface IRepositorioGenerico<TEntidad, TEntidadID>
        :IAgregar<TEntidad>,IEditar<TEntidad>,IEliminar<TEntidadID>,IListar<TEntidad,TEntidadID>
    {
    }
}
