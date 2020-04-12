using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ProjetoAPI.Models;
using System.Data;

namespace ProjetoAPI.DAO
{
    public class usuarioDAO
    {
        string connectionString = "Server=DESKTOP-IKUEHMR;Database=Projeto;Integrated Security=true;";

        public int GravaUsuario(Usuario u)
        {
            int retorno = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "Insert into Usuario (login,senha) Values(@login, @senha)";
                SqlCommand comando = new SqlCommand(comandoSQL, con);
                comando.CommandType = CommandType.Text;

                comando.Parameters.AddWithValue("@login", u.Login);
                comando.Parameters.AddWithValue("@senha", u.Senha);

                try
                {
                    con.Open();
                    retorno = comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
            return retorno;
        }
        public int DeletaUsuario(int id)
        {
            int retorno = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "Delete from Usuario where id = @ID";
                SqlCommand comando = new SqlCommand(comandoSQL, con);
                comando.CommandType = CommandType.Text;

                comando.Parameters.AddWithValue("@ID", id);

                try
                {
                    con.Open();
                    retorno = comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
            return retorno;
        }
        public bool ValidaUsuario(Usuario u)
        {
            List<Usuario> usuarioList = new List<Usuario>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "Select login, senha from Usuario where login = @login and senha = @senha";
                SqlCommand comando = new SqlCommand(comandoSQL, con);
                comando.CommandType = CommandType.Text;

                comando.Parameters.AddWithValue("@login", u.Login);
                comando.Parameters.AddWithValue("@senha", u.Senha);

                try
                {
                    con.Open();
                    SqlDataReader rdr = comando.ExecuteReader();

                    while (rdr.Read())
                    {
                        Usuario usuario = new Usuario();

                        usuario.Login = rdr["login"].ToString();
                        usuario.Senha = rdr["senha"].ToString();

                        usuarioList.Add(usuario);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
            foreach(var user in usuarioList)
            {
                if (user.Login == u.Login && user.Senha == u.Senha)
                {
                    return true;
                }
            }
            return false;
        }
        public bool ValidaLogin(string login)
        {
            List<Usuario> usuarioList = new List<Usuario>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "SELECT login from Usuario";
                SqlCommand comando = new SqlCommand(comandoSQL, con);
                comando.CommandType = CommandType.Text;

                try
                {
                    con.Open();
                    SqlDataReader rdr = comando.ExecuteReader();

                    while (rdr.Read())
                    {
                        Usuario usuario = new Usuario();

                        usuario.Login = rdr["login"].ToString();

                        usuarioList.Add(usuario);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }

            foreach (var user in usuarioList)
            {
                if (user.Login == login)
                {
                    return true;
                }

            }
            return false;
        }
    }
}
