#pragma once
#include <time.h>

namespace VsOpenCV
{
	public ref class VsCvOpticalFlow : public VsCvImage
	{
		private:

		int width, height;
		long number_of_frames;
		long current_frame;
		
		IplImage *frame, *frame1_1C, *frame2_1C, *eig_image, *temp_image , *pyramid1, *pyramid2;

		String^ vsResult;

		public:

		VsCvOpticalFlow(int in, int out, int w, int h, cvDepth depth, int channels)
			: VsCvImage(in, out, w, h, depth, channels)
		{
		}

		~VsCvOpticalFlow(void)
		{
			IplImage* ptr;

			ptr = frame1_1C; cvReleaseImage(&ptr);
			ptr = frame2_1C; cvReleaseImage(&ptr);
			ptr = eig_image; cvReleaseImage(&ptr);
			ptr = temp_image; cvReleaseImage(&ptr);
			ptr = pyramid1; cvReleaseImage(&ptr);
			ptr = pyramid2; cvReleaseImage(&ptr);
		}

		void VsInit()
		{
			vsResult = "";
			/* Read the video's frame size out of the AVI. */
			height = Height; width = Width;
			current_frame = 0;

			frame1_1C = cvCreateImage(cvSize(width, height), IPL_DEPTH_8U, 1);
			frame2_1C = cvCreateImage(cvSize(width, height), IPL_DEPTH_8U, 1);
			eig_image = cvCreateImage(cvSize(width, height), IPL_DEPTH_32F, 1);
			temp_image = cvCreateImage(cvSize(width, height), IPL_DEPTH_32F, 1);
			pyramid1 = cvCreateImage(cvSize(width, height), IPL_DEPTH_8U, 1);
			pyramid2 = cvCreateImage(cvSize(width, height), IPL_DEPTH_8U, 1);
		}

		void VsConfiguration(int th1, int th2)
		{
			
		}

		String^ VsResult()
		{
			return vsResult;
		}

		Bitmap^ VsProcess(Bitmap^ srcImage1)
		{
			LoadImage(srcImage1, 1);

			vsResult = "";

			cvCopy(frame1_1C, frame2_1C);
			cvCopy(image1, imageout);

			cvConvertImage(image1, frame1_1C, CV_CVTIMG_FLIP);

			/* Shi and Tomasi Feature Tracking! */

			/* Preparation: This array will contain the features found in frame 1. */
			CvPoint2D32f frame1_features[400];

			/* Preparation: BEFORE the function call this variable is the array size
			 * (or the maximum number of features to find).  AFTER the function call
			 * this variable is the number of features actually found.
			 */
			int number_of_features;
			
			/* I'm hardcoding this at 400.  But you should make this a #define so that you can
			 * change the number of features you use for an accuracy/speed tradeoff analysis.
			 */
			number_of_features = 400;

			/* Actually run the Shi and Tomasi algorithm!!
			 * "frame1_1C" is the input image1.
			 * "eig_image" and "temp_image" are just workspace for the algorithm.
			 * The first ".01" specifies the minimum quality of the features (based on the eigenvalues).
			 * The second ".01" specifies the minimum Euclidean distance between features.
			 * "NULL" means use the entire input image1.  You could point to a part of the image1.
			 * WHEN THE ALGORITHM RETURNS:
			 * "frame1_features" will contain the feature points.
			 * "number_of_features" will be set to a value <= 400 indicating the number of feature points found.
			 */
			cvGoodFeaturesToTrack(frame1_1C, eig_image, temp_image, frame1_features, &number_of_features, .01, .01, NULL);

			/* Pyramidal Lucas Kanade Optical Flow! */

			/* This array will contain the locations of the points from frame 1 in frame 2. */
			CvPoint2D32f frame2_features[400];

			/* The i-th element of this array will be non-zero if and only if the i-th feature of
			 * frame 1 was found in frame 2.
			 */
			char optical_flow_found_feature[400];

			/* The i-th element of this array is the error in the optical flow for the i-th feature
			 * of frame1 as found in frame 2.  If the i-th feature was not found (see the array above)
			 * I think the i-th entry in this array is undefined.
			 */
			float optical_flow_feature_error[400];

			/* This is the window size to use to avoid the aperture problem (see slide "Optical Flow: Overview"). */
			CvSize optical_flow_window = cvSize(3,3);
			
			/* This termination criteria tells the algorithm to stop when it has either done 20 iterations or when
			 * epsilon is better than .3.  You can play with these parameters for speed vs. accuracy but these values
			 * work pretty well in many situations.
			 */
			CvTermCriteria optical_flow_termination_criteria
				= cvTermCriteria( CV_TERMCRIT_ITER | CV_TERMCRIT_EPS, 20, .3 );

			/* Actually run Pyramidal Lucas Kanade Optical Flow!!
			 * "frame1_1C" is the first frame with the known features.
			 * "frame2_1C" is the second frame where we want to find the first frame's features.
			 * "pyramid1" and "pyramid2" are workspace for the algorithm.
			 * "frame1_features" are the features from the first frame.
			 * "frame2_features" is the (outputted) locations of those features in the second frame.
			 * "number_of_features" is the number of features in the frame1_features array.
			 * "optical_flow_window" is the size of the window to use to avoid the aperture problem.
			 * "5" is the maximum number of pyramids to use.  0 would be just one level.
			 * "optical_flow_found_feature" is as described above (non-zero iff feature found by the flow).
			 * "optical_flow_feature_error" is as described above (error in the flow for this feature).
			 * "optical_flow_termination_criteria" is as described above (how long the algorithm should look).
			 * "0" means disable enhancements.  (For example, the second array isn't pre-initialized with guesses.)
			 */
			cvCalcOpticalFlowPyrLK(frame1_1C, frame2_1C, pyramid1, pyramid2, frame1_features, frame2_features, number_of_features, optical_flow_window, 5, optical_flow_found_feature, optical_flow_feature_error, optical_flow_termination_criteria, 0 );
			
			/* For fun (and debugging :)), let's draw the flow field. */
			for(int i = 0; i < number_of_features; i++)
			{
				/* If Pyramidal Lucas Kanade didn't really find the feature, skip it. */
				if ( optical_flow_found_feature[i] == 0 )	continue;

				int line_thickness;				line_thickness = 1;
				/* CV_RGB(red, green, blue) is the red, green, and blue components
				 * of the color you want, each out of 255.
				 */	
				CvScalar line_color;			line_color = CV_RGB(255,0,0);
		
				/* Let's make the flow field look nice with arrows. */

				/* The arrows will be a bit too short for a nice visualization because of the high framerate
				 * (ie: there's not much motion between the frames).  So let's lengthen them by a factor of 3.
				 */
				CvPoint p,q;
				p.x = (int) frame1_features[i].x;
				p.y = (int) frame1_features[i].y;
				q.x = (int) frame2_features[i].x;
				q.y = (int) frame2_features[i].y;

				vsResult += p.x.ToString() + "," + p.y.ToString() + "," + q.x.ToString() + "," + q.y.ToString() + ";";

				double angle;		angle = atan2( (double) p.y - q.y, (double) p.x - q.x );
				double hypotenuse;	hypotenuse = sqrt( square(p.y - q.y) + square(p.x - q.x) );

				/* Here we lengthen the arrow by a factor of three. */
				q.x = (int) (p.x - 3 * hypotenuse * cos(angle));
				q.y = (int) (p.y - 3 * hypotenuse * sin(angle));

				/* Now we draw the main line of the arrow. */
				/* "frame1" is the frame to draw on.
				 * "p" is the point where the line begins.
				 * "q" is the point where the line stops.
				 * "CV_AA" means antialiased drawing.
				 * "0" means no fractional bits in the center cooridinate or radius.
				 */
				cvLine( imageout, p, q, line_color, line_thickness, CV_AA, 0 );
				/* Now draw the tips of the arrow.  I do some scaling so that the
				 * tips look proportional to the main line of the arrow.
				 */			
				p.x = (int) (q.x + 9 * cos(angle + pi / 4));
				p.y = (int) (q.y + 9 * sin(angle + pi / 4));
				cvLine( imageout, p, q, line_color, line_thickness, CV_AA, 0 );
				p.x = (int) (q.x + 9 * cos(angle - pi / 4));
				p.y = (int) (q.y + 9 * sin(angle - pi / 4));
				cvLine( imageout, p, q, line_color, line_thickness, CV_AA, 0 );
			}

			return SaveImage(1);
		}

		static const double pi = 3.14159265358979323846;

		inline static double square(int a)
		{
			return a * a;
		}
	};
}