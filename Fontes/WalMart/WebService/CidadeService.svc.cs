using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CidadeService" in code, svc and config file together.
    public class CidadeService : ICidadeService
    {
        public bool Add(Model.CidadeModel data)
        {
            bool result = false;
            try
            {
                var conn = Utils.HelperSettings.ReadString("ConnectionString");
                var dal = new DAL.CidadeDAL(conn);
                dal.Insert(data);
                result = true;
            }
            catch (Exception ex)
            {
                Utils.HelperLog.WriteText(ex, "CidadeService.Add");
            }
            return result;
        }

        public bool Update(Model.CidadeModel data)
        {
            bool result = false;
            try
            {
                var conn = Utils.HelperSettings.ReadString("ConnectionString");
                var dal = new DAL.CidadeDAL(conn);
                dal.Update(data);
                result = true;
            }
            catch (Exception ex)
            {
                Utils.HelperLog.WriteText(ex, "CidadeService.Update");
            }
            return result;
        }

        public bool Delete(int codigo)
        {
            bool result = false;
            try
            {
                var conn = Utils.HelperSettings.ReadString("ConnectionString");
                var dal = new DAL.CidadeDAL(conn);
                dal.Delete(codigo);
                result = true;
            }
            catch (Exception ex)
            {
                Utils.HelperLog.WriteText(ex, "CidadeService.Delete");
            }
            return result;
        }

        public List<Model.CidadeModel> List(int codigo)
        {
            List<Model.CidadeModel> result = new List<Model.CidadeModel>();
            try
            {
                var conn = Utils.HelperSettings.ReadString("ConnectionString");
                var dal = new DAL.CidadeDAL(conn);
                var temp = dal.Select(codigo, string.Empty);
                if (temp != null)
                {
                    result.AddRange(temp);
                }
            }
            catch (Exception ex)
            {
                Utils.HelperLog.WriteText(ex, "CidadeService.List");
            }
            return result;
        }
    }
}
