using DevExpress.Web;
using EydapTickets.Models;
using EydapTickets.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Globalization;
using System.Threading;
using System.Net;

namespace EydapTickets.Controllers
{
    public class BaseController : Controller
    {
        //set caching time out to one hour
        //TODO: Consider changing this.
        private TimeSpan mCacheTimeout = new TimeSpan(1, 0, 0);
        private EydapTickets.Models.UsersModel mUser = null;

        virtual protected void FixActiveMenu()
        {
            ViewBag.IsIncidents = true;
        }

        protected TimeSpan GetDefaultCacheTimeout
        {
            get { return mCacheTimeout; }

            private set { }
        }

        protected EydapTickets.Models.UsersModel GetCurrentUser()
        {
            ClearLastUserCookie();

            if (mUser == null)
            {
                string userName = User.Identity.Name;

                if (userName.Contains("\\") && userName.LastIndexOf("\\") < userName.Length)
                {
                    userName = userName.Substring(userName.LastIndexOf("\\") + 1);
                }

                mUser = (EydapTickets.Models.UsersModel)HttpContext.Cache.Get(userName);

                if (mUser == null)
                {
                    Logger.Instance().Info(string.Format("User: {0} was not found in cache, trying to get from db", userName));

                    Logger.Instance().Info(HttpContext.User.Identity.Name);
                    Logger.Instance().Info(User.Identity.Name);

                    //get the user from the db
                    mUser = UsersDAL.GetUserByUserName(userName);

                    if (mUser != null)
                    {
                        Logger.Instance().Info(string.Format("Found application user: {0}, adding object to cache", userName));
                        //save to cache
                        HttpContext.Cache.Add(userName, mUser, null, DateTime.Now.Add(mCacheTimeout), Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
                    }
                    else
                    {
                        ViewData["UserName"] = userName;
                    }
                }
            }

            if (mUser != null)
            {
                ViewData["UserHeaderLabel"] = string.Format("{0} {1} ({2}, {3})", mUser.Name, mUser.SurName, mUser.GetUsersSectorName(), mUser.GetUsersDepartmentName());
            }

            return mUser;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            /*const string culture = "el-GR";
            CultureInfo ci = CultureInfo.GetCultureInfo(culture);

            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;*/
        }

        private void ClearLastUserCookie()
        {
            string cookieName = "TSWA-Last-User";
            HttpCookie cookie = Request.Cookies[cookieName];
            if (cookie != null)
            {
                Logger.Instance().Info(string.Format("Removing '{0}' cookie", cookieName));
                cookie = new HttpCookie(cookieName, string.Empty)
                {
                    Expires = DateTime.Now.AddYears(-5)
                };
                Response.Cookies.Set(cookie);
            }
        }

        public void ClearUserFromCache()
        {
            string lUserName = User.Identity.Name;
            if (lUserName.Contains("\\") && lUserName.LastIndexOf("\\") < lUserName.Length)
            {
                lUserName = lUserName.Substring(lUserName.LastIndexOf("\\") + 1);
                Logger.Instance().Info("User found in cache " + lUserName);
            }

            if (HttpContext.Cache.Get(lUserName) != null)
            {
                HttpContext.Cache.Remove(lUserName);
                Logger.Instance().Info("User removed from cache " + lUserName);
            }
        }

        /// <summary>
        /// Returns true if the authenticated user has access to the app
        /// </summary>
        /// <returns></returns>
        protected bool UserHasAccess()
        {
            try
            {
                return GetCurrentUser() != null;
            }
            catch (Exception ex)
            {
                Logger.Instance().Error("Error on UserHasAccess", ex);
            }

            return false;
        }

        //
        // 12.05.2017, Andreas Kasapleris,
        // ViewBag.AccessToInvestigations defines whether user can
        // access Investigations menu
        //

        private void FixGeneralViewBagKeyValues()
        {
            // Add if user is admin
            var currentUser = GetCurrentUser();
            var lIsAdmin = currentUser.Role == EydapTickets.Models.UsersModel.UserRole.Administrator;

            ViewBag.IsAdmin = lIsAdmin;
            ViewBag.UserId = currentUser.UserId;
            ViewBag.User = currentUser;
            ViewBag.DepartmentId = currentUser.DepartmentId;
            ViewBag.BCC = currentUser.UserNameBCC;
            ViewBag.AccessToInvestigations = currentUser.AccessToInvestigations;
            ViewBag.IsOnAdminMenu = false;
            ViewBag.ShowMainButtonStrip = true;
            ViewBag.PrintIncidentUrl = HttpUtility.UrlDecode(Url.Action("Print", "Incidents", new {Area = "", Id = "{0}"}));
            ViewBag.LocateIncidentUrl = "http://gisweb:8080/addressMap/index.jsp?latitude={0}&longitude={1}";
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
          base.OnActionExecuting(filterContext);

            if (filterContext.ActionDescriptor.ActionName != "Logout")
            {

                if (!UserHasAccess())
                {
                    Logger.Instance().Warning("Authenticated user: " + User.Identity.Name + " tried to access the app, but was denied access");

                    //TODO: Fix AccessRequired view in Home controller
                    //filterContext.Result = new RedirectResult(Url.Action("AccessRequired", "Home"));

                    //return 401 unauthenticated
                    filterContext.Result = new HttpUnauthorizedResult();
                }
                else
                {
                    FixGeneralViewBagKeyValues();
                    FixActiveMenu();
                }
            }
        }

        /// <summary>Safely execute a method that has no parameters and does not return a value.</summary>
        /// <param name="method">The method to safely execute.</param>
        protected void SafeExecute(Action method)
        {
            try {
                method();
            } catch (Exception exception) {
                ViewData["EditError"] = exception.Message;
            }
        }

        /// <summary>Safely execute a method that has one parameter and does not return a value.</summary>
        /// <param name="method">The method to safely execute.</param>
        /// <param name="arg">The parameter of the executed method.</param>
        /// <typeparam name="T">The type of the parameter of the executed method.</typeparam>
        protected void SafeExecute<T>(Action<T> method, T arg)
        {
            try
            {
                method(arg);
            } catch (Exception exception) {
                ViewData["EditError"] = exception.Message;
            }
        }

        /// <summary>Safely execute a method that has two parameters and does not return a value.</summary>
        /// <param name="method">The method to safely execute.</param>
        /// <param name="arg1">The first parameter of the executed method.</param>
        /// <param name="arg2">The second parameter of the executed method.</param>
        /// <typeparam name="T1">The type of the first parameter of the executed method.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the executed method.</typeparam>
        protected void SafeExecute<T1, T2>(Action<T1, T2> method, T1 arg1, T2 arg2)
        {
            try
            {
                method(arg1, arg2);
            } catch (Exception exception) {
                ViewData["EditError"] = exception.Message;
            }
        }

        /// <summary>Safely execute a method that has three parameters and does not return a value.</summary>
        /// <param name="method">The method to safely execute.</param>
        /// <param name="arg1">The first parameter of the executed method.</param>
        /// <param name="arg2">The second parameter of the executed method.</param>
        /// <param name="arg3">The third parameter of the executed method.</param>
        /// <typeparam name="T1">The type of the first parameter of the executed method.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the executed method.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the executed method.</typeparam>
        protected void SafeExecute<T1, T2, T3>(Action<T1, T2, T3> method, T1 arg1, T2 arg2, T3 arg3)
        {
            try
            {
                method(arg1, arg2, arg3);
            } catch (Exception exception) {
                ViewData["EditError"] = exception.Message;
            }
        }

        /// <summary>Safely execute a method that has four parameters and does not return a value.</summary>
        /// <param name="method">The method to safely execute.</param>
        /// <param name="arg1">The first parameter of the executed method.</param>
        /// <param name="arg2">The second parameter of the executed method.</param>
        /// <param name="arg3">The third parameter of the executed method.</param>
        /// <param name="arg4">The fourth parameter of the executed method.</param>
        /// <typeparam name="T1">The type of the first parameter of the executed method.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the executed method.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the executed method.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the executed method.</typeparam>
        protected void SafeExecute<T1, T2, T3, T4>(Action<T1, T2, T3, T4> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            try
            {
                method(arg1, arg2, arg3, arg4);
            } catch (Exception exception) {
                ViewData["EditError"] = exception.Message;
            }
        }

        /// <summary>Safely execute a method that has five parameters and does not return a value.</summary>
        /// <param name="method">The method to safely execute.</param>
        /// <param name="arg1">The first parameter of the executed method.</param>
        /// <param name="arg2">The second parameter of the executed method.</param>
        /// <param name="arg3">The third parameter of the executed method.</param>
        /// <param name="arg4">The fourth parameter of the executed method.</param>
        /// <param name="arg5">The fifth parameter of the executed method.</param>
        /// <typeparam name="T1">The type of the first parameter of the executed method.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the executed method.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the executed method.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the executed method.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the executed method.</typeparam>
        protected void SafeExecute<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            try
            {
                method(arg1, arg2, arg3, arg4, arg5);
            } catch (Exception exception) {
                ViewData["EditError"] = exception.Message;
            }
        }

