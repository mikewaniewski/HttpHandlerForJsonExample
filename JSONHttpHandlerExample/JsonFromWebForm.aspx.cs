using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
 
using System.Runtime.Serialization.Json;
using System.Web.Services;

namespace JSONHttpHandlerExample
{
    public partial class JsonFromWebForm : System.Web.UI.Page
    {

        public class Customer
        {
            public int ID { get; set; }
            public string userName { get; set; }
        }


        [WebMethod]
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";
            var cust = new Customer
            {
                ID = int.Parse(Request["ID"]),
                userName = "testUser"
            };

            var ser = new DataContractJsonSerializer(typeof(Customer));

            ser.WriteObject(Response.OutputStream, cust);
        }
    }
}