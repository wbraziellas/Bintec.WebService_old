using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bintec.WebService.Repository.Base
{
    public abstract class ConexaoBase
    {
        protected string _strConnection = string.Empty;

        public abstract bool Conectar();
        public abstract bool Desconectar();
    }
}
