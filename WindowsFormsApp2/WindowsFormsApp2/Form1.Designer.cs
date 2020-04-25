namespace WindowsFormsApp2
{
    partial class Form1
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
            this.lbAllRoutes = new System.Windows.Forms.Label();
            this.lbAddVertexWithAdge = new System.Windows.Forms.Label();
            this.lbDjikstra = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbAddEdge = new System.Windows.Forms.Label();
            this.tbUkupno = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.rbPeske = new System.Windows.Forms.RadioButton();
            this.rbVozilo = new System.Windows.Forms.RadioButton();
            this.rbManuelno = new System.Windows.Forms.RadioButton();
            this.tbUnos = new System.Windows.Forms.TextBox();
            this.rbTaksi = new System.Windows.Forms.RadioButton();
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
            this.gmap.Location = new System.Drawing.Point(282, 0);
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
            this.gmap.Size = new System.Drawing.Size(854, 551);
            this.gmap.TabIndex = 0;
            this.gmap.Zoom = 10D;
            this.gmap.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.gmap_OnMarkerClick);
            this.gmap.Load += new System.EventHandler(this.gmap_Load);
            this.gmap.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gmap_MouseDoubleClick);
            // 
            // lbAllRoutes
            // 
            this.lbAllRoutes.AccessibleName = "allRoutesLbl";
            this.lbAllRoutes.AutoSize = true;
            this.lbAllRoutes.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbAllRoutes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbAllRoutes.Location = new System.Drawing.Point(12, 9);
            this.lbAllRoutes.Name = "lbAllRoutes";
            this.lbAllRoutes.Size = new System.Drawing.Size(87, 15);
            this.lbAllRoutes.TabIndex = 1;
            this.lbAllRoutes.Text = "Show All Routes";
            // 
            // lbAddVertexWithAdge
            // 
            this.lbAddVertexWithAdge.AccessibleName = "addVertexLbl";
            this.lbAddVertexWithAdge.AutoSize = true;
            this.lbAddVertexWithAdge.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbAddVertexWithAdge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbAddVertexWithAdge.Location = new System.Drawing.Point(12, 36);
            this.lbAddVertexWithAdge.Name = "lbAddVertexWithAdge";
            this.lbAddVertexWithAdge.Size = new System.Drawing.Size(114, 15);
            this.lbAddVertexWithAdge.TabIndex = 2;
            this.lbAddVertexWithAdge.Text = "Add Vertex With Edge";
            // 
            // lbDjikstra
            // 
            this.lbDjikstra.AccessibleName = "dijkstraLbl";
            this.lbDjikstra.AutoSize = true;
            this.lbDjikstra.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbDjikstra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbDjikstra.Font = new System.Drawing.Font("Script MT Bold", 9.163636F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDjikstra.Location = new System.Drawing.Point(12, 97);
            this.lbDjikstra.Name = "lbDjikstra";
            this.lbDjikstra.Size = new System.Drawing.Size(54, 17);
            this.lbDjikstra.TabIndex = 3;
            this.lbDjikstra.Text = "Dijkstra";
            this.lbDjikstra.Click += new System.EventHandler(this.label3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 148);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(264, 20);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 196);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(264, 20);
            this.textBox2.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AccessibleName = "startPointLbl";
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Starting Point";
            // 
            // label5
            // 
            this.label5.AccessibleName = "destinationLbl";
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Destination";
            // 
            // lbAddEdge
            // 
            this.lbAddEdge.Location = new System.Drawing.Point(0, 0);
            this.lbAddEdge.Name = "lbAddEdge";
            this.lbAddEdge.Size = new System.Drawing.Size(100, 10);
            this.lbAddEdge.TabIndex = 16;
            // 
            // tbUkupno
            // 
            this.tbUkupno.Location = new System.Drawing.Point(12, 256);
            this.tbUkupno.Name = "tbUkupno";
            this.tbUkupno.ReadOnly = true;
            this.tbUkupno.Size = new System.Drawing.Size(264, 20);
            this.tbUkupno.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AccessibleName = "distanceLbl";
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 237);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Distance";
            // 
            // label8
            // 
            this.label8.AccessibleName = "clearLbl";
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.78182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 438);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "Clear";
//            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // rbPeske
            // 
            this.rbPeske.AutoSize = true;
            this.rbPeske.Location = new System.Drawing.Point(186, 313);
            this.rbPeske.Name = "rbPeske";
            this.rbPeske.Size = new System.Drawing.Size(55, 17);
            this.rbPeske.TabIndex = 12;
            this.rbPeske.TabStop = true;
            this.rbPeske.Text = "Peske";
            this.rbPeske.UseVisualStyleBackColor = true;
            // 
            // rbVozilo
            // 
            this.rbVozilo.AutoSize = true;
            this.rbVozilo.Location = new System.Drawing.Point(186, 337);
            this.rbVozilo.Name = "rbVozilo";
            this.rbVozilo.Size = new System.Drawing.Size(55, 17);
            this.rbVozilo.TabIndex = 13;
            this.rbVozilo.TabStop = true;
            this.rbVozilo.Text = "Autom";
            this.rbVozilo.UseVisualStyleBackColor = true;
            // 
            // rbManuelno
            // 
            this.rbManuelno.AutoSize = true;
            this.rbManuelno.Location = new System.Drawing.Point(186, 382);
            this.rbManuelno.Name = "rbManuelno";
            this.rbManuelno.Size = new System.Drawing.Size(72, 17);
            this.rbManuelno.TabIndex = 14;
            this.rbManuelno.TabStop = true;
            this.rbManuelno.Text = "Manuelno";
            this.rbManuelno.UseVisualStyleBackColor = true;
            // 
            // tbUnos
            // 
            this.tbUnos.Location = new System.Drawing.Point(20, 300);
            this.tbUnos.Name = "tbUnos";
            this.tbUnos.Size = new System.Drawing.Size(100, 20);
            this.tbUnos.TabIndex = 15;
            // 
            // rbTaksi
            // 
            this.rbTaksi.AutoSize = true;
            this.rbTaksi.Location = new System.Drawing.Point(186, 359);
            this.rbTaksi.Name = "rbTaksi";
            this.rbTaksi.Size = new System.Drawing.Size(51, 17);
            this.rbTaksi.TabIndex = 17;
            this.rbTaksi.TabStop = true;
            this.rbTaksi.Text = "Taksi";
            this.rbTaksi.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 551);
            this.Controls.Add(this.rbTaksi);
            this.Controls.Add(this.tbUnos);
            this.Controls.Add(this.rbManuelno);
            this.Controls.Add(this.rbVozilo);
            this.Controls.Add(this.rbPeske);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbUkupno);
            this.Controls.Add(this.lbAddEdge);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lbDjikstra);
            this.Controls.Add(this.lbAddVertexWithAdge);
            this.Controls.Add(this.lbAllRoutes);
            this.Controls.Add(this.gmap);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gmap;
        private System.Windows.Forms.Label lbAllRoutes;
        private System.Windows.Forms.Label lbAddVertexWithAdge;
        private System.Windows.Forms.Label lbDjikstra;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbAddEdge;
        private System.Windows.Forms.TextBox tbUkupno;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rbPeske;
        private System.Windows.Forms.RadioButton rbVozilo;
        private System.Windows.Forms.RadioButton rbManuelno;
        private System.Windows.Forms.TextBox tbUnos;
        private System.Windows.Forms.RadioButton rbTaksi;
    }
}

