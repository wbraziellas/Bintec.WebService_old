using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bintec.WebService.Domain.DTO;
using Bintec.WebService.Domain.Repository;

namespace Bintec.WebService.Controller
{
    public class XmlPorEmpresaController
    {
        #region Propriedades

        private List<XmlPorEmpresaDTO> _lsitaXmlPorEmpresaDTO;
        private List<XmlPorEmpresaDTO> listaXmlPorEmpresaDTO
        {
            get { return _lsitaXmlPorEmpresaDTO ?? (_lsitaXmlPorEmpresaDTO = new List<XmlPorEmpresaDTO>()); }
            set { _lsitaXmlPorEmpresaDTO = value; }
        }

        private XmlPorEmpresaRepository _xmlPorEmpresaRepository;
        private XmlPorEmpresaRepository xmlPorEmpresaRepository
        {
            get { return _xmlPorEmpresaRepository ?? (_xmlPorEmpresaRepository = new XmlPorEmpresaRepository()); }
        }

        #endregion

        public List<XmlPorEmpresaDTO> RetornaXmlPorEmpresa(string cnpj)
        {
            return listaXmlPorEmpresaDTO = xmlPorEmpresaRepository.SelecionarXmlPorEmpresa(cnpj);
        }
    }
}
