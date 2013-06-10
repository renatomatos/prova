using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class CidadeDAL : BaseDAL
    {
        public CidadeDAL(string connectionString) : base(connectionString) { }

        public void Insert(Model.CidadeModel data)
        {
            try
            {
                System.Data.SqlClient.SqlParameter[] parameters = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@Capital", data.Capital ? "S" : "N" ),
                    new System.Data.SqlClient.SqlParameter("@Estado", data.EstadoCodigo),
                    new System.Data.SqlClient.SqlParameter("@Nome", data.Nome)
                };

                ExecuteCommand("usp_cidade_insert", parameters);
            }
            catch (Exception ex)
            {
                Utils.HelperLog.WriteText(ex, "CidadeDAL.Insert");
            }
        }

        public void Update(Model.CidadeModel data)
        {
            try
            {
                System.Data.SqlClient.SqlParameter[] parameters = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@Codigo", data.Codigo),
                    new System.Data.SqlClient.SqlParameter("@Capital", data.Capital ? "S" : "N" ),
                    new System.Data.SqlClient.SqlParameter("@Estado", data.EstadoCodigo),
                    new System.Data.SqlClient.SqlParameter("@Nome", data.Nome)
                };

                ExecuteCommand("usp_cidade_update", parameters);
            }
            catch (Exception ex)
            {
                Utils.HelperLog.WriteText(ex, "CidadeDAL.Update");
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

                ExecuteCommand("usp_cidade_delete", parameters);
            }
            catch (Exception ex)
            {
                Utils.HelperLog.WriteText(ex, "CidadeDAL.Delete");
            }
        }

        public List<Model.CidadeModel> Select(int codigo, string nome)
        {
            List<Model.CidadeModel> result = new List<Model.CidadeModel>();
            try
            {
                System.Data.SqlClient.SqlParameter[] parameters = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@Codigo", codigo),
                    new System.Data.SqlClient.SqlParameter("@Nome", nome)
                };

                ExecuteReader("usp_cidade_select", parameters, s =>
                {
                    result.Add(new Model.CidadeModel(s));
                });
            }
            catch (Exception ex)
            {
                Utils.HelperLog.WriteText(ex, "CidadeDAL.Select");
            }
            return result;
        }

    }
}
