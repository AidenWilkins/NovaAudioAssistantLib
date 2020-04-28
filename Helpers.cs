using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaAudioAssistantLib
{
    public static class Helpers
    {
        public delegate void Function();

        public delegate void FunctionSub(string subCommand = "");
    }
}
