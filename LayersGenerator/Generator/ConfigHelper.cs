using System.Configuration;


namespace Generator
{
	public class ConfigHelper
	{
		private static string GetConfigValue(string key)
		{
			string value = ConfigurationManager.AppSettings[key];
			return value;
		}


		/// <summary>
		/// Get Template Name from App.Settings
		/// </summary>
		public static string TemplateName => GetConfigValue("TemplateName");

	}
}
