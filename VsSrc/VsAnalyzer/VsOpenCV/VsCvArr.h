#pragma once

namespace VsOpenCV
{
	public ref class VsCvArr abstract 
	{
	public:
		virtual property CvArr* Array
		{
			CvArr* get() = 0;
		}
	};
}