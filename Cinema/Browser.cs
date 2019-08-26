/*
 * Created by SharpDevelop.
 * User: User
 * Date: 03.01.2018
 * Time: 20:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cinema
{
	/// <summary>
	/// Description of Browser.
	/// </summary>
	public partial class Browser : Form
	{
		public Browser()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			this.Top = 0;
			this.Left = 0;
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			this.Hide();
		}
		
		void BrowserDeactivate(object sender, EventArgs e)
		{
			this.Hide();
		}
	}
}
