using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bintec.WebService.Repository.ConexaoMySql;
using MySql.Data.MySqlClient;
using System.Data;
using Bintec.WebService.Domain.DTO;

namespace Bintec.WebService.Domain.Repository
{
    public class XmlPorEmpresaRepository
    {
        #region Propriedades

        private ConexaoMySql _conexaoMySql;
        private ConexaoMySql conexaoMySql
        {
            get { return _conexaoMySql ?? (_conexaoMySql = new ConexaoMySql()); }
        }

        #endregion

        public List<XmlPorEmpresaDTO> SelecionarXmlPorChaveDeAcesso(string chavedeacesso)
        {
            #region comando SQL
            var _strCmd = "SELECT" +
                                "ID" +
                                "CNPJ" +
                                "XML" + 
                                "TIPONF" + 
                                "ENTRADAOUSAIDA" +
                                "SERIE" + 
                                "NUMERO" +
                                "CHAVEDEACESSO" +
                          "FROM XMLPOREMPRESA WHERE CHAVEDEACESSO = @CHAVEDEACESSO";
            #endregion
            
            conexaoMySql.Conectar();

            try
            {
                MySqlCommand _cmdSql = new MySqlCommand(_strCmd);
                _cmdSql.Parameters.Add(new MySqlParameter("@CHAVEDEACESSO", chavedeacesso));

                var _adapter = new MySqlDataAdapter() { SelectCommand = _cmdSql };
                var _data = new DataTable();

                _adapter.Fill(_data);

                return ConverterDataEmXmlPorEmpresa(_data);
            }
            catch(Exception eErro)
            {
                throw eErro;                
            }
            finally
            {
                conexaoMySql.Desconectar();
            }            
        }


        #region Métodos Privados

        private List<XmlPorEmpresaDTO> ConverterDataEmXmlPorEmpresa(DataTable data)
        {
            var listaXml = new List<XmlPorEmpresaDTO>();

            foreach(DataRow row in data.Rows)
            {
                var linha = row.ItemArray;
                var linhaXml = new XmlPorEmpresaDTO();

                linhaXml.Id = int.Parse(linha[0].ToString());
                linhaXml.Cnpj = linha[1].ToString();
                linhaXml.Xml = Encoding.ASCII.GetBytes(linha[2].ToString());
                linhaXml.TipoNf = linha[3].ToString();
                linhaXml.EntradaOuSaida = linha[4].ToString();
                linhaXml.Serie = linha[5].ToString();
                linhaXml.Numero = int.Parse(linha[6].ToString());
                linhaXml.ChaveDeAcesso = linha[7].ToString();

                listaXml.Add(linhaXml);
            }

            return listaXml;
        }

        #endregion
    }
}
