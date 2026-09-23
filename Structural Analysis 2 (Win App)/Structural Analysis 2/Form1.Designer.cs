namespace Structural_Analysis_2
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
            this.btnCalculate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtEI = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtFi = new System.Windows.Forms.TextBox();
            this.txtEta = new System.Windows.Forms.TextBox();
            this.txtkapa = new System.Windows.Forms.TextBox();
            this.txtSy = new System.Windows.Forms.TextBox();
            this.txtAlpha = new System.Windows.Forms.TextBox();
            this.txtx = new System.Windows.Forms.TextBox();
            this.txtBeta = new System.Windows.Forms.TextBox();
            this.txtL = new System.Windows.Forms.TextBox();
            this.txtM = new System.Windows.Forms.TextBox();
            this.txtq2 = new System.Windows.Forms.TextBox();
            this.txtq1 = new System.Windows.Forms.TextBox();
            this.txtP = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFEM_AC = new System.Windows.Forms.Label();
            this.lblFEM_CA = new System.Windows.Forms.Label();
            this.labal = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDel = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCalculate
            // 
            this.btnCalculate.BackColor = System.Drawing.Color.White;
            this.btnCalculate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCalculate.Font = new System.Drawing.Font("B Nazanin", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnCalculate.ForeColor = System.Drawing.Color.Green;
            this.btnCalculate.Location = new System.Drawing.Point(672, 420);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(161, 70);
            this.btnCalculate.TabIndex = 1;
            this.btnCalculate.Text = "محاسبه";
            this.btnCalculate.UseVisualStyleBackColor = false;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            this.btnCalculate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnCalculate_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(195, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "(β) ضریب سختی ";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(163, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "(P) مقدار نیروی متمرکز";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(154, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 24);
            this.label4.TabIndex = 2;
            this.label4.Text = "(q1) مقدار نیروی گسترده";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(152, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 24);
            this.label5.TabIndex = 3;
            this.label5.Text = "(q2) مقدار نیروی گسترده";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(208, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 24);
            this.label6.TabIndex = 4;
            this.label6.Text = "(M) مقدار لنگر";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(231, 327);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 24);
            this.label10.TabIndex = 8;
            this.label10.Text = "(α) ضریب ";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(234, 370);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 24);
            this.label11.TabIndex = 9;
            this.label11.Text = "(ψ) ضریب";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(193, 287);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(105, 24);
            this.label12.TabIndex = 7;
            this.label12.Text = "(X) ضریب سختی ";
            // 
            // txtEI
            // 
            this.txtEI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEI.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtEI.Location = new System.Drawing.Point(9, 8);
            this.txtEI.MaxLength = 30;
            this.txtEI.Name = "txtEI";
            this.txtEI.Size = new System.Drawing.Size(176, 26);
            this.txtEI.TabIndex = 13;
            this.txtEI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEI.Enter += new System.EventHandler(this.txtP_Enter);
            this.txtEI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtP_KeyPress);
            this.txtEI.Leave += new System.EventHandler(this.txtP_Leave);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(191, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 24);
            this.label8.TabIndex = 0;
            this.label8.Text = "(EI) مقدار سختی ";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(233, 408);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 24);
            this.label13.TabIndex = 10;
            this.label13.Text = "(K) ضریب";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(234, 447);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 24);
            this.label14.TabIndex = 11;
            this.label14.Text = "(n) ضریب";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(221, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "(L) طول تیر ";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(234, 487);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 24);
            this.label7.TabIndex = 12;
            this.label7.Text = "(φ) ضریب";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Structural_Analysis_2.Properties.Resources.Capture2;
            this.pictureBox2.Location = new System.Drawing.Point(250, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(598, 69);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 33;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Structural_Analysis_2.Properties.Resources.Capture1;
            this.pictureBox1.Location = new System.Drawing.Point(250, 87);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(598, 298);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // txtFi
            // 
            this.txtFi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFi.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtFi.Location = new System.Drawing.Point(9, 484);
            this.txtFi.MaxLength = 30;
            this.txtFi.Name = "txtFi";
            this.txtFi.Size = new System.Drawing.Size(219, 26);
            this.txtFi.TabIndex = 25;
            this.txtFi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFi.Enter += new System.EventHandler(this.txtP_Enter);
            this.txtFi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtP_KeyPress);
            this.txtFi.Leave += new System.EventHandler(this.txtP_Leave);
            // 
            // txtEta
            // 
            this.txtEta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEta.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtEta.Location = new System.Drawing.Point(9, 444);
            this.txtEta.MaxLength = 30;
            this.txtEta.Name = "txtEta";
            this.txtEta.Size = new System.Drawing.Size(219, 26);
            this.txtEta.TabIndex = 24;
            this.txtEta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEta.Enter += new System.EventHandler(this.txtP_Enter);
            this.txtEta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtP_KeyPress);
            this.txtEta.Leave += new System.EventHandler(this.txtP_Leave);
            // 
            // txtkapa
            // 
            this.txtkapa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtkapa.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtkapa.Location = new System.Drawing.Point(9, 405);
            this.txtkapa.MaxLength = 30;
            this.txtkapa.Name = "txtkapa";
            this.txtkapa.Size = new System.Drawing.Size(218, 26);
            this.txtkapa.TabIndex = 23;
            this.txtkapa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtkapa.Enter += new System.EventHandler(this.txtP_Enter);
            this.txtkapa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtP_KeyPress);
            this.txtkapa.Leave += new System.EventHandler(this.txtP_Leave);
            // 
            // txtSy
            // 
            this.txtSy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSy.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtSy.Location = new System.Drawing.Point(9, 367);
            this.txtSy.MaxLength = 30;
            this.txtSy.Name = "txtSy";
            this.txtSy.Size = new System.Drawing.Size(219, 26);
            this.txtSy.TabIndex = 22;
            this.txtSy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSy.Enter += new System.EventHandler(this.txtP_Enter);
            this.txtSy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtP_KeyPress);
            this.txtSy.Leave += new System.EventHandler(this.txtP_Leave);
            // 
            // txtAlpha
            // 
            this.txtAlpha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAlpha.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtAlpha.Location = new System.Drawing.Point(9, 324);
            this.txtAlpha.MaxLength = 30;
            this.txtAlpha.Name = "txtAlpha";
            this.txtAlpha.Size = new System.Drawing.Size(216, 26);
            this.txtAlpha.TabIndex = 21;
            this.txtAlpha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAlpha.Enter += new System.EventHandler(this.txtP_Enter);
            this.txtAlpha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtP_KeyPress);
            this.txtAlpha.Leave += new System.EventHandler(this.txtP_Leave);
            // 
            // txtx
            // 
            this.txtx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtx.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtx.Location = new System.Drawing.Point(9, 284);
            this.txtx.MaxLength = 30;
            this.txtx.Name = "txtx";
            this.txtx.Size = new System.Drawing.Size(178, 26);
            this.txtx.TabIndex = 20;
            this.txtx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtx.Enter += new System.EventHandler(this.txtP_Enter);
            this.txtx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtP_KeyPress);
            this.txtx.Leave += new System.EventHandler(this.txtP_Leave);
            // 
            // txtBeta
            // 
            this.txtBeta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBeta.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtBeta.Location = new System.Drawing.Point(9, 245);
            this.txtBeta.MaxLength = 30;
            this.txtBeta.Name = "txtBeta";
            this.txtBeta.Size = new System.Drawing.Size(180, 26);
            this.txtBeta.TabIndex = 19;
            this.txtBeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBeta.Enter += new System.EventHandler(this.txtP_Enter);
            this.txtBeta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtP_KeyPress);
            this.txtBeta.Leave += new System.EventHandler(this.txtP_Leave);
            // 
            // txtL
            // 
            this.txtL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtL.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtL.Location = new System.Drawing.Point(9, 206);
            this.txtL.MaxLength = 30;
            this.txtL.Name = "txtL";
            this.txtL.Size = new System.Drawing.Size(206, 26);
            this.txtL.TabIndex = 18;
            this.txtL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtL.Enter += new System.EventHandler(this.txtP_Enter);
            this.txtL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtP_KeyPress);
            this.txtL.Leave += new System.EventHandler(this.txtP_Leave);
            // 
            // txtM
            // 
            this.txtM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtM.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtM.Location = new System.Drawing.Point(9, 166);
            this.txtM.MaxLength = 30;
            this.txtM.Name = "txtM";
            this.txtM.Size = new System.Drawing.Size(193, 26);
            this.txtM.TabIndex = 17;
            this.txtM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtM.Enter += new System.EventHandler(this.txtP_Enter);
            this.txtM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtP_KeyPress);
            this.txtM.Leave += new System.EventHandler(this.txtP_Leave);
            // 
            // txtq2
            // 
            this.txtq2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtq2.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtq2.Location = new System.Drawing.Point(9, 123);
            this.txtq2.MaxLength = 30;
            this.txtq2.Name = "txtq2";
            this.txtq2.Size = new System.Drawing.Size(137, 26);
            this.txtq2.TabIndex = 16;
            this.txtq2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtq2.Enter += new System.EventHandler(this.txtP_Enter);
            this.txtq2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtP_KeyPress);
            this.txtq2.Leave += new System.EventHandler(this.txtP_Leave);
            // 
            // txtq1
            // 
            this.txtq1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtq1.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtq1.Location = new System.Drawing.Point(9, 83);
            this.txtq1.MaxLength = 30;
            this.txtq1.Name = "txtq1";
            this.txtq1.Size = new System.Drawing.Size(139, 26);
            this.txtq1.TabIndex = 15;
            this.txtq1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtq1.Enter += new System.EventHandler(this.txtP_Enter);
            this.txtq1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtP_KeyPress);
            this.txtq1.Leave += new System.EventHandler(this.txtP_Leave);
            // 
            // txtP
            // 
            this.txtP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtP.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtP.Location = new System.Drawing.Point(9, 43);
            this.txtP.MaxLength = 30;
            this.txtP.Name = "txtP";
            this.txtP.Size = new System.Drawing.Size(148, 26);
            this.txtP.TabIndex = 14;
            this.txtP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtP.Enter += new System.EventHandler(this.txtP_Enter);
            this.txtP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtP_KeyPress);
            this.txtP.Leave += new System.EventHandler(this.txtP_Leave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkKhaki;
            this.panel1.Controls.Add(this.lblFEM_AC);
            this.panel1.Controls.Add(this.lblFEM_CA);
            this.panel1.Controls.Add(this.labal);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Location = new System.Drawing.Point(12, 391);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(475, 126);
            this.panel1.TabIndex = 3;
            // 
            // lblFEM_AC
            // 
            this.lblFEM_AC.AutoSize = true;
            this.lblFEM_AC.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFEM_AC.Location = new System.Drawing.Point(112, 16);
            this.lblFEM_AC.Name = "lblFEM_AC";
            this.lblFEM_AC.Size = new System.Drawing.Size(0, 30);
            this.lblFEM_AC.TabIndex = 2;
            // 
            // lblFEM_CA
            // 
            this.lblFEM_CA.AutoSize = true;
            this.lblFEM_CA.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFEM_CA.Location = new System.Drawing.Point(112, 91);
            this.lblFEM_CA.Name = "lblFEM_CA";
            this.lblFEM_CA.Size = new System.Drawing.Size(0, 30);
            this.lblFEM_CA.TabIndex = 3;
            // 
            // labal
            // 
            this.labal.AutoSize = true;
            this.labal.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labal.Location = new System.Drawing.Point(1, 16);
            this.labal.Name = "labal";
            this.labal.Size = new System.Drawing.Size(105, 30);
            this.labal.TabIndex = 0;
            this.labal.Text = "FEM (AC)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label9.Location = new System.Drawing.Point(1, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 30);
            this.label9.TabIndex = 1;
            this.label9.Text = "FEM (CA)";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkKhaki;
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtP);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtq1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtq2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtM);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtL);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtBeta);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtx);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.txtAlpha);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.txtSy);
            this.panel2.Controls.Add(this.txtEI);
            this.panel2.Controls.Add(this.txtkapa);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.txtEta);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.txtFi);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(854, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(301, 522);
            this.panel2.TabIndex = 0;
            // 
            // btnDel
            // 
            this.btnDel.BackColor = System.Drawing.Color.White;
            this.btnDel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDel.Font = new System.Drawing.Font("B Nazanin", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnDel.ForeColor = System.Drawing.Color.Red;
            this.btnDel.Location = new System.Drawing.Point(505, 420);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(161, 70);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "پاک کردن";
            this.btnDel.UseVisualStyleBackColor = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.label18);
            this.panel3.Controls.Add(this.label19);
            this.panel3.Location = new System.Drawing.Point(8, 8);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(236, 377);
            this.panel3.TabIndex = 34;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label15.Location = new System.Drawing.Point(3, 212);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(228, 113);
            this.label15.TabIndex = 6;
            this.label15.Text = "  q2 > q1)  - 5 \r\n(α * L) > ((K * L) + (φ * L))";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label15.UseCompatibleTextRendering = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label16.Location = new System.Drawing.Point(71, 171);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(93, 30);
            this.label16.TabIndex = 5;
            this.label16.Text = "n < α  - 4 ";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label17.Location = new System.Drawing.Point(70, 129);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(94, 30);
            this.label17.TabIndex = 4;
            this.label17.Text = "n > α  - 3 ";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label18.Location = new System.Drawing.Point(70, 87);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(95, 30);
            this.label18.TabIndex = 3;
            this.label18.Text = "ψ < α  - 2 ";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label19.Location = new System.Drawing.Point(71, 45);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(93, 30);
            this.label19.TabIndex = 2;
            this.label19.Text = "ψ > α  - 1 ";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 529);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Structural Analysis 2";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtEI;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtFi;
        private System.Windows.Forms.TextBox txtEta;
        private System.Windows.Forms.TextBox txtkapa;
        private System.Windows.Forms.TextBox txtSy;
        private System.Windows.Forms.TextBox txtAlpha;
        private System.Windows.Forms.TextBox txtx;
        private System.Windows.Forms.TextBox txtBeta;
        private System.Windows.Forms.TextBox txtL;
        private System.Windows.Forms.TextBox txtM;
        private System.Windows.Forms.TextBox txtq2;
        private System.Windows.Forms.TextBox txtq1;
        private System.Windows.Forms.TextBox txtP;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblFEM_AC;
        private System.Windows.Forms.Label lblFEM_CA;
        private System.Windows.Forms.Label labal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
    }
}

