using Pi.Math;
using System.Configuration;

namespace Pi.Wcf
{
    public class PiService : IPiService
    {
        private static readonly int _DefaultDp = 6;
        private static readonly bool _MetricsEnabled;

        static PiService()
        {
            _MetricsEnabled = bool.Parse(ConfigurationManager.AppSettings["Computation:Metrics:Enabled"]);
        }

        public string Pi(string dp)
        {
            int.TryParse(dp, out int actualDp);
            if (actualDp < 1)
            {
                actualDp = _DefaultDp;
            }
            var pi = MachinFormula.Calculate(actualDp, _MetricsEnabled);
            return pi.ToString();
        }
    }
}
