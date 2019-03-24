using System;
using System.IO;
using System.Xml.Serialization;

namespace Generator
{
	public class XMLHelper
	{
		/// <summary>
		/// convert string to class
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="contents">contents</param>
		/// <returns></returns>
		public T DeserializeText<T>(string contents) where T : class
		{
			using (TextReader reader = new StringReader(contents))
			{
				try
				{
					T temp = (T)new XmlSerializer(typeof(T)).Deserialize(reader);
					return temp;
				}
				catch (Exception ex)
				{
					reader?.Dispose();
					return null;
				}
			}
		}

	}
}
