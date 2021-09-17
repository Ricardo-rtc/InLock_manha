using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Properties.Repositories
{
    /// <summary>
    /// Classe responsável pelo repositório dos usuários 
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {

        private string stringConexao = "Data Source= NOTE0113E3\\SQLEXPRESS; initial catalog=inlock_games_manha; user Id=sa; pwd=Senai@132";
        //private readonly string stringConexao = "Data Source=DESKTOP-C8POL51\\SQLSERVEREXPRESS; initial catalog = inlock_games_manha; user Id = sa; pwd=senai@132";


        public UsuarioDomain Login(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT idUsuario, email, U.idTipoUsuario, TU.titulo " +
                                     "FROM Usuarios U INNER JOIN TipoUsuario TU ON U.idTipoUsuario = TU.idTipoUsuario " +
                                     "WHERE email = @email AND senha = @senha";

                // Define o comando cmd passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    // Define os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando e armazena os dados no objeto rdr
                    SqlDataReader rdr = cmd.ExecuteReader();

                    // Caso dados tenham sido obtidos
                    if (rdr.Read())
                    {
                        // Cria um objeto do tipo UsuarioDomain
                        UsuarioDomain usuarioBuscado = new UsuarioDomain
                        {
                            // Atribui às propriedades os valores das colunas do banco de dados
                            idUsuario = Convert.ToInt32(rdr["idUsuario"]),
                            email = rdr["email"].ToString(),
                            idTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"]),
                            tipoUsuario = new TipoUsuarioDomain()
                            {
                                titulo = rdr["titulo"].ToString()
                            }
                        };

                        // Retorna o usuário buscado
                        return usuarioBuscado;
                    }

                    // Caso não encontre um email e senha correspondente, retorna null
                    return null;
                }
            }
        }
    }
}
