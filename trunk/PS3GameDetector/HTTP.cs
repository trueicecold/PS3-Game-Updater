using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace PS3GameDetector
{
    class HTTP
    {
        public static string UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US) AppleWebKit/534.10 (KHTML, like Gecko) Chrome/8.0.552.237 Safari/534.10";
        public static string Referer = "";

        public static string POST(string strURL, string strPars)
        {
            return (HttpRequest("POST", strURL, strPars));
        }

        public static string POST(string strURL, string strPars, CookieContainer c)
        {
            return (HttpPostRquestWithSession(strURL, strPars, c, ""));
        }

        public static string GET(string strURL)
        {
            return (HttpRequest("GET", strURL, ""));
        }

        public static string SimplifyCookies(CookieContainer c, string strUrl)
        {
            CookieCollection col = c.GetCookies(new Uri(strUrl));
            string finalCookie = "";

            for (int i = 0; i < col.Count; i++)
            {
                if (i == col.Count - 1)
                {
                    finalCookie = finalCookie + col[i];
                }
                else
                {
                    finalCookie = finalCookie + col[i] + "&";
                }
            }

            return finalCookie;
        }

        private static string HttpRequest(string strMethod, string strURL, string strPars)
        {
            System.Net.HttpWebRequest req = (HttpWebRequest)System.Net.WebRequest.Create(strURL);
            req.AllowAutoRedirect = true;
            req.ContentType = "application/x-www-form-urlencoded";
            req.Timeout = 10000;

            req.Method = strMethod;

            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
            if (strMethod == "POST")
            {
                byte[] bytes = System.Text.Encoding.ASCII.GetBytes(strPars);
                req.ContentLength = bytes.Length;

                System.IO.Stream os = req.GetRequestStream();
                os.Write(bytes, 0, bytes.Length);
                os.Close();
            }

            HttpWebRequest reqU = (HttpWebRequest)req;

            try
            {
                HttpWebResponse response = (HttpWebResponse)reqU.GetResponse();
                System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream());
                return sr.ReadToEnd().Trim();
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        static string HttpPostRquestWithSession(string url, string pars, CookieContainer cookies, string Referer)
        {
            System.Net.HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.CookieContainer = cookies;
            req.AllowAutoRedirect = true;

            req.ContentType = "application/x-www-form-urlencoded";

            if (Referer != "")
            {
                req.Referer = Referer;
            }

            req.KeepAlive = true;

            req.Method = "POST";
            req.Timeout = 30000;
            byte[] bytes = System.Text.Encoding.Default.GetBytes(pars);
            req.ContentLength = bytes.Length;

            System.IO.Stream os = req.GetRequestStream();
            os.Write(bytes, 0, bytes.Length);
            os.Close();

            System.Net.WebResponse resp = req.GetResponse();

            if (resp == null) return null;

            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream(), Encoding.GetEncoding(1255));
            string rt = sr.ReadToEnd().Trim();
            return rt;
        }

        static bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}
