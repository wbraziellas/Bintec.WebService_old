using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Bintec.WebService.Repository.Base
{
    public abstract class ConexaoBase
    {
        protected string _strConnection = string.Empty;
        protected MySqlConnection _conexaoMySQL;

        public abstract bool Conectar();
        public abstract bool Desconectar();
    }
}
