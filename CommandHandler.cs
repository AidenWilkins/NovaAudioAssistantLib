using System.Collections.Generic;
using System.Speech.Recognition;

namespace NovaAudioAssistantLib
{
    public class CommandHandler
    {
        private static Dictionary<string, CommandSet> commandSet;
        static Choices customPreCommands = new Choices();
        static Choices customCommands = new Choices();
        static Choices customSubCommands = new Choices();
        string currentCustomPreCommand = "";
        private float confidence = 0.925f;

        public CommandHandler()
        {
            commandSet = new Dictionary<string, CommandSet>();
        }

        public bool InitCommandSet(string setName = "command")
        {
            if (!commandSet.ContainsKey(setName))
            {
                currentCustomPreCommand = setName;
                commandSet.Add(setName, new CommandSet());
                customPreCommands.Add(setName);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CreateCommandCall(string keyword, Helpers.Function function)
        {
            commandSet[currentCustomPreCommand].AddCommand(keyword, function);
            customCommands.Add(keyword);
        }

        public void CreateSubCommandCall(string keyword, Helpers.FunctionSub function)
        {
            commandSet[currentCustomPreCommand].AddCommand(keyword, function);
            customCommands.Add(keyword);
        }

        public void CreateSubCommand(string keyword)
        {
            customSubCommands.Add(keyword);
        }

        public void RunCommand(string setName, string keyword, string subCommand = "")
        {
            if (commandSet.ContainsKey(setName))
            {
                commandSet[setName].RunCommand(keyword, subCommand);
            }
        }

        public Choices GetCommands()
        {
            return customCommands;
        }

        public Choices GetPreCommands()
        {
            return customPreCommands;
        }

        public Choices GetSubCommands()
        {
            return customSubCommands;
        }

        public float GetConfidence()
        {
            return confidence;
        }

        public void SetConfidence(float confidence)
        {
            this.confidence = confidence;
        }
    }
}
