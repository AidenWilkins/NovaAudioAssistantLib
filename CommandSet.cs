using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaAudioAssistantLib
{
    public class CommandSet
    {
        private static Dictionary<string, dynamic> set = new Dictionary<string, dynamic>();

        public void AddCommand(string keyword, Helpers.Function function)
        {
            if (!set.ContainsKey(keyword))
            {
                set.Add(keyword, function);
            }
        }

        public void AddCommand(string keyword, Helpers.FunctionSub function)
        {
            if (!set.ContainsKey(keyword))
            {
                set.Add(keyword, function);
            }
        }

        public void RunCommand(string keyword, string subCommand)
        {
            if (set.ContainsKey(keyword))
            {
                try
                {
                    set[keyword](subCommand);
                }
                catch
                {
                    set[keyword]();
                }
            }
        }
    }
}
