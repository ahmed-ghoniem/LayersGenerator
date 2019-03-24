using System;
using System.IO;

namespace Generator
{
	public class FileHelper
	{
		public void SaveFileToDisk(string contents, string directoryBase, string folderName, string fileName)
		{
			string directoryPath = System.IO.Path.Combine(directoryBase,"output", folderName);
			//create directoryPath if not exist
			if (!Directory.Exists(directoryPath))
			{
				Directory.CreateDirectory(directoryPath);
			}
			//save bytes to physical file 
			string filePath = System.IO.Path.Combine(directoryPath, fileName);
			File.WriteAllText(filePath, contents);
		}


		public string ReadFile(string directoryPath, string fileName)
		{
			string contents = String.Empty;
			string filePath = System.IO.Path.Combine(directoryPath, fileName);
			//create directoryPath if not exist
			if (File.Exists(filePath))
			{
				contents = File.ReadAllText(filePath);
			}
			return contents;
		}
	}
}
