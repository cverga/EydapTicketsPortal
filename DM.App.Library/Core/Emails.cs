using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.App.Library.Core
{

    public class Emails
    {

        public static string EMAIL_DELIMITER = ";";

        /// <summary>
        ///
        /// </summary>
        /// <param name="outboundMailSenderAddress"></param>
        /// <param name="messageFromTitle"></param>
        /// <param name="emailAddresses"></param>
        /// <param name="ccEmailAddresses"></param>
        /// <param name="bccEmailAddresses"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="from"></param>
        /// <param name="spFiles"></param>
        public static void SendEmail(string outboundMailSenderAddress, string messageFromTitle, List<string> emailAddresses, List<string> ccEmailAddresses, List<string> bccEmailAddresses, string subject, string body, System.Net.Mail.MailAddress from)
        {
            try
            {
                if (!string.IsNullOrEmpty(outboundMailSenderAddress))
                {
                    using (System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage())
                    {
                        if (from != null)
                            msg.From = from;
                        else
                            msg.From = new System.Net.Mail.MailAddress(outboundMailSenderAddress, messageFromTitle);
                        if (emailAddresses != null)
                        {
                            foreach (string email in emailAddresses)
                            {
                                msg.To.Add(new System.Net.Mail.MailAddress(email));
                            }
                        }
                        if (ccEmailAddresses != null)
                        {
                            foreach (string email in ccEmailAddresses)
                            {
                                msg.CC.Add(new System.Net.Mail.MailAddress(email));
                            }
                        }
                        if (bccEmailAddresses != null)
                        {
                            foreach (string email in bccEmailAddresses)
                            {
                                msg.Bcc.Add(new System.Net.Mail.MailAddress(email));
                            }
                        }
                        msg.IsBodyHtml = true;
                        msg.Body = body;
                        msg.Subject = subject;
                        if (!string.IsNullOrEmpty(subject) && subject.Length > 100)
                            msg.Subject = subject.Substring(0, 100) + "...";

                        //if (spFiles != null)
                        //{
                        //    for (int i = 0; i < spFiles.Length; i++)
                        //    {
                        //        System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(spFiles[i].OpenBinaryStream().Value, spFiles[i].Name);
                        //        msg.Attachments.Add(attachment);
                        //    }
                        //}
                        if (!string.IsNullOrEmpty(outboundMailSenderAddress))
                        {
                            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(outboundMailSenderAddress);
                            client.Send(msg);
                        }
                    }
                }
            }
            catch (Exception /* exeption */)
            {
                //Logger.LogEvent(CommonSP.Core.Configuration.APPLICATION_NAME, string.Format(CommonSP.Core.Configuration.ERROR_STRING_FORMAT, null, "EMails", "SendEmail", exeption.ToString()), System.Diagnostics.EventLogEntryType.Warning);
            }
        }

        public static string UntokenizeContent(string template, Dictionary<string, object> objects)
        {
            string text = string.Copy(template);
            Dictionary<string, string> tokens = new Dictionary<string, string>();
            string temp = string.Copy(template);
            while (!string.IsNullOrEmpty(temp))
            {
                int pos1 = temp.IndexOf("[[", StringComparison.InvariantCultureIgnoreCase);
                int pos2 = temp.IndexOf("]]", StringComparison.InvariantCultureIgnoreCase);

                if (pos1 > -1 && pos2 > -1)
                {
                    string key = temp.Substring(pos1, pos2 - pos1 + 2);
                    if (!tokens.ContainsKey(key))
                    {
                        string value = temp.Substring(pos1 + 2, pos2 - pos1 - 2);
                        if (value.IndexOf(".") > -1)
                        {
                            string entity = value.Substring(0, value.IndexOf("."));
                            if (objects.ContainsKey(entity) && objects[entity] != null)
                            {
                                string field = value.Substring(value.IndexOf(".") + 1);
                                object obj = objects[entity];
                                try
                                {
                                    System.Reflection.PropertyInfo pi = obj.GetType().GetProperty(field);
                                    if (pi != null)
                                    {
                                        object propvalue = pi.GetValue(obj);
                                        if (propvalue != null)
                                            value = propvalue.ToString();
                                    }
                                    else
                                    {
                                        System.Reflection.FieldInfo fi = obj.GetType().GetField(field);
                                        if (fi != null)
                                        {
                                            object propvalue = fi.GetValue(obj);
                                            if (propvalue != null)
                                                value = propvalue.ToString();
                                        }
                                    }
                                }
                                catch (Exception)
                                {
                                }
                            }
                        }
                        else
                        {
                            if (objects.ContainsKey(value) && objects[value] != null)
                            {
                                value = objects[value].ToString();
                            }
                        }
                        tokens.Add(key, value);
                    }
                }
                else
                    break;
                if (temp.Length > pos2 + 2)
                    temp = temp.Substring(pos2 + 2);
                else
                    temp = null;
            }

            foreach (KeyValuePair<string, string> kvp in tokens)
            {
                text = text.Replace(kvp.Key, kvp.Value);
            }

            return text;
        }
    }
}
