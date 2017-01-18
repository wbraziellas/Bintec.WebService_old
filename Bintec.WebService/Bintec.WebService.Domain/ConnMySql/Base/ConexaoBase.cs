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
        protected string _strConnection = "Server=localhost;Port=3306;Database=repositorio;Uid=bintec;Pwd = Intuit2014;";
        protected MySqlConnection _conexaoMySQL;

        public abstract bool Conectar();
        public abstract bool Desconectar();
    }
}
