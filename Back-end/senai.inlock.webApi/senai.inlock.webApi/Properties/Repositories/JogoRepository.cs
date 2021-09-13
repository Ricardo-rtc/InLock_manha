using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Properties.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        //string Conexao = Conectar ao arquivo da BD
        //Data source = Conexão do Pc
        //inital catalog = nome do arquivo a ser lido
        //user Id=UsuariodoSql; pwd=senhaSql";
        private string stringConexao = "Data Source=NOTE0113E5\\SQLEXPRESS; initial catalog=inlock_games_manha; user Id=sa; pwd=Senai@132";
        public void AtualizarIdCorpo(JogoDomain jogoAtualizado)
        //Buscar jogo por ID!!
        public Jogo BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }
        public void Cadastrar(JogoDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query a ser executa
                string queryInsert = "INSERT INTO jogo(nomeJogo, descricao, dataLancamento, valor, idEstudio)" +
                                     "VALUES(@nomeJogo, @descricao, @dataLancamento, @valor, @idEstudio)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))

                {
                    // Passa o valor para o parâmetro.
                    cmd.Parameters.AddWithValue("@nomeJogo", novoJogo.NomeJogo);
                    cmd.Parameters.AddWithValue("@descricao", novoJogo.Descricao);
                    cmd.Parameters.AddWithValue("@dataLancamento", novoJogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@valor", novoJogo.Valor);
                    cmd.Parameters.AddWithValue("@idEstudio", novoJogo.IdEstudio);

                    // Open = abrir conexão com a BD
                    con.Open();

                    // ExecuteNonQuery ele executa a query
                    cmd.ExecuteNonQuery();
                }
            }

        }

        public void Deletar(int idJogo)
        {
            throw new NotImplementedException();
        }

        public List<JogoDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
