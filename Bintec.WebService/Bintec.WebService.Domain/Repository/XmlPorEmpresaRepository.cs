using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bintec.WebService.Domain.ConnMySql;
using MySql.Data.MySqlClient;
using System.Data;
using Bintec.WebService.Domain.DTO;

namespace Bintec.WebService.Domain.Repository
{
    public class XmlPorEmpresaRepository : ConexaoMySql
    {

        public List<XmlPorEmpresaDTO> SelecionarXmlPorChaveDeAcesso(string chavedeacesso)
        {
            #region SQL para criar registro
            var _strCmd = "SELECT" +
                                " ID," +
                                " CNPJ," +
                                " XML," + 
                                " TIPONF," + 
                                " ENTRADAOUSAIDA," +
                                " SERIE," + 
                                " NUMERO," +
                                " CHAVEDEACESSO," +
                                " DATAEMISSAO" +
                          " FROM XMLPOREMPRESA WHERE CHAVEDEACESSO = @CHAVEDEACESSO";
            #endregion                                   

            try
            {
                Conectar();

                MySqlCommand _cmdSql = new MySqlCommand(_strCmd, _conexaoMySQL);
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
                Desconectar();
            }            
        }

        public string InserirXmlPorChaveDeAcesso(XmlPorEmpresaDTO xmlPorEmpresa)
        {
            #region SQL inserir item na tabela

            string _strCmd = "INSERT INTO " +
                                "XMLPOREMPRESA(CNPJ, XML, TIPONF, ENTRADAOUSAIDA, SERIE, NUMERO, CHAVEDEACESSO, DATAEMISSAO) " +
                             "VALUES(@CNPJ, @XML, @TIPONF, @ENTRADAOUSAIDA, @SERIE, @NUMERO, @CHAVEDEACESSO, @DATAEMISSAO)";

            #endregion            

            try
            {
                Conectar();

                MySqlCommand _cmdSql = new MySqlCommand(_strCmd, _conexaoMySQL);
                _cmdSql.Parameters.AddWithValue("@CNPJ", xmlPorEmpresa.Cnpj);
                _cmdSql.Parameters.AddWithValue("@XML", xmlPorEmpresa.Xml);
                _cmdSql.Parameters.AddWithValue("@TIPONF", xmlPorEmpresa.TipoNf);
                _cmdSql.Parameters.AddWithValue("@ENTRADAOUSAIDA", xmlPorEmpresa.EntradaOuSaida);
                _cmdSql.Parameters.AddWithValue("@SERIE", xmlPorEmpresa.Serie);
                _cmdSql.Parameters.AddWithValue("@NUMERO", xmlPorEmpresa.Numero);
                _cmdSql.Parameters.AddWithValue("@CHAVEDEACESSO", xmlPorEmpresa.ChaveDeAcesso);
                _cmdSql.Parameters.AddWithValue("@DATAEMISSAO", xmlPorEmpresa.DataEmissao);

                _cmdSql.ExecuteNonQuery();

                return RetornaIdDoValorInseridoNaTabela(xmlPorEmpresa.Cnpj, xmlPorEmpresa.ChaveDeAcesso);
            }
            catch(Exception eError)
            {
                return "Erro ao gravar dados no banco: " + eError; ;                
            }
            finally
            {
                Desconectar();
            }            
        }

        public string AtualizarXmlPorChaveDeAcesso(XmlPorEmpresaDTO xmlPorEmpresa)
        {
            #region SQL Atualizar tabela
            string _strSql = "UPDATE XMLPOREMPRESA SET " +
                                    "CNPJ = @CNPJ, " +
                                    "XML = @XML, " +
                                    "TIPONF = @TIPONF, " +
                                    "ENTRADAOUSAIDA = @ENTRADAOUSAIDA, " + 
                                    "SERIE = @SERIE, " +
                                    "NUMERO = @NUMERO, " +
                                    "CHAVEDEACESSO = @CHAVEDEACESSO, " +
                                    "DATAEMISSAO = @DATAEMISSAO " +
                              "WHERE ID = @ID";

            #endregion

            try
            {
                Conectar();

                MySqlCommand _cmdSql = new MySqlCommand(_strSql, _conexaoMySQL);
                
                _cmdSql.Parameters.AddWithValue("@CNPJ", xmlPorEmpresa.Cnpj);
                _cmdSql.Parameters.AddWithValue("@XML", xmlPorEmpresa.Xml);
                _cmdSql.Parameters.AddWithValue("@TIPONF", xmlPorEmpresa.TipoNf);
                _cmdSql.Parameters.AddWithValue("@ENTRADAOUSAIDA", xmlPorEmpresa.EntradaOuSaida);
                _cmdSql.Parameters.AddWithValue("@SERIE", xmlPorEmpresa.Serie);
                _cmdSql.Parameters.AddWithValue("@NUMERO", xmlPorEmpresa.Numero);
                _cmdSql.Parameters.AddWithValue("@CHAVEDEACESSO", xmlPorEmpresa.ChaveDeAcesso);
                _cmdSql.Parameters.AddWithValue("@DATAEMISSAO", xmlPorEmpresa.DataEmissao);
                _cmdSql.Parameters.AddWithValue("@ID", xmlPorEmpresa.Id);

                _cmdSql.ExecuteNonQuery();

                return "Ok";
            }
            catch(Exception eError)
            {
                return "Erro ao atualizar registro: " + eError;
            }
            finally
            {
                Desconectar();
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
                linhaXml.TipoNf = int.Parse(linha[3].ToString());
                linhaXml.EntradaOuSaida = linha[4].ToString();
                linhaXml.Serie = linha[5].ToString();
                linhaXml.Numero = int.Parse(linha[6].ToString());
                linhaXml.ChaveDeAcesso = linha[7].ToString();
                linhaXml.DataEmissao = DateTime.Parse(linha[8].ToString());

                listaXml.Add(linhaXml);
            }

            return listaXml;
        }

        private string RetornaIdDoValorInseridoNaTabela(string cnpj, string chavedeacesso)
        {
            string _strCmd = "SELECT ID FROM XMLPOREMPRESA WHERE " +
                                "CNPJ = @CNPJ AND CHAVEDEACESSO = @CHAVEDEACESSO";


            try
            {
                MySqlCommand _cmdSql = new MySqlCommand(_strCmd, _conexaoMySQL);
                _cmdSql.Parameters.Add(new MySqlParameter("@CNPJ", cnpj));
                _cmdSql.Parameters.Add(new MySqlParameter("@CHAVEDEACESSO", chavedeacesso));

                MySqlDataAdapter _adapter = new MySqlDataAdapter() { SelectCommand = _cmdSql };
                DataTable _data = new DataTable();

                _adapter.Fill(_data);

                return _data.ToString();
            }
            catch (Exception eError)
            {
                throw eError;
            }
        }          
        
        #endregion
    }
}
