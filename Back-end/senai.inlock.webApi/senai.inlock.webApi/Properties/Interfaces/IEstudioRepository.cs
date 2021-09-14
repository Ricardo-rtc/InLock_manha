using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo EstudioRepository
    /// </summary>
    interface IEstudioRepository
    {
        /// <summary>
        /// Retorna todos os Estudios
        /// </summary>
        /// <returns>Uma lista de estúdios</returns>
        List<EstudioDomain> ListarTodosComJogos();

       
    }
}
