#pragma once
#include <time.h>

namespace VsOpenCV
{
	public ref class VsCvLipDetection : public VsCvImage
	{
		private:
		static int thresh = 50;

		public:

		int row_thresh, col_thresh;
		int area_choose;
		
		String^ vsResult;

		CvMemStorage* seqStorage ;

		CvMat *map_matrix, *map_matrix2;
		IplImage *inp_img;
		IplImage *src_img, *dst_img;
		IplImage *row_img, *row_img1;
		IplImage *col_img, *col_img1;

		VsCvLipDetection(int in, int out, int w, int h, cvDepth depth, int channels)
			: VsCvImage(in, out, w, h, depth, channels)
		{

		}

		~VsCvLipDetection(void)
		{
			IplImage* ptr;
			ptr = inp_img; cvReleaseImage(&ptr);
			ptr = src_img;cvReleaseImage(&ptr);
			ptr = dst_img; cvReleaseImage(&ptr);
			ptr = row_img;  cvReleaseImage(&ptr);
			ptr = row_img1;cvReleaseImage(&ptr);
			ptr = col_img;cvReleaseImage(&ptr);
			ptr = col_img1;  cvReleaseImage(&ptr);
		}

		void VsInit()
		{
			row_thresh = 15;
			col_thresh = 10;
			area_choose = 20;
 
			map_matrix = NULL;
			map_matrix2= NULL;
			inp_img = NULL;
			src_img = NULL;
			dst_img = NULL;
			row_img = NULL;
			row_img1 = NULL;
			col_img = NULL;
			col_img1 = NULL;

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
			cvResetImageROI(imageout);
			cvCopy(image1, imageout);
			vsResult = "";

			if(inp_img == NULL)	inp_img = cvCloneImage(imageout); 
			else { cvResetImageROI(inp_img); cvResetImageROI(imageout);	cvCopy(imageout, inp_img); }
						         
			seqStorage = cvCreateMemStorage(0);

			showPlate(inp_img, findPlate(inp_img, seqStorage)) ;

			CvMemStorage *ptr = seqStorage;
			cvReleaseMemStorage(&ptr);

			if(dst_img != NULL)
			{
				cvResetImageROI(dst_img);

				if(map_matrix2 == NULL) map_matrix2 = cvCreateMat (2, 3, CV_32FC1);

				cvmSet(map_matrix2,0,0,0.5);
				cvmSet(map_matrix2,0,1,0);
				cvmSet(map_matrix2,0,2,170);
				cvmSet(map_matrix2,1,0,0);
				cvmSet(map_matrix2,1,1,0.5);
				cvmSet(map_matrix2,1,2, 120);

				cvWarpAffine(dst_img, imageout, map_matrix2, CV_INTER_LINEAR);
			}

			return SaveImage(1);
		}

		double angle( CvPoint* pt1, CvPoint* pt2, CvPoint* pt0 )
		{
			double dx1 = pt1->x - pt0->x;
			double dy1 = pt1->y - pt0->y;
			double dx2 = pt2->x - pt0->x;
			double dy2 = pt2->y - pt0->y;
			return (dx1*dx2 + dy1*dy2)/sqrt((dx1*dx1 + dy1*dy1)*(dx2*dx2 + dy2*dy2) + 1e-10);
		}

		CvSeq* findPlate(IplImage* inp_img, CvMemStorage* seqStorage)
		{
			int i, c , l, N = 11;
			double s, t;
			CvSize sz = cvSize(inp_img->width, inp_img->height);
			IplImage* gray_image  = cvCreateImage(sz, 8, 1 ); 
			IplImage* chnl_image  = cvCreateImage(sz, 8, 1 );;
			CvSeq *seqResult = NULL, *seqContours = NULL, *seqSquares = NULL;

			seqSquares = cvCreateSeq(0, sizeof(CvSeq), sizeof(CvPoint), seqStorage);
			
			for(c = 0; c < 3; c++)
			{
				cvResetImageROI(inp_img); cvResetImageROI(chnl_image);
				cvSetImageCOI(inp_img, c+1);
				cvCopy(inp_img, chnl_image, 0);
			    			  
				for(l = 0; l < N; l++)
				{			     
					if(l == 0)
					{
						cvCanny(chnl_image, gray_image, 0, thresh, 5);
						cvDilate(gray_image,  gray_image, 0, 1);
					}
					else
					{
						cvThreshold(chnl_image, gray_image, (l+1)*255/N, 255, CV_THRESH_BINARY);
					}
			        
					cvFindContours(gray_image, seqStorage, &seqContours, sizeof(CvContour),
						CV_RETR_LIST, CV_CHAIN_APPROX_SIMPLE, cvPoint(0,0) );
			        
					// each contour
					while(seqContours)
					{			            
						seqResult = cvApproxPoly( seqContours, sizeof(CvContour), seqStorage,
							CV_POLY_APPROX_DP, cvContourPerimeter(seqContours)*0.02, 0 );
						if( seqResult->total == 4 &&
							fabs(cvContourArea(seqResult,CV_WHOLE_SEQ)) >  5000 && fabs(cvContourArea(seqResult,CV_WHOLE_SEQ)) < 10000
							&&  cvCheckContourConvexity(seqResult))
						{
							s = 0;			                
							for( i = 0; i < 5; i++ )
							{
								if( i >= 2 )
								{
									t = fabs(angle(
									(CvPoint*)cvGetSeqElem( seqResult, i ),
									(CvPoint*)cvGetSeqElem( seqResult, i-2 ),
									(CvPoint*)cvGetSeqElem( seqResult, i-1 )));
									s = s > t ? s : t;
								}
							}
							if( s < 0.3 )
								for( i = 0; i < 4; i++ )
									cvSeqPush(seqSquares,
										(CvPoint*)cvGetSeqElem( seqResult, i ));
						}
			            
						// take the next contour
						seqContours = seqContours->h_next;
					}
				}
			}

			cvSetImageCOI(inp_img, 0);

			// release all the temporary images
			cvReleaseImage(&gray_image);
			cvReleaseImage(&chnl_image);

			return seqSquares;
		}// find plate
		
		// cutColumn
		void cutColumn(IplImage* dst_img, int y1, int y2)
		{	
			int ab_range[640]	={0};
			int wb_range[10]	={0};
			int bw_range[10]	={0};
			int black=0, white=0, x=0, y=0, i;

			if(col_img == NULL) col_img = cvCloneImage (dst_img);
			else { cvResetImageROI(dst_img); cvResetImageROI(col_img); cvCopy(dst_img, col_img); }

			cvSmooth (col_img, col_img, CV_GAUSSIAN, 5);
			
			if(col_img1 == NULL) { col_img1 = cvCreateImage(cvGetSize(col_img), 8, 1);	cvFlip(col_img1, col_img1, 0); }

			cvCvtColor(col_img, col_img1, CV_BGR2GRAY);
			cvThreshold(col_img1, col_img1, 0, 255, CV_THRESH_BINARY | CV_THRESH_OTSU);

			//-------------------------------------------------------------------------------
			//read col
			for(x=0; x<col_img1->width; x++)
			{
				black=0;
				for(y=y1; y<y2; y++)
				{
					if(((uchar*)(col_img1->imageData+col_img1->widthStep*y))[x]==0)
						black++;
				}

				if (black > col_thresh)
					ab_range[x] = 0;  //set black = 0
				else ab_range[x] = 1;  //set white = 1
			}
			 
			//-------------------------------------------------------------------------------
			// find transition
			y = 0;
			bool bg = false;
			for(x=0; x<col_img1->width; x++)
			{
				if((ab_range[x]==1) && (ab_range[x+1]==0) && bg == false) // find white 1 --->black 0
				{
					wb_range[y]=x-1;
					bg = true;
				}				
				if((ab_range[x]==0) && (ab_range[x+1]==1) && bg == true)  // find black 0 --->white 1
				{
					bw_range[y]=x+1;
					bg = false; 					
					if(bw_range[y] - wb_range[y] > area_choose) y++;
				}
			}
			
			//-------------------------------------------------------------------------------
			// draw rectangle
			for(i=0; i<y; i++)
			{
				cvLine(dst_img, cvPoint(wb_range[i], y1), cvPoint(wb_range[i], y2), CV_RGB(0, 255*(i%2),255*((i+1)%2)), 2, CV_AA, 0);
				cvLine(dst_img, cvPoint(bw_range[i], y1), cvPoint(bw_range[i], y2),	CV_RGB(0, 255*(i%2),255*((i+1)%2)), 2, CV_AA, 0);
			}
		}

		// cutRow
		void cutRow(IplImage* dst_img ) 
		{	 
			int ab_range[640]	={0};
			int wb_range[10]	={0};
			int bw_range[10]	={0};
			int black=0, white=0, x=0, y=0, i;

			if(row_img == NULL) row_img = cvCloneImage (dst_img);
			else { cvResetImageROI(row_img); cvResetImageROI(dst_img); cvCopy(dst_img, row_img); }

			cvSmooth (row_img, row_img, CV_GAUSSIAN, 5);
			
			if(row_img1 == NULL) { row_img1 = cvCreateImage(cvGetSize(row_img), 8, 1);	cvFlip(row_img1, row_img1, 0); }

			cvCvtColor(row_img, row_img1, CV_BGR2GRAY);
			cvThreshold(row_img1, row_img1, 0, 255, CV_THRESH_BINARY | CV_THRESH_OTSU);

			//-------------------------------------------------------------------------------
			//read row
			for(y=0; y<row_img1->height; y++)
			{
				black=0;
				for(x=0; x<row_img1->width; x++)
				{
					if(((uchar*)(row_img1->imageData+row_img1->widthStep*y))[x]==0)
						black++;
				}

				if (black > row_thresh)
					ab_range[y] = 0;  //set black = 0
				else ab_range[y] = 1;  //set white = 1
			}
			 
			//-------------------------------------------------------------------------------
			// find transition
			x =0;
			bool bg = false;
			for(y=0; y<row_img1->height; y++)
			{
				if((ab_range[y]==1) && (ab_range[y+1]==0) && bg == false) // find white 1 --->black 0
				{
					wb_range[x]=y-5;
					bg = true;
				}				
				if((ab_range[y]==0) && (ab_range[y+1]==1) && bg == true)  // find black 0 --->white 1
				{
					bw_range[x]=y+5;
					bg = false; 					
					if(bw_range[x] - wb_range[x] > area_choose) x++;
				}
			}
			
			//-------------------------------------------------------------------------------
			// draw rectangle
			for(i=0; i<x; i++)
			{
				cvLine(dst_img, cvPoint(0, wb_range[i]), cvPoint(dst_img->width , wb_range[i]), CV_RGB(255,0,0), 2, CV_AA, 0);
				cvLine(dst_img, cvPoint(0, bw_range[i]), cvPoint(dst_img->width , bw_range[i]),	CV_RGB(255,0,0), 2, CV_AA, 0);
				cutColumn(dst_img, wb_range[i], bw_range[i]);
			}
		}// cutrow

		void showPlate(IplImage* inp_img, CvSeq* seqSquares)
		{
			int i;
			int pt_left[3] ={0};
			int pt_right[3]={0};
			CvPoint2D32f src_pnt[4], dst_pnt[4];
			CvSeqReader seqReader;
			CvRectStore *pt_rect[5];

			pt_rect[0] = new CvRectStore(); pt_rect[1] = new CvRectStore();	pt_rect[2] = new CvRectStore(); pt_rect[3] = new CvRectStore();

			cvStartReadSeq(seqSquares, &seqReader, 0);

			// read 4 elements at a time (all vertices of a square)
			for(i = 0; i < seqSquares->total; i += 4)
			{
				int count = 4;
				CvPoint pt[4], *rect = pt;

				// read 4 vertices
				CV_READ_SEQ_ELEM(pt[0], seqReader);
				CV_READ_SEQ_ELEM(pt[1], seqReader);
				CV_READ_SEQ_ELEM(pt[2], seqReader);
				CV_READ_SEQ_ELEM(pt[3], seqReader);

				// draw
				cvPolyLine(imageout, &rect, &count, 1, 1, CV_RGB(0,255,0), 3, CV_AA, 0 ); 

				//-------------------------Success Find Plate --------------------------------------
				//------------------------- Read Value in Each Point -------------------------------
				pt_rect[0]->id=0; pt_rect[0]->rect=cvRect(pt[0].x,pt[0].y,0,0);
				pt_rect[1]->id=1; pt_rect[1]->rect=cvRect(pt[1].x,pt[1].y,0,0);
				pt_rect[2]->id=2; pt_rect[2]->rect=cvRect(pt[2].x,pt[2].y,0,0);
				pt_rect[3]->id=3; pt_rect[3]->rect=cvRect(pt[3].x,pt[3].y,0,0);

				// find mean at x ,y
				int p=0, sum_x=0, mean_x;
				for(p=0; p<4; p++)
				{
					sum_x = sum_x + pt_rect[p]->rect.x;
				}
				mean_x = (sum_x)/4;

				int q=0, sum_y=0, mean_y;
				for(q=0; q<4; q++)
				{
					sum_y = sum_y + pt_rect[q]->rect.y;
				}
				mean_y = (sum_y)/4;

				//------------------- compare x_mean for tell p[0,1,2,3] = left or right ---------------------------

				int r=0,l_count=0,r_count=0;

				for(r=0;r<4;r++)
				{
					if((pt_rect[r]->rect.x)< mean_x)
					{
						pt_left[l_count] = r;
						l_count++;
					}
					else if ((pt_rect[r]->rect.x) > mean_x)
					{
						pt_right[r_count] = r;
						r_count++;
					}
				}

				//----------------- compare y_mean  for tell top or bottom ---------------------------------
				int pt_top_left =0, pt_bottom_left=0, pt_top_right=0, pt_bottom_right=0;

				int s;
				for(s=0;s< 2;s++)
				{
					//left
					if((pt_rect[pt_left[s]]->rect.y) < mean_y) pt_top_left = pt_left[s];
					else if((pt_rect[pt_left[s]]->rect.y)  > mean_y) pt_bottom_left = pt_left[s];
					// right
					if((pt_rect[pt_right[s]]->rect.y) < mean_y) pt_top_right = pt_right[s];
					else if((pt_rect[pt_right[s]]->rect.y)  > mean_y) pt_bottom_right = pt_right[s];
				}

				//printf("pt_top_left = %d pt_bottom_left = %d  \n",pt_top_left ,pt_bottom_left);
				//printf("pt_top_right = %d pt_bottom_right = %d  \n",pt_top_right ,pt_bottom_right);

				// find min max  x,y for each  
				int min_x,max_x,a;
				min_x = pt_rect[0]->rect.x ; // min x
				max_x = pt_rect[0]->rect.x ; // max x

				for(a=0;a<4;a++)
				{
					if(pt_rect[a]->rect.x < min_x) 
					min_x = pt_rect[a]->rect.x;

					if(pt_rect[a]->rect.x > max_x) 
					max_x = pt_rect[a]->rect.x;
				}

				//printf("min_x = %d  max_x = %d \n",min_x,max_x);
				int min_y,max_y,b;
				min_y = pt_rect[0]->rect.y ; // min y
				max_y = pt_rect[0]->rect.y ; // max y
				for(b=0;b<4;b++)
				{
					if(pt_rect[b]->rect.y < min_y) 
					min_y = pt_rect[b]->rect.y;

					if(pt_rect[b]->rect.y > max_y) 
					max_y = pt_rect[b]->rect.y;
				}
				//printf("min_y = %d  max_y = %d \n",min_y,max_y);
				//printf("------------------------\n");

				//---------------------- GetAffineTransform and WarpAffine --------------------------------			 
				if(src_img == NULL) src_img = cvCloneImage (inp_img);
				else { cvResetImageROI(inp_img); cvResetImageROI(src_img); cvCopy(inp_img, src_img); }
				
				if(dst_img == NULL) dst_img = cvCloneImage (inp_img);
				else { cvResetImageROI(inp_img); cvResetImageROI(dst_img); cvCopy(inp_img, dst_img); }

				src_pnt[0] = cvPoint2D32f ((pt_rect[pt_top_left]->rect.x),(pt_rect[pt_top_left]->rect.y));
				src_pnt[1] = cvPoint2D32f ((pt_rect[pt_bottom_left]->rect.x),(pt_rect[pt_bottom_left]->rect.y));
				src_pnt[2] = cvPoint2D32f ((pt_rect[pt_top_right]->rect.x),(pt_rect[pt_top_right]->rect.y));
				src_pnt[3] = cvPoint2D32f ((pt_rect[pt_bottom_right]->rect.x),(pt_rect[pt_bottom_right]->rect.y));

				dst_pnt[0] = cvPoint2D32f (0,0);
				dst_pnt[1] = cvPoint2D32f (0, 240);
				dst_pnt[2] = cvPoint2D32f (320,0);
				dst_pnt[3] = cvPoint2D32f (320,240);

				if(map_matrix == NULL) map_matrix = cvCreateMat (2, 3, CV_32FC1);

				cvGetAffineTransform(src_pnt, dst_pnt, map_matrix);
				cvWarpAffine (src_img, dst_img, map_matrix, CV_INTER_LINEAR + CV_WARP_FILL_OUTLIERS, cvScalarAll (255));

				cutRow(dst_img);
			}

			delete pt_rect[0]; delete pt_rect[1]; delete pt_rect[2];	delete pt_rect[3];

			//cvReleaseMat (&map_matrix); // ยังไม่ release
		}//show plate
	};
}