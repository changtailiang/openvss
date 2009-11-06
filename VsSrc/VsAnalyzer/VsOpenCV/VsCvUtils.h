/**
 * (C) 2007 Elad Ben-Israel
 * This code is licenced under the GPL.
 */

#pragma once

namespace VsOpenCV
{
	public ref class VsCvUtils
	{
	public:
		static void StringToCharPointer(String^ string, char* output, int size)
		{
			pin_ptr<const __wchar_t> p = PtrToStringChars(string);
			wcstombs_s(NULL, output, size, p, size);
		}

		static int Round(double val)
		{
			return cvRound(val);
		}

		static Color ScalarToColor(CvScalar scalar)
		{
			return Color::FromArgb((int) scalar.val[2], (int) scalar.val[1], (int) scalar.val[0]);
		}
	};
};