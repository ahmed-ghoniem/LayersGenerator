using System;
using System.Data.Entity.Design.PluralizationServices;
using System.Globalization;

namespace Generator
{
	public class PluralizationHelper
	{
		public string Pluralize(string word)
		{
			string pluralizeWord = word;
			CultureInfo ci = new CultureInfo("en-us");
			PluralizationService ps = PluralizationService.CreateService(ci);
			if (ps.IsSingular(word))
			{
				pluralizeWord = ps.Pluralize(word);
			}
			return pluralizeWord;
		}

		public string GetInstanceName(string word)
		{
			string pluralizeWord =   Char.ToLowerInvariant(word[0]) + word.Substring(1);			
			return pluralizeWord;
		}
	}
}
