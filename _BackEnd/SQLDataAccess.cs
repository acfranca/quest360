using System;
using System.Data;
using System.Data.SqlClient;
using _WebControls;

namespace QuestRep._BackEnd
{
    public class SQLDataAccess
    {
        public static SqlConnection GetSqlServerConnection()
        {
            SqlConnection conn = new SqlConnection(GetConnectionString());
            return conn;
        }

        private static string GetConnectionString()
        {
            return new Funcoes().DecryptString(System.Configuration.ConfigurationManager.AppSettings["SQLConnectOn"]);
        }

        public static SqlParameter CreateParameter(string pNome, SqlDbType pTipo, int pTamanho, ParameterDirection pDirecao, object pValor)
        {
            SqlParameter parameter = new SqlParameter(pNome, pTipo);
            if (pTamanho > 0)
                parameter.Size = pTamanho;

            parameter.Direction = pDirecao;

            if (pValor != null)
                parameter.Value = pValor;
            else
                parameter.Value = DBNull.Value;

            return parameter;
        }

        public static void ExecuteNonQuery(string commandText, SqlParameter[] parametros)
        {
            SqlConnection conn = GetSqlServerConnection();

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(commandText);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter newParam in parametros)
                {
                    cmd.Parameters.Add(newParam);
                }

                //Execute the command
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                if (sqlEx.Number == 2627) // Erro de primary key
                {
                    throw new ApplicationException("Não é possível incluir o registro pois existe outro registro com o mesmo código. Favor verificar.");
                }
                else if (sqlEx.Number == 547) // Erro de foreign key na exclusao
                {
                    //throw new ApplicationException("Não é possível excluir o registro pois existem tabelas filho associadas. Favor verificar.");
                    throw new ApplicationException("547");
                }
                else
                {
                    throw sqlEx;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public static string ExecuteNonQuery(string commandText, SqlParameter[] parametros, string pOutput)
        {
            SqlConnection conn = GetSqlServerConnection();

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(commandText);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter newParam in parametros)
                {
                    cmd.Parameters.Add(newParam);
                }

                //Execute the command
                cmd.ExecuteNonQuery();
                return cmd.Parameters[pOutput].Value.ToString();
            }
            catch (SqlException sqlEx)
            {
                if (sqlEx.Number == 2627) // Erro de primary key
                {
                    throw new ApplicationException("Não é possível incluir o registro pois existe outro registro com o mesmo código. Favor verificar.");
                }
                else if (sqlEx.Number == 547) // Erro de foreign key na exclusao
                {
                    //throw new ApplicationException("Não é possível excluir o registro pois existem tabelas filho associadas. Favor verificar.");
                    throw new ApplicationException("547");
                }
                else
                {
                    throw sqlEx;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public static void ExecuteNonQuery(string commandText, SqlParameter[] parametros, SqlConnection conn, SqlTransaction tran)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(commandText);
                cmd.Connection = conn;
                cmd.Transaction = tran;
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter newParam in parametros)
                {
                    cmd.Parameters.Add(newParam);
                }

                //Execute the command
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ExecuteNonQuery(string commandText, SqlParameter[] parametros, string pOutput, SqlConnection conn, SqlTransaction tran)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(commandText);
                cmd.Connection = conn;
                cmd.Transaction = tran;
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter newParam in parametros)
                {
                    cmd.Parameters.Add(newParam);
                }

                //Execute the command
                cmd.ExecuteNonQuery();

                return cmd.Parameters[pOutput].Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable ExecuteDataTable(string commandText, SqlParameter[] parametros)
        {
            DataTable dtRetorno = new DataTable();
            SqlConnection conn = GetSqlServerConnection();

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(commandText);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter newParam in parametros)
                {
                    cmd.Parameters.Add(newParam);
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtRetorno);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return dtRetorno;
        }

        public static DataTable ExecuteDataTable(string commandText, SqlParameter[] parametros, SqlConnection conn, SqlTransaction tran)
        {
            DataTable dtRetorno = new DataTable();

            try
            {
                SqlCommand cmd = new SqlCommand(commandText);
                cmd.Connection = conn;
                cmd.Transaction = tran;
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter newParam in parametros)
                {
                    cmd.Parameters.Add(newParam);
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtRetorno);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtRetorno;
        }

        public static object ExecuteScalar(string commandText, SqlParameter[] parametros)
        {
            SqlConnection conn = GetSqlServerConnection();

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(commandText);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter newParam in parametros)
                {
                    cmd.Parameters.Add(newParam);
                }

                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public static object ExecuteScalar(string commandText, SqlParameter[] parametros, SqlConnection conn, SqlTransaction tran)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(commandText);
                cmd.Connection = conn;
                cmd.Transaction = tran;
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter newParam in parametros)
                {
                    cmd.Parameters.Add(newParam);
                }

                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static object ExecuteQueryCode_Update(string commandText, SqlParameter[] parametros)
        {
            SqlConnection conn = GetSqlServerConnection();

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(commandText);
                cmd.Connection = conn;

                foreach (SqlParameter newParam in parametros)
                {
                    cmd.Parameters.Add(newParam);
                }

                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public static object ExecuteQueryCode_Update(string commandText)
        {
            SqlConnection conn = GetSqlServerConnection();

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(commandText);
                cmd.Connection = conn;

                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public static DataTable ExecuteQueryCode_Select(string commandText, SqlParameter[] parametros)
        {
            DataTable dtRetorno = new DataTable();
            SqlConnection conn = GetSqlServerConnection();

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(commandText);
                cmd.Connection = conn;

                foreach (SqlParameter newParam in parametros)
                {
                    cmd.Parameters.Add(newParam);
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtRetorno);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return dtRetorno;
        }

        public static DataTable ExecuteQueryCode_Select(string commandText)
        {
            DataTable dtRetorno = new DataTable();
            SqlConnection conn = GetSqlServerConnection();

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(commandText);
                cmd.Connection = conn;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtRetorno);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return dtRetorno;
        }
    }
}