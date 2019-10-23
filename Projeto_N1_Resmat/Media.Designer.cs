namespace Projeto_N1_Resmat
{
    partial class Media
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
            this.rbMedia_2 = new System.Windows.Forms.RadioButton();
            this.rbMedia_1 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_Comecar_Medio = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // rbMedia_2
            // 
            this.rbMedia_2.AutoSize = true;
            this.rbMedia_2.Location = new System.Drawing.Point(473, 182);
            this.rbMedia_2.Name = "rbMedia_2";
            this.rbMedia_2.Size = new System.Drawing.Size(14, 13);
            this.rbMedia_2.TabIndex = 16;
            this.rbMedia_2.TabStop = true;
            this.rbMedia_2.UseVisualStyleBackColor = true;
            this.rbMedia_2.CheckedChanged += new System.EventHandler(this.rbMedia_2_CheckedChanged);
            // 
            // rbMedia_1
            // 
            this.rbMedia_1.AutoSize = true;
            this.rbMedia_1.Location = new System.Drawing.Point(97, 182);
            this.rbMedia_1.Name = "rbMedia_1";
            this.rbMedia_1.Size = new System.Drawing.Size(14, 13);
            this.rbMedia_1.TabIndex = 15;
            this.rbMedia_1.TabStop = true;
            this.rbMedia_1.UseVisualStyleBackColor = true;
            this.rbMedia_1.CheckedChanged += new System.EventHandler(this.rbMedia_1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(250, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 24);
            this.label1.TabIndex = 14;
            this.label1.Text = "Essa treliça tem 4 nós e 5 barras";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(314, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 24);
            this.label2.TabIndex = 10;
            this.label2.Text = "Treliças Médias";
            // 
            // bt_Comecar_Medio
            // 
            this.bt_Comecar_Medio.Location = new System.Drawing.Point(301, 445);
            this.bt_Comecar_Medio.Name = "bt_Comecar_Medio";
            this.bt_Comecar_Medio.Size = new System.Drawing.Size(219, 32);
            this.bt_Comecar_Medio.TabIndex = 18;
            this.bt_Comecar_Medio.Text = "Começar";
            this.bt_Comecar_Medio.UseVisualStyleBackColor = true;
            this.bt_Comecar_Medio.Click += new System.EventHandler(this.bt_Comecar_Medio_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Projeto_N1_Resmat.Properties.Resources.Menu_Media_2;
            this.pictureBox2.Location = new System.Drawing.Point(473, 201);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(250, 99);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Projeto_N1_Resmat.Properties.Resources.Menu_Media_1;
            this.pictureBox1.Location = new System.Drawing.Point(90, 201);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 99);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // Media
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 531);
            this.Controls.Add(this.bt_Comecar_Medio);
            this.Controls.Add(this.rbMedia_2);
            this.Controls.Add(this.rbMedia_1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Name = "Media";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Media";
            this.Load += new System.EventHandler(this.Media_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton rbMedia_2;
        private System.Windows.Forms.RadioButton rbMedia_1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_Comecar_Medio;
    }
}