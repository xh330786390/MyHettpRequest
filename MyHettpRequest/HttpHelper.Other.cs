using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyHettpRequest
{
    public partial class HttpHelper
    {
        public static string HttpPostConnectToServer(string serverUrl, string postData)
        {
            var dataArray = Encoding.UTF8.GetBytes(postData);
            //创建请求  
            var request = (HttpWebRequest)HttpWebRequest.Create(serverUrl);
            request.Method = "POST";
            request.ContentLength = dataArray.Length;
            //设置上传服务的数据格式  
            request.ContentType = "application/x-www-form-urlencoded";
            //请求的身份验证信息为默认  
            request.Credentials = CredentialCache.DefaultCredentials;
            //请求超时时间  
            request.Timeout = 10000;
            //创建输入流  
            Stream dataStream;
            //using (var dataStream = request.GetRequestStream())  
            //{  
            //    dataStream.Write(dataArray, 0, dataArray.Length);  
            //    dataStream.Close();  
            //}  
            try
            {
                dataStream = request.GetRequestStream();
            }
            catch (Exception)
            {
                return null;//连接服务器失败  
            }
            //发送请求  
            dataStream.Write(dataArray, 0, dataArray.Length);
            dataStream.Close();
            //读取返回消息  
            string res;
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                res = reader.ReadToEnd();
                reader.Close();
            }
            catch (Exception ex)
            {
                //var result = new ServerResult();
                return "{\"error\":\"connectToServer\",\"error_description\":\"" + ex.Message + "\"}";//连接服务器失败  
            }
            return res;
        }

        public static string HttpGetConnectToServer(string serverUrl, string postData)
        {
            //创建请求  
            var request = (HttpWebRequest)HttpWebRequest.Create(serverUrl + "?" + postData);
            request.Method = "GET";
            //设置上传服务的数据格式  
            request.ContentType = "application/x-www-form-urlencoded";
            //请求的身份验证信息为默认  
            request.Credentials = CredentialCache.DefaultCredentials;
            //请求超时时间  
            request.Timeout = 10000;
            //读取返回消息  
            string res;
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                res = reader.ReadToEnd();
                reader.Close();
            }
            catch (Exception ex)
            {
                //var result = new ServerResult();  
                return "{\"error\":\"connectToServer\",\"error_description\":\"" + ex.Message + "\"}";
            }
            return res;
        }
    }
}
