using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bintec.WebService.Domain.DTO;
using Bintec.WebService.Domain.Repository;

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
        public void Testar_Conexao_Base()
        {
            
        }
    }
}
