namespace NovaAudioAssistantLib.Settings
{
    public struct Setting
    {
        private string name;
        private object value;

        public Setting(string name, object value)
        {
            this.name = name;
            this.value = value;
        }

        public void UpdateValue(object value)
        {
            this.value = value;
        }

        public void UpdateName(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        } 

        public object GetValue()
        {
            return value;
        }
    }
}
