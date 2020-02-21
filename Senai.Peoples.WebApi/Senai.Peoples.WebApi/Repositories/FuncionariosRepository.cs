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

        public void Deletar(int id)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada passando o valor como parâmetro
                string queryDelete = "DELETE FROM Funcionarios WHERE ID_Funcionarios = @ID";

                // Declara o comando passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void AtualizarIdCorpo(FuncionariosDomain funcionarios)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string queryUpdate = "UPDATE Funcionarios SET Nome = @Nome,Sobrenome = @Sobrenome WHERE ID_Funcionarios = @ID";

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    // Passa os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@ID", funcionarios.ID_Funcionarios);
                    cmd.Parameters.AddWithValue("@Nome", funcionarios.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionarios.Sobrenome);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void AtualizarIdUrl(int id, FuncionariosDomain funcionarios)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string queryUpdate = "UPDATE Funcionarios SET Nome = @Nome,Sobrenome = @Sobrenome WHERE ID_Funcionarios = @ID";

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    // Passa os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Nome", funcionarios.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionarios.Sobrenome);


                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public FuncionariosDomain BuscarPorId(int id)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string querySelectById = "SELECT ID_Funcionarios,Nome,Sobrenome from Funcionarios WHERE ID_Funcionarios = @ID";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader fazer a leitura no banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Executa a query
                    rdr = cmd.ExecuteReader();

                    // Caso a o resultado da query possua registro
                    if (rdr.Read())
                    {
                        // Cria um objeto 
                        FuncionariosDomain funcionario = new FuncionariosDomain
                        {                   

                            ID_Funcionarios = Convert.ToInt32(rdr[0]),

                            Nome = rdr["Nome"].ToString(),

                            Sobrenome = rdr["Sobrenome"].ToString()
                        };

                        // Retorna os funcionarios com os dados obtidos
                        return funcionario;
                    }

                    // Caso o resultado da query não possua registros, retorna null
                    return null;
                }
            }
        }


        public void Cadastrar(FuncionariosDomain funcionarios)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryInsert = "INSERT INTO Funcionarios(Nome,Sobrenome) VALUES (@Nome,@Sobrenome)";


                SqlCommand cmd = new SqlCommand(queryInsert, con);

                cmd.Parameters.AddWithValue("@Nome", funcionarios.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome", funcionarios.Sobrenome);

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

    

