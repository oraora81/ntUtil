using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace ntCmdFtp
{
    class FtpBase
    {
        public FtpWebRequest m_request;

        public bool Connect(string address, string port, string id, string pwd)
        {
            if (address.Length == 0)
            {
                return false;
            }

            string conStr = "ftp://";
            conStr += address;
            if (port.Length != 0)
            {
                conStr += ":";
                conStr += port;
            }

            FtpWebRequest m_request = WebRequest.Create(conStr) as FtpWebRequest;
            if (m_request == null)
            {
                return false;
            }

            m_request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            m_request.Credentials = new NetworkCredential("admin", "#otmdnjem@!");
            FtpWebResponse response = (FtpWebResponse)m_request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            Console.WriteLine(reader.ReadToEnd());

            Console.WriteLine("Directory List Complete, Status {0}", response.StatusDescription);

            reader.Close();
            response.Close();

            return true;
        }
    }
}
