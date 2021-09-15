using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Properties.Repositories
{

    public class EstudioRepository : IEstudioRepository
    {
        //string Conexao = Conectar ao arquivo da BD
        //Data source = Conexão do Pc
        //inital catalog = nome do arquivo a ser lido
        //user Id=UsuariodoSql; pwd=senhaSql";
        // user Id=sa; pwd=senai@132
        private readonly string stringConexao = "Data Source=DESKTOP-7KLLDB1\\SQLEXPRESS; initial catalog = inlock_games_manha; user Id = cardoso; pwd=Senai@132";

        //Conexão pc do cardoso DESKTOP-7KLLDB1


        public List<EstudioDomain> ListarComJogos()
        {
            List<EstudioDomain> listaEstudios = new List<EstudioDomain>();

            //Declara a SqlConnection con passando a string de conexao como parametro.
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idEstudio, nomeEstudio FROM Estudio";

                //Abre a conexão com o banco de dados
                con.Open();

                //Percorre o Banco de dados
                SqlDataReader rdr;

                //Executa a query no banco de dados
                using(SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    //executa a query e salva os dados no rdr
                    rdr = cmd.ExecuteReader();

                    while(rdr.Read())
                    {
                        List<JogoDomain> listaJogos = new List<JogoDomain>();

                        EstudioDomain estudio = new EstudioDomain()
                        {
                            idEstudio = Convert.ToInt32(rdr[0]),
                            nomeEstudio = rdr[1].ToString()
                        };

                        using (SqlConnection conGames = new SqlConnection(stringConexao))
                        {
                            string querySelectAllGames = "SELECT idJogo, nomeJogo, descricao, dataLancamento, valor FROM Jogos WHERE idEstudio = @idEstudio";

                            conGames.Open();

                            SqlDataReader rdrGames;

                            using (SqlCommand cmdGames = new SqlCommand(querySelectAllGames, conGames))
                            {
                                cmdGames.Parameters.AddWithValue("@idEstudio", estudio.idEstudio);
                                rdrGames = cmdGames.ExecuteReader();

                                while (rdrGames.Read())
                                {
                                    JogoDomain jogo = new JogoDomain()
                                    {
                                        idJogo = Convert.ToInt32(rdrGames[0]),

                                        nomeJogo = rdrGames[1].ToString(),

                                        descricao = rdrGames[2].ToString(),

                                        dataLancamento = Convert.ToDateTime(rdrGames[3]),

                                        valor = Convert.ToDecimal(rdrGames[4])
                                    };

                                    listaJogos.Add(jogo);

                                }
                            }

                            estudio.ListaJogos = listaJogos;
                            listaEstudios.Add(estudio);
                        }
                    }
                }
            }
            return listaEstudios;
        }
    }
}
