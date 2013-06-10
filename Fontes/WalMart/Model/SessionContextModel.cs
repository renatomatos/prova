using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model
{
    public static class SessionContextModel
    {
        public static string UserName
        {
            get
            {
                if ((HttpContext.Current != null) && (HttpContext.Current.Session != null))
                {
                    if (HttpContext.Current.Session["UserName"] == null)
                    {
                        HttpContext.Current.Session["UserName"] = "";
                    }
                    return HttpContext.Current.Session["UserName"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                if ((HttpContext.Current != null) && (HttpContext.Current.Session != null))
                {
                    HttpContext.Current.Session["UserName"] = value;
                }
            }
        }

        public static void Clear()
        {
            UserName = string.Empty;

            if ((HttpContext.Current != null) && (HttpContext.Current.Session != null))
            {
                HttpContext.Current.Session.RemoveAll();
                HttpContext.Current.Session.Abandon();
            }
        }

        public static bool IsValid
        {
            get
            {
                if (string.IsNullOrEmpty(SessionContextModel.UserName))
                {
                    return false;
                }

                return true;
            }
        }

    }
}