#pragma once
#define ORIG_WIN_SIZE  24
#include <time.h>

namespace VsOpenCV
{
	public ref class VsCvObjectDetection : public VsCvImage
	{
		public:

		String^ vsResult;

		CvMemStorage* storage;
		CvHaarClassifierCascade* hid_cascade;
		int objindex;

		VsCvObjectDetection(int in, int out, int width, int height, cvDepth depth, int channels)
			: VsCvImage(in, out, width, height, depth, channels)
		{
		}

		~VsCvObjectDetection(void)
		{
			
		}

		void VsInit()
		{
			storage = cvCreateMemStorage();
			hid_cascade = 0;
			objindex = 0;

			VsLoadObject1();
		}

		void VsLoadObject1() { hid_cascade = cvLoadHaarClassifierCascade(".\\opencv\\data\\haarcascade_eye.xml", cvSize( ORIG_WIN_SIZE, ORIG_WIN_SIZE )); }

		void VsLoadObject2() { hid_cascade = cvLoadHaarClassifierCascade(".\\opencv\\data\\haarcascade_eye_tree_eyeglasses.xml", cvSize( ORIG_WIN_SIZE, ORIG_WIN_SIZE )); }

		void VsLoadObject3() { hid_cascade = cvLoadHaarClassifierCascade(".\\opencv\\data\\haarcascade_frontalface_alt.xml", cvSize( ORIG_WIN_SIZE, ORIG_WIN_SIZE )); }

		void VsLoadObject4() { hid_cascade = cvLoadHaarClassifierCascade(".\\opencv\\data\\haarcascade_frontalface_alt2.xml", cvSize( ORIG_WIN_SIZE, ORIG_WIN_SIZE )); }

		void VsLoadObject5() { hid_cascade = cvLoadHaarClassifierCascade(".\\opencv\\data\\haarcascade_frontalface_alt_tree.xml", cvSize( ORIG_WIN_SIZE, ORIG_WIN_SIZE )); }

		void VsLoadObject6() { hid_cascade = cvLoadHaarClassifierCascade(".\\opencv\\data\\haarcascade_frontalface_default.xml", cvSize( ORIG_WIN_SIZE, ORIG_WIN_SIZE )); }

		void VsLoadObject7() { hid_cascade = cvLoadHaarClassifierCascade(".\\opencv\\data\\haarcascade_fullbody.xml", cvSize( ORIG_WIN_SIZE, ORIG_WIN_SIZE )); }

		void VsLoadObject8() { hid_cascade = cvLoadHaarClassifierCascade(".\\opencv\\data\\haarcascade_lefteye_2splits.xml", cvSize( ORIG_WIN_SIZE, ORIG_WIN_SIZE )); }

		void VsLoadObject9() { hid_cascade = cvLoadHaarClassifierCascade(".\\opencv\\data\\haarcascade_lowerbody.xml", cvSize( ORIG_WIN_SIZE, ORIG_WIN_SIZE )); }

		void VsLoadObject10() { hid_cascade = cvLoadHaarClassifierCascade(".\\opencv\\data\\haarcascade_mcs_eyepair_big.xml", cvSize( ORIG_WIN_SIZE, ORIG_WIN_SIZE )); }

		void VsLoadObject11() { hid_cascade = cvLoadHaarClassifierCascade(".\\opencv\\data\\haarcascade_mcs_eyepair_small.xml", cvSize( ORIG_WIN_SIZE, ORIG_WIN_SIZE )); }

		void VsLoadObject12() { hid_cascade = cvLoadHaarClassifierCascade(".\\opencv\\data\\haarcascade_mcs_lefteye.xml", cvSize( ORIG_WIN_SIZE, ORIG_WIN_SIZE )); }

		void VsLoadObject13() { hid_cascade = cvLoadHaarClassifierCascade(".\\opencv\\data\\haarcascade_mcs_mouth.xml", cvSize( ORIG_WIN_SIZE, ORIG_WIN_SIZE )); }

		void VsLoadObject14() { hid_cascade = cvLoadHaarClassifierCascade(".\\opencv\\data\\haarcascade_mcs_nose.xml", cvSize( ORIG_WIN_SIZE, ORIG_WIN_SIZE )); }

		void VsLoadObject15() { hid_cascade = cvLoadHaarClassifierCascade(".\\opencv\\data\\haarcascade_mcs_righteye.xml", cvSize( ORIG_WIN_SIZE, ORIG_WIN_SIZE )); }

		void VsLoadObject16() { hid_cascade = cvLoadHaarClassifierCascade(".\\opencv\\data\\haarcascade_mcs_upperbody.xml", cvSize( ORIG_WIN_SIZE, ORIG_WIN_SIZE )); }

		void VsLoadObject17() { hid_cascade = cvLoadHaarClassifierCascade(".\\opencv\\data\\haarcascade_profileface.xml", cvSize( ORIG_WIN_SIZE, ORIG_WIN_SIZE )); }

		void VsLoadObject18() { hid_cascade = cvLoadHaarClassifierCascade(".\\opencv\\data\\haarcascade_righteye_2splits.xml", cvSize( ORIG_WIN_SIZE, ORIG_WIN_SIZE )); }

		void VsLoadObject19() { hid_cascade = cvLoadHaarClassifierCascade(".\\opencv\\data\\haarcascade_upperbody.xml", cvSize( ORIG_WIN_SIZE, ORIG_WIN_SIZE )); }

		void VsUnloadObject()
		{
			CvHaarClassifierCascade *hid = hid_cascade;
			cvReleaseHaarClassifierCascade(&hid);
			hid_cascade = 0;
		}

		void VsConfiguration(int idx)
		{
			if(idx != objindex && (idx>=0 && idx<=7))
			{
				VsUnloadObject();
				objindex = idx;
				switch(objindex)
				{
					case 0 : VsLoadObject1(); break;
					case 1 : VsLoadObject2(); break;
					case 2 : VsLoadObject3(); break;
					case 3 : VsLoadObject4(); break;
					case 4 : VsLoadObject5(); break;
					case 5 : VsLoadObject6(); break;
					case 6 : VsLoadObject7(); break;
					case 7 : VsLoadObject8(); break;
					case 8 : VsLoadObject9(); break;
					case 9 : VsLoadObject10(); break;
					case 10 : VsLoadObject11(); break;
					case 11 : VsLoadObject12(); break;
					case 12 : VsLoadObject13(); break;
					case 13 : VsLoadObject14(); break;
					case 14 : VsLoadObject15(); break;
					case 15 : VsLoadObject16(); break;
					case 16 : VsLoadObject17(); break;
					case 17 : VsLoadObject18(); break;
					case 18 : VsLoadObject19(); break;
				}
			}
		}

		String^ VsResult()
		{
			return vsResult;
		}

		Bitmap^ VsProcess(Bitmap^ srcImage1) 
		{
			LoadImage(srcImage1, 1);

			cvCopy(image1, imageout);

			vsResult = "";

			if( hid_cascade && image1 )
			{
				int scale = 2;
				CvSize img_size = cvGetSize( image1 );
				IplImage* temp = cvCreateImage( cvSize(img_size.width/2,img_size.height/2), 8, 3 );
				IplImage* canvas = cvCreateImage( cvSize(temp->width,temp->height*3/2), 8, 3 );
				CvPoint offset = cvPoint( 0, temp->height/3 );
				int i;

				cvZero( canvas );
				cvPyrDown( image1, temp );
				cvClearMemStorage( storage );

				cvSetImageROI( canvas, cvRect( offset.x, offset.y, temp->width, temp->height ));
				cvCopy( temp, canvas );
				cvResetImageROI( canvas );
		    
				if( hid_cascade )
				{
					CvSeq* faces = cvHaarDetectObjects( canvas, hid_cascade, storage, 1.2, 2, 1 );
					scale = 2;

					vsResult = "";
					for( i = 0; i < (faces ? faces->total : 0); i++ )
					{
						CvRect r = *(CvRect*)cvGetSeqElem( faces, i );
						r.x -= offset.x;
						r.y -= offset.y;
						cvRectangle(imageout,
									 cvPoint(r.x*scale,/*image1->height - */r.y*scale),
									 cvPoint((r.x+r.width)*scale,/*image1->height - */(r.y+r.height)*scale),
									 CV_RGB(255,0,0), 3);
						// update face information
						vsResult += (r.x*scale).ToString() + "," + (r.y*scale).ToString() + "," + (r.width*scale).ToString() + "," + (r.height*scale).ToString() + ";";
					}
				}

				cvReleaseImage( &temp );
				cvReleaseImage( &canvas );
			}

			return SaveImage(1);
		}
	};
}