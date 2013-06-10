using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class EstadoDAL : BaseDAL
    {
        public EstadoDAL(string connectionString) : base(connectionString) { }
        
        public void Insert(Model.EstadoModel data)
        {
            try
            {
                System.Data.SqlClient.SqlParameter[] parameters = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@Pais", data.Pais),
                    new System.Data.SqlClient.SqlParameter("@Nome", data.Nome),
                    new System.Data.SqlClient.SqlParameter("@Sigla", data.Sigla),
                    new System.Data.SqlClient.SqlParameter("@Regiao", data.Regiao)
                };

                ExecuteCommand("usp_estado_insert", parameters);
            }
            catch (Exception ex)
            {
                Utils.HelperLog.WriteText(ex, "EstadoDAL.Insert");
            }
        }

        public void Update(Model.EstadoModel data)
        {
            try
            {
                System.Data.SqlClient.SqlParameter[] parameters = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@Codigo", data.Codigo),
                    new System.Data.SqlClient.SqlParameter("@Pais", data.Pais),
                    new System.Data.SqlClient.SqlParameter("@Nome", data.Nome),
                    new System.Data.SqlClient.SqlParameter("@Sigla", data.Sigla),
                    new System.Data.SqlClient.SqlParameter("@Regiao", data.Regiao)
                };

                ExecuteCommand("usp_estado_update", parameters);
            }
            catch (Exception ex)
            {
                Utils.HelperLog.WriteText(ex, "EstadoDAL.Update");
            }
        }

        public void Delete(int codigo)
        {
            try
            {
                System.Data.SqlClient.SqlParameter[] parameters = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@Codigo", codigo)
                };

                ExecuteCommand("usp_estado_delete", parameters);
            }
            catch (Exception ex)
            {
                Utils.HelperLog.WriteText(ex, "EstadoDAL.Delete");
            }
        }

        public List<Model.EstadoModel> Select(int codigo, string nome)
        {
            List<Model.EstadoModel> result = new List<Model.EstadoModel>();
            try
            {
                System.Data.SqlClient.SqlParameter[] parameters = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@Codigo", codigo),
                    new System.Data.SqlClient.SqlParameter("@Nome", nome)
                };

                ExecuteReader("usp_estado_select", parameters, s => 
                {
                    result.Add(new Model.EstadoModel(s));
                });
            }
            catch (Exception ex)
            {
                Utils.HelperLog.WriteText(ex, "EstadoDAL.Select");
            }
            return result;
        }

    }
}
