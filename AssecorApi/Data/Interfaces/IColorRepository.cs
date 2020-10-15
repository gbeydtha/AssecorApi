using AssecorApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssecorApi.Data.Interfaces
{
    public interface IColorRepository
    {
        IEnumerable<Color> Colors { get; }
    }
}
