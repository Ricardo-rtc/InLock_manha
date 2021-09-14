using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage = "Informe o e-mail")]
        public string email { get; set; }
        [Required(ErrorMessage = "Informe a senha")]
        [StringLength(100,MinimumLength = 5,ErrorMessage = "A senha deve conter no mínimo 5 caracteres")]
        public string senha { get; set; }
        public int idTipoUsuario { get; set; }
        public TipoUsuarioDomain tipoUsuario { get; set; }
    }
}
