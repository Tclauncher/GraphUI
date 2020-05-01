/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2020/5/1
 * 时间: 12:36
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace Layerx
{
	/// <summary>
	/// Description of Layerx.
	/// </summary>
	public class Layerx
	{
		public Layerx()
		{
		}
	}
	public class GLocation
	{
		int _x;
		int _y;
		double _dx;
		double _dy;
		public GLocation(double dx,double dy)
		{
			_dx=dx;
			_dy=dy;
		}
		public GLocation(double x,double dy)
		{
			_dx=dx;
			_dy=dy;
		}
	}
}
