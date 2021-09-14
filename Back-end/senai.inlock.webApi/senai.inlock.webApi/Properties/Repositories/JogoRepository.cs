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
        private string stringConexao = "Data Source=DESKTOP-C8POL51\\SQLEXPRESS; initial catalog=inlock_games_manha; user Id=sa; pwd=senai@132";
        

        public void Atualizar(int id, JogoDomain jogoAtualizado)
        {
            throw new NotImplementedException();
        }

        public JogoDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Jogo novoJogo)
        {
           
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                
                string queryInsert = "INSERT INTO jogo(nomeJogo, descricao, dataLancamento, valor, idEstudio)" +
                                     "VALUES(@nomeJogo, @descricao, @dataLancamento, @valor, @idEstudio)";

                
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nomeJogo", novoJogo.NomeJogo);
                    cmd.Parameters.AddWithValue("@descricao", novoJogo.Descricao);
                    cmd.Parameters.AddWithValue("@dataLancamento", novoJogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@valor", novoJogo.Valor);
                    cmd.Parameters.AddWithValue("@idEstudio", novoJogo.IdEstudio);

                   
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

                            Estudio = new EstudioDomain()
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
