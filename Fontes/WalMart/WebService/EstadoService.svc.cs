using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebService
{
    public class EstadoService : IEstadoService
    {
        public bool Add(Model.EstadoModel data)
        {
            bool result = false;
            try
            {
                var conn = Utils.HelperSettings.ReadString("ConnectionString");
                var dal = new DAL.EstadoDAL(conn);
                dal.Insert(data);
                result = true;
            }
            catch (Exception ex)
            {
                Utils.HelperLog.WriteText(ex, "EstadoService.Add");
            }
            return result;
        }

        public bool Update(Model.EstadoModel data)
        {
            bool result = false;
            try
            {
                var conn = Utils.HelperSettings.ReadString("ConnectionString");
                var dal = new DAL.EstadoDAL(conn);
                dal.Update(data);
                result = true;
            }
            catch (Exception ex)
            {
                Utils.HelperLog.WriteText(ex, "EstadoService.Update");
            }
            return result;
        }

        public bool Delete(int codigo)
        {
            bool result = false;
            try
            {
                var conn = Utils.HelperSettings.ReadString("ConnectionString");
                var dal = new DAL.EstadoDAL(conn);
                dal.Delete(codigo);
                result = true;
            }
            catch (Exception ex)
            {
                Utils.HelperLog.WriteText(ex, "EstadoService.Delete");
            }
            return result;
        }

        public List<Model.EstadoModel> List(int codigo)
        {
            List<Model.EstadoModel> result = new List<Model.EstadoModel>();
            try
            {
                var conn = Utils.HelperSettings.ReadString("ConnectionString");
                var dal = new DAL.EstadoDAL(conn);
                var temp = dal.Select(codigo, string.Empty);
                if (temp != null)
                {
                    result.AddRange(temp);
                }
            }
            catch (Exception ex)
            {
                Utils.HelperLog.WriteText(ex, "EstadoService.List");
            }
            return result;
        }
    }
}
