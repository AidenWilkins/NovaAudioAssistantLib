using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaAudioAssistantLib.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class Addon : Attribute
    {
        private string name;
        private string desc;
        private string creator;
        private string version;

        public Addon(string name, string desc = "", string creator = "", string version = "0.1.0")
        {
            this.name = name;
            this.desc = desc;
            this.creator = creator;
            this.version = version;
        }

        public virtual string Name
        {
            get { return name; }
        }

        public virtual string Desc
        {
            get { return desc; }
        }

        public virtual string Creator
        {
            get { return creator; }
        }

        public virtual string Version
        {
            get { return version; }
        }
    }
}
