using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.App.Library.Core
{
    public class GenericUser
    {
        public int Id { get; set; }
        public string LoginName { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public bool IsSiteAdmin { get; set; }
        public List<string> Groups { get; set; }

        public GenericUser(string loginName)
        {
            this.LoginName = loginName;
        }

        public GenericUser(System.Security.Principal.IPrincipal principal)
        {
            Groups = new List<string>();
            if (principal != null && principal.Identity != null)
            {
                this.LoginName = principal.Identity.Name;
                this.Title = principal.Identity.Name;
            }
        }

#if SPAPP
        public GenericUser(Microsoft.SharePoint.Client.User user)
        {
            Groups = new List<string>();
            if (user != null)
            {
                if (user.IsPropertyAvailable("LoginName"))
                    this.LoginName = user.LoginName;
                if (user.IsPropertyAvailable("Email"))
                    this.Email = user.Email;
                if (user.IsPropertyAvailable("IsSiteAdmin"))
                    this.IsSiteAdmin = user.IsSiteAdmin;
                if (user.IsPropertyAvailable("Title"))
                    this.Title = user.Title;
                if (user.IsPropertyAvailable("Id"))
                    this.Id = user.Id;
            }
        }

        public static Core.GenericUser GetCurrentUser(Microsoft.SharePoint.Client.ClientContext clientContext, dynamic ViewBag)
        {
            Core.GenericUser currentUser = null;
            Microsoft.SharePoint.Client.User spUser = null;

            //using (var clientContext = spContext.CreateUserClientContextForSPHost())
            {
                if (clientContext != null)
                {
                    spUser = clientContext.Web.CurrentUser;

                    clientContext.Load(spUser, user => user.Title, user => user.IsSiteAdmin, user => user.UserId, user => user.LoginName, user => user.Id);
                    clientContext.ExecuteQuery();
                    if (spUser != null)
                    {
                        Microsoft.SharePoint.Client.GroupCollection groups = spUser.Groups;
                        clientContext.Load(groups);
                        clientContext.ExecuteQuery();

                        currentUser = new Core.GenericUser(spUser);
                        if (ViewBag != null)
                        {
                            ViewBag.UserName = spUser.Title;
                            ViewBag.SPUser = currentUser;
                        }
                        if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Session != null)
                        {
                            System.Web.HttpContext.Current.Session["_UserName"] = currentUser.LoginName;
                            System.Web.HttpContext.Current.Session["_IsSiteAdmin"] = currentUser.IsSiteAdmin;
                        }
                        if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null)
                        {
                            string anotherAccount = System.Web.HttpContext.Current.Request.QueryString["LoginAsAnotherUserAccount"];
                            if (!string.IsNullOrEmpty(anotherAccount))
                            {
                                currentUser.LoginName = SP.UserUtility.GetLoginNameInClaimsFormat(anotherAccount);
                            }
                            else
                            {
                                anotherAccount = System.Web.HttpContext.Current.Request.QueryString["su"];
                                if (!string.IsNullOrEmpty(anotherAccount))
                                {
                                    currentUser.LoginName = SP.UserUtility.GetLoginNameInClaimsFormat(anotherAccount);
                                }
                            }
                        }
                    }
                }
            }

            if (currentUser == null)
            {
                if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.User != null)
                {
                    return GetCurrentUser(System.Web.HttpContext.Current.User, ViewBag);
                }
            }
            return currentUser;
        }
#endif

        public static Core.GenericUser GetCurrentUser(System.Security.Principal.IPrincipal principal, dynamic ViewBag)
        {
            Core.GenericUser user = null;
            if (principal != null)
            {
                user = new Core.GenericUser(principal);

                if (ViewBag != null)
                {
                    if (string.IsNullOrEmpty(user.Title))
                        ViewBag.UserName = user.LoginName;
                    else
                        ViewBag.UserName = user.Title;

                    ViewBag.SPUser = user;
                }
                if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Session != null)
                {
                    System.Web.HttpContext.Current.Session["_UserName"] = user.LoginName;
                    System.Web.HttpContext.Current.Session["_IsSiteAdmin"] = user.IsSiteAdmin;
                }
                if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null)
                {
                    string anotherAccount = System.Web.HttpContext.Current.Request.QueryString["LoginAsAnotherUserAccount"];
                    if (!string.IsNullOrEmpty(anotherAccount))
                    {
                        user.Title = anotherAccount;
                        user.LoginName = anotherAccount;
                    }
                    else
                    {
                        anotherAccount = System.Web.HttpContext.Current.Request.QueryString["su"];
                        if (!string.IsNullOrEmpty(anotherAccount))
                        {
                            user.Title = anotherAccount;
                            user.LoginName = anotherAccount;
                        }
                    }
                }
            }
            return user;
        }
    }
}
