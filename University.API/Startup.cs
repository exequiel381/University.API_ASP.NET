using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using University.BL.Data;

[assembly: OwinStartup(typeof(University.API.Startup))]

namespace University.API
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            //Configure the db context to use a single instance per request
            app.CreatePerOwinContext(UniversityContext.Create);    
        }
    }
}
