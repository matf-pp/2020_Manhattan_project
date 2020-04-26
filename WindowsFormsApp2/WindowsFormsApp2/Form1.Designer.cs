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
            this.lbAddEdge = new System.Windows.Forms.Label();
            this.rbPeske = new System.Windows.Forms.RadioButton();
            this.rbVozilo = new System.Windows.Forms.RadioButton();
            this.rbManuelno = new System.Windows.Forms.RadioButton();
            this.rbTaksi = new System.Windows.Forms.RadioButton();
            this.tbUkupno = new System.Windows.Forms.TextBox();
            this.dijkstraBt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gmap
            // 
            this.gmap.AccessibleName = "gmap";
            this.gmap.Bearing = 0F;
            this.gmap.CanDragMap = true;
            this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmap.GrayScaleMode = false;
            this.gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmap.LevelsKeepInMemmory = 5;
            this.gmap.Location = new System.Drawing.Point(375, 0);
            this.gmap.Margin = new System.Windows.Forms.Padding(4);
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
            this.gmap.Size = new System.Drawing.Size(1271, 856);
            this.gmap.TabIndex = 0;
            this.gmap.Zoom = 15D;
            this.gmap.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.gmap_OnMarkerClick);
            this.gmap.Load += new System.EventHandler(this.gmap_Load);
            this.gmap.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gmap_MouseDoubleClick);
            // 
            // lbAddEdge
            // 
            this.lbAddEdge.Location = new System.Drawing.Point(0, 0);
            this.lbAddEdge.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAddEdge.Name = "lbAddEdge";
            this.lbAddEdge.Size = new System.Drawing.Size(133, 12);
            this.lbAddEdge.TabIndex = 16;
            // 
            // rbPeske
            // 
            this.rbPeske.AutoSize = true;
            this.rbPeske.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.rbPeske.Location = new System.Drawing.Point(248, 386);
            this.rbPeske.Margin = new System.Windows.Forms.Padding(4);
            this.rbPeske.Name = "rbPeske";
            this.rbPeske.Size = new System.Drawing.Size(68, 21);
            this.rbPeske.TabIndex = 12;
            this.rbPeske.TabStop = true;
            this.rbPeske.Text = "Peske";
            this.rbPeske.UseVisualStyleBackColor = true;
            // 
            // rbVozilo
            // 
            this.rbVozilo.AutoSize = true;
            this.rbVozilo.Location = new System.Drawing.Point(248, 415);
            this.rbVozilo.Margin = new System.Windows.Forms.Padding(4);
            this.rbVozilo.Name = "rbVozilo";
            this.rbVozilo.Size = new System.Drawing.Size(69, 21);
            this.rbVozilo.TabIndex = 13;
            this.rbVozilo.TabStop = true;
            this.rbVozilo.Text = "Autom";
            this.rbVozilo.UseVisualStyleBackColor = true;
            // 
            // rbManuelno
            // 
            this.rbManuelno.AutoSize = true;
            this.rbManuelno.Location = new System.Drawing.Point(248, 470);
            this.rbManuelno.Margin = new System.Windows.Forms.Padding(4);
            this.rbManuelno.Name = "rbManuelno";
            this.rbManuelno.Size = new System.Drawing.Size(91, 21);
            this.rbManuelno.TabIndex = 14;
            this.rbManuelno.TabStop = true;
            this.rbManuelno.Text = "Manuelno";
            this.rbManuelno.UseVisualStyleBackColor = true;
            // 
            // rbTaksi
            // 
            this.rbTaksi.AutoSize = true;
            this.rbTaksi.Location = new System.Drawing.Point(248, 442);
            this.rbTaksi.Margin = new System.Windows.Forms.Padding(4);
            this.rbTaksi.Name = "rbTaksi";
            this.rbTaksi.Size = new System.Drawing.Size(63, 21);
            this.rbTaksi.TabIndex = 17;
            this.rbTaksi.TabStop = true;
            this.rbTaksi.Text = "Taksi";
            this.rbTaksi.UseVisualStyleBackColor = true;
            // 
            // tbUkupno
            // 
            this.tbUkupno.Location = new System.Drawing.Point(34, 339);
            this.tbUkupno.Margin = new System.Windows.Forms.Padding(4);
            this.tbUkupno.Name = "tbUkupno";
            this.tbUkupno.Size = new System.Drawing.Size(198, 22);
            this.tbUkupno.TabIndex = 15;
            // 
            // dijkstraBt
            // 
            this.dijkstraBt.Location = new System.Drawing.Point(34, 210);
            this.dijkstraBt.Name = "dijkstraBt";
            this.dijkstraBt.Size = new System.Drawing.Size(323, 91);
            this.dijkstraBt.TabIndex = 18;
            this.dijkstraBt.Text = "dijkstra";
            this.dijkstraBt.UseVisualStyleBackColor = true;
            this.dijkstraBt.Click += new System.EventHandler(this.dijkstraBt_Click);
            // 
            // form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 757);
            this.Controls.Add(this.dijkstraBt);
            this.Controls.Add(this.rbTaksi);
            this.Controls.Add(this.tbUkupno);
            this.Controls.Add(this.rbManuelno);
            this.Controls.Add(this.rbVozilo);
            this.Controls.Add(this.rbPeske);
            this.Controls.Add(this.lbAddEdge);
            this.Controls.Add(this.gmap);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gmap;
        private System.Windows.Forms.Label lbAddEdge;
        private System.Windows.Forms.RadioButton rbPeske;
        private System.Windows.Forms.RadioButton rbVozilo;
        private System.Windows.Forms.RadioButton rbManuelno;
        private System.Windows.Forms.RadioButton rbTaksi;
        private System.Windows.Forms.TextBox tbUkupno;
        private System.Windows.Forms.Button dijkstraBt;
    }
}

