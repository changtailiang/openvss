using System;
using Nolme.Xml;

namespace Test_XmlConfiguration
{
	class Class1
	{
		/// <summary>
		/// The main entry point for the application.
		/// This sample demonstrate how to serialize to XML various objects
		/// like integer, string, hashtable, arraylist, color with different levels of recursion
		/// (XmlList in XmlHashtable for example :))
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			try
			{
				string				szConfigurationFile = @"./config.XML";
				TestConfiguration	Config = new TestConfiguration ();

				// Save configuration file
				Console.WriteLine ("Writing configuration file");
				Config.Save (szConfigurationFile);

				// Assign new values
				Console.WriteLine ("Reset values");
				Config.MyFloat	= 0.0f;
				Config.MyString	=String.Empty;
				Config.MyInt	= 64;

				// Reload default values
				Console.WriteLine ("Reload default configuration");
				Config = TestConfiguration.Load (szConfigurationFile);
			}
			catch (Exception e)
			{
				Console.WriteLine ("ERROR");
				Console.WriteLine (e.ToString ());
			}

			Console.WriteLine ("Press Return to quit");
			Console.ReadLine ();
		}
	}
}
