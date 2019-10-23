namespace Projeto_N1_Resmat
{
    partial class Complexas
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
            this.button1 = new System.Windows.Forms.Button();
            this.rbComplexas_2 = new System.Windows.Forms.RadioButton();
            this.rbComplexas_1 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.imgComplex_2 = new System.Windows.Forms.PictureBox();
            this.imgComplex_1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgComplex_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgComplex_1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(299, 444);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(219, 32);
            this.button1.TabIndex = 28;
            this.button1.Text = "Começar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rbComplexas_2
            // 
            this.rbComplexas_2.AutoSize = true;
            this.rbComplexas_2.Location = new System.Drawing.Point(484, 178);
            this.rbComplexas_2.Name = "rbComplexas_2";
            this.rbComplexas_2.Size = new System.Drawing.Size(14, 13);
            this.rbComplexas_2.TabIndex = 26;
            this.rbComplexas_2.TabStop = true;
            this.rbComplexas_2.UseVisualStyleBackColor = true;
            this.rbComplexas_2.CheckedChanged += new System.EventHandler(this.rbComplexas_2_CheckedChanged);
            // 
            // rbComplexas_1
            // 
            this.rbComplexas_1.AutoSize = true;
            this.rbComplexas_1.Location = new System.Drawing.Point(90, 178);
            this.rbComplexas_1.Name = "rbComplexas_1";
            this.rbComplexas_1.Size = new System.Drawing.Size(14, 13);
            this.rbComplexas_1.TabIndex = 25;
            this.rbComplexas_1.TabStop = true;
            this.rbComplexas_1.UseVisualStyleBackColor = true;
            this.rbComplexas_1.CheckedChanged += new System.EventHandler(this.rbComplexas_1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(258, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(319, 24);
            this.label1.TabIndex = 24;
            this.label1.Text = "Essa treliça tem 8 Nós com 13 barras";
            // 
            // imgComplex_2
            // 
            this.imgComplex_2.Image = global::Projeto_N1_Resmat.Properties.Resources.Tela_Hard_2;
            this.imgComplex_2.Location = new System.Drawing.Point(484, 201);
            this.imgComplex_2.Name = "imgComplex_2";
            this.imgComplex_2.Size = new System.Drawing.Size(250, 99);
            this.imgComplex_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgComplex_2.TabIndex = 22;
            this.imgComplex_2.TabStop = false;
            // 
            // imgComplex_1
            // 
            this.imgComplex_1.Image = global::Projeto_N1_Resmat.Properties.Resources.Tela_Hard_1;
            this.imgComplex_1.Location = new System.Drawing.Point(90, 201);
            this.imgComplex_1.Name = "imgComplex_1";
            this.imgComplex_1.Size = new System.Drawing.Size(250, 99);
            this.imgComplex_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgComplex_1.TabIndex = 21;
            this.imgComplex_1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(310, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 24);
            this.label2.TabIndex = 20;
            this.label2.Text = "Treliças Complexas";
            // 
            // Complexas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 531);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rbComplexas_2);
            this.Controls.Add(this.rbComplexas_1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imgComplex_2);
            this.Controls.Add(this.imgComplex_1);
            this.Controls.Add(this.label2);
            this.Name = "Complexas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Complexas";
            ((System.ComponentModel.ISupportInitialize)(this.imgComplex_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgComplex_1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rbComplexas_2;
        private System.Windows.Forms.RadioButton rbComplexas_1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox imgComplex_2;
        private System.Windows.Forms.PictureBox imgComplex_1;
        private System.Windows.Forms.Label label2;
    }
}