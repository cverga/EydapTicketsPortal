using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DM.App.Library.Core
{
    public class HttpProxy
    {
        public string ServiceContract { get; set; }
        public string ServiceUrl { get; set; }
        public bool IsPost { get; set; }
        public string PostData { get; set; }
        public string Response { get; set; }
        public System.Net.ICredentials Credentials { get; set; }
        public bool AutoDetectEncoding { get; set; }
        public Dictionary<string, string> Headers { get; set; }

        public HttpProxy(string serviceContract, string serviceUrl, bool isPost, string postData)
        {
            this.ServiceContract = serviceContract;
            this.ServiceUrl = serviceUrl;
            this.IsPost = isPost;
            this.PostData = postData;

            this.Headers = new Dictionary<string, string>();
        }

        public bool GetExternalData()
        {
            bool isMethodPost = false;
            isMethodPost = this.IsPost;

            System.Net.HttpWebRequest request = null;
            request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(this.ServiceUrl);
            request.UseDefaultCredentials = true;
            if (this.Credentials != null)
                request.Credentials = this.Credentials;

            if (this.Headers != null)
            {
                foreach (KeyValuePair<string, string> item in this.Headers)
                {
                    request.Headers.Add(item.Key, item.Value);
                }
            }

            if (isMethodPost)
            {
                string postData = this.PostData;
                byte[] data = System.Text.Encoding.UTF8.GetBytes(postData);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                using (System.IO.Stream s = request.GetRequestStream())
                {
                    s.Write(data, 0, data.Length);
                }
            }
            System.Net.HttpWebResponse response = null;
            try
            {
                response = (System.Net.HttpWebResponse)request.GetResponse();

            }
            catch (System.Net.WebException ex)
            {
                if (ex.Response != null)
                {
                    if (ex.Response.Headers["SPRequestGuid"] != null)
                    {
                        Guid correlationId = new Guid(ex.Response.Headers["SPRequestGuid"]);
                    }
                }
                throw;
            }
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                if (this.AutoDetectEncoding)
                {
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream()))
                    {
                        this.Response = sr.ReadToEnd();
                    }
                }
                else
                {
                    using (System.IO.Stream s = response.GetResponseStream())
                    {
                        string responseText = "";
                        int defaultSize = 1024 * 1024;
                        if (response.ContentLength > 0)
                            defaultSize = Convert.ToInt32(response.ContentLength);
                        byte[] buffer = new byte[defaultSize];
                        int bytesRead = 0;

                        while ((bytesRead = s.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            responseText += System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        }
                        this.Response = responseText;
                    }
                }
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                // Do nothing
            }
            else
                throw new Exception(string.Format("Action service call failed. Status code: {0} [{1}]", response.StatusCode, response.StatusDescription));

            response.Close();
            return true;
        }
    }
}