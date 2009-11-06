using System;
using Nolme.Xml;

namespace Test_XmlTranslation
{
	class Class1
	{
		/// <summary>
		/// The main entry point for the application.
		/// This sample demonstrate how to serialize to XML translation objet
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			try
			{
				// INIT
				Translation	MyTranslation = new Translation ();

				string szFilename = @".\Translation.XML";
				MyTranslation.GenerateFile (szFilename);
				MyTranslation.Clear ();
				MyTranslation.Load (szFilename);

				// Set translation language
				MyTranslation.CurrentLanguage = Language.English;

				// Translate few words
				string szTextToTranslate = "TRAD_Test";
				string szTranslatedText;
				szTranslatedText = MyTranslation.Translate (szTextToTranslate);

				Console.WriteLine ("Current language : ");
				Console.WriteLine ("'" + MyTranslation.CurrentLanguage.ToString () + "'");
				Console.WriteLine ();

				Console.WriteLine ("Text to translate : ");
				Console.WriteLine ("'" + szTextToTranslate + "'");
				Console.WriteLine ();

				Console.WriteLine ("Text in current language : ");
				Console.WriteLine ("'" + szTranslatedText + "'");
				Console.WriteLine ();
			}
			catch (Exception e)
			{
				Console.WriteLine ("ERROR");
				Console.WriteLine (e.ToString ());
			}

			Console.WriteLine ("Press RETURN to quit");
			Console.ReadLine ();
		}
	}
}
