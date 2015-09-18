using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace THU.LabSystem.AuthExt
{
    public class AuthExtCookie
    {
        private static string RoleCookieKey = "LAB_ROLE";
        public static void SetRole(int role)
        {
            System.Web.HttpContext ctx = System.Web.HttpContext.Current;
            if (ctx != null)
            {
                if (ctx.Request.Cookies[AuthExtCookie.RoleCookieKey] == null)
                {
                    ctx.Response.Cookies.Add(new HttpCookie(AuthExtCookie.RoleCookieKey, NHExt.Runtime.Util.EncryptHelper.Encrypt(role.ToString())));
                }
                else
                {
                    ctx.Response.Cookies[AuthExtCookie.RoleCookieKey].Value = NHExt.Runtime.Util.EncryptHelper.Encrypt(role.ToString());
                }
                ctx.Response.Cookies[AuthExtCookie.RoleCookieKey].Expires = DateTime.Now.AddDays(1);
            }
        }

        public static int GetRole()
        {
            System.Web.HttpContext ctx = System.Web.HttpContext.Current;
            if (ctx != null)
            {
                if (ctx.Request.Cookies[AuthExtCookie.RoleCookieKey] == null)
                {
                    return -1;
                }
                else
                {
                    try
                    {
                        string roleStr = NHExt.Runtime.Util.EncryptHelper.Decrypt(ctx.Request.Cookies[AuthExtCookie.RoleCookieKey].Value);
                        return Convert.ToInt32(roleStr);
                    }
                    catch (Exception ex)
                    {
                        return -1;
                    }
                }
            }
            else
            {
                return -1;
            }
        }

        public static void Clear()
        {
            System.Web.HttpContext ctx = System.Web.HttpContext.Current;
            if (ctx != null)
            {
                if (ctx.Request.Cookies[AuthExtCookie.RoleCookieKey] != null)
                {
                    try
                    {
                        ctx.Response.Cookies.Remove(AuthExtCookie.RoleCookieKey);
                        NHExt.Runtime.Auth.AuthContext.ClearContext();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }

        }

        public static bool IsAuth()
        {
            if (NHExt.Runtime.Auth.AuthContext.GetInstance().IsAuth() && AuthExt.AuthExtCookie.GetRole() > 0)
            {
                return true;
            }
            return false;
        }
    }
}