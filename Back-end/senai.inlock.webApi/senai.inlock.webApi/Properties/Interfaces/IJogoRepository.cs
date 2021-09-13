using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo JogoRepository
    /// </summary>
    interface IJogoRepository
    {
        /// <summary>
        /// Retorna todos os Jogos
        /// </summary>
        /// <returns>Uma lista de jogos</returns>
        List<JogoDomain> ListarTodos();

        /// <summary>
        /// Busca um jogo pelo id
        /// </summary>
        /// <param name="idJogo"></param>
        /// <returns>Um objeto do tipo JogoDomain que foi buscado</returns>
        JogoDomain BuscarPorId(int idJogo);

        /// <summary>
        /// Cadastra um novojogo
        /// </summary>
        /// <param name="novoJogo">Cadastra um novo jogo</param>

        void Cadastrar(JogoDomain novoJogo);

        /// <summary>
        /// Atualiza um Jogo existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="jogoAtualizado"></param>
        /// ex: http://localhost:5000/api/jogos
        void AtualizarIdCorpo(JogoDomain jogoAtualizado);

        /// <summary>
        /// Atualiza um Jogo existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idJogo">id do jogo que será atualizado</param>
        /// <param name="jogoAtualizado">Objeto jogoAtualizado com os novos dados</param>
        /// ex: http://localhost:5000/api/Jogo/4
        void AtualizarIdUrl(int idJogo, JogoDomain jogoAtualizado);

        /// <summary>
        /// Deleta um jogo
        /// </summary>
        /// <param name="idJogo">id do jogo que será deletado</param>
        void Deletar(int idJogo);
    }
}
