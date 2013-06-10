using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebService
{
    public class UsuarioService : IUsuarioService
    {
        public bool Add(Model.UsuarioModel data)
        {
            bool result = false;
            try
            {
                var conn = Utils.HelperSettings.ReadString("ConnectionString");
                var dal = new DAL.UsuarioDAL(conn);
                dal.Insert(data);
                result = true;
            }
            catch (Exception ex)
            {
                Utils.HelperLog.WriteText(ex, "UsuarioService.Add");
            }
            return result;
        }

        public bool Update(Model.UsuarioModel data)
        {
            bool result = false;
            try
            {
                var conn = Utils.HelperSettings.ReadString("ConnectionString");
                var dal = new DAL.UsuarioDAL(conn);
                dal.Update(data);
                result = true;
            }
            catch (Exception ex)
            {
                Utils.HelperLog.WriteText(ex, "UsuarioService.Update");
            }
            return result;
        }

        public bool Delete(int codigo)
        {
            bool result = false;
            try
            {
                var conn = Utils.HelperSettings.ReadString("ConnectionString");
                var dal = new DAL.UsuarioDAL(conn);
                dal.Delete(codigo);
                result = true;
            }
            catch (Exception ex)
            {
                Utils.HelperLog.WriteText(ex, "UsuarioService.Delete");
            }
            return result;
        }

        public List<Model.UsuarioModel> List(int codigo)
        {
            List<Model.UsuarioModel> result = new List<Model.UsuarioModel>();
            try
            {
                var conn = Utils.HelperSettings.ReadString("ConnectionString");
                var dal = new DAL.UsuarioDAL(conn);
                var temp = dal.Select(codigo, string.Empty);
                if (temp != null)
                {
                    result.AddRange(temp);
                }
            }
            catch (Exception ex)
            {
                Utils.HelperLog.WriteText(ex, "UsuarioService.List");
            }
            return result;
        }

        public List<Model.UsuarioModel> Find(string login)
        {
            List<Model.UsuarioModel> result = new List<Model.UsuarioModel>();
            try
            {
                var conn = Utils.HelperSettings.ReadString("ConnectionString");
                var dal = new DAL.UsuarioDAL(conn);
                var temp = dal.Select(0, login);
                if (temp != null)
                {
                    result.AddRange(temp);
                }
            }
            catch (Exception ex)
            {
                Utils.HelperLog.WriteText(ex, "UsuarioService.Find");
            }
            return result;
        }
    }
}
