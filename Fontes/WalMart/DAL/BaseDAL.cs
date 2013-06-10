using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public delegate void ReadingEventHandler(System.Data.SqlClient.SqlDataReader rd);
    
    public class BaseDAL
    {
        private System.Data.SqlClient.SqlConnection _conn = null;

        public BaseDAL(string connectionString)
        {
            _conn = new System.Data.SqlClient.SqlConnection(connectionString);
        }

        public void ExecuteCommand(string procName, System.Data.SqlClient.SqlParameter[] parameters)
        {
            // abre a conexão para ser finalizada após a execução do command
            _conn.Open();
            try
            {
                // cria uma transação para o command
                var trans = _conn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                try
                {
                    var cmd = _conn.CreateCommand();
                    cmd.Transaction = trans;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = procName;
                    
                    // se existem parameteros
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    cmd.ExecuteNonQuery();

                    // comita os dados
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    // se a transação existe, finaliza
                    if (trans != null)
                    {
                        trans.Rollback();
                    }

                    Utils.HelperLog.WriteText(ex, "BaseDAL.ExecuteCommand");
                }
            }
            finally 
            {
                // fecha a conexao para liberar o sqlpool
                _conn.Close();
            }
        }

        public void ExecuteReader(string procName, System.Data.SqlClient.SqlParameter[] parameters, ReadingEventHandler e)
        {
            // abre a conexão para ser finalizada após a execução do command
            _conn.Open();
            try
            {
                try
                {
                    var cmd = _conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = procName;

                    // se existem parameteros
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    if (e != null)
                    {
                        using (System.Data.SqlClient.SqlDataReader rd = cmd.ExecuteReader())
                        {
                            try
                            {
                                while (rd.Read())
                                {
                                    e.Invoke(rd);
                                }
                            }
                            finally
                            {
                                rd.Close();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Utils.HelperLog.WriteText(ex, "BaseDAL.ExecuteReader");
                }
            }
            finally
            {
                // fecha a conexao para liberar o sqlpool
                _conn.Close();
            }
        }

    }
}
