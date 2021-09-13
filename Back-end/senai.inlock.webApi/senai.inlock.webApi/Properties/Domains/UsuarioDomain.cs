using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    public class UsuarioDomain
    {
        /// <summary>
        /// Classe que representa a tabela de Usuario
        /// </summary>
        public int idUsuario { get; set; }
        public int idTipoUsuario { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public TipoUsuarioDomain tipoUsuario { get; set; }
    }
}