        /// <summary>Safely execute a method that has six parameters and does not return a value.</summary>
        /// <param name="method">The method to safely execute.</param>
        /// <param name="arg1">The first parameter of the executed method.</param>
        /// <param name="arg2">The second parameter of the executed method.</param>
        /// <param name="arg3">The third parameter of the executed method.</param>
        /// <param name="arg4">The fourth parameter of the executed method.</param>
        /// <param name="arg5">The fifth parameter of the executed method.</param>
        /// <param name="arg6">The sixth parameter of the executed method.</param>
        /// <typeparam name="T1">The type of the first parameter of the executed method.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the executed method.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the executed method.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the executed method.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the executed method.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the executed method.</typeparam>
        protected void SafeExecute<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
            try
            {
                method(arg1, arg2, arg3, arg4, arg5, arg6);
            } catch (Exception exception) {
                ViewData["EditError"] = exception.Message;
            }
        }

        /// <summary>Safely execute a method that has seven parameters and does not return a value.</summary>
        /// <param name="method">The method to safely execute.</param>
        /// <param name="arg1">The first parameter of the executed method.</param>
        /// <param name="arg2">The second parameter of the executed method.</param>
        /// <param name="arg3">The third parameter of the executed method.</param>
        /// <param name="arg4">The fourth parameter of the executed method.</param>
        /// <param name="arg5">The fifth parameter of the executed method.</param>
        /// <param name="arg6">The sixth parameter of the executed method.</param>
        /// <param name="arg7">The seventh parameter of the executed method.</param>
        /// <typeparam name="T1">The type of the first parameter of the executed method.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the executed method.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the executed method.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the executed method.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the executed method.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the executed method.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the executed method.</typeparam>
        protected void SafeExecute<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
        {
            try
            {
                method(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            } catch (Exception exception) {
                ViewData["EditError"] = exception.Message;
            }
        }

        /// <summary>Safely execute a method that has eight parameters and does not return a value.</summary>
        /// <param name="method">The method to safely execute.</param>
        /// <param name="arg1">The first parameter of the executed method.</param>
        /// <param name="arg2">The second parameter of the executed method.</param>
        /// <param name="arg3">The third parameter of the executed method.</param>
        /// <param name="arg4">The fourth parameter of the executed method.</param>
        /// <param name="arg5">The fifth parameter of the executed method.</param>
        /// <param name="arg6">The sixth parameter of the executed method.</param>
        /// <param name="arg7">The seventh parameter of the executed method.</param>
        /// <param name="arg8">The eighth parameter of the executed method.</param>
        /// <typeparam name="T1">The type of the first parameter of the executed method.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the executed method.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the executed method.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the executed method.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the executed method.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the executed method.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the executed method.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the executed method.</typeparam>
        protected void SafeExecute<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
        {
            try
            {
                method(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            } catch (Exception exception) {
                ViewData["EditError"] = exception.Message;
            }
        }

        /// <summary>Safely execute a method that has no parameters and returns a value of the type specified by the <typeparamref name="TResult" /> parameter.</summary>
        /// <typeparam name="TResult">The type of the return value of the executed method.</typeparam>
        /// <returns>The return value of the executed method.</returns>
        protected TResult SafeExecute<TResult>(Func<TResult> method)
        {
            try {
                return method();
            } catch (Exception exception) {
                ViewData["EditError"] = exception.Message;
            }
            return default(TResult);
        }

        /// <summary>Safely execute a method that has one parameter and returns a value of the type specified by the <typeparamref name="TResult" /> parameter.</summary>
        /// <param name="method">The method to safely execute.</param>
        /// <param name="arg">The parameter of the executed method.</param>
        /// <typeparam name="T">The type of the parameter of the executed method.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the executed method.</typeparam>
        /// <returns>The return value of the executed method.</returns>
        protected TResult SafeExecute<T, TResult>(Func<T, TResult> method, T arg)
        {
            try {
                return method(arg);
            } catch (Exception exception) {
                ViewData["EditError"] = exception.Message;
            }
            return default(TResult);
        }

        /// <summary>Safely execute a method that has two parameters and returns a value of the type specified by the <typeparamref name="TResult" /> parameter.</summary>
        /// <param name="method">The method to safely execute.</param>
        /// <param name="arg1">The first parameter of the executed method.</param>
        /// <param name="arg2">The second parameter of the executed method.</param>
        /// <typeparam name="T1">The type of the first parameter of the executed method.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the executed method.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the executed method.</typeparam>
        /// <returns>The return value of the executed method.</returns>
        protected TResult SafeExecute<T1, T2, TResult>(Func<T1, T2, TResult> method, T1 arg1, T2 arg2)
        {
            try {
                return method(arg1, arg2);
            } catch (Exception exception) {
                ViewData["EditError"] = exception.Message;
            }
            return default(TResult);
        }

        /// <summary>Safely execute a method that has three parameters and returns a value of the type specified by the <typeparamref name="TResult" /> parameter.</summary>
        /// <param name="method">The method to safely execute.</param>
        /// <param name="arg1">The first parameter of the executed method.</param>
        /// <param name="arg2">The second parameter of the executed method.</param>
        /// <param name="arg3">The third parameter of the executed method.</param>
        /// <typeparam name="T1">The type of the first parameter of the executed method.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the executed method.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the executed method.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the executed method.</typeparam>
        /// <returns>The return value of the executed method.</returns>
        protected TResult SafeExecute<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> method, T1 arg1, T2 arg2, T3 arg3)
        {
            try {
                return method(arg1, arg2, arg3);
            } catch (Exception exception) {
                ViewData["EditError"] = exception.Message;
            }
            return default(TResult);
        }

        /// <summary>Safely execute a method that has four parameters and returns a value of the type specified by the <typeparamref name="TResult" /> parameter.</summary>
        /// <param name="method">The method to safely execute.</param>
        /// <param name="arg1">The first parameter of the executed method.</param>
        /// <param name="arg2">The second parameter of the executed method.</param>
        /// <param name="arg3">The third parameter of the executed method.</param>
        /// <param name="arg4">The fourth parameter of the executed method.</param>
        /// <typeparam name="T1">The type of the first parameter of the executed method.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the executed method.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the executed method.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the executed method.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the executed method.</typeparam>
        /// <returns>The return value of the executed method.</returns>
        protected TResult SafeExecute<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            try {
                return method(arg1, arg2, arg3, arg4);
            } catch (Exception exception) {
                ViewData["EditError"] = exception.Message;
            }
            return default(TResult);
        }

