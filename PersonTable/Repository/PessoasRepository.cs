using PersonTable.Models;
using System.Data;
using System.Data.SqlClient;

namespace PersonTable.Repository
{
    public class PessoasRepository
    {
        public IList<Pessoas> Listar()
        {
            IList<Pessoas> lista = new List<Pessoas>();

            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("TablePersonConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "SELECT IDTIPO, NOME, ENDEREÇO FROM PESSOAS";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Pessoas pessoas = new Pessoas();
                    pessoas.IdTipo = Convert.ToInt32(dataReader["IDTIPO"]);
                    pessoas.Nome = dataReader["NOME"].ToString();
                    pessoas.Endereço = dataReader["ENDEREÇO"].ToString();

                    lista.Add(pessoas);
                }

                connection.Close();

            }
            return lista;
        }

        public Pessoas Consultar(int id)
        {

            Pessoas pessoas = new Pessoas();

            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("TablePersonConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "SELECT IDTIPO, NOME, ENDEREÇO FROM PESSOAS WHERE IDTIPO = @IDTIPO ";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@IDTIPO", SqlDbType.Int);
                command.Parameters["@IDTIPO"].Value = id;
                connection.Open();

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    pessoas.IdTipo = Convert.ToInt32(dataReader["IDTIPO"]);
                    pessoas.Nome = dataReader["NOME"].ToString();
                    pessoas.Endereço = dataReader["ENDEREÇO"].ToString();
                }

                connection.Close();

            }
            return pessoas;
        }

        public void Inserir(Pessoas pessoas)
        {
            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("TablePersonConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "INSERT INTO PESSOAS ( NOME, ENDEREÇO ) VALUES ( @nome, @ender ) ";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.Add("@nome", SqlDbType.Text);
                command.Parameters["@nome"].Value = pessoas.Nome;
                command.Parameters.Add("@ender", SqlDbType.Text);
                command.Parameters["@ender"].Value = pessoas.Endereço;

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
        }

        public void Alterar(Pessoas pessoas)
        {
            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("TablePersonConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "UPDATE PESSOAS SET NOME = @nome , ENDEREÇO = @ender WHERE IDTIPO = @id  ";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.Add("@nome", SqlDbType.Text);
                command.Parameters.Add("@ender", SqlDbType.Text);
                command.Parameters.Add("@id", SqlDbType.Int);
                command.Parameters["@nome"].Value = pessoas.Nome;
                command.Parameters["@ender"].Value = pessoas.Endereço;
                command.Parameters["@id"].Value = pessoas.IdTipo;

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
        }

        public void Excluir(int id)
        {
            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("TablePersonConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "DELETE PESSOAS WHERE IDTIPO = @id  ";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.Add("@id", SqlDbType.Int);
                command.Parameters["@id"].Value = id;

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

        }
    }
}