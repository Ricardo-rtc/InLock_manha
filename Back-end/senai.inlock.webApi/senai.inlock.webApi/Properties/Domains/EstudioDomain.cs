using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    /// <summary>
    /// Classe que representa a tabela de Estudio
    /// </summary>
    public class EstudioDomain
    {
        public int idEstudio { get; set; }
        public string nomeEstudio { get; set; }
        public List<JogoDomain> ListaJogos { get; set; }
    }
}
