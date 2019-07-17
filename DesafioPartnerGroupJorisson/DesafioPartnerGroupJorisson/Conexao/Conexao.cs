using System.Data.SqlClient;

namespace DesafioPartnerGroupJorisson
{
    public class Conexao
    {
        SqlConnection con = new SqlConnection();
        /// <summary>
        /// Construtor que Define a String de Conexão com o banco de dados
        /// </summary>
        public Conexao()
        {
            con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BaseDadosDesafio;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }
        /// <summary>
        /// Método para Conectar com o Banco de dados
        /// </summary>
        /// <returns></returns>
        public SqlConnection conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed) {
                con.Open();
            }

            return con;
        }
        /// <summary>
        /// Método para Desconectar do Banco de Dados
        /// </summary>
        public void desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
