using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class FuncionarioRepository
    {

        List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();


        private string StringConexao =
            "Data Source= .\\SqlExpress; Initial catalog=M_Peoples; User Id=sa; Pwd=132;";

        public List<FuncionarioDomain> Listar()
        {


            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT IdFuncionario, NomeFuncionario, SobrenomeFuncionario FROM Funcionarios ORDER BY IdFuncionario ASC";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"]),
                            NomeFuncionario = rdr["NomeFuncionario"].ToString(),
                            SobrenomeFuncionario = rdr["SobrenomeFuncionario"].ToString()
                        };
                        funcionarios.Add(funcionario);
                    }

                }

            }
            return funcionarios;
        }


        public FuncionarioDomain BuscarPorId(int id)
        {
            string Query = "SELECT IdFuncionario, NomeFuncionario,SobrenomeFuncionario FROM Funcionarios WHERE IdFuncionario = @IdFuncionario";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdFuncionario", id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            FuncionarioDomain funcionario = new FuncionarioDomain
                            {
                                IdFuncionario = Convert.ToInt32(sdr["IdFuncionario"]),
                                NomeFuncionario = sdr["NomeFuncionario"].ToString(),
                                SobrenomeFuncionario = sdr["SobrenomeFuncionario"].ToString()
                            };
                            return funcionario;
                        }
                    }
                    return null;
                }
            }
        }

        public void Deletar(int id)
        {
            string Query = "DELETE FROM Funcionarios WHERE IdFuncionario = @IdFuncionario";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {

                SqlCommand cmd = new SqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@IdFuncionario", id);
                con.Open();

                cmd.ExecuteNonQuery();

            }
        }

        public void Cadastrar(FuncionarioDomain funcionario)
        {
            string Query = "INSERT INTO Funcionarios (NomeFuncionario,SobrenomeFuncionario) VALUES (@NomeFuncionario,@SobrenomeFuncionario)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@NomeFuncionario", funcionario.NomeFuncionario);
                cmd.Parameters.AddWithValue("@SobrenomeFuncionario", funcionario.SobrenomeFuncionario);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public void Alterar(FuncionarioDomain funcionarioDomain)
        {
            string Query = "UPDATE Funcionarios SET NomeFuncionario = @NomeFuncionario, SobrenomeFuncionario = @SobrenomeFuncionario Where IdFuncionario = @IdFuncionario";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@NomeFuncionario", funcionarioDomain.NomeFuncionario);
                cmd.Parameters.AddWithValue("@SobrenomeFuncionario", funcionarioDomain.SobrenomeFuncionario);
                cmd.Parameters.AddWithValue("@IdFuncionario", funcionarioDomain.IdFuncionario);

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public FuncionarioDomain BuscarPorNome(string nomeFuncionario)
        {
            string Query = "SELECT IdFuncionario, NomeFuncionario,SobrenomeFuncionario FROM Funcionarios WHERE NomeFuncionario like @NomeFuncionario";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@NomeFuncionario", nomeFuncionario);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            FuncionarioDomain funcionario = new FuncionarioDomain
                            {
                                IdFuncionario = Convert.ToInt32(sdr["IdFuncionario"]),
                                NomeFuncionario = sdr["NomeFuncionario"].ToString(),
                                SobrenomeFuncionario = sdr["SobrenomeFuncionario"].ToString()
                            };
                            return funcionario;
                        }
                    }
                    return null;
                }
            }
        }
    }
}
