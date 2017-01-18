﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bintec.WebService.Domain.DTO;
using Bintec.WebService.Domain.Repository;
using Bintec.WebService.Domain.ConnMySql;

namespace Bintec.WebService.Teste
{
    [TestClass]
    public class Testes
    {
        #region Propriedades

        private XmlPorEmpresaDTO _xmlPorEmpresaDTO;
        private XmlPorEmpresaDTO xmlPorEmpresaDTO
        {
            get { return _xmlPorEmpresaDTO ?? (_xmlPorEmpresaDTO = new XmlPorEmpresaDTO()); }
        }

        private List<XmlPorEmpresaDTO> _listaXmlPorEmpresaDTO;
        private List<XmlPorEmpresaDTO> listaXmlPorEmpresaDTO
        {
            get { return _listaXmlPorEmpresaDTO ?? (_listaXmlPorEmpresaDTO = new List<XmlPorEmpresaDTO>()); }
        }

        private XmlPorEmpresaRepository _xmlPorEmpresaRepository;
        private XmlPorEmpresaRepository xmlPorEmpresaRepository
        {
            get { return _xmlPorEmpresaRepository ?? (_xmlPorEmpresaRepository = new XmlPorEmpresaRepository()); }
        }

        private ConexaoMySql _conexaoMySQL;
        private ConexaoMySql conexaoMySQL
        {
            get { return _conexaoMySQL ?? (_conexaoMySQL = new ConexaoMySql()); }
        }

        #endregion


        [TestMethod]
        public void Testar_Conexao_Base()
        {
            var conexao = conexaoMySQL.Conectar();
            Assert.IsTrue(conexao, "Falha na conexão");
        }

        [TestMethod]
        public void Retornar_Itens_da_tabela_XmlPorEmpresa()
        {
            var lista = xmlPorEmpresaRepository.SelecionarXmlPorChaveDeAcesso("33170105947398000191650010000015831000015832");
            Assert.IsNotNull(lista, "ERRO AO CARREGAR A LISTA!");
        }
    }
}
