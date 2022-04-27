using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DM.App.Library.Models
{
    public class ExternalDB
    {
        private const string DefaultCategoryName = "Default";
        public const string EntityIncident = "Incidents";
        public const string EntityTask = "Tasks";
        public const string EntityVisit = "Visits";

        // Andreas Kasapleris, 08.09.2016
        public const string EntityInvestigations = "Investigations";

        #region Categories
        public static int GetDefaultCategoryId(string categoryName)
        {
            try
            {
                //string cacheKey = string.Format("DA_{0}_{1}", "GetPrefectures", spWeb.Language);
                //if (Core.Configuration.GetConfigurationCacheEnabled(spWeb) && System.Web.HttpRuntime.Cache != null && System.Web.HttpRuntime.Cache[cacheKey] != null)
                //{
                //    if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null && System.Web.HttpContext.Current.Request.QueryString[Core.Configuration.QS_CACHE] == Core.Configuration.QS_CACHE_INVALIDATE)
                //    {
                //         // Do nothing, cache will be refreshed below
                //    }
                //    else
                //        return System.Web.HttpRuntime.Cache[cacheKey] as List<CategoriesFields>;
                //}
                using (System.Web.Hosting.HostingEnvironment.Impersonate())
                {
                    using (ExternalDBEntities ctx = new ExternalDBEntities()) //string.Format(CONN_STRING_FORMAT, Core.Configuration.GetExternalDB(spWeb))))
                    {
                        //IQueryable<Categories> entities = ctx.Categories.Where(e => (e.CategoryName == (string.IsNullOrEmpty(categoryName) ? DefaultCategoryName : categoryName)));
                        //List<Categories> results = entities.ToList();

                        //int id = -1;
                        //if (results.Count > 0)
                        //    id = results[0].Id;
                        ////if (Core.Configuration.GetConfigurationCacheEnabled(spWeb) && System.Web.HttpRuntime.Cache != null && System.Web.HttpRuntime.Cache[cacheKey] != null)
                        ////{
                        ////    System.Web.HttpRuntime.Cache.Add(cacheKey, results, null, DateTime.Now.AddMinutes(Core.Configuration.GetConfigurationCacheDuration(spWeb)), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.NotRemovable, null);
                        ////}
                        //return id;
                        return GetDefaultCategoryId(ctx, categoryName);
                    }
                }
            }
            catch (Exception /* exeption */)
            {
                //Logger.LogEvent(string.Format(Core.Configuration.ERROR_STRING_FORMAT, null, "DataAccess.Get", null, exception.ToString()), System.Diagnostics.EventLogEntryType.Error);
            }
            return -1;
        }

        public static int GetDefaultCategoryId(ExternalDBEntities ctx, string categoryName)
        {
            IQueryable<Categories> entities = ctx.Categories.Where(e => (e.CategoryName == (string.IsNullOrEmpty(categoryName) ? DefaultCategoryName : categoryName)));
            List<Categories> results = entities.ToList();

            int id = -1;
            if (results.Count > 0)
                id = results[0].Id;
            //if (Core.Configuration.GetConfigurationCacheEnabled(spWeb) && System.Web.HttpRuntime.Cache != null && System.Web.HttpRuntime.Cache[cacheKey] != null)
            //{
            //    System.Web.HttpRuntime.Cache.Add(cacheKey, results, null, DateTime.Now.AddMinutes(Core.Configuration.GetConfigurationCacheDuration(spWeb)), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.NotRemovable, null);
            //}
            return id;
        }

        public static IEnumerable<vCategoriesHierarchy> GetCategories(int? id)
        {
            try
            {
                //string cacheKey = string.Format("DA_{0}_{1}", "GetPrefectures", spWeb.Language);
                //if (Core.Configuration.GetConfigurationCacheEnabled(spWeb) && System.Web.HttpRuntime.Cache != null && System.Web.HttpRuntime.Cache[cacheKey] != null)
                //{
                //    if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null && System.Web.HttpContext.Current.Request.QueryString[Core.Configuration.QS_CACHE] == Core.Configuration.QS_CACHE_INVALIDATE)
                //    {
                //         // Do nothing, cache will be refreshed below
                //    }
                //    else
                //        return System.Web.HttpRuntime.Cache[cacheKey] as List<CategoriesFields>;
                //}
                using (System.Web.Hosting.HostingEnvironment.Impersonate())
                {
                    using (ExternalDBEntities ctx = new ExternalDBEntities()) //string.Format(CONN_STRING_FORMAT, Core.Configuration.GetExternalDB(spWeb))))
                    {
                        //IQueryable<vCategoriesHierarchy> entities = ctx.vCategoriesHierarchy.OrderBy(e => e.HierarchyLevel).ThenBy(e => e.CategoryName);
                        //List<vCategoriesHierarchy> results = entities.ToList();

                        //if (id.HasValue)
                        //{
                        //    results = results.Where(e => e.Id == id.Value).ToList();
                        //}

                        ////if (Core.Configuration.GetConfigurationCacheEnabled(spWeb) && System.Web.HttpRuntime.Cache != null && System.Web.HttpRuntime.Cache[cacheKey] != null)
                        ////{
                        ////    System.Web.HttpRuntime.Cache.Add(cacheKey, results, null, DateTime.Now.AddMinutes(Core.Configuration.GetConfigurationCacheDuration(spWeb)), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.NotRemovable, null);
                        ////}
                        //return results;
                        return GetCategories(ctx, id);
                    }
                }
            }
            catch (Exception /* exception */)
            {
                //Logger.LogEvent(string.Format(Core.Configuration.ERROR_STRING_FORMAT, null, "DataAccess.Get", null, exception.ToString()), System.Diagnostics.EventLogEntryType.Error);
            }
            return new List<vCategoriesHierarchy>();
        }

        public static IEnumerable<vCategoriesHierarchy> GetCategories(ExternalDBEntities ctx, int? id)
        {
            IQueryable<vCategoriesHierarchy> entities = ctx.vCategoriesHierarchy.OrderBy(e => e.HierarchyLevel).ThenBy(e => e.CategoryName);
            List<vCategoriesHierarchy> results = entities.ToList();

            if (id.HasValue)
            {
                results = results.Where(e => e.Id == id.Value).ToList();
            }

            //if (Core.Configuration.GetConfigurationCacheEnabled(spWeb) && System.Web.HttpRuntime.Cache != null && System.Web.HttpRuntime.Cache[cacheKey] != null)
            //{
            //    System.Web.HttpRuntime.Cache.Add(cacheKey, results, null, DateTime.Now.AddMinutes(Core.Configuration.GetConfigurationCacheDuration(spWeb)), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.NotRemovable, null);
            //}
            return results;
        }

        public static Categories GetCategoryByAlias(string alias)
        {
            try
            {
                //string cacheKey = string.Format("DA_{0}_{1}", "GetPrefectures", spWeb.Language);
                //if (Core.Configuration.GetConfigurationCacheEnabled(spWeb) && System.Web.HttpRuntime.Cache != null && System.Web.HttpRuntime.Cache[cacheKey] != null)
                //{
                //    if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null && System.Web.HttpContext.Current.Request.QueryString[Core.Configuration.QS_CACHE] == Core.Configuration.QS_CACHE_INVALIDATE)
                //    {
                //         // Do nothing, cache will be refreshed below
                //    }
                //    else
                //        return System.Web.HttpRuntime.Cache[cacheKey] as List<CategoriesFields>;
                //}
                using (System.Web.Hosting.HostingEnvironment.Impersonate())
                {
                    using (ExternalDBEntities ctx = new ExternalDBEntities()) //string.Format(CONN_STRING_FORMAT, Core.Configuration.GetExternalDB(spWeb))))
                    {
                        //IQueryable<Categories> entities = ctx.Categories.Where(e => e.Alias == alias);
                        //List<Categories> results = entities.ToList();

                        ////if (Core.Configuration.GetConfigurationCacheEnabled(spWeb) && System.Web.HttpRuntime.Cache != null && System.Web.HttpRuntime.Cache[cacheKey] != null)
                        ////{
                        ////    System.Web.HttpRuntime.Cache.Add(cacheKey, results, null, DateTime.Now.AddMinutes(Core.Configuration.GetConfigurationCacheDuration(spWeb)), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.NotRemovable, null);
                        ////}
                        //return results.FirstOrDefault();
                        return GetCategoryByAlias(ctx, alias);
                    }
                }
            }
            catch (Exception /* exception */)
            {
                //Logger.LogEvent(string.Format(Core.Configuration.ERROR_STRING_FORMAT, null, "DataAccess.Get", null, exception.ToString()), System.Diagnostics.EventLogEntryType.Error);
            }
            return null;
        }

        public static Categories GetCategoryByAlias(ExternalDBEntities ctx, string alias)
        {
            IQueryable<Categories> entities = ctx.Categories.Where(e => e.Alias == alias);
            List<Categories> results = entities.ToList();

            //if (Core.Configuration.GetConfigurationCacheEnabled(spWeb) && System.Web.HttpRuntime.Cache != null && System.Web.HttpRuntime.Cache[cacheKey] != null)
            //{
            //    System.Web.HttpRuntime.Cache.Add(cacheKey, results, null, DateTime.Now.AddMinutes(Core.Configuration.GetConfigurationCacheDuration(spWeb)), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.NotRemovable, null);
            //}
            return results.FirstOrDefault();
        }

        public static IEnumerable<CategoriesFields> GetCategoriesFields(int categoryId, string entity)
        {
            try
            {
                //string cacheKey = string.Format("DA_{0}_{1}", "GetPrefectures", spWeb.Language);
                //if (Core.Configuration.GetConfigurationCacheEnabled(spWeb) && System.Web.HttpRuntime.Cache != null && System.Web.HttpRuntime.Cache[cacheKey] != null)
                //{
                //    if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null && System.Web.HttpContext.Current.Request.QueryString[Core.Configuration.QS_CACHE] == Core.Configuration.QS_CACHE_INVALIDATE)
                //    {
                //         // Do nothing, cache will be refreshed below
                //    }
                //    else
                //        return System.Web.HttpRuntime.Cache[cacheKey] as List<CategoriesFields>;
                //}
                using (System.Web.Hosting.HostingEnvironment.Impersonate())
                {
                    using (ExternalDBEntities ctx = new ExternalDBEntities()) //string.Format(CONN_STRING_FORMAT, Core.Configuration.GetExternalDB(spWeb))))
                    {
                        //IQueryable<CategoriesFields> entities = ctx.CategoriesFields.Where(e => (e.CategoryId == categoryId && e.Entity == entity && e.RowStatus == 0)).OrderBy(e => e.SortOrder).ThenBy(e => e.LayoutOrder);
                        //List<CategoriesFields> results = entities.ToList();

                        //if (results.Count == 0)
                        //{
                        //    // Get parent configuration
                        //    IEnumerable<vCategoriesHierarchy> categories = GetCategories(null);
                        //    vCategoriesHierarchy category = categories.Where(e => e.Id == categoryId).FirstOrDefault();
                        //    if (category != null)
                        //    {
                        //        string[] parents = category.Parents.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        //        foreach (string parentId in parents)
                        //        {
                        //            int id = -1;
                        //            if (int.TryParse(parentId, out id))
                        //            {
                        //                entities = ctx.CategoriesFields.Where(e => (e.CategoryId == id && e.Entity == entity && e.RowStatus == 0)).OrderBy(e => e.SortOrder).ThenBy(e => e.LayoutOrder);
                        //                results = entities.ToList();
                        //                if (results.Count > 0)
                        //                    break;
                        //            }
                        //        }
                        //    }
                        //    if (results.Count == 0)
                        //    {
                        //        // Get default configuration
                        //        int defaultCategoryId = GetDefaultCategoryId(null);
                        //        entities = ctx.CategoriesFields.Where(e => (e.CategoryId == defaultCategoryId && e.Entity == entity && e.RowStatus == 0)).OrderBy(e => e.SortOrder).ThenBy(e => e.LayoutOrder);
                        //        results = entities.ToList();
                        //    }
                        //}
                        ////if (Core.Configuration.GetConfigurationCacheEnabled(spWeb) && System.Web.HttpRuntime.Cache != null && System.Web.HttpRuntime.Cache[cacheKey] != null)
                        ////{
                        ////    System.Web.HttpRuntime.Cache.Add(cacheKey, results, null, DateTime.Now.AddMinutes(Core.Configuration.GetConfigurationCacheDuration(spWeb)), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.NotRemovable, null);
                        ////}
                        //return results;
                        return GetCategoriesFields(ctx, categoryId, entity);
                    }
                }
            }
            catch (Exception /* exception */)
            {
                //Logger.LogEvent(string.Format(Core.Configuration.ERROR_STRING_FORMAT, null, "DataAccess.Get", null, exception.ToString()), System.Diagnostics.EventLogEntryType.Error);
            }
            return new List<CategoriesFields>();
        }

        public static IEnumerable<CategoriesFields> GetCategoriesFields(ExternalDBEntities ctx, int categoryId, string entity)
        {
            IQueryable<CategoriesFields> entities = ctx.CategoriesFields.Where(e => (e.CategoryId == categoryId && e.Entity == entity && e.RowStatus == 0)).OrderBy(e => e.SortOrder).ThenBy(e => e.LayoutOrder);
            List<CategoriesFields> results = entities.ToList();

            if (results.Count == 0)
            {
                // Get parent configuration
                IEnumerable<vCategoriesHierarchy> categories = GetCategories(null);
                vCategoriesHierarchy category = categories.Where(e => e.Id == categoryId).FirstOrDefault();
                if (category != null)
                {
                    string[] parents = category.Parents.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string parentId in parents)
                    {
                        int id = -1;
                        if (int.TryParse(parentId, out id))
                        {
                            entities = ctx.CategoriesFields.Where(e => (e.CategoryId == id && e.Entity == entity && e.RowStatus == 0)).OrderBy(e => e.SortOrder).ThenBy(e => e.LayoutOrder);
                            results = entities.ToList();
                            if (results.Count > 0)
                                break;
                        }
                    }
                }
                if (results.Count == 0)
                {
                    // Get default configuration
                    int defaultCategoryId = GetDefaultCategoryId(null);
                    entities = ctx.CategoriesFields.Where(e => (e.CategoryId == defaultCategoryId && e.Entity == entity && e.RowStatus == 0)).OrderBy(e => e.SortOrder).ThenBy(e => e.LayoutOrder);
                    results = entities.ToList();
                }
            }
            //if (Core.Configuration.GetConfigurationCacheEnabled(spWeb) && System.Web.HttpRuntime.Cache != null && System.Web.HttpRuntime.Cache[cacheKey] != null)
            //{
            //    System.Web.HttpRuntime.Cache.Add(cacheKey, results, null, DateTime.Now.AddMinutes(Core.Configuration.GetConfigurationCacheDuration(spWeb)), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.NotRemovable, null);
            //}
            return results;
        }

        public static IEnumerable<int> GetCustomizedCategories(string entity)
        {
            try
            {
                //string cacheKey = string.Format("DA_{0}_{1}", "GetPrefectures", spWeb.Language);
                //if (Core.Configuration.GetConfigurationCacheEnabled(spWeb) && System.Web.HttpRuntime.Cache != null && System.Web.HttpRuntime.Cache[cacheKey] != null)
                //{
                //    if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null && System.Web.HttpContext.Current.Request.QueryString[Core.Configuration.QS_CACHE] == Core.Configuration.QS_CACHE_INVALIDATE)
                //    {
                //         // Do nothing, cache will be refreshed below
                //    }
                //    else
                //        return System.Web.HttpRuntime.Cache[cacheKey] as List<CategoriesFields>;
                //}
                using (System.Web.Hosting.HostingEnvironment.Impersonate())
                {
                    using (ExternalDBEntities ctx = new ExternalDBEntities()) //string.Format(CONN_STRING_FORMAT, Core.Configuration.GetExternalDB(spWeb))))
                    {
                        //IEnumerable<int> entities = ctx.Database.SqlQuery<int>("select distinct CategoryId from CategoriesFields where Entity = '" + entity + "'");
                        //List<int> results = entities.ToList();

                        ////ExecuteSqlCommand("", null);
                        //return results;
                        return GetCustomizedCategories(ctx, entity);
                    }
                }
            }
            catch (Exception /* exception */)
            {
                //Logger.LogEvent(string.Format(Core.Configuration.ERROR_STRING_FORMAT, null, "DataAccess.Get", null, exception.ToString()), System.Diagnostics.EventLogEntryType.Error);
            }
            return new List<int>();
        }

        public static IEnumerable<int> GetCustomizedCategories(ExternalDBEntities ctx, string entity)
        {
            IEnumerable<int> entities = ctx.Database.SqlQuery<int>("select distinct CategoryId from CategoriesFields where Entity = '" + entity + "'");
            List<int> results = entities.ToList();

            //ExecuteSqlCommand("", null);
            return results;
        }

        public static IEnumerable<CategoriesFieldsPerTaskType> GetCategoriesFieldsPerTaskType(int categoryId, string entity, int taskType)
        {
            try
            {
                //string cacheKey = string.Format("DA_{0}_{1}", "GetPrefectures", spWeb.Language);
                //if (Core.Configuration.GetConfigurationCacheEnabled(spWeb) && System.Web.HttpRuntime.Cache != null && System.Web.HttpRuntime.Cache[cacheKey] != null)
                //{
                //    if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null && System.Web.HttpContext.Current.Request.QueryString[Core.Configuration.QS_CACHE] == Core.Configuration.QS_CACHE_INVALIDATE)
                //    {
                //         // Do nothing, cache will be refreshed below
                //    }
                //    else
                //        return System.Web.HttpRuntime.Cache[cacheKey] as List<CategoriesFields>;
                //}
                using (System.Web.Hosting.HostingEnvironment.Impersonate())
                {
                    using (ExternalDBEntities ctx = new ExternalDBEntities()) //string.Format(CONN_STRING_FORMAT, Core.Configuration.GetExternalDB(spWeb))))
                    {
                        return GetCategoriesFieldsPerTaskType(ctx, categoryId, entity, taskType);
                    }
                }
            }
            catch (Exception /* exception */)
            {
                //Logger.LogEvent(string.Format(Core.Configuration.ERROR_STRING_FORMAT, null, "DataAccess.Get", null, exception.ToString()), System.Diagnostics.EventLogEntryType.Error);
            }
            return new List<CategoriesFieldsPerTaskType>();
        }

        public static IEnumerable<CategoriesFieldsPerTaskType> GetCategoriesFieldsPerTaskType(ExternalDBEntities ctx, int categoryId, string entity, int taskType)
        {
            IQueryable<CategoriesFieldsPerTaskType> entities = ctx.CategoriesFieldsPerTaskType.Where(e => (e.CategoryId == categoryId && e.Entity == entity && e.TaskType == taskType && e.RowStatus == 0));
            List<CategoriesFieldsPerTaskType> results = entities.ToList();

            //if (Core.Configuration.GetConfigurationCacheEnabled(spWeb) && System.Web.HttpRuntime.Cache != null && System.Web.HttpRuntime.Cache[cacheKey] != null)
            //{
            //    System.Web.HttpRuntime.Cache.Add(cacheKey, results, null, DateTime.Now.AddMinutes(Core.Configuration.GetConfigurationCacheDuration(spWeb)), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.NotRemovable, null);
            //}
            return results;
        }

        public static IEnumerable<CategoriesFieldsPerApplicationRole> GetCategoriesFieldsPerApplicationRole(int categoryId, string entity, int applicationRoleId)
        {
            try
            {
                //string cacheKey = string.Format("DA_{0}_{1}", "GetPrefectures", spWeb.Language);
                //if (Core.Configuration.GetConfigurationCacheEnabled(spWeb) && System.Web.HttpRuntime.Cache != null && System.Web.HttpRuntime.Cache[cacheKey] != null)
                //{
                //    if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null && System.Web.HttpContext.Current.Request.QueryString[Core.Configuration.QS_CACHE] == Core.Configuration.QS_CACHE_INVALIDATE)
                //    {
                //         // Do nothing, cache will be refreshed below
                //    }
                //    else
                //        return System.Web.HttpRuntime.Cache[cacheKey] as List<CategoriesFields>;
                //}
                using (System.Web.Hosting.HostingEnvironment.Impersonate())
                {
                    using (ExternalDBEntities ctx = new ExternalDBEntities()) //string.Format(CONN_STRING_FORMAT, Core.Configuration.GetExternalDB(spWeb))))
                    {
                        return GetCategoriesFieldsPerApplicationRole(ctx, categoryId, entity, applicationRoleId);
                    }
                }
            }
            catch (Exception /* exception */)
            {
                //Logger.LogEvent(string.Format(Core.Configuration.ERROR_STRING_FORMAT, null, "DataAccess.Get", null, exception.ToString()), System.Diagnostics.EventLogEntryType.Error);
            }
            return new List<CategoriesFieldsPerApplicationRole>();
        }

        public static IEnumerable<CategoriesFieldsPerApplicationRole> GetCategoriesFieldsPerApplicationRole(ExternalDBEntities ctx, int categoryId, string entity, int applicationRoleId)
        {
            IQueryable<CategoriesFieldsPerApplicationRole> entities = ctx.CategoriesFieldsPerApplicationRole.Where(e => (e.CategoryId == categoryId && e.Entity == entity && e.ApplicationRoleId == applicationRoleId && e.RowStatus == 0));
            List<CategoriesFieldsPerApplicationRole> results = entities.ToList();

            //if (Core.Configuration.GetConfigurationCacheEnabled(spWeb) && System.Web.HttpRuntime.Cache != null && System.Web.HttpRuntime.Cache[cacheKey] != null)
            //{
            //    System.Web.HttpRuntime.Cache.Add(cacheKey, results, null, DateTime.Now.AddMinutes(Core.Configuration.GetConfigurationCacheDuration(spWeb)), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.NotRemovable, null);
            //}
            return results;
        }

        public static IEnumerable<Fields> GetFields()
        {
            try
            {
                //string cacheKey = string.Format("DA_{0}_{1}", "GetPrefectures", spWeb.Language);
                //if (Core.Configuration.GetConfigurationCacheEnabled(spWeb) && System.Web.HttpRuntime.Cache != null && System.Web.HttpRuntime.Cache[cacheKey] != null)
                //{
                //    if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null && System.Web.HttpContext.Current.Request.QueryString[Core.Configuration.QS_CACHE] == Core.Configuration.QS_CACHE_INVALIDATE)
                //    {
                //         // Do nothing, cache will be refreshed below
                //    }
                //    else
                //        return System.Web.HttpRuntime.Cache[cacheKey] as List<CategoriesFields>;
                //}
                using (System.Web.Hosting.HostingEnvironment.Impersonate())
                {
                    using (ExternalDBEntities ctx = new ExternalDBEntities()) //string.Format(CONN_STRING_FORMAT, Core.Configuration.GetExternalDB(spWeb))))
                    {
                        //IQueryable<vCategoriesConfigurationRoles> entities = ctx.vCategoriesConfigurationRoles.Where(e => e.CategoryId == categoryId).OrderBy(e => e.ApprovalSortOrder).ThenBy(e => e.RoleSortOrder);
                        //List<vCategoriesConfigurationRoles> results = entities.ToList();

                        ////if (Core.Configuration.GetConfigurationCacheEnabled(spWeb) && System.Web.HttpRuntime.Cache != null && System.Web.HttpRuntime.Cache[cacheKey] != null)
                        ////{
                        ////    System.Web.HttpRuntime.Cache.Add(cacheKey, results, null, DateTime.Now.AddMinutes(Core.Configuration.GetConfigurationCacheDuration(spWeb)), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.NotRemovable, null);
                        ////}
                        //return results;
                        return GetFields(ctx);
                    }
                }
            }
            catch (Exception /* exception */)
            {
                //Logger.LogEvent(string.Format(Core.Configuration.ERROR_STRING_FORMAT, null, "DataAccess.Get", null, exception.ToString()), System.Diagnostics.EventLogEntryType.Error);
            }
            return new List<Fields>();
        }

        public static IEnumerable<Fields> GetFields(ExternalDBEntities ctx)
        {
            IQueryable<Fields> entities = ctx.Fields.OrderBy(e => e.Entity).ThenBy(e => e.FieldName);
            List<Fields> results = entities.ToList();

            //if (Core.Configuration.GetConfigurationCacheEnabled(spWeb) && System.Web.HttpRuntime.Cache != null && System.Web.HttpRuntime.Cache[cacheKey] != null)
            //{
            //    System.Web.HttpRuntime.Cache.Add(cacheKey, results, null, DateTime.Now.AddMinutes(Core.Configuration.GetConfigurationCacheDuration(spWeb)), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.NotRemovable, null);
            //}
            return results;
        }

        #endregion

        #region SQL Queries
        public static IEnumerable<Models.DTO.LookupItem> GetLookupKVPs(string query)
        {

            try
            {
                using (System.Web.Hosting.HostingEnvironment.Impersonate())
                {
                    using (ExternalDBEntities ctx = new ExternalDBEntities())
                    {
                        return GetLookupKVPs(ctx, query);
                    }
                }
            }
            catch (Exception /* exception */)
            {
                //Logger.LogEvent(string.Format(Core.Configuration.ERROR_STRING_FORMAT, null, "DataAccess.Get", null, exception.ToString()), System.Diagnostics.EventLogEntryType.Error);
            }
            return new List<Models.DTO.LookupItem>();
        }

        public static IEnumerable<Models.DTO.LookupItem> GetLookupKVPs(ExternalDBEntities ctx, string query)
        {
            IEnumerable<Models.DTO.LookupItem> results = ctx.Database.SqlQuery<Models.DTO.LookupItem>(query).ToList();

            //if (Core.Configuration.GetConfigurationCacheEnabled(spWeb) && System.Web.HttpRuntime.Cache != null && System.Web.HttpRuntime.Cache[cacheKey] != null)
            //{
            //    System.Web.HttpRuntime.Cache.Add(cacheKey, results, null, DateTime.Now.AddMinutes(Core.Configuration.GetConfigurationCacheDuration(spWeb)), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.NotRemovable, null);
            //}
            return results;
        }
        #endregion
    }
}