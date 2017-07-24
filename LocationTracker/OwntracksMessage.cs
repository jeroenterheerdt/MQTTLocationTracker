using System;

namespace LocationTracker
{
    internal class OwntracksMessage
    {
        public string _type { get; set; }
        public long tst { get; set; }

        public OwntracksMessage(string t)
        {
            _type = t;
            tst = DateTimeOffset.Now.ToUnixTimeSeconds();
        }
    }
}