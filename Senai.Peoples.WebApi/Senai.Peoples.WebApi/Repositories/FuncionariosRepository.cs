using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositório
{
    public class FuncionariosRepository : IFuncionarios

    {
        private string stringConexao = "Data Source=DEV1301\\SQLEXPRESS; initial catalog=M_Peoples; user Id=sa; pwd=sa@132";

        public void Cadastrar(FuncionariosDomain funcionarios)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryInsert = "INSERT INTO Funcionarios(@Nome,@Socrenome) VALUES (@Nome,@Sobrenome)";


                SqlCommand cmd = new SqlCommand(queryInsert, con);

                cmd.Parameters.AddWithValue("@Nome", Funcionarioes.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome",Funcionarios.Sobrenome);

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public List<FuncionariosDomain> Listar()
        {
            // Cria uma lista filmes onde serão armazenados os dados
            List<FuncionariosDomain> funcionarios = new List<FuncionariosDomain>();

            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT ID_Funcionarios,Nome,Sobrenome FROM Funcionarios";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader para percorrer a tabela do banco
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    // Executa a query
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para ler, o laço se repete
                    while (rdr.Read())
                    {

                        FuncionariosDomain funcionario  = new FuncionariosDomain
                        {
                            ID_Funcionarios = Convert.ToInt32(rdr[0]),

                            Nome = rdr["Nome"].ToString(),

                            Sobrenome = rdr["Sobrenome"].ToString()
                        };

                        // Adiciona o filme criado à tabela filmes
                        funcionarios.Add(funcionario);
                    }
                }
            }
            // Retorna a lista de filmes
            return funcionarios;
        }
    }
}

    

