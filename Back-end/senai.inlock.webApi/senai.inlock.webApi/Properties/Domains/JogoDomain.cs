using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    /// <summary>
    /// Classe que representa a tabela de Jogo
    /// </summary>
    public class JogoDomain
    {
        public int idJogo { get; set; }
        public int idEstudio { get; set; }
        public string nomeJogo { get; set; }
        public string descricao { get; set; }
        public DateTime dataLancamento { get; set; }
        public int valor { get; set; }
        public EstudioDomain estudio { get; set; }
    }
}
