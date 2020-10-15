using AssecorApi.Data.Interfaces;
using AssecorApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssecorApi.Data.Mock
{
    public class MockColorRepository : IColorRepository
    {
        public IEnumerable<Color> Colors        {

            get
            {
                return new List<Color>
                {
                            new Color{ Id = 1, ColorName = "blue"},
                            new Color{ Id = 2, ColorName = "grün"},
                            new Color{ Id = 3, ColorName = "violett"},
                            new Color{ Id = 4, ColorName = "rot"},
                            new Color{ Id = 5, ColorName = "gelb"},
                            new Color{ Id = 6, ColorName = "türkis"},
                            new Color{ Id = 7, ColorName = "weiß"}
                };
            }
        }
     }
}

