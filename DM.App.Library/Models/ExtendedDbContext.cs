using System;

namespace DM.App.Library.Models
{
    public partial class ExternalDBEntities
    {
        public ExternalDBEntities(string connectionString)
            : base(connectionString)
        {
        }

        public override int SaveChanges()
        {
            try
            {
                foreach (var entry in this.ChangeTracker.Entries())
                {
                    if (entry.State == System.Data.Entity.EntityState.Added || entry.State == System.Data.Entity.EntityState.Modified || entry.State == System.Data.Entity.EntityState.Deleted)
                    {
                        //if (entry.Entity is Models.Requests)
                        //{
                        //    (entry.Entity as Models.Requests).SaveHistoryItem(this, entry.State);
                        //}
                        //else if (entry.Entity is Models.Tasks)
                        //{
                        //    (entry.Entity as Models.Tasks).SaveHistoryItem(this, entry.State);
                        //}
                    }
                }

                int result = base.SaveChanges();
                return result;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                foreach (System.Data.Entity.Validation.DbEntityValidationResult result in ex.EntityValidationErrors)
                {
                    string entityName = result.Entry.Entity.GetType().FullName;
                    foreach (var validationError in result.ValidationErrors)
                    {
                        sb.AppendFormat("Class: {0}, Property: {1}, Error: {2}{3}",
                            entityName,
                            validationError.PropertyName,
                            validationError.ErrorMessage,
                            Environment.NewLine);
                    }
                }
                System.Diagnostics.Trace.TraceInformation(sb.ToString());
                throw new Exception(sb.ToString());
            }
            catch (System.Data.Entity.Validation.DbUnexpectedValidationException ex)
            {
                if (ex.InnerException != null)
                    throw ex.InnerException;
                else
                    throw ex;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                if (ex.InnerException != null)
                {
                    if (ex.InnerException.InnerException != null)
                    {
                        throw new Exception(ex.InnerException.InnerException.Message);
                    }
                    else
                    {
                        throw ex.InnerException;
                    }
                }
                else
                {
                    throw ex;
                }
            }
        }
    }
}