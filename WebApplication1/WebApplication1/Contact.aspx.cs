using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebApplication1
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("https://samples.openweathermap.org/");

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://openweathermap.org/");

            Task<HttpResponseMessage> response = client.GetAsync("data/2.5/weather?q=London,uk&appid=b6907d289e10d714a6e88b30761fae22");
            var result = response.Result.Content.ReadAsStringAsync().Result;

            var definition = new { visibility = "" };
            var wheather = JsonConvert.DeserializeAnonymousType(result.Replace(@"\", ""), definition);
            this.Label1.Text = wheather.visibility;
        }
    }
}