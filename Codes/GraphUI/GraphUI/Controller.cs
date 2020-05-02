/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2020/5/1
 * 时间: 15:12
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
namespace GraphUI
{
	/// <summary>
	/// Description of Controller.
	/// </summary>
	public class Controller
	{
		public Controller()
		{
			FORM.Player p=new FORM.Player();
			p.Show();
			for(int i=9;i>=0;i--)
			{
				Thread.Sleep(1000);
				Console.Write(i.ToString());
			}
		//	Player.EVENT_UPDATE updater;
		//	updater = p.FUpdate;
		//	updater();
		}
	}
}
