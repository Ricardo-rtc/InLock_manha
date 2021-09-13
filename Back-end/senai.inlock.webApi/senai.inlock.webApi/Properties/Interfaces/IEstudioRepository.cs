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
        List<EstudioDomain> ListarTodos();

        /// <summary>
        /// Busca um Estudio pelo id
        /// </summary>
        /// <param name="idEstudio"></param>
        /// <returns>Um objeto do tipo EstudioDomain que foi buscado</returns>
        EstudioDomain BuscarPorId(int idEstudio);

        /// <summary>
        /// Cadastra um novo Estudio
        /// </summary>
        /// <param name="novoEstudio">Cadastra um novo Estúdio</param>
        
        void Cadastrar(EstudioDomain novoEstudio);

        /// <summary>
        /// Atualiza um Estudio existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="estudioAtualizado"></param>
        /// ex: http://localhost:5000/api/estudios
        void AtualizarIdCorpo(EstudioDomain estudioAtualizado);

        /// <summary>
        /// Atualiza um Estudio existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idEstudio">id do estudio que será atualizado</param>
        /// <param name="estudioAtualizado">Objeto estudioAtualizado com os novos dados</param>
        /// ex: http://localhost:5000/api/generos/4
        void AtualizarIdUrl(int idEstudio, EstudioDomain estudioAtualizado);

        /// <summary>
        /// Deleta um Estúdio
        /// </summary>
        /// <param name="idEstudio">id do estudio que será deletado</param>
        void Deletar(int idEstudio);
    }
}
