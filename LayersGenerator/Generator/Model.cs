using System.Collections.Generic;
using System.Xml.Serialization;

namespace Generator.Model
{

	// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public class Model
	{
		[XmlArray(ElementName = "Items")]
		[XmlArrayItem("Item")]
		public List<Item> Items { get; set; }

        public string ModelNameSpace { get; set; }

		public Model()
		{
			Items = new List<Item>();
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public class Item
	{
		public string FolderName { get; set; }
		public string NameSpace { get; set; }
		public string Suffix { get; set; }
		public string Prefix { get; set; }
		public string Class { get; set; }
	}
}
