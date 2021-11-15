using pessoa.api.Business.DAL;
using pessoa.api.Business.Entity;
using pessoa.api.Configuration;
using pessoa.api.Model.Pessoa;
using System;
using System.Data;
using System.Data.Odbc;
using System.Threading.Tasks;

namespace pessoa.api.Infraestructura.Data.DAL
{
    public class PessoaDao : IPessoaDao
    {
        public void Cadastrar(Pessoa p, Endereco e, Telefone t, TipoTelefone tt)
        {
            using (OdbcConnection conn = DbConnectionFactory.CreateConnection())
            {
                conn.Open();
                try
                {
                    OdbcCommand cmd = new OdbcCommand("{CALL Cadastrar_Pessoa(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)}", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Nome", p.Nome);
                    cmd.Parameters.AddWithValue("@Cpf", p.Cpf);
                    cmd.Parameters.AddWithValue("@Logradouro", e.Logradouro);
                    cmd.Parameters.AddWithValue("@Numero", e.Numero);
                    cmd.Parameters.AddWithValue("@Cep", e.Cep);
                    cmd.Parameters.AddWithValue("@Bairro", e.Bairro);
                    cmd.Parameters.AddWithValue("@Cidade", e.Cidade);
                    cmd.Parameters.AddWithValue("@Estado", e.Estado);
                    cmd.Parameters.AddWithValue("@Tipo", tt.Tipo);
                    cmd.Parameters.AddWithValue("@Numero", t.Numero);
                    cmd.Parameters.AddWithValue("@Ddd", t.Ddd);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public void Atualizar(long cpf, Pessoa p, Endereco e, Telefone t, TipoTelefone tt)
        {
            using (OdbcConnection conn = DbConnectionFactory.CreateConnection())
            {
                conn.Open();
                try
                {
                    OdbcCommand cmd = new OdbcCommand("{CALL Atualizar_Pessoa(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)}", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Cpf", cpf);
                    cmd.Parameters.AddWithValue("@Nome", p.Nome);
                    cmd.Parameters.AddWithValue("@Logradouro", e.Logradouro);
                    cmd.Parameters.AddWithValue("@Numero", e.Numero);
                    cmd.Parameters.AddWithValue("@Cep", e.Cep);
                    cmd.Parameters.AddWithValue("@Bairro", e.Bairro);
                    cmd.Parameters.AddWithValue("@Cidade", e.Cidade);
                    cmd.Parameters.AddWithValue("@Estado", e.Estado);
                    cmd.Parameters.AddWithValue("@Tipo", tt.Tipo);
                    cmd.Parameters.AddWithValue("@Numero", t.Numero);
                    cmd.Parameters.AddWithValue("@Ddd", t.Ddd);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public void Deletar(long cpf)
        {
            using (OdbcConnection conn = DbConnectionFactory.CreateConnection())
            {
                conn.Open();
                try
                {
                    OdbcCommand cmd = new OdbcCommand("{CALL Deletar_Pessoa(?)}", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Cpf", cpf);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public async Task<PessoaViewModelOutput> ObterPessoa(long cpf)
        {

            using (OdbcConnection conn = DbConnectionFactory.CreateConnection())
            {
                OdbcCommand cmd = new OdbcCommand("{CALL Consultar_Pessoa(?)}", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cpf", cpf);

                conn.Open();

                OdbcDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    PessoaViewModelOutput pessoa = new PessoaViewModelOutput();

                    pessoa.Nome = dr["Nome"] as string;
                    pessoa.Cpf = cpf;
                    pessoa.Logradouro = dr["Logradouro"] as string;
                    pessoa.Numero = Convert.ToInt32(dr["Numero"]);
                    pessoa.Cep = Convert.ToInt32(dr["Cep"]);
                    pessoa.Bairro = dr["Bairro"] as string;
                    pessoa.Cidade = dr["Cidade"] as string;
                    pessoa.Estado = dr["Estado"] as string;
                    pessoa.NumeroTelefone = Convert.ToInt32(dr["Numero"]);
                    pessoa.Ddd = Convert.ToInt32(dr["Ddd"]);
                    pessoa.Tipo = dr["Tipo"] as string;

                    return pessoa;
                }
                return null;
            }
        }
    }
}
