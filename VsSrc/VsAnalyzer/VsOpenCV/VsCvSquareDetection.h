#pragma once
#include <time.h>

namespace VsOpenCV
{
	public ref class VsCvSquareDetection : public VsCvImage
	{
		private:
		String^ vsResult;
		static int thresh = 50;
		static int N = 11;
		int width, height;

		int i, c, l;
		double s, t;

		IplImage *timg, *gray, *pyr, *tgray;
		CvMemStorage* storage;

		CvSeq *squares, *result, *contours;

		public:

		VsCvSquareDetection(int in, int out, int w, int h, cvDepth depth, int channels)
			: VsCvImage(in, out, w, h, depth, channels)
		{
		}

		~VsCvSquareDetection(void)
		{
			IplImage* ptr;
			ptr = timg; cvReleaseImage(&ptr);
			ptr = gray; cvReleaseImage(&ptr);
			ptr = pyr;  cvReleaseImage(&ptr);
			ptr = tgray;cvReleaseImage(&ptr);
		}

		void VsInit()
		{
			width = Width; height = Height;

			timg = cvCreateImage(cvSize(width, height), IPL_DEPTH_8U, 3); 
			gray = cvCreateImage(cvSize(width, height), IPL_DEPTH_8U, 1); 
			pyr  = cvCreateImage(cvSize(width/2, height/2), IPL_DEPTH_8U, 3 );
			tgray= cvCreateImage(cvSize(width, height), IPL_DEPTH_8U, 1);

			vsResult = "";
		}

		void VsConfiguration(int th)
		{
			thresh = th;
		}

		String^ VsResult()
		{
			return vsResult;
		}

		Bitmap^ VsProcess(Bitmap^ srcImage1)
		{
			LoadImage(srcImage1, 1);

			vsResult = "";

			// find square
			findSquares4();

			// find and draw the squares
			drawSquares();	        

			return SaveImage(1);
		}

		// helper function:
		// finds a cosine of angle between vectors
		// from pt0->pt1 and from pt0->pt2 
		double angle( CvPoint* pt1, CvPoint* pt2, CvPoint* pt0 )
		{
			double dx1 = pt1->x - pt0->x;
			double dy1 = pt1->y - pt0->y;
			double dx2 = pt2->x - pt0->x;
			double dy2 = pt2->y - pt0->y;
			return (dx1*dx2 + dy1*dy2)/sqrt((dx1*dx1 + dy1*dy1)*(dx2*dx2 + dy2*dy2) + 1e-10);
		}

		// returns sequence of squares detected on the image1.
		// the sequence is stored in the specified memory storage
		void findSquares4()
		{
			// clear memory storage - reset free space position
			storage = cvCreateMemStorage(0);
			squares = cvCreateSeq( 0, sizeof(CvSeq), sizeof(CvPoint), storage );
		
			// copy image1
			cvSetImageCOI(timg, 0);
			cvCopy(image1, timg);
			cvCopy(image1, imageout);

			// select the maximum ROI in the image1
			// with the width and height divisible by 2
			cvSetImageROI(timg, cvRect( 0, 0, width, height));
		    
			// down-scale and upscale the image1 to filter out the noise
			cvPyrDown( timg, pyr, 7 );
			cvPyrUp( pyr, timg, 7 );
		    
			// find squares in every color plane of the image1
			for( c = 0; c < 3; c++ )
			{
				// extract the c-th color plane
				cvSetImageCOI( timg, c+1 );
				cvCopy(timg, tgray, 0);
		        
				// try several threshold levels
				for( l = 0; l < N; l++ )
				{
					// hack: use Canny instead of zero threshold level.
					// Canny helps to catch squares with gradient shading   
					if( l == 0 )
					{
						// apply Canny. Take the upper threshold from slider
						// and set the lower to 0 (which forces edges merging) 
						cvCanny( tgray, gray, 0, thresh, 5 );
						// dilate canny output to remove potential
						// holes between edge segments 
						cvDilate( gray, gray, 0, 1 );
					}
					else
					{
						// apply threshold if l!=0:
						//     tgray(x,y) = gray(x,y) < (l+1)*255/N ? 255 : 0
						cvThreshold( tgray, gray, (l+1)*255/N, 255, CV_THRESH_BINARY );
					}
		            
					// find contours and store them all as a list
					CvSeq *cont=contours;
					cvFindContours(gray, storage, &cont, sizeof(CvContour),
						CV_RETR_LIST, CV_CHAIN_APPROX_SIMPLE, cvPoint(0,0) );
		            
					// test each contour
					while(cont)
					{
						// approximate contour with accuracy proportional
						// to the contour perimeter
						result = cvApproxPoly( cont, sizeof(CvContour), storage,
							CV_POLY_APPROX_DP, cvContourPerimeter(cont)*0.02, 0 );
						// square contours should have 4 vertices after approximation
						// relatively large area (to filter out noisy contours)
						// and be convex.
						// Note: absolute value of an area is used because
						// area may be positive or negative - in accordance with the
						// contour orientation
						if( result->total == 4 &&
							fabs(cvContourArea(result,CV_WHOLE_SEQ)) > 1000 &&
							cvCheckContourConvexity(result) )
						{
							s = 0;
		                    
							for( i = 0; i < 5; i++ )
							{
								// find minimum angle between joint
								// edges (maximum of cosine)
								if( i >= 2 )
								{
									t = fabs(angle(
									(CvPoint*)cvGetSeqElem( result, i ),
									(CvPoint*)cvGetSeqElem( result, i-2 ),
									(CvPoint*)cvGetSeqElem( result, i-1 )));
									s = s > t ? s : t;
								}
							}
		                    
							// if cosines of all angles are small
							// (all angles are ~90 degree) then write quandrange
							// vertices to resultant sequence 
							if( s < 0.3 )
								for( i = 0; i < 4; i++ )
									cvSeqPush( squares,
										(CvPoint*)cvGetSeqElem( result, i ));
						}
						// take the next contour
						cont = cont->h_next;
					}
				}
			}

			CvMemStorage* smem = storage;
			cvReleaseMemStorage(&smem);
		}

		// the function draws all the squares in the image1
		void drawSquares()
		{
			CvSeqReader reader;
			int i;
		    
			// initialize reader of the sequence
			cvStartReadSeq( squares, &reader, 0 );
		    
			// read 4 sequence elements at a time (all vertices of a square)
			for( i = 0; i < squares->total; i += 4 )
			{
				CvPoint pt[4], *rect = pt;
				int count = 4;
		        
				// read 4 vertices
				CV_READ_SEQ_ELEM( pt[0], reader );
				CV_READ_SEQ_ELEM( pt[1], reader );
				CV_READ_SEQ_ELEM( pt[2], reader );
				CV_READ_SEQ_ELEM( pt[3], reader );
		        
				// draw the square as a closed polyline 
				cvPolyLine(imageout, &rect, &count, 1, 1, CV_RGB(255,0,0), 3, CV_AA, 0 );

				vsResult += pt[0].x.ToString() + "," + pt[0].y.ToString() + "," + pt[1].x.ToString() + "," + pt[1].y.ToString() + "," +
					pt[2].x.ToString() + "," + pt[2].y.ToString() + "," + pt[3].x.ToString() + "," + pt[3].y.ToString() + ";";
			}		    
		}
	};
}