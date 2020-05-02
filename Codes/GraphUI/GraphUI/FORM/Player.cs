/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2020/5/1
 * 时间: 16:06
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GraphUI.FORM
{
	/// <summary>
	/// Description of Player.
	/// </summary>
	public partial class Player : Form
	{
		protected override CreateParams CreateParams
		{
			get
			{
              	CreateParams cp  =   base .CreateParams;
				cp.ExStyle  |=   0x00080000 ;  //  WS_EX_LAYERED 扩展样式
				return  cp;
			}
		}
		public Player()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		PAINTER painter;
		void Timer1Tick(object sender, EventArgs e)
		{
			painter=new PAINTER(this.Handle,new GLocation(this.Location.X,this.Location.Y));
			painter.PAINT(new Bitmap(@"C:\Users\Administrator\Desktop\cyclebin\a.png"));
		}
	}
}
