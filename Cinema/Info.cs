
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
namespace Cinema
{
	
	public partial class Info : Form
	{
		public Info()
		{
			
			InitializeComponent();
			
		}
		
		
		void Button1Click(object sender, EventArgs e)
		{
			if (checkBox1.Checked == true)
			{
			File.WriteAllText("status", "1");
			}
			this.Close();
			
		}
	}
}
