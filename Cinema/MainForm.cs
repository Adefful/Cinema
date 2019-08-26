
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Threading;
using System.Windows.Forms;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Cinema
{
	
	public partial class MainForm : Form
	{	int page = 1;
		int bottom= 20;
		string[] files;
		string[] filesLoaded;
		string path = @"C:\Users\Комп\Documents\Torrents";
        // TODO:     
		string pathLoaded = @"C:\Users\Комп\Documents\LoadedTorrents";
		string movie;
		int amount = 0;
		Loading_form load;
		Browser browser;
		
		public MainForm()
		{	
			
			 load = new Loading_form();
			 browser = new Browser();
			 Info info = new Info();
			InitializeComponent();
			// page of page
			GetFiles();
			using (StreamWriter sw = new StreamWriter("page.txt", false, System.Text.Encoding.Default))
   			 {
       		 sw.WriteLine("1");
    		}
			if (File.ReadAllText("status")!= "1")
			{
				info.Show();
			}
		}
		public List<Movies> read()
		{
			 FileStream file1 = new FileStream("some.txt", FileMode.Open); //создаем файловый поток
  			 StreamReader reader = new StreamReader(file1); // создаем «потоковый читатель» и связываем его с файловым потоком 
  			 movie = reader.ReadToEnd(); //считываем все данные с потока и выводим на экран
   			 reader.Close(); //закрываем поток
   			 
   			 List<Movies> list  = JsonConvert.DeserializeObject<List<Movies>>(movie);
   			 return list;
		
		}
		public void draw(List<Movies> list)
		{	//for draw picture
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			WebClient wc = new WebClient();
			//List<GroupBox> gb = new List<GroupBox>();
			 //kol-vo elements
			 amount =0;
			foreach (var i in list)  // img , link rating , name
			{	
				
				GroupBox gbox = new GroupBox();
				gbox.Text = System.Net.WebUtility.UrlDecode(i.name).ToString();
				gbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
				gbox.Font = new System.Drawing.Font("Tahoma", 10.7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));		
				gbox.Height = 300;
				gbox.Width   = 500;
				gbox.Left = 13;
				gbox.BackColor = Color.White;
				foreach (var f in files)
				{	
					if (f.ToString().Remove(0, path.Length) == (System.Net.WebUtility.UrlDecode(i.name).ToString() + ".torrent"))
					{
						gbox.ForeColor = Color.FromArgb(200,200,200);	
						gbox.BackColor = Color.FromArgb(245, 246, 248);}
				}
				foreach (var f in filesLoaded)
				{
					if (f.ToString().Remove(0, path.Length) == System.Net.WebUtility.UrlDecode(i.name).ToString() + " .torrent")
					{gbox.ForeColor = Color.FromArgb(100,100,100);
					gbox.BackColor = Color.FromArgb(245, 246, 248);
					}
				}
				gbox.Top = (gbox.Size.Height+10) * amount + bottom;
				
				Label info_lb = new Label();
				info_lb.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
				info_lb.Location = new System.Drawing.Point(145, 40);
				info_lb.Size = new System.Drawing.Size(250, 225);
				info_lb.Text = "Наведи на иконку Скачать, чтобы увидеть подробности";
				
				Label delimiter = new Label();
				delimiter.Width=2;
				delimiter.Height= gbox.Size.Height;
				delimiter.Left =385;
				delimiter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
				
				PictureBox picture = new PictureBox();
				picture.Width = 120;
				picture.Height = 177;
				picture.Top    = 30;
				picture.Left   = 10;
				picture.ImageLocation = i.img.ToString();
				picture.Click += (sender, args) =>
                       {
					browser.Show();
					browser.webBrowser1.Navigate(i.link);
						};
				
				
				Label lbl = new Label();
				lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(245)))), ((int)(((byte)(248)))));
				lbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
				lbl.Location = new System.Drawing.Point(10, 215);
				lbl.Size = new System.Drawing.Size(120, 35);
				lbl.Text = i.rating.ToString();
				
				if (i.rating[0]=='-')
				{
				lbl.ForeColor = Color.Red;
				}
				else lbl.ForeColor = Color.Green;
				lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
				
				gbox.Controls.Add(picture);
				gbox.Controls.Add(lbl);
				gbox.Controls.Add(delimiter);
				gbox.Controls.Add(info_lb);
				
				Controls.Add(gbox);
				int count_button=0;
				foreach (var torrent in i.torrents.Values)			//inside groupbox	
				{
					Button bt = new Button();
					bt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
					bt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
					bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
					bt.Location = new System.Drawing.Point(450, (45)*count_button +25);
					bt.Size = new System.Drawing.Size(45, 45);
					bt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
					bt.UseVisualStyleBackColor = true;
					
					Label Size_lb =new Label();
					Size_lb.Font = new System.Drawing.Font("AA American Captain", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
					Size_lb.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
					Size_lb.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
					Size_lb.Location = new System.Drawing.Point(380, (45)*count_button +25);
					Size_lb.Size = new System.Drawing.Size(90, 45);
					Size_lb.Text = torrent["size"] + " Gb";
					Size_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
					
					bt.Click += (sender, args) =>
                       {
						toolStripProgressBar1.Value = 0;
						try{	//download torrentt file
							
                wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
               
                wc.DownloadFileAsync(new Uri("http://filmitorrent.org" + torrent["download"].ToString()), path + System.Net.WebUtility.UrlDecode(i.name)+".torrent");
						//wc.DownloadFile("http://filmitorrent.org" + torrent["download"].ToString(),path + System.Net.WebUtility.UrlDecode(i.name)+".torrent");
						} catch (Exception) {wc.DownloadFile("http://filmitorrent.org" + torrent["download"].ToString(),path + i.name.Replace(':',' ').ToString()+".torrent");}
						/*for (int v=0; v<100; v++)
							toolStripProgressBar1.Value++;
						*/
						toolStripStatusLabel1.Text = "Скачено: " + System.Net.WebUtility.UrlDecode(i.name);
                       };
					
					bt.MouseMove += (sender, args) =>
					{
						info_lb.Text = System.Net.WebUtility.UrlDecode(torrent["info"]);
					
					};
					gbox.Controls.Add(bt);
					gbox.Controls.Add(Size_lb);				
					count_button++;
				}
				//gb.Add(gbox);		
			amount++;	
		}
		}
	
		public void GetFiles()
		{
			 files = Directory.GetFiles(path, "*torrent");
			 filesLoaded = Directory.GetFiles(pathLoaded, "*torrent");
		
		
		}
        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Maximum = (int)e.TotalBytesToReceive / 100;
            toolStripProgressBar1.Value = (int)e.BytesReceived / 100;
        }
		
		void MainFormPaint(object sender, PaintEventArgs e)
		{
			statusStrip1.Top = this.VerticalScroll.Value/this.Height;
			label1.Top       = this.VerticalScroll.Value/this.Height;
			button3.Top      = this.VerticalScroll.Value/this.Height;
			//button1.Text = this.VerticalScroll.Value.ToString();
			button1.Visible = false;
			button1.Top = this.Height- button1.Height;
			if (this.VerticalScroll.Value >= this.VerticalScroll.Maximum- 1080 - 50)
				button1.Visible = true;
			
			
		}
		
		
		void MainFormLoad(object sender, EventArgs e) // set form
		{	
			this.Left = 1920;
			label1.Height = 1030;
			this.Width = 540;
			this.Top = 0;
			this.Left = 1920 - this.Width;
			this.Height = 1080 - 45;
			this.VerticalScroll.LargeChange = 100;
			timer1.Start();
			
			
		}
		
		void ToolStripStatusLabel2Click(object sender, EventArgs e)   //folder open
		{
			System.Diagnostics.Process.Start("explorer", path);
		}
		
		void Label1Click(object sender, EventArgs e)
		{
			if (this.Left == (1920 - this.Width)) {this.Left += this.Width-10;}
			else {this.Left -= this.Width-10;}
			
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			//this.VerticalScroll.Value = 0;	
				page ++;
				bottom= 1080;
			using (StreamWriter sw = new StreamWriter("page.txt", false, System.Text.Encoding.Default))
   			{
       		 sw.WriteLine(page);
    		}	
				
				timer1.Start();
									
				
						
		}
		
		void Timer1Tick(object sender, EventArgs e)
		{
			load.Show();
			Process.Start("Parsing.py");
			Thread.Sleep(1000);
		here:
			try {
				File.ReadAllText("status");}
			catch(Exception ) {goto here;}
			
			//if (File.GetLastAccessTime("some.txt"))
			draw(read());
			
			timer1.Stop();
			load.Hide();
			
		
		}

		
		void Button3Click(object sender, EventArgs e)
		{
			this.Close();
			
		}
	}
	
	
	
	public class Movies
		{	
			public string link { get; set;}
            public string rating { get; set; }
            public string name { get; set; }            
            public string img { get; set; }    
            public Dictionary<string, Dictionary<string, string >> torrents{get; set;}
		}
	
	
}
