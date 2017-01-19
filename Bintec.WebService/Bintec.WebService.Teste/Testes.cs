using System;
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
                
        #endregion

        [TestMethod]
        public void Retornar_Itens_da_tabela_XmlPorEmpresa()
        {
            var lista = xmlPorEmpresaRepository.SelecionarXmlPorChaveDeAcesso("33170105947398000191650010000015831000015832");
            Assert.IsNotNull(lista, "ERRO AO CARREGAR A LISTA!");
        }

        [TestMethod]
        public void testar_inserir_item_na_tabela_XmlPorEmpresa()
        {
            xmlPorEmpresaDTO.Cnpj = "12312345645678";
            xmlPorEmpresaDTO.Xml = Encoding.ASCII.GetBytes("teste");
            xmlPorEmpresaDTO.TipoNf = 56;
            xmlPorEmpresaDTO.EntradaOuSaida = "entrada";
            xmlPorEmpresaDTO.Serie = "1";
            xmlPorEmpresaDTO.Numero = 1234;
            xmlPorEmpresaDTO.ChaveDeAcesso = "73737473847534756836875687346856387468376539";
            xmlPorEmpresaDTO.DataEmissao = DateTime.Parse("19/01/2017");

            var id = xmlPorEmpresaRepository.InserirXmlPorChaveDeAcesso(xmlPorEmpresaDTO);

            Assert.IsNotNull(id, "Não retornou valor!");
        }

        [TestMethod]
        public void Atualizar_registro_tabela_XmlPorEmpresa()
        {
            #region Montagem do Objeto para envio

            xmlPorEmpresaDTO.Id = 7;
            xmlPorEmpresaDTO.Cnpj = "11122233345678";
            xmlPorEmpresaDTO.Xml = Encoding.ASCII.GetBytes("teste");
            xmlPorEmpresaDTO.TipoNf = 56;
            xmlPorEmpresaDTO.EntradaOuSaida = "entrada";
            xmlPorEmpresaDTO.Serie = "1";
            xmlPorEmpresaDTO.Numero = 1234;
            xmlPorEmpresaDTO.ChaveDeAcesso = "73737473847534756836875687346856387468376539";
            xmlPorEmpresaDTO.DataEmissao = DateTime.Parse("19/01/2017");

            #endregion
                        
            var retorno = xmlPorEmpresaRepository.AtualizarXmlPorChaveDeAcesso(xmlPorEmpresaDTO);

            Assert.IsNotNull(retorno, "Não retornou registro");
        }
    }
}
