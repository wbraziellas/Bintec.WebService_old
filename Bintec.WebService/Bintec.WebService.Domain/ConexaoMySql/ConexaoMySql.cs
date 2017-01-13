using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bintec.WebService.Repository.Base;
using MySql.Data.MySqlClient;

namespace Bintec.WebService.Repository.ConexaoMySql
{
    public class ConexaoMySql : ConexaoBase
    {
        public override bool Conectar()
        {

            _strConnection = "";

            MySqlConnection _conexaoMySQL = new MySqlConnection(_strConnection);


            throw new NotImplementedException();
        }

        public override bool Desconectar()
        {
            throw new NotImplementedException();
        }
    }
}
