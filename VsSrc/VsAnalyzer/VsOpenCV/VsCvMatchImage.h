#pragma once
#include <time.h>

namespace VsOpenCV
{
	public ref class VsCvMatchImage : public VsCvImage
	{
		private:
		String^ vsResult;

		// TODO
		//load1 and load2
		IplImage    *load1               , *load2      ;
		IplImage    *hsv_load1      , *hsv_load2  ;
		IplImage    *hue_load1      , *hue_load2  ;
		IplImage    *mask_load1   , *mask_load2 ;
		CvHistogram *hist_load1  , *hist_load2 ;

		//image1 and image2 
		IplImage *hsv_image1   , *hsv_image2   ;
		IplImage *hue_image1   , *hue_image2   ;
		IplImage *mask_image1  , *mask_image2  ;
		IplImage *backproject1 , *backproject2 ;



		//CvMat 
		CvMat *map_matrix;
		int TX, X1, X2 ;
		int TY, Y1, Y2 ;

		//key
		int match;
		int count;
		int maxcount;


		int width, height;

	

		public:

		VsCvMatchImage(int in, int out, int w, int h, cvDepth depth, int channels)
			: VsCvImage(in, out, w, h, depth, channels)
		{

		}

		void VsInit()
		{
			// TODO
			vsResult = "";
			maxcount = 50;
			int  hdims1 = 16;
			int  hdims2 = 16;
			float hranges_arr1[] = {0, 180};
			float hranges_arr2[] = {0, 180};
			float *hranges1 = 	hranges_arr1,*hranges2 = hranges_arr2;

			load1 = cvLoadImage("laser point1.bmp");
			load2 = cvLoadImage("laser point2.bmp");

			map_matrix =  cvCreateMat(2, 3, CV_32F); 

			TX = 0, X1= 0, X2= 0 ;
			TY= 0, Y1= 0, Y2= 0 ;

			match = 0;
			count = 0;

			hsv_load1  = cvCreateImage(  cvGetSize(load1),  IPL_DEPTH_8U, 3);
			hsv_load2  = cvCreateImage(  cvGetSize(load2),  IPL_DEPTH_8U, 3);

			hue_load1 = cvCreateImage( cvGetSize(load1),  IPL_DEPTH_8U, 1);
			hue_load2 = cvCreateImage( cvGetSize(load2),  IPL_DEPTH_8U, 1);

			mask_load1  = cvCreateImage( cvGetSize(load1),  IPL_DEPTH_8U, 1);
			mask_load2  = cvCreateImage( cvGetSize(load2),  IPL_DEPTH_8U, 1); 

			hist_load1 = cvCreateHist( 1, &hdims1, CV_HIST_ARRAY, &hranges1);
			hist_load2 = cvCreateHist( 1, &hdims2, CV_HIST_ARRAY, &hranges2);

			hsv_image1 = cvCreateImage(cvSize(Width, Height), IPL_DEPTH_8U, 3);
			hsv_image2 = cvCreateImage(cvSize(Width, Height), IPL_DEPTH_8U, 3);
			
			hue_image1 = cvCreateImage( cvSize(Width, Height), IPL_DEPTH_8U, 1);
			hue_image2 = cvCreateImage( cvSize(Width, Height), IPL_DEPTH_8U, 1);

			mask_image1 = cvCreateImage( cvSize(Width, Height), IPL_DEPTH_8U, 1);
			mask_image2 = cvCreateImage( cvSize(Width, Height), IPL_DEPTH_8U, 1);

			backproject1 = cvCreateImage( cvSize(Width, Height), IPL_DEPTH_8U, 1);
			backproject2 = cvCreateImage( cvSize(Width, Height), IPL_DEPTH_8U, 1);


			cvCvtColor( load1, hsv_load1,  CV_BGR2HSV );
			cvCvtColor( load2, hsv_load2,  CV_BGR2HSV );

			cvInRangeS( hsv_load1, cvScalar( 0, 0, 250, 0), cvScalar( 180, 256, 256, 0 ), mask_load1);
			cvSplit( hsv_load1, hue_load1, 0, 0, 0 );

			cvInRangeS( hsv_load2, cvScalar( 0, 0, 250, 0), cvScalar( 180, 256, 256, 0 ), mask_load2);
			cvSplit( hsv_load2, hue_load2, 0, 0, 0 );

			IplImage *tmp_hue_load1 = hue_load1;
			IplImage *tmp_hue_load2 = hue_load2;

			cvCalcHist( &tmp_hue_load1, hist_load1, 0, mask_load1 );
			cvCalcHist( &tmp_hue_load2, hist_load2, 0, mask_load2 );

		}

		~VsCvMatchImage(void)
		{
			// TODO
			IplImage* str;

			str = load1 ;   cvReleaseImage(&str);
			str = load2 ;   cvReleaseImage(&str);

			str = hsv_load1;    cvReleaseImage(&str);
			str = hsv_load2;    cvReleaseImage(&str);

			str = hue_load1;    cvReleaseImage(&str);
			str = hue_load2;    cvReleaseImage(&str);

			str = mask_load1;   cvReleaseImage(&str);
			str = mask_load2;   cvReleaseImage(&str);

			str = hsv_image1;   cvReleaseImage(&str);
			str = hsv_image2;   cvReleaseImage(&str);

			str = hue_image1;   cvReleaseImage(&str);
			str = hue_image2;   cvReleaseImage(&str);

			str = mask_image1;  cvReleaseImage(&str);
			str = mask_image2;  cvReleaseImage(&str);

			str = backproject1; cvReleaseImage(&str);
			str = backproject2; cvReleaseImage(&str);
		}

		void VsConfiguration(int th)
		{
			   if(th> 25)
					count=0;
		}

		String^ VsResult()
		{
			return vsResult;
		}

		Bitmap^ VsProcess(Bitmap^ srcImage1, Bitmap^ srcImage2)
		{
			LoadImage(srcImage1, 1);	// load "image1"
			LoadImage(srcImage2, 2);	// load "image2"	
			cvSet(imageout, cvScalar(255, 255, 255));
		
			// TODO
			CvBox2D track_box1, track_box2;
			CvConnectedComp track_comp1, track_comp2;
			CvPoint p1, p2;
			CvRect selection1,    selection2;
			CvRect track_window1, track_window2;
			
			selection1 = cvRect(0, 80, 320, 80);
			selection2 = cvRect(0, 80, 320, 80 );

			track_window1 = selection1;
			track_window2 = selection2;

			if( count != maxcount )
			{
				cvCvtColor( image1, hsv_image1,  CV_BGR2HSV );
				cvCvtColor( image2, hsv_image2,  CV_BGR2HSV );

				cvInRangeS( hsv_image1, cvScalar( 0, 30, 250, 0), cvScalar( 180, 256, 256, 0 ), mask_image1);
				cvSplit( hsv_image1, hue_image1, 0, 0, 0 );

				cvInRangeS( hsv_image2, cvScalar( 0, 30, 250, 0), cvScalar( 180, 256, 256, 0 ), mask_image2);
				cvSplit( hsv_image2, hue_image2, 0, 0, 0 );
							
				//track object1 
				IplImage *tmp_hue_image1 = hue_image1;
				cvCalcBackProject( &tmp_hue_image1, backproject1, hist_load1 );
				cvAnd( backproject1, mask_image1, backproject1, 0 );
				cvCamShift( backproject1, track_window1, 
										cvTermCriteria ( CV_TERMCRIT_EPS | CV_TERMCRIT_ITER, 10, 1),
										&track_comp1, &track_box1);
				track_window1 = track_comp1.rect;
				if( image1->origin )
					track_box1.angle  = -track_box1.angle;
				p1 = cvPoint( cvRound( track_box1.center.x), cvRound( track_box1.center.y));
				X1 = p1.x;
				Y1 = p1.y;

				cvCircle( image1, p1, 5, CV_RGB( 255, 0, 0), 3, CV_AA, 0);

				//track object2
				IplImage *tmp_hue_image2 = hue_image2;
				cvCalcBackProject( &tmp_hue_image2, backproject2, hist_load2 );
				cvAnd( backproject2, mask_image2, backproject2, 0 );
				cvCamShift( backproject2, track_window2, 
										cvTermCriteria ( CV_TERMCRIT_EPS | CV_TERMCRIT_ITER, 10, 1),
										&track_comp2, &track_box2);
				track_window2 = track_comp2.rect;
				if( image2->origin )
					track_box2.angle  = -track_box2.angle;
				p2 = cvPoint( cvRound( track_box2.center.x), cvRound( track_box2.center.y));
				X2 = p2.x;
				Y2 = p2.y;

				cvCircle( image2, p2, 5, CV_RGB( 255, 0, 0), 3, CV_AA, 0);

				TX = X1 - X2;
				TY = Y1 - Y2;

				match = 1;
				count++;
			}
			if( match == 1 )
			{
					cvmSet(map_matrix, 0, 0, 1);
					cvmSet(map_matrix, 0, 1, 0);
					cvmSet(map_matrix, 0, 2,abs(17));
					cvmSet(map_matrix, 1, 0, 0);
					cvmSet(map_matrix, 1, 1, 1);
					cvmSet(map_matrix, 1, 2, abs(0));

					cvWarpAffine(image1,imageout, map_matrix,CV_INTER_LINEAR);

					cvmSet( map_matrix, 0, 2, abs(TX+17));
					cvmSet( map_matrix, 1, 2, abs(0));

					cvWarpAffine(image2, imageout, map_matrix, CV_INTER_LINEAR);
			}
			
			return SaveImage(2);
		}
	};
}