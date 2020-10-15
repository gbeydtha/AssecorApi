using AssecorApi.Data.Interfaces;
using AssecorApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssecorApi.Data.Repositories
{
    public class ColorRepository : IColorRepository
    {
        private readonly AddDbContext _addDbContext;
        public ColorRepository(AddDbContext addDbContext)
        {
            _addDbContext = addDbContext; 
        }

        public IEnumerable<Color> Colors => _addDbContext.Colors;

    }
}