        /// <summary>Safely execute a method that has five parameters and returns a value of the type specified by the <typeparamref name="TResult" /> parameter.</summary>
        /// <param name="method">The method to safely execute.</param>
        /// <param name="arg1">The first parameter of the executed method.</param>
        /// <param name="arg2">The second parameter of the executed method.</param>
        /// <param name="arg3">The third parameter of the executed method.</param>
        /// <param name="arg4">The fourth parameter of the executed method.</param>
        /// <param name="arg5">The fifth parameter of the executed method.</param>
        /// <typeparam name="T1">The type of the first parameter of the executed method.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the executed method.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the executed method.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the executed method.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the executed method.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the executed method.</typeparam>
        /// <returns>The return value of the executed method.</returns>
        protected TResult SafeExecute<T1, T2, T3, T4, T5, TResult>(Func<T1, T2, T3, T4, T5, TResult> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            try {
                return method(arg1, arg2, arg3, arg4, arg5);
            } catch (Exception exception) {
                ViewData["EditError"] = exception.Message;
            }
            return default(TResult);
        }

        /// <summary>Safely execute a method that has six parameters and returns a value of the type specified by the <typeparamref name="TResult" /> parameter.</summary>
        /// <param name="method">The method to safely execute.</param>
        /// <param name="arg1">The first parameter of the executed method.</param>
        /// <param name="arg2">The second parameter of the executed method.</param>
        /// <param name="arg3">The third parameter of the executed method.</param>
        /// <param name="arg4">The fourth parameter of the executed method.</param>
        /// <param name="arg5">The fifth parameter of the executed method.</param>
        /// <param name="arg6">The sixth parameter of the executed method.</param>
        /// <typeparam name="T1">The type of the first parameter of the executed method.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the executed method.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the executed method.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the executed method.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the executed method.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the executed method.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the executed method.</typeparam>
        /// <returns>The return value of the executed method.</returns>
        protected TResult SafeExecute<T1, T2, T3, T4, T5, T6, TResult>(Func<T1, T2, T3, T4, T5, T6, TResult> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
            try {
                return method(arg1, arg2, arg3, arg4, arg5, arg6);
            } catch (Exception exception) {
                ViewData["EditError"] = exception.Message;
            }
            return default(TResult);
        }

