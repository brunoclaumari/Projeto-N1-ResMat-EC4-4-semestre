namespace Projeto_N1_Resmat
{
    partial class FormPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnEscolhaModelo = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(145, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(537, 91);
            this.label1.TabIndex = 0;
            this.label1.Text = "Treliça Tools";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(317, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Escolha o Nível:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Simples",
            "Médias",
            "Complexas"});
            this.comboBox1.Location = new System.Drawing.Point(300, 240);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(192, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // btnEscolhaModelo
            // 
            this.btnEscolhaModelo.Location = new System.Drawing.Point(286, 461);
            this.btnEscolhaModelo.Name = "btnEscolhaModelo";
            this.btnEscolhaModelo.Size = new System.Drawing.Size(219, 32);
            this.btnEscolhaModelo.TabIndex = 5;
            this.btnEscolhaModelo.Text = "Escolha o modelo";
            this.btnEscolhaModelo.UseVisualStyleBackColor = true;
            this.btnEscolhaModelo.Click += new System.EventHandler(this.btnEscolhaModelo_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(485, 341);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 99);
            this.label4.TabIndex = 9;
            this.label4.Text = "082170001\r\n082170034\r\n082170016\r\n082170013\r\n082170039\r\n082170021\r\n082170024";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(262, 341);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(217, 99);
            this.label3.TabIndex = 8;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 531);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnEscolhaModelo);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Treliça-Tools";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnEscolhaModelo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}

