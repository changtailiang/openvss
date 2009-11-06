using System;
using System.Drawing;
using System.Threading;
using System.Runtime.InteropServices;	// for DllImport, MarshalAs, etc
using System.Windows.Forms;
using Nolme.Core;

namespace Nolme.Win32
{
	public sealed class CaptureUtility
	{
		private CaptureUtility () {}

		public static Bitmap Capture (System.Windows.Forms.Control control)
		{
			if (control == null)		throw new NolmeArgumentNullException ();

			// http://www.csharphelp.com/archives2/archive393.html
			//Variable to keep the handle of the btimap.
			IntPtr m_HBitmap;

			//Variable to keep the refrence to the desktop bitmap.
			System.Drawing.Bitmap bmp=null;

			//In size variable we shall keep the size of the screen.
			int Width, Height;

			//Here we get the handle to the desktop device context.
			IntPtr   hDC = User32ApiNativeMethods.GetDC(control.Handle);
			//IntPtr   hDC = User32ApiNativeMethods.GetDC(User32ApiNativeMethods.GetDesktopWindow()); 

			//Here we make a compatible device context in memory for screen device context.
			IntPtr hMemDC = Gdi32ApiNativeMethods.CreateCompatibleDC(hDC);
      
			//We pass SM_CXSCREEN constant to GetSystemMetrics to get the X coordinates of screen.
			//Width = User32ApiNativeMethods.GetSystemMetrics (User32ApiNativeMethods.SM_CXSCREEN);
			Width = control.Width;

			//We pass SM_CYSCREEN constant to GetSystemMetrics to get the Y coordinates of screen.
			//Height = User32ApiNativeMethods.GetSystemMetrics(User32ApiNativeMethods.SM_CYSCREEN);
			Height = control.Height;
      
			//We create a compatible bitmap of screen size and using screen device context.
			m_HBitmap = Gdi32ApiNativeMethods.CreateCompatibleBitmap(hDC, Width, Height);
      
			//As m_HBitmap is IntPtr we can not check it against null. For this purspose IntPtr.Zero is used.
			if (m_HBitmap!=IntPtr.Zero)
			{
				//Here we select the compatible bitmap in memeory device context and keeps the refrence to Old bitmap.
				IntPtr hOld = (IntPtr)Gdi32ApiNativeMethods.SelectObject(hMemDC,  m_HBitmap);

				//We copy the Bitmap to the memory device context.
				Gdi32ApiNativeMethods.BitBlt(hMemDC, 0, 0,Width,Height, hDC, 0, 0,Gdi32ApiNativeMethods.SRCCOPY);

				//We select the old bitmap back to the memory device context.
				Gdi32ApiNativeMethods.SelectObject(hMemDC, hOld);

				//We delete the memory device context.
				Gdi32ApiNativeMethods.DeleteDC(hMemDC);

				//We release the screen device context.
				User32ApiNativeMethods.ReleaseDC(User32ApiNativeMethods.GetDesktopWindow(), hDC);

				//Image is created by Image bitmap handle and assigned to Bitmap variable.
				bmp=System.Drawing.Image.FromHbitmap(m_HBitmap); 

				//Delete the compatible bitmap object. 
				Gdi32ApiNativeMethods.DeleteObject(m_HBitmap);

				return bmp;
			}
			//If m_HBitmap is null retunrn null.
			return null;
		}
	}

	/// <summary>
	/// Summary description for Win32BitmapUtility.
	/// </summary>
	public sealed class Win32BitmapUtility
	{
		private Win32BitmapUtility() {}
		
		static public Bitmap ConvertToGrayscale(Bitmap sourceBitmap)
		{
			if (sourceBitmap == null)		throw new NolmeArgumentNullException ();

			Bitmap bm = new Bitmap(sourceBitmap.Width,sourceBitmap.Height);

			for(int y=0;y<bm.Height;y++)
			{
				for(int x=0;x<bm.Width;x++)
				{
					Color c=sourceBitmap.GetPixel(x,y);

					int luma = (int)(c.R*0.3 + c.G*0.59+ c.B*0.11);
					bm.SetPixel(x,y,Color.FromArgb(luma,luma,luma));
				}
			}
			return bm;
		/*
		Image img = Image.FromFile(dlg.FileName);
        Bitmap bm = new Bitmap(img.Width,img.Height);
        Graphics g = Graphics.FromImage(bm);
 
        
        ColorMatrix cm = new ColorMatrix(new float[][]{   new float[]{0.5f,0.5f,0.5f,0,0},
                                  new float[]{0.5f,0.5f,0.5f,0,0},
                                  new float[]{0.5f,0.5f,0.5f,0,0},
                                  new float[]{0,0,0,1,0,0},
                                  new float[]{0,0,0,0,1,0},
                                  new float[]{0,0,0,0,0,1}});
        
        //Gilles Khouzams colour corrected grayscale shear
        //ColorMatrix cm = new ColorMatrix(new float[][]{   new float[]{0.3f,0.3f,0.3f,0,0},
        //                        new float[]{0.59f,0.59f,0.59f,0,0},
        //                        new float[]{0.11f,0.11f,0.11f,0,0},
        //                        new float[]{0,0,0,1,0,0},
        //                        new float[]{0,0,0,0,1,0},
        //                        new float[]{0,0,0,0,0,1}});

				ImageAttributes ia = new ImageAttributes();
		ia.SetColorMatrix(cm);
		g.DrawImage(img,new Rectangle(0,0,img.Width,img.Height),0,0,img.Width,img.Height,GraphicsUnit.Pixel,ia);
		g.Dispose();
		this.BackgroundImage=bm;
		*/
		}
	}
}
