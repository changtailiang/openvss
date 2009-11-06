using System;
using System.ComponentModel;		// [Description()] Tag
using System.Xml;
using System.Xml.Serialization;

namespace Nolme.Xml
{
	public enum Language
	{
		[Description("Invalid")]
		Invalid = -1,
		Arabic,
		Brazilian,
		Chinese,
		Czech,
		Danish,
		Dutch,
		English,
		Finnish,
		French,
		German,
		Greek,
		Hebrew,
		Hungarian,
		Italian,
		Japanese,
		Korean,
		Norwegian,
		Polish,
		Portuguese,
		Russian,
		Spanish,
		Swedish,
		Turkish,
		Max
	};


	/// <summary>
	/// Summary description for XmlLanguage.
	/// </summary>
	public class XmlLanguage
	{
		private Language	m_Language;

		public XmlLanguage()
		{
			m_Language			= Language.Invalid;
		}

		public XmlLanguage(Language language)
		{
			m_Language			= language;
		}

		[System.Xml.Serialization.XmlAttribute ("Language")]
		public Language		Language
		{
			get {return m_Language; }
			set {m_Language = value ;}
		}

		#region Static
		public static Language ConvertStringToLanguage (string languageToConvert)
		{
			if		(string.Compare (languageToConvert, "Arabic"	) == 0) return Language.Arabic		;
			else if (string.Compare (languageToConvert, "Brazilian"	) == 0) return Language.Brazilian	;
			else if (string.Compare (languageToConvert, "Chinese"	) == 0) return Language.Chinese		;
			else if (string.Compare (languageToConvert, "Czech"		) == 0) return Language.Czech		;
			else if (string.Compare (languageToConvert, "Danish"	) == 0) return Language.Danish		;
			else if (string.Compare (languageToConvert, "Dutch"		) == 0) return Language.Dutch		;
			else if (string.Compare (languageToConvert, "English"	) == 0) return Language.English		;
			else if (string.Compare (languageToConvert, "Finnish"	) == 0) return Language.Finnish		;
			else if (string.Compare (languageToConvert, "French"	) == 0) return Language.French		;
			else if (string.Compare (languageToConvert, "German"	) == 0) return Language.German		;
			else if (string.Compare (languageToConvert, "Greek"		) == 0) return Language.Greek		;
			else if (string.Compare (languageToConvert, "Hebrew"	) == 0) return Language.Hebrew		;
			else if (string.Compare (languageToConvert, "Hungarian"	) == 0) return Language.Hungarian	;
			else if (string.Compare (languageToConvert, "Italian"	) == 0) return Language.Italian		;
			else if (string.Compare (languageToConvert, "Japanese"	) == 0) return Language.Japanese	;
			else if (string.Compare (languageToConvert, "Korean"	) == 0) return Language.Korean		;
			else if (string.Compare (languageToConvert, "Norwegian"	) == 0) return Language.Norwegian	;
			else if (string.Compare (languageToConvert, "Polish"	) == 0) return Language.Polish		;
			else if (string.Compare (languageToConvert, "Portuguese") == 0) return Language.Portuguese	;
			else if (string.Compare (languageToConvert, "Russian"	) == 0) return Language.Russian		;
			else if (string.Compare (languageToConvert, "Spanish"	) == 0) return Language.Spanish		;
			else if (string.Compare (languageToConvert, "Swedish"	) == 0) return Language.Swedish		;
			else if (string.Compare (languageToConvert, "Turkish"	) == 0) return Language.Turkish		;
			else															return Language.Invalid;
		}
		#endregion
	}
}
