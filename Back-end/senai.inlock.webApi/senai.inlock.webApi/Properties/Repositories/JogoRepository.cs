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
        // User CARDOSO private string stringConexao = "Data Source=DESKTOP-7KLLDB1\\SQLEXPRESS; initial catalog=inlock_games_manha; user Id=cardoso; pwd=Senai@132";
        private string stringConexao = "Data Source=NOTE0113E3\\SQLEXPRESS; initial catalog=inlock_games_manha; user Id=sa; pwd=Senai@132";



        public void Atualizar(int id, JogoDomain jogoAtualizado)
        {
           throw new NotImplementedException();
        }

        public JogoDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(JogoDomain novoJogo)
        {
           
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                
                string queryInsert = "INSERT INTO jogo(nomeJogo, descricao, dataLancamento, valor, idEstudio)" +
                                     "VALUES(@nomeJogo, @descricao, @dataLancamento, @valor, @idEstudio)";

                
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nomeJogo", novoJogo.nomeJogo);
                    cmd.Parameters.AddWithValue("@descricao", novoJogo.descricao);
                    cmd.Parameters.AddWithValue("@dataLancamento", novoJogo.dataLancamento);
                    cmd.Parameters.AddWithValue("@valor", novoJogo.valor);
                    cmd.Parameters.AddWithValue("@idEstudio", novoJogo.idEstudio);

                   
                    con.Open();

                    
                    cmd.ExecuteNonQuery();
                }
            }
        }

        


        public void Deletar(int id)
        {
            throw new NotImplementedException();
       }

        public List<JogoDomain> ListarTodos()
        {

            List<JogoDomain> listaJogos = new List<JogoDomain>();


            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string querySelectAll = "SELECT J.idJogo, nomeJogo, descricao, dataLancamento, valor, J.idEstudio, E.nomeEstudio FROM jogo J " +
                                        "INNER JOIN estudio E " +
                                        "ON J.idEstudio = E.idEstudio";


                con.Open();


                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {

                    rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {

                        JogoDomain jogo = new JogoDomain()
                        {

                            idJogo = Convert.ToInt32(rdr[0]),

                            nomeJogo = rdr[1].ToString(),

                            descricao = rdr[2].ToString(),

                            dataLancamento = Convert.ToDateTime(rdr[3]),

                            valor = Convert.ToDecimal(rdr[4]),

                            idEstudio = Convert.ToInt32(rdr[5]),

                            estudio = new EstudioDomain()
                            {
                                nomeEstudio = rdr[6].ToString()
                            }
                        };


                        listaJogos.Add(jogo);
                    }
                }
            }


            return listaJogos;

        }        
    }
}
