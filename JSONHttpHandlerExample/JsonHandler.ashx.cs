using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;


namespace JSONHttpHandlerExample
{
    /// <summary>
    /// Summary description for JsonHandler
    /// </summary>
    public class JsonHandler : IHttpHandler
    {

        public class Customer
        {
            public int ID { get; set; }
            public string userName { get; set; }
        }


        public void ProcessRequest(HttpContext context)
        {

            var jsonSerializer = new JavaScriptSerializer();

            var cust = new Customer

            {
                ID = int.Parse(context.Request.QueryString["ID"]),
                userName = "testUser"
            };



            context.Response.ContentType = "application/json";
            context.Response.ContentEncoding = Encoding.UTF8;
            context.Response.Write(jsonSerializer.Serialize(cust));



        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}