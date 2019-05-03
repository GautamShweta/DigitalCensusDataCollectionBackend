
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using System.Web.Http.Cors;
namespace Nagarro_Exit_Test_Assignment.App_Start
    {
    

    public class WebApiConfig
        {
        public static void Register(HttpConfiguration configuration)
            {
              configuration.Routes.MapHttpRoute("API Default", "api/{controller}/{id}",
              new { id = RouteParameter.Optional });

            var jsonFormatter = configuration.Formatters.JsonFormatter;
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            configuration.Formatters.Remove(configuration.Formatters.XmlFormatter);
            jsonFormatter.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
            var cors = new EnableCorsAttribute("*", "*", "*");//origins,headers,methods   
            configuration.EnableCors(cors);
            }
        }
    }