        /// <summary>Safely execute a method that has seven parameters and returns a value of the type specified by the <typeparamref name="TResult" /> parameter.</summary>
        /// <param name="method">The method to safely execute.</param>
        /// <param name="arg1">The first parameter of the executed method.</param>
        /// <param name="arg2">The second parameter of the executed method.</param>
        /// <param name="arg3">The third parameter of the executed method.</param>
        /// <param name="arg4">The fourth parameter of the executed method.</param>
        /// <param name="arg5">The fifth parameter of the executed method.</param>
        /// <param name="arg6">The sixth parameter of the executed method.</param>
        /// <param name="arg7">The seventh parameter of the executed method.</param>
        /// <typeparam name="T1">The type of the first parameter of the executed method.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the executed method.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the executed method.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the executed method.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the executed method.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the executed method.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the executed method.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the executed method.</typeparam>
        /// <returns>The return value of the executed method.</returns>
        protected TResult SafeExecute<T1, T2, T3, T4, T5, T6, T7, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, TResult> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
        {
            try {
                return method(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            } catch (Exception exception) {
                ViewData["EditError"] = exception.Message;
            }
            return default(TResult);
        }

        /// <summary>Safely execute a method that has eight parameters and returns a value of the type specified by the <typeparamref name="TResult" /> parameter.</summary>
        /// <param name="method">The method to safely execute.</param>
        /// <param name="arg1">The first parameter of the executed method.</param>
        /// <param name="arg2">The second parameter of the executed method.</param>
        /// <param name="arg3">The third parameter of the executed method.</param>
        /// <param name="arg4">The fourth parameter of the executed method.</param>
        /// <param name="arg5">The fifth parameter of the executed method.</param>
        /// <param name="arg6">The sixth parameter of the executed method.</param>
        /// <param name="arg7">The seventh parameter of the executed method.</param>
        /// <param name="arg8">The eighth parameter of the executed method.</param>
        /// <typeparam name="T1">The type of the first parameter of the executed method.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the executed method.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the executed method.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the executed method.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the executed method.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the executed method.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the executed method.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the executed method.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the executed method.</typeparam>
        /// <returns>The return value of the executed method.</returns>
        protected TResult SafeExecute<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
        {
            try {
                return method(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            } catch (Exception exception) {
                ViewData["EditError"] = exception.Message;
            }
            return default(TResult);
        }
    }
}