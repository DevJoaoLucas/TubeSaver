namespace TubeSaver
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.textBoxUrlYoutube = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonProcessar = new System.Windows.Forms.Button();
            this.progressBarPrincipal = new System.Windows.Forms.ProgressBar();
            this.buttonLoadOptions = new System.Windows.Forms.Button();
            this.comboBoxOpcoesQualidade = new System.Windows.Forms.ComboBox();
            this.buttonLinkedin = new System.Windows.Forms.Button();
            this.buttonGithub = new System.Windows.Forms.Button();
            this.labelStatusUsuario = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxUrlYoutube
            // 
            this.textBoxUrlYoutube.Location = new System.Drawing.Point(12, 29);
            this.textBoxUrlYoutube.MaxLength = 100;
            this.textBoxUrlYoutube.Name = "textBoxUrlYoutube";
            this.textBoxUrlYoutube.Size = new System.Drawing.Size(260, 20);
            this.textBoxUrlYoutube.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "URL do Youtube";
            // 
            // buttonProcessar
            // 
            this.buttonProcessar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonProcessar.Location = new System.Drawing.Point(421, 25);
            this.buttonProcessar.Name = "buttonProcessar";
            this.buttonProcessar.Size = new System.Drawing.Size(83, 23);
            this.buttonProcessar.TabIndex = 2;
            this.buttonProcessar.Text = "Baixar Vídeo";
            this.buttonProcessar.UseVisualStyleBackColor = true;
            this.buttonProcessar.Click += new System.EventHandler(this.buttonProcessar_Click);
            // 
            // progressBarPrincipal
            // 
            this.progressBarPrincipal.Location = new System.Drawing.Point(12, 81);
            this.progressBarPrincipal.Name = "progressBarPrincipal";
            this.progressBarPrincipal.Size = new System.Drawing.Size(492, 23);
            this.progressBarPrincipal.TabIndex = 3;
            // 
            // buttonLoadOptions
            // 
            this.buttonLoadOptions.Location = new System.Drawing.Point(295, 52);
            this.buttonLoadOptions.Name = "buttonLoadOptions";
            this.buttonLoadOptions.Size = new System.Drawing.Size(109, 23);
            this.buttonLoadOptions.TabIndex = 4;
            this.buttonLoadOptions.Text = "Carregar Opções";
            this.buttonLoadOptions.UseVisualStyleBackColor = true;
            this.buttonLoadOptions.Click += new System.EventHandler(this.buttonLoadOptions_Click);
            // 
            // comboBoxOpcoesQualidade
            // 
            this.comboBoxOpcoesQualidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOpcoesQualidade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxOpcoesQualidade.FormattingEnabled = true;
            this.comboBoxOpcoesQualidade.Location = new System.Drawing.Point(295, 27);
            this.comboBoxOpcoesQualidade.Name = "comboBoxOpcoesQualidade";
            this.comboBoxOpcoesQualidade.Size = new System.Drawing.Size(109, 21);
            this.comboBoxOpcoesQualidade.TabIndex = 5;
            // 
            // buttonLinkedin
            // 
            this.buttonLinkedin.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonLinkedin.Location = new System.Drawing.Point(425, 110);
            this.buttonLinkedin.Name = "buttonLinkedin";
            this.buttonLinkedin.Size = new System.Drawing.Size(75, 23);
            this.buttonLinkedin.TabIndex = 6;
            this.buttonLinkedin.Text = "Linkedin";
            this.buttonLinkedin.UseVisualStyleBackColor = true;
            this.buttonLinkedin.Click += new System.EventHandler(this.buttonLinkedin_Click);
            // 
            // buttonGithub
            // 
            this.buttonGithub.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonGithub.Location = new System.Drawing.Point(344, 110);
            this.buttonGithub.Name = "buttonGithub";
            this.buttonGithub.Size = new System.Drawing.Size(75, 23);
            this.buttonGithub.TabIndex = 7;
            this.buttonGithub.Text = "Github";
            this.buttonGithub.UseVisualStyleBackColor = true;
            this.buttonGithub.Click += new System.EventHandler(this.buttonGithub_Click);
            // 
            // labelStatusUsuario
            // 
            this.labelStatusUsuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelStatusUsuario.AutoSize = true;
            this.labelStatusUsuario.Location = new System.Drawing.Point(9, 120);
            this.labelStatusUsuario.Name = "labelStatusUsuario";
            this.labelStatusUsuario.Size = new System.Drawing.Size(28, 13);
            this.labelStatusUsuario.TabIndex = 8;
            this.labelStatusUsuario.Text = "v1.0";
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 139);
            this.Controls.Add(this.labelStatusUsuario);
            this.Controls.Add(this.buttonGithub);
            this.Controls.Add(this.buttonLinkedin);
            this.Controls.Add(this.comboBoxOpcoesQualidade);
            this.Controls.Add(this.buttonLoadOptions);
            this.Controls.Add(this.progressBarPrincipal);
            this.Controls.Add(this.buttonProcessar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxUrlYoutube);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TubeSaver - Baixar Vídeo do Youtube";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxUrlYoutube;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonProcessar;
        private System.Windows.Forms.ProgressBar progressBarPrincipal;
        private System.Windows.Forms.Button buttonLoadOptions;
        public System.Windows.Forms.ComboBox comboBoxOpcoesQualidade;
        private System.Windows.Forms.Button buttonLinkedin;
        private System.Windows.Forms.Button buttonGithub;
        private System.Windows.Forms.Label labelStatusUsuario;
    }
}

