using System.Collections.Generic;
using System.Dynamic;
using System.Web.Http;
using System.Security.Cryptography;
using Newtonsoft.Json.Linq;
using System.Text;
using System;
using System.Net;
using System.Net.Http;

namespace MessageService
{
    public class MessagesController : ApiController
    {
        private static Dictionary<string, string> _msgTable = new Dictionary<string, string>();
        private readonly string ErrorMessage = "Message not found";
        private readonly SHA256 ShaEncrption= SHA256.Create();

        [Route("messages/{hash}")]
        [HttpGet]
        public string Get(string hash)
        {
            dynamic response = new ExpandoObject();
            if (_msgTable.ContainsKey(hash))
                response.message = _msgTable[hash];
            else
            {
                response.err_msg = ErrorMessage;
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(response))
                });
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(response);
        }

        [Route("messages")]
        [HttpPost]
        public string Post(JObject jsonResult)
        {
            dynamic stuff = jsonResult;
            dynamic response = new ExpandoObject();
            response.digest = Hash(stuff.message);
            return Newtonsoft.Json.JsonConvert.SerializeObject(response);
        }

        private string Hash(dynamic input)
        {
            var inputString = Convert.ToString(input);
            byte[] bytes = Encoding.Unicode.GetBytes(inputString);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            _msgTable[hashString] = inputString;
            return hashString;
        }
    }
}
