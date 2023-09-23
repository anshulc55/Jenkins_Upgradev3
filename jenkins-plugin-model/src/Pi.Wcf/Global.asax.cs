using Prometheus;
using System;
using System.Configuration;

namespace Pi.Wcf
{
    public class Global : System.Web.HttpApplication
    {
        private static MetricServer _Server;        

        protected void Application_Start(object sender, EventArgs e)
        {
            var metricsEnabled = bool.Parse(ConfigurationManager.AppSettings["Computation:Metrics:Enabled"]);
            if (metricsEnabled)
            {
                _Server = new MetricServer(50505);
                _Server.Start();
            }
        }

        protected void Application_End(object sender, EventArgs e)
        {
            if (_Server != null)
            {
                _Server.Stop();
            }
        }
    }
}