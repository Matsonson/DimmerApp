using System;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace DimmerApp {
    public static class ConfigManager
    {
        public static AppConfig LoadConfig(string filePath)
        {
            try
            {
                string jsonString = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<AppConfig>(jsonString);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading configuration: {ex.Message}");
                return null;
            }
        }
    }
}
