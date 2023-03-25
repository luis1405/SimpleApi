using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Interfaces
{
    public interface IAgregar<TEntidad>
    {
        Task<int> Agregar(TEntidad entidad);
    }
}
