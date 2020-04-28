using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace NovaAudioAssistantLib.Settings
{
    public class SettingsHandler
    {
        private List<Setting> settings = new List<Setting>();
        private static XmlDocument doc = new XmlDocument();
        private string file;

        public SettingsHandler(string file)
        {
            this.file = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), file);
            if (!File.Exists(file))
            {
                SaveSettings();
            }
            doc.Load(file);

            XmlNodeList nodes = doc.SelectNodes("Settings/Setting");
            foreach (XmlNode node in nodes)
            {
                string name = node.Attributes[0].InnerText;
                string value_ = node.InnerText;
                object value = null;

                try
                {
                    value = int.Parse(value_);
                    settings.Add(new Setting(name, value));
                    continue;
                }
                catch { }

                try
                {
                    value = bool.Parse(value_);
                    settings.Add(new Setting(name, value));
                    continue;
                }
                catch { }

                try
                {
                    value = value_;
                    settings.Add(new Setting(name, value));
                    continue;
                }
                catch { }
            }
        }

        public void AddSetting(string name, object value)
        {
            if (!SettingExists(name))
            {
                settings.Add(new Setting(name, value));
            }
        }

        public Setting GetSetting(string name)
        {
            foreach (Setting setting in settings)
            {
                if (setting.GetName() == name)
                {
                    return setting;
                }
            }
            return new Setting();
        }

        public void UpdateSetting(string name, Setting setting)
        {
            settings.Remove(GetSetting(name));
            settings.Add(setting);
        }

        public void SaveSettings()
        {
            if (settings.Count > 0)
            {
                XmlWriterSettings xmlSettings = new XmlWriterSettings();
                xmlSettings.Indent = true;
                xmlSettings.IndentChars = "     ";
                xmlSettings.NewLineOnAttributes = false;
                xmlSettings.OmitXmlDeclaration = true;

                XmlWriter writer = XmlWriter.Create(file, xmlSettings);
                writer.WriteStartDocument();
                writer.WriteStartElement("Settings");
                foreach (Setting setting in settings)
                {
                    writer.WriteStartElement("Setting");
                    writer.WriteAttributeString("name", setting.GetName());
                    writer.WriteString(setting.GetValue().ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
            }
        }

        public bool SettingExists(string name)
        {
            foreach (Setting setting in settings)
            {
                if (setting.GetName() == name)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
