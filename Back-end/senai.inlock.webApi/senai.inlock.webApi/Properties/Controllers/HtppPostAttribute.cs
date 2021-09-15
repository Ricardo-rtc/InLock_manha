using System;

namespace senai.inlock.webApi.Properties.Controllers
{
    internal class HtppPostAttribute : Attribute
    {
        private string v;

        public HtppPostAttribute(string v)
        {
            this.v = v;
        }
    }
}