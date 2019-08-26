/*
 * Created by SharpDevelop.
 * User: User
 * Date: 03.01.2018
 * Time: 20:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Cinema
{
	partial class Info
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.DarkGray;
			this.label1.Location = new System.Drawing.Point(2, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(373, 82);
			this.label1.TabIndex = 0;
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.White;
			this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(371, 81);
			this.label3.TabIndex = 2;
			this.label3.Text = "Эта программа помогает быстро скачать торррент файл фильма. Ван не нужно будет за" +
			"ходить на разные сайты, чтобы найти понравившийся фильм. Вы можете выбрать любой" +
			" фильм в этой проге. Нажимай на картинку фильма, чтобы перейти на сайт. Также ранее скаченные файлы помечаются серым цветом.";
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Silver;
			this.label2.Location = new System.Drawing.Point(69, 106);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(171, 128);
			this.label2.TabIndex = 3;
			this.label2.Text = "В настройках  программы uTorrent, вы можете выбрать автоматическкую загрузку торр" +
			"ент файлов из папки, в которую эта програ скачивает торренты. ";
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.White;
			this.label4.Location = new System.Drawing.Point(69, 106);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(169, 126);
			this.label4.TabIndex = 4;
			this.label4.Text = "В настройках  программы uTorrent, вы можете выбрать автоматическкую загрузку торр" +
			"ент файлов из папки, в которую эта програ скачивает торренты. ";
			// 
			// checkBox1
			// 
			this.checkBox1.BackColor = System.Drawing.Color.Gainsboro;
			this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.checkBox1.Location = new System.Drawing.Point(365, 213);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(233, 32);
			this.checkBox1.TabIndex = 5;
			this.checkBox1.Text = "Больше не показывать";
			this.checkBox1.UseVisualStyleBackColor = false;
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.button1.Location = new System.Drawing.Point(262, 213);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(77, 32);
			this.button1.TabIndex = 6;
			this.button1.Text = "Понял!";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// Info
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.ClientSize = new System.Drawing.Size(610, 257);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Name = "Info";
			this.Text = "Для чего это нужно?";
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}
