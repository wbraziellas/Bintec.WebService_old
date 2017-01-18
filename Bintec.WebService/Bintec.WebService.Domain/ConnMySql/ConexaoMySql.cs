using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bintec.WebService.Repository.Base;
using MySql.Data.MySqlClient;

namespace Bintec.WebService.Domain.ConnMySql
{
    public abstract class ConexaoMySql : ConexaoBase
    {
        public override bool Conectar()
        {         
            _conexaoMySQL = new MySqlConnection(_strConnection);

            try
            {
                if (_conexaoMySQL.State == System.Data.ConnectionState.Closed)
                {
                    _conexaoMySQL.Open();
                    return true;
                }
                else
                    return false;
            }
            catch(Exception eError)
            {
                _conexaoMySQL.Close();
                throw eError;                
            }          
        }

        public override bool Desconectar()
        {
            try
            {
                if (_conexaoMySQL.State != System.Data.ConnectionState.Closed)
                {
                    _conexaoMySQL.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception eError)
            {
                throw eError;
            }
        }
    }
}
