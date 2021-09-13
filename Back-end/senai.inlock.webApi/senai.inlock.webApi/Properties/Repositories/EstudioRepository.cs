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
        private string stringConexao = "Data Source=NOTE0113E5\\SQLEXPRESS; initial catalog=inlock_games_manha; user Id=sa; pwd=Senai@132";
        public void AtualizarIdCorpo(EstudioDomain estudioAtualizado)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int idEstudio, EstudioDomain estudioAtualizado)
        {
            throw new NotImplementedException();
        }

        public EstudioDomain BuscarPorId(int idEstudio)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(EstudioDomain novoEstudio)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idEstudio)
        {
            throw new NotImplementedException();
        }

        public List<EstudioDomain> ListarTodos()
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
                        EstudioDomain estudio = new EstudioDomain()
                        {
                            idEstudio = Convert.ToInt32(rdr[0]),
                            nomeEstudio = rdr[1].ToString()
                        };

                        listaEstudios.Add(estudio);

                    }
                }
            };
            return listaEstudios;
        }
    }
}
