using System;
using Nolme.Xml;

namespace Test_XmlTranslation
{
	/// <summary>
	/// Summary description for Translation.
	/// </summary>
	public class Translation : XmlTranslator
	{
		public Translation()
		{
			
		}

		public void GenerateFile (string fileName)
		{
			XmlTranslatorElement element;

			// Add word translation
			element = new XmlTranslatorElement ("TRAD_Test", 0);
			element.AddOrUpdate (Language.French, "Ceci est un test", "Vincent", DateTime.Now);
			element.AddOrUpdate (Language.English, "This is a test", "Vincent", DateTime.Now);
			this.AddOrUpdateContainer (element);

			// Add word translation
			element = new XmlTranslatorElement ("TRAD_Languages", 0);
			element.AddOrUpdate (Language.French, "Langages", "Vincent", DateTime.Now);
			element.AddOrUpdate (Language.English, "Languages", "Vincent", DateTime.Now);
			this.AddOrUpdateContainer (element);

			// Add word translation
			this.Save (fileName);
		}
	}
}
