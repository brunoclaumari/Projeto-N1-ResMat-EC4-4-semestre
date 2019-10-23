namespace Projeto_N1_Resmat
{
    partial class Simples
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rbSimples_1 = new System.Windows.Forms.RadioButton();
            this.rbSimples_2 = new System.Windows.Forms.RadioButton();
            this.bt_Comecar_Simples = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(312, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Treliças Simples";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(250, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Essa treliça tem 4 Nós com 5 barras";
            // 
            // rbSimples_1
            // 
            this.rbSimples_1.AutoSize = true;
            this.rbSimples_1.Cursor = System.Windows.Forms.Cursors.Default;
            this.rbSimples_1.Location = new System.Drawing.Point(90, 178);
            this.rbSimples_1.Name = "rbSimples_1";
            this.rbSimples_1.Size = new System.Drawing.Size(14, 13);
            this.rbSimples_1.TabIndex = 7;
            this.rbSimples_1.TabStop = true;
            this.rbSimples_1.UseVisualStyleBackColor = true;
            this.rbSimples_1.CheckedChanged += new System.EventHandler(this.rbSimples_1_CheckedChanged);
            // 
            // rbSimples_2
            // 
            this.rbSimples_2.AutoSize = true;
            this.rbSimples_2.Cursor = System.Windows.Forms.Cursors.Default;
            this.rbSimples_2.Location = new System.Drawing.Point(475, 178);
            this.rbSimples_2.Name = "rbSimples_2";
            this.rbSimples_2.Size = new System.Drawing.Size(14, 13);
            this.rbSimples_2.TabIndex = 8;
            this.rbSimples_2.TabStop = true;
            this.rbSimples_2.UseVisualStyleBackColor = true;
            this.rbSimples_2.CheckedChanged += new System.EventHandler(this.rbSimples_2_CheckedChanged);
            // 
            // bt_Comecar_Simples
            // 
            this.bt_Comecar_Simples.Cursor = System.Windows.Forms.Cursors.Default;
            this.bt_Comecar_Simples.Location = new System.Drawing.Point(301, 445);
            this.bt_Comecar_Simples.Name = "bt_Comecar_Simples";
            this.bt_Comecar_Simples.Size = new System.Drawing.Size(219, 32);
            this.bt_Comecar_Simples.TabIndex = 19;
            this.bt_Comecar_Simples.Text = "Começar";
            this.bt_Comecar_Simples.UseVisualStyleBackColor = true;
            this.bt_Comecar_Simples.Click += new System.EventHandler(this.bt_Comecar_Simples_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox2.Image = global::Projeto_N1_Resmat.Properties.Resources.Menu_Simples_2;
            this.pictureBox2.Location = new System.Drawing.Point(475, 201);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(285, 136);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Image = global::Projeto_N1_Resmat.Properties.Resources.Menu_Simples_1;
            this.pictureBox1.Location = new System.Drawing.Point(90, 201);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(285, 136);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Simples
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 531);
            this.Controls.Add(this.bt_Comecar_Simples);
            this.Controls.Add(this.rbSimples_2);
            this.Controls.Add(this.rbSimples_1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Name = "Simples";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Simples";
            this.Load += new System.EventHandler(this.Simples_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbSimples_1;
        private System.Windows.Forms.RadioButton rbSimples_2;
        private System.Windows.Forms.Button bt_Comecar_Simples;
    }
}