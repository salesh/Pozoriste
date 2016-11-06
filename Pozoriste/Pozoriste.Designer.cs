﻿namespace Pozoriste
{
    partial class Pozoriste
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pozoriste));
            this.textLabel = new System.Windows.Forms.Label();
            this.upit1 = new System.Windows.Forms.Button();
            this.upit2 = new System.Windows.Forms.Button();
            this.upit3 = new System.Windows.Forms.Button();
            this.MyToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // textLabel
            // 
            this.textLabel.BackColor = System.Drawing.Color.Transparent;
            this.textLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textLabel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textLabel.Location = new System.Drawing.Point(192, 73);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(200, 50);
            this.textLabel.TabIndex = 0;
            this.textLabel.Text = "Izaberite upit";
            this.textLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // upit1
            // 
            this.upit1.Location = new System.Drawing.Point(53, 162);
            this.upit1.Name = "upit1";
            this.upit1.Size = new System.Drawing.Size(119, 52);
            this.upit1.TabIndex = 1;
            this.upit1.Text = "Upit 1";
            this.MyToolTip.SetToolTip(this.upit1, resources.GetString("upit1.ToolTip"));
            this.upit1.UseVisualStyleBackColor = true;
            this.upit1.Click += new System.EventHandler(this.upit1_Click);
            // 
            // upit2
            // 
            this.upit2.Location = new System.Drawing.Point(53, 260);
            this.upit2.Name = "upit2";
            this.upit2.Size = new System.Drawing.Size(119, 52);
            this.upit2.TabIndex = 2;
            this.upit2.Text = "Upit 2";
            this.MyToolTip.SetToolTip(this.upit2, "Prikazuje sifru i naziv predstave koja se u tekucoj godini \r\nnajvise puta nalazi " +
        "na repertoaru.  ");
            this.upit2.UseVisualStyleBackColor = true;
            this.upit2.Click += new System.EventHandler(this.upit2_Click);
            // 
            // upit3
            // 
            this.upit3.Location = new System.Drawing.Point(53, 361);
            this.upit3.Name = "upit3";
            this.upit3.Size = new System.Drawing.Size(119, 52);
            this.upit3.TabIndex = 3;
            this.upit3.Text = "Upit 3";
            this.MyToolTip.SetToolTip(this.upit3, resources.GetString("upit3.ToolTip"));
            this.upit3.UseVisualStyleBackColor = true;
            this.upit3.Click += new System.EventHandler(this.upit3_Click);
            // 
            // MyToolTip
            // 
            this.MyToolTip.AutoPopDelay = 30000;
            this.MyToolTip.InitialDelay = 0;
            this.MyToolTip.IsBalloon = true;
            this.MyToolTip.ReshowDelay = 100;
            // 
            // Pozoriste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Pozoriste.Properties.Resources.stage;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.upit3);
            this.Controls.Add(this.upit2);
            this.Controls.Add(this.upit1);
            this.Controls.Add(this.textLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Pozoriste";
            this.Text = "Pozoriste";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label textLabel;
        private System.Windows.Forms.Button upit1;
        private System.Windows.Forms.Button upit2;
        private System.Windows.Forms.Button upit3;
        private System.Windows.Forms.ToolTip MyToolTip;
    }
}

