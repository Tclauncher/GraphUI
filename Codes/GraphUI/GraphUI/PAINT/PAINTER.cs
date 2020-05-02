/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2020/5/1
 * 时间: 12:21
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
namespace GraphUI
{
	/// <summary>
	/// Description of PAINTER.
	/// </summary>
	class PAINTER
	{
		GLocation _winlocation;
		IntPtr _handle;
		public PAINTER(IntPtr handle,GLocation winlocation)
		{
			_winlocation=winlocation;
			_handle=handle;
		}
		public void PAINT(Bitmap bitmap)
		{
			if (!Bitmap.IsCanonicalPixelFormat(bitmap.PixelFormat) || !Bitmap.IsAlphaPixelFormat(bitmap.PixelFormat))
                throw new ApplicationException("TEXTURE-FORMAT-ERROR");
            IntPtr oldBits = IntPtr.Zero;
            IntPtr screenDC = GetDC(_handle);
            IntPtr hBitmap = IntPtr.Zero;
            IntPtr memDc = CreateCompatibleDC(screenDC);
            try
            {
                Point topLoc = new Point(_winlocation.x,_winlocation.y);
                Size bitMapSize = new Size(bitmap.Width, bitmap.Height);
                BLENDFUNCTION blendFunc = new BLENDFUNCTION();
                Point srcLoc = new Point(0, 0);

                hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));
                oldBits = SelectObject(memDc, hBitmap);
                blendFunc.BlendOp = AC_SRC_OVER;
                blendFunc.SourceConstantAlpha = 255;
                blendFunc.AlphaFormat = AC_SRC_ALPHA;
                blendFunc.BlendFlags = 0;
                UpdateLayeredWindow(_handle, screenDC, ref topLoc, ref bitMapSize, memDc, ref srcLoc, 0, ref blendFunc, ULW_ALPHA);
            }
            catch(Exception)
            {
            	
            }
            finally
            {
                if (hBitmap != IntPtr.Zero)
                {
                    SelectObject(memDc, oldBits);
                    DeleteObject(hBitmap);
                }
                ReleaseDC(IntPtr.Zero, screenDC);
                DeleteDC(memDc);
            }
		}
		#region API
		public   enum  Bool
		{
		False  =   0 ,
		True
		};
		[StructLayout(LayoutKind.Sequential)]
		public   struct  Point
		{
			public  Int32 x;
			public  Int32 y;
			
			public  Point(Int32 x, Int32 y) 
			{  this .x  =  x;  this .y  =  y; }
		}
		[StructLayout(LayoutKind.Sequential)]
		public   struct  Size
		{
			public  Int32 cx;
			public  Int32 cy;
			
			public  Size(Int32 cx, Int32 cy) 
			{  this .cx  =  cx;  this .cy  =  cy; }
		}
		[StructLayout(LayoutKind.Sequential, Pack  =   1 )]
		struct  ARGB
		{
			public   byte  Blue;
			public   byte  Green;
			public   byte  Red;
			public   byte  Alpha;
		}
		[StructLayout(LayoutKind.Sequential, Pack  =   1 )]
		public   struct  BLENDFUNCTION
		{
			public   byte  BlendOp;
			public   byte  BlendFlags;
			public   byte  SourceConstantAlpha;
			public   byte  AlphaFormat;
		}
		public   const  Int32 ULW_COLORKEY  =   0x00000001 ;
		public   const  Int32 ULW_ALPHA  =   0x00000002 ;
		public   const  Int32 ULW_OPAQUE  =   0x00000004 ;
		public   const   byte  AC_SRC_OVER  =   0x00 ;
		public   const   byte  AC_SRC_ALPHA  =   0x01 ;
		[DllImport(@"C:\Windows\System32\user32.dll " , ExactSpelling  =   true , SetLastError  =   true )]
		public   static   extern  Bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst,  ref  Point pptDst,  ref  Size psize, IntPtr hdcSrc,  ref  Point pprSrc, Int32 crKey,  ref  BLENDFUNCTION pblend, Int32 dwFlags);
		[DllImport(@"C:\Windows\System32\user32.dll " , ExactSpelling  =   true , SetLastError  =   true )]
		public   static   extern  IntPtr GetDC(IntPtr hWnd);
		[DllImport(@"C:\Windows\System32\user32.dll " , ExactSpelling  =   true )]
		public   static   extern   int  ReleaseDC(IntPtr hWnd, IntPtr hDC);
		[DllImport( "gdi32.dll " , ExactSpelling  =   true , SetLastError  =   true )]
		public   static   extern  IntPtr CreateCompatibleDC(IntPtr hDC);
		[DllImport( "gdi32.dll " , ExactSpelling  =   true , SetLastError  =   true )]
		public   static   extern  Bool DeleteDC(IntPtr hdc);
		[DllImport( " gdi32.dll " , ExactSpelling  =   true )]
		public   static   extern  IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
		[DllImport( " gdi32.dll " , ExactSpelling  =   true , SetLastError  =   true )]
		public   static   extern  Bool DeleteObject(IntPtr hObject);
		[DllImport( " user32.dll " , EntryPoint  =   " SendMessage " )]
		public   static   extern   int  SendMessage( int  hWnd,  int  wMsg,  int  wParam,  int  lParam);
		[DllImport( " user32.dll " , EntryPoint  =   " ReleaseCapture " )]
		public   static   extern   int  ReleaseCapture();
		public   const   int  WM_SysCommand  =   0x0112 ;
		public   const   int  SC_MOVE  =   0xF012 ;
		public   const   int  SC_MAXIMIZE  =   61488 ;
		public   const   int  SC_MINIMIZE  =   61472 ;
		#endregion
	}
}
