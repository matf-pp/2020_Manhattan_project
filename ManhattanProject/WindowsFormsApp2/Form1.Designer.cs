using System;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    partial class form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gmap = new GMap.NET.WindowsForms.GMapControl();
            this.rbPeske = new System.Windows.Forms.RadioButton();
            this.rbVozilo = new System.Windows.Forms.RadioButton();
            this.rbTaksi = new System.Windows.Forms.RadioButton();
            this.tbUkupno = new System.Windows.Forms.TextBox();
            this.dijkstraBt = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.hideLabel = new System.Windows.Forms.Panel();
            this.hideHelpbt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.Clear = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.help1 = new WindowsFormsApp2.help();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // gmap
            // 
            this.gmap.AccessibleName = "gmap";
            this.gmap.AutoSize = true;
            this.gmap.Bearing = 0F;
            this.gmap.CanDragMap = true;
            this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmap.GrayScaleMode = false;
            this.gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmap.LevelsKeepInMemmory = 5;
            this.gmap.Location = new System.Drawing.Point(532, 0);
            this.gmap.MarkersEnabled = true;
            this.gmap.MaxZoom = 18;
            this.gmap.MinZoom = 2;
            this.gmap.MouseWheelZoomEnabled = true;
            this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gmap.Name = "gmap";
            this.gmap.NegativeMode = false;
            this.gmap.PolygonsEnabled = true;
            this.gmap.RetryLoadTile = 0;
            this.gmap.RoutesEnabled = true;
            this.gmap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmap.ShowTileGridLines = false;
            this.gmap.Size = new System.Drawing.Size(901, 659);
            this.gmap.TabIndex = 0;
            this.gmap.Zoom = 16D;
            this.gmap.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.gmap_OnMarkerClick);
            this.gmap.Load += new System.EventHandler(this.gmap_Load);
            this.gmap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gmap_MouseClick);
            this.gmap.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gmap_MouseDoubleClick);
            // 
            // rbPeske
            // 
            this.rbPeske.AutoSize = true;
            this.rbPeske.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPeske.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rbPeske.Location = new System.Drawing.Point(64, 148);
            this.rbPeske.Name = "rbPeske";
            this.rbPeske.Size = new System.Drawing.Size(62, 21);
            this.rbPeske.TabIndex = 12;
            this.rbPeske.TabStop = true;
            this.rbPeske.Text = "Peske";
            this.rbPeske.UseVisualStyleBackColor = true;
            // 
            // rbVozilo
            // 
            this.rbVozilo.AutoSize = true;
            this.rbVozilo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbVozilo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rbVozilo.Location = new System.Drawing.Point(64, 175);
            this.rbVozilo.Name = "rbVozilo";
            this.rbVozilo.Size = new System.Drawing.Size(70, 21);
            this.rbVozilo.TabIndex = 13;
            this.rbVozilo.TabStop = true;
            this.rbVozilo.Text = "Autom";
            this.rbVozilo.UseVisualStyleBackColor = true;
            // 
            // rbTaksi
            // 
            this.rbTaksi.AutoSize = true;
            this.rbTaksi.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTaksi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rbTaksi.Location = new System.Drawing.Point(64, 202);
            this.rbTaksi.Name = "rbTaksi";
            this.rbTaksi.Size = new System.Drawing.Size(55, 21);
            this.rbTaksi.TabIndex = 17;
            this.rbTaksi.TabStop = true;
            this.rbTaksi.Text = "Taksi";
            this.rbTaksi.UseVisualStyleBackColor = true;
            // 
            // tbUkupno
            // 
            this.tbUkupno.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUkupno.Location = new System.Drawing.Point(3, 101);
            this.tbUkupno.Name = "tbUkupno";
            this.tbUkupno.ReadOnly = true;
            this.tbUkupno.Size = new System.Drawing.Size(212, 21);
            this.tbUkupno.TabIndex = 15;
            this.tbUkupno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dijkstraBt
            // 
            this.dijkstraBt.BackColor = System.Drawing.Color.White;
            this.dijkstraBt.FlatAppearance.BorderSize = 0;
            this.dijkstraBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dijkstraBt.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dijkstraBt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dijkstraBt.Location = new System.Drawing.Point(2, 10);
            this.dijkstraBt.Margin = new System.Windows.Forms.Padding(2);
            this.dijkstraBt.Name = "dijkstraBt";
            this.dijkstraBt.Size = new System.Drawing.Size(213, 74);
            this.dijkstraBt.TabIndex = 18;
            this.dijkstraBt.Text = "Put";
            this.dijkstraBt.UseVisualStyleBackColor = false;
            this.dijkstraBt.Click += new System.EventHandler(this.dijkstraBt_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.help1);
            this.panel1.Controls.Add(this.hideLabel);
            this.panel1.Controls.Add(this.hideHelpbt);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(304, 659);
            this.panel1.TabIndex = 19;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // hideLabel
            // 
            this.hideLabel.BackColor = System.Drawing.Color.Red;
            this.hideLabel.Location = new System.Drawing.Point(3, 180);
            this.hideLabel.Name = "hideLabel";
            this.hideLabel.Size = new System.Drawing.Size(10, 25);
            this.hideLabel.TabIndex = 25;
            // 
            // hideHelpbt
            // 
            this.hideHelpbt.FlatAppearance.BorderSize = 0;
            this.hideHelpbt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hideHelpbt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hideHelpbt.ForeColor = System.Drawing.Color.White;
            this.hideHelpbt.Location = new System.Drawing.Point(5, 180);
            this.hideHelpbt.Name = "hideHelpbt";
            this.hideHelpbt.Size = new System.Drawing.Size(291, 25);
            this.hideHelpbt.TabIndex = 24;
            this.hideHelpbt.Text = "Hide help";
            this.hideHelpbt.UseVisualStyleBackColor = true;
            this.hideHelpbt.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 75);
            this.label1.TabIndex = 19;
            this.label1.Text = "Manhattan Project";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Red;
            this.panel3.Location = new System.Drawing.Point(3, 71);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 98);
            this.panel3.TabIndex = 20;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(9, 74);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(290, 95);
            this.button2.TabIndex = 22;
            this.button2.Text = "Help";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gray;
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.linkLabel1);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.Clear);
            this.panel4.Controls.Add(this.dijkstraBt);
            this.panel4.Controls.Add(this.tbUkupno);
            this.panel4.Controls.Add(this.rbPeske);
            this.panel4.Controls.Add(this.rbVozilo);
            this.panel4.Controls.Add(this.rbTaksi);
            this.panel4.ForeColor = System.Drawing.Color.White;
            this.panel4.Location = new System.Drawing.Point(312, 1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(218, 659);
            this.panel4.TabIndex = 21;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkLabel1.Location = new System.Drawing.Point(3, 441);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(208, 72);
            this.linkLabel1.TabIndex = 23;
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(10, 420);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 21);
            this.label2.TabIndex = 20;
            this.label2.Text = "LINK OD ZNAMENITOSTI:\r\n";
            // 
            // Clear
            // 
            this.Clear.AccessibleName = "Clear";
            this.Clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Clear.FlatAppearance.BorderSize = 0;
            this.Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Clear.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clear.ForeColor = System.Drawing.Color.Black;
            this.Clear.Location = new System.Drawing.Point(10, 243);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(205, 83);
            this.Clear.TabIndex = 19;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = false;
            this.Clear.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel5.Location = new System.Drawing.Point(306, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(10, 659);
            this.panel5.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(9, 329);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(205, 91);
            this.label3.TabIndex = 24;
            this.label3.Text = "klikom na marker koji \r\nobelezava znamenitost\r\ndolazi do pojave linka\r\nna kom moz" +
    "emo saznati \r\nnesto vise o istoj\r\n ";
            // 
            // help1
            // 
            this.help1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.help1.Location = new System.Drawing.Point(1, 226);
            this.help1.Name = "help1";
            this.help1.Size = new System.Drawing.Size(304, 454);
            this.help1.TabIndex = 26;
            // 
            // form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1434, 659);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.gmap);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "form1";
            this.Text = "Manhattan Project";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void gmap_OnMarkerClick(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gmap;
        private System.Windows.Forms.RadioButton rbPeske;
        private System.Windows.Forms.RadioButton rbVozilo;
        private System.Windows.Forms.RadioButton rbTaksi;
        private System.Windows.Forms.TextBox tbUkupno;
        private System.Windows.Forms.Button dijkstraBt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button hideHelpbt;
        private System.Windows.Forms.Panel hideLabel;
        private help help1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Clear;
        private LinkLabel linkLabel1;
        private Label label3;
    }
}

