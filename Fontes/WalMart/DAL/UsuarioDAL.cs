using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class UsuarioDAL : BaseDAL
    {
        public UsuarioDAL(string connectionString) : base(connectionString) { }
        
        public void Insert(Model.UsuarioModel data)
        {
            try
            {
                System.Data.SqlClient.SqlParameter[] parameters = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@Login", data.Login),
                    new System.Data.SqlClient.SqlParameter("@Nome", data.Nome),
                    new System.Data.SqlClient.SqlParameter("@Senha", data.Senha)
                };

                ExecuteCommand("usp_usuario_insert", parameters);
            }
            catch (Exception ex)
            {
                Utils.HelperLog.WriteText(ex, "UsuarioDAL.Insert");
            }
        }

        public void Update(Model.UsuarioModel data)
        {
            try
            {
                System.Data.SqlClient.SqlParameter[] parameters = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@Id", data.Id),
                    new System.Data.SqlClient.SqlParameter("@Nome", data.Nome),
                    new System.Data.SqlClient.SqlParameter("@Senha", data.Senha)
                };

                ExecuteCommand("usp_usuario_update", parameters);
            }
            catch (Exception ex)
            {
                Utils.HelperLog.WriteText(ex, "UsuarioDAL.Update");
            }
        }

        public void Delete(int codigo)
        {
            try
            {
                System.Data.SqlClient.SqlParameter[] parameters = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@Id", codigo)
                };

                ExecuteCommand("usp_usuario_delete", parameters);
            }
            catch (Exception ex)
            {
                Utils.HelperLog.WriteText(ex, "UsuarioDAL.Delete");
            }
        }

        public List<Model.UsuarioModel> Select(int codigo, string login)
        {
            List<Model.UsuarioModel> result = new List<Model.UsuarioModel>();
            try
            {
                System.Data.SqlClient.SqlParameter[] parameters = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@Id", codigo),
                    new System.Data.SqlClient.SqlParameter("@Login", login)
                };

                ExecuteReader("usp_usuario_select", parameters, s => 
                {
                    result.Add(new Model.UsuarioModel(s));
                });
            }
            catch (Exception ex)
            {
                Utils.HelperLog.WriteText(ex, "UsuarioDAL.Select");
            }
            return result;
        }

    }
}
