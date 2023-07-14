using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imobiliaria.Models
{
    public class FiltroUsuarioModel
    {
        public string Nome { get; set; }
        public string TipoUsuario { get; set; }

        public FiltroUsuarioModel()
        {
            this.Nome = "";
            this.TipoUsuario = "";
        }

    }
}
