#pragma once
#include <time.h>
#include "cvaux.h"

namespace VsOpenCV
{
	public ref class VsCvFqiDetection : public VsCvImage
	{
	private:

		CvMemStorage* storage;
		CvHaarClassifierCascade* cascade ;

		const char* cascade_name ;


		double bestCovarMatrixValue;
		double maxCovarMatrix;
		double totalCM;
		double meanCM;

		double sdVar;
		double totalVar;
		double meanVar;

		int bFound;
		double alpha;

		float* covarMatrix;
		float* flipCovarMatrix;
		double addCM1;
		double addCM2;

		IplImage *hsv, *hue, *mask, *backproject, *histimg;
		IplImage* returnBetterFace;
		IplImage* returnBetterFace2;
		IplImage* picBestFace;
		IplImage* hasFace;
		IplImage* bestFaceReturn;
		IplImage** detected;
		IplImage** flipDetected;
		IplImage* avg;
		IplImage* flipAvg;

		CvHistogram *hist;

		time_t start_face, end_face;

		double diffTimeFace;

		int firstImageNumber;
		int lastImageNumber;
		int backproject_mode;
		int select_object;
		int track_object;
		int hdims;
		int vmin , vmax , smin ;
		int imgIdx;
		int point1x;
		int point2x;
		int point1y;
		int point2y;

		CvMat* map_matrix;

		String^ vsResult;
		static int thresh = 1;
		int width, height;


	public:

		VsCvFqiDetection(int in, int out, int w, int h, cvDepth depth, int channels)
			: VsCvImage(in, out, w, h, depth, channels)
		{
			width = w;
			height = h;
		}

		~VsCvFqiDetection(void)
		{
			CvHistogram *hst = hist;
			cvReleaseHist(&hst);
			
			IplImage* ptrFace;

			ptrFace = hasFace;				cvReleaseImage(&ptrFace);
			ptrFace = bestFaceReturn;		cvReleaseImage(&ptrFace);

			IplImage* ptr;
			//ptr = timg; cvReleaseImage(&ptr);

			ptr = hsv;					cvReleaseImage(&ptr);
			ptr = hue;					cvReleaseImage(&ptr);
			ptr = mask;					cvReleaseImage(&ptr);
			ptr = backproject;			cvReleaseImage(&ptr);
			ptr = histimg;				cvReleaseImage(&ptr);
			ptr = returnBetterFace;		cvReleaseImage(&ptr);
			ptr = returnBetterFace2;	cvReleaseImage(&ptr);
			ptr = picBestFace;			cvReleaseImage(&ptr);
			ptr = avg;					cvReleaseImage(&ptr);
			ptr = flipAvg;				cvReleaseImage(&ptr);
			ptr = detected[0];			cvReleaseImage(&detected[0]);
			ptr = detected[1];			cvReleaseImage(&detected[1]);
			ptr = flipDetected[0];		cvReleaseImage(&flipDetected[0]);
			ptr = flipDetected[1];		cvReleaseImage(&flipDetected[1]);

		}

		void VsInit()
		{
			float hranges_arr[] = {0,180};
			float *hranges = hranges_arr;
			int hdims = 16;

			cascade = 0;
			bFound = 0;
			alpha = 0.15;
			cascade_name = ".\\opencv\\data\\haarcascade_frontalface_alt2.xml";
			cascade = (CvHaarClassifierCascade*)cvLoad(cascade_name, 0, 0, 0);

			bestCovarMatrixValue = 0;
			maxCovarMatrix=0;
			totalCM = 0;  //total Covariance Matrix
			meanCM = 0;

			sdVar = 0;
			totalVar = 0;
			meanVar = 0;

			covarMatrix = (float*)cvAlloc(sizeof(float)*10*10);  //allocate memory
			flipCovarMatrix = (float*)cvAlloc(sizeof(float)*10*10);  //allocate memory

			hsv    = cvCreateImage(cvSize(width, height), IPL_DEPTH_8U, 3);
			hue    = cvCreateImage(cvSize(width, height), IPL_DEPTH_8U, 1);;
			mask = cvCreateImage(cvSize(width, height), IPL_DEPTH_8U, 1);;
			backproject = cvCreateImage(cvSize(width, height), IPL_DEPTH_8U, 1);;
			histimg = cvCreateImage(cvSize(width, height), IPL_DEPTH_8U, 1);
			hasFace = cvCreateImage(cvSize(150,150),8,3);

			hist = cvCreateHist( 1, &hdims, CV_HIST_ARRAY, &hranges, 1 );

			returnBetterFace = 0;
			returnBetterFace2 = 0;
			picBestFace = cvCreateImage(cvSize(150,150),8,3);
			bestFaceReturn = 0;

			firstImageNumber = 0;
			lastImageNumber = 2;
			backproject_mode = 0;
			select_object = 0;
			track_object = 0;

			hdims = 16;
			vmin = 10;
			vmax = 256;
			smin = 30;
			imgIdx = 0;

			map_matrix = cvCreateMat(2,3,CV_32F);

			width = Width; height = Height;

			if( detected == 0 ) {
				detected = (IplImage**)malloc(2*sizeof(detected[0]));
				memset( detected, 0, 2*sizeof(detected[0]));
			}

			for(int i = 0; i < 2; i++ ) {
				cvReleaseImage( &detected[i] );
				detected[i] = cvCreateImage( cvSize(150,150), IPL_DEPTH_8U, 3 );
				cvZero( detected[i] );
			}

			if( flipDetected == 0 ) {
				flipDetected = (IplImage**)malloc(2*sizeof(flipDetected[0]));
				memset( flipDetected, 0, 2*sizeof(flipDetected[0]));
			}

			for(int i = 0; i < 2; i++ ) {
				cvReleaseImage( &flipDetected[i] );
				flipDetected[i] = cvCreateImage( cvSize(150,150), IPL_DEPTH_8U,3 );
				cvZero( flipDetected[i] );
			}

			vsResult = "";
		}

		// configuration
		void VsConfiguration(int th)
		{
			// TODO
			thresh = th;
		}

		String^ VsResult()
		{
			return vsResult;
		}

		Bitmap^ VsProcess(Bitmap^ srcImage1)    // source 1 camera
		{
			LoadImage(srcImage1, 1);

			cvCopy(image1, imageout);

			vsResult = "";

			storage = cvCreateMemStorage(0);

			FqiDetection();

			//Show Output
			if(bFound) 
			{
				cvmSet(map_matrix,0,0,0.5);
				cvmSet(map_matrix,0,1,0);
				cvmSet(map_matrix,0,2,245);
				cvmSet(map_matrix,1,0,0);
				cvmSet(map_matrix,1,1,0.5);
				cvmSet(map_matrix,1,2,165);

				cvWarpAffine(picBestFace, imageout, map_matrix, CV_INTER_LINEAR);
			}

			CvMemStorage *ptr = storage;
			cvReleaseMemStorage(&ptr);

			return SaveImage(1);
		}

		void FqiDetection()
		{		
			if(FaceDetection())
			{
				if(imgIdx<2)
				{
					cvCopy(hasFace, detected[imgIdx]);
					cvFlip(hasFace, flipDetected[imgIdx]);
					cvTranspose(flipDetected[imgIdx], flipDetected[imgIdx]);
					imgIdx++;
				}
				else
				{
					FindBestFace(); 
					imgIdx = 1;
				}
			}
		}


		bool FaceDetection()
		{
			CvPoint pt1,pt2;
			CvRect selection_faceDetect;
			int i;
			bool bFace = false;
			double scale = 1.3;
			IplImage* detectedFace = NULL;
			IplImage* faceResize = NULL;
			IplImage* gray = cvCreateImage( cvSize(imageout->width,imageout->height), 8, 1 );
			IplImage* small_img = cvCreateImage( cvSize( cvRound (imageout->width/scale), cvRound (imageout->height/scale)),8, 1 );

			cvCvtColor( imageout, gray, CV_BGR2GRAY );
			cvResize( gray, small_img, CV_INTER_LINEAR );
			cvEqualizeHist( small_img, small_img );
			cvClearMemStorage( storage );

			if(cascade)
			{
				double t = (double)cvGetTickCount();
				CvSeq* faces = cvHaarDetectObjects( small_img, cascade, storage,
					1.1, 3, 0/*CV_HAAR_DO_CANNY_PRUNING*/,
					cvSize(0, 0) );
				t = (double)cvGetTickCount() - t;

				for( i = 0; i < (faces ? faces->total : 0); i++ )
				{
					CvRect* r = (CvRect*)cvGetSeqElem( faces, i );

					pt1.x = (int)(r->x*scale);
					pt2.x = (int)((r->x+r->width)*scale);
					pt1.y = (int)(r->y*scale);
					pt2.y = (int)((r->y+r->height)*scale);

					point1x = (int)(r->x*scale);
					point2x = (int)((r->x+r->width)*scale);
					point1y = (int)(r->y*scale);
					point2y = (int)((r->y+r->height)*scale);

					selection_faceDetect = cvRect((int)(r->x*scale), (int)(r->y*scale), (int)(r->width*scale), (int)(r->height*scale));
					track_object=-1;

					FaceTracking();

					CvRect roi;
					roi.x = pt1.x+10;
					roi.y = pt1.y+4;
					roi.width = (pt2.x-15)-pt1.x;
					roi.height = (pt2.y-10)-pt1.y;
					detectedFace = cvCloneImage(imageout);
					cvSetImageROI(detectedFace,roi);

					const double scale_r = 1;

					cvResize(detectedFace, hasFace,CV_INTER_LINEAR);
					bFace = true;
				}
			}

			if(detectedFace!=NULL) cvReleaseImage( &detectedFace );
			cvReleaseImage( &gray );
			cvReleaseImage( &small_img );

			time_t tmp = end_face;
			time (&tmp);

			return bFace;
		}

		void FaceTracking()
		{
			CvPoint pt1,pt2;
			CvRect selection_faceTracking;
			CvRect track_window;
			CvBox2D track_box;
			CvConnectedComp track_comp;

			pt1.x = point1x;
			pt2.x = point2x;
			pt1.y = point1y;
			pt2.y = point2y;

			cvCvtColor( imageout, hsv, CV_BGR2HSV );

			if(track_object)
			{
				int _vmin = vmin, _vmax = vmax;

				cvInRangeS( hsv, cvScalar(0,smin,MIN(_vmin,_vmax),0),
					cvScalar(180,256,MAX(_vmin,_vmax),0), mask );
				cvSplit( hsv, hue, 0, 0, 0 );
				IplImage *tmp = hue;

				if( track_object < 0 )
				{
					selection_faceTracking = cvRect(point1x,point1y,point2x-point1x,point2y-point1y);
					cvSetImageROI( tmp, selection_faceTracking );
					cvSetImageROI( mask, selection_faceTracking );					
					cvCalcHist( &tmp, hist, 0, mask );     //Calculate Histogram of Image
					track_window = selection_faceTracking;
					track_object = 1;
					cvResetImageROI( tmp );
					cvResetImageROI( mask );
				}

				cvCalcBackProject( &tmp, backproject, hist );
				cvAnd( backproject, mask, backproject, 0 );
				cvCamShift(backproject, track_window,
					cvTermCriteria( CV_TERMCRIT_EPS | CV_TERMCRIT_ITER, 10, 1 ),
					&track_comp, &track_box );
				track_window = track_comp.rect;

				if( imageout->origin )
					track_box.angle = -track_box.angle;
			}

			cvRectangle(imageout, pt1, pt2, CV_RGB(255,0,0), 3, CV_AA, 0);
		}

		void FindBestFace()
		{ 
			IplImage* face[2];
			IplImage* flipFace[2];

			double usedCM[2];
			double flipUsedCM[2];			

			for(int i=0;i<2;i++)
			{
				face[i]=cvCreateImage(cvSize(150,150),8/*IPL_DEPTH_8U*/,1);
				flipFace[i]=cvCreateImage(cvSize(150,150),8/*IPL_DEPTH_8U*/,1);

				cvCvtColor(detected[i],face[i],CV_BGR2GRAY);
				cvCvtColor(flipDetected[i],flipFace[i],CV_BGR2GRAY);
			}

			avg = cvCreateImage(cvSize(150,150),32/*IPL_DEPTH_32F*/,1);
			cvSetZero(avg);
			flipAvg = cvCreateImage(cvSize(150,150),32/*IPL_DEPTH_32F*/,1);
			cvSetZero(flipAvg);

			// Calculate Covariance Matrix
			cvCalcCovarMatrixEx(2,face,0,0,0,0,avg, covarMatrix);
			cvCalcCovarMatrixEx(2,flipFace,0,0,0,0,flipAvg, flipCovarMatrix);
			
			if(covarMatrix[0] > 0 && covarMatrix[3] > 0 &&
				flipCovarMatrix[0] > 0 && flipCovarMatrix[3] > 0)
			{
				usedCM[0] = covarMatrix[1];
				usedCM[1] = covarMatrix[3];

				flipUsedCM[0] = flipCovarMatrix[1];
				flipUsedCM[1] = flipCovarMatrix[3];

				addCM1 = usedCM[0]; // + flipUsedCM[0];
				addCM2 = usedCM[1]; // + flipUsedCM[1];
							
				if(totalCM < 0)
				{
					totalCM = 0;
					meanCM = 0;
					totalVar = 0;
					meanVar = 0;
				}

				// running average of covariances
				totalCM = (1-alpha)*totalCM + alpha*addCM2;
				meanCM = totalCM;

				// running variance of covariances
				totalVar = (1-alpha)*totalVar + alpha*((addCM2-meanCM)*(addCM2-meanCM));
				meanVar = totalVar;
				sdVar = sqrt(meanVar);

				// is it the best face?
				if ( ((addCM2 >= meanCM) && addCM2 <= (meanCM + thresh*sdVar/15))) 
				{
					// is it better than the last best face?
					//if((addCM1 > maxCovarMatrix))
					{
						maxCovarMatrix = addCM1;
						cvCopy(detected[1],		picBestFace);
						cvCopy(detected[1],     detected[0]);
						cvCopy(flipDetected[1], flipDetected[0]);
						bFound =1;
					}
				}
			}	

			cvReleaseImage(&face[0]);
			cvReleaseImage(&face[1]);
			cvReleaseImage(&flipFace[0]);
			cvReleaseImage(&flipFace[1]);
		}

		void timeReset()
		{
			imgIdx = 1;
			totalCM = 0;
			meanCM = 0;
			totalVar = 0;
			meanVar = 0;
		}
	};
}
