using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationTracker
{
    class OwntracksLocationMessage:OwntracksMessage
    {
        public double acc { get; set; }
        public double lat { get; set; }

        public double lon { get; set; }

        public OwntracksLocationMessage(double lat, double lon, double acc): base("location")
        {
            this.lat = lat;
            this.lon = lon;
            this.acc = acc;
        }
    }
}
