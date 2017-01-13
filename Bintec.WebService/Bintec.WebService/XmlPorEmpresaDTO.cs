﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bintec.WebService.DTO
{
    public class XmlPorEmpresaDTO
    {
        public int Id { get; set; }
        public string Cnpj { get; set; }
        public byte[] Xml { get; set; }
        public string TipoNf { get; set; }
        public string EntradaOuSaida { get; set; }
        public string Serie { get; set; }
        public int Numero { get; set; }
        public int ChaveDeAcesso { get; set; }
    }
}
