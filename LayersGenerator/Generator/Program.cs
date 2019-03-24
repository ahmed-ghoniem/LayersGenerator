using Generator.Model;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;

namespace Generator
{
	internal class Program
	{

		private static void Main(string[] args)
		{
			string path = AppDomain.CurrentDomain.BaseDirectory;
			Console.WriteLine(path);
			FileHelper fileHelper = new FileHelper();
			PluralizationHelper ph = new PluralizationHelper();
			string fileContents = fileHelper.ReadFile(path, "Model.XML");
			XMLHelper xmlHelper = new XMLHelper();
			Model.Model model = xmlHelper.DeserializeText<Model.Model>(fileContents);
			Console.WriteLine("Please Enter Model Name");
			string className=Console.ReadLine();
			//string ModelName = "User";
			string ModelName = className;
			string instanceModel = ph. GetInstanceName(ModelName);
			string BaseModelName = "BaseModel";
			string PKType = "int";

			foreach (Item item in model.Items)
			{
				string contents = item.Class;
				contents = contents.Replace("{NameSpace}", item.NameSpace);
				contents = contents.Replace("{ModelName}", ModelName);
				contents = contents.Replace("{ModelNameSpace}", "Model");
				contents = contents.Replace("{ModelNamePluralized}", ph.Pluralize(ModelName));
				contents = contents.Replace("{PKType}", PKType);
				contents = contents.Replace("{BaseModelName}", BaseModelName);
				contents = contents.Replace("{instanceModel}", instanceModel);
				contents = ArrangeUsingRoslyn(contents);
				fileHelper.SaveFileToDisk(contents, path, item.FolderName, item.Prefix + ModelName + item.Suffix + ".cs");
			}
			//Console.ReadLine();
		}
		public static string ArrangeUsingRoslyn(string csCode)
		{
			var tree = CSharpSyntaxTree.ParseText(csCode);
			var root = tree.GetRoot().NormalizeWhitespace();
			var ret = root.ToFullString();
			return ret;
		}
	}
}
