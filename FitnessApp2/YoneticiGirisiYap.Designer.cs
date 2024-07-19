namespace FitnessApp2
{
    partial class YoneticiGirisiYap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YoneticiGirisiYap));
            pictureBox1 = new PictureBox();
            groupBox1 = new GroupBox();
            label3 = new Label();
            label1 = new Label();
            textBox2 = new TextBox();
            rbYonetici = new RadioButton();
            rbPersonel = new RadioButton();
            label2 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(68, 107);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(404, 376);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 16;
            pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(76, 110, 192);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(rbYonetici);
            groupBox1.Controls.Add(rbPersonel);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(button1);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(556, -14);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(559, 630);
            groupBox1.TabIndex = 17;
            groupBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label3.ForeColor = Color.White;
            label3.Location = new Point(187, 79);
            label3.Name = "label3";
            label3.Size = new Size(219, 33);
            label3.TabIndex = 23;
            label3.Text = "Welcome Back !";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semilight", 10.2F, FontStyle.Italic, GraphicsUnit.Point, 162);
            label1.ForeColor = Color.White;
            label1.Location = new Point(187, 274);
            label1.Name = "label1";
            label1.Size = new Size(78, 23);
            label1.TabIndex = 22;
            label1.Text = "Password";
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.ButtonHighlight;
            textBox2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            textBox2.Location = new Point(193, 305);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(213, 34);
            textBox2.TabIndex = 21;
            // 
            // rbYonetici
            // 
            rbYonetici.AutoSize = true;
            rbYonetici.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            rbYonetici.Location = new Point(193, 363);
            rbYonetici.Name = "rbYonetici";
            rbYonetici.Size = new Size(79, 27);
            rbYonetici.TabIndex = 20;
            rbYonetici.TabStop = true;
            rbYonetici.Text = "admin";
            rbYonetici.UseVisualStyleBackColor = true;
            // 
            // rbPersonel
            // 
            rbPersonel.AutoSize = true;
            rbPersonel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            rbPersonel.Location = new Point(291, 363);
            rbPersonel.Name = "rbPersonel";
            rbPersonel.Size = new Size(105, 27);
            rbPersonel.TabIndex = 19;
            rbPersonel.TabStop = true;
            rbPersonel.Text = "employee";
            rbPersonel.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semilight", 10.2F, FontStyle.Italic, GraphicsUnit.Point, 162);
            label2.ForeColor = Color.White;
            label2.Location = new Point(187, 200);
            label2.Name = "label2";
            label2.Size = new Size(82, 23);
            label2.TabIndex = 18;
            label2.Text = "Username";
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.ButtonHighlight;
            textBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            textBox1.Location = new Point(193, 226);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(213, 34);
            textBox1.TabIndex = 17;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(122, 150, 214);
            button1.Font = new Font("Century", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button1.ForeColor = Color.White;
            button1.Location = new Point(193, 423);
            button1.Name = "button1";
            button1.Size = new Size(213, 52);
            button1.TabIndex = 16;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // YoneticiGirisiYap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1117, 613);
            Controls.Add(groupBox1);
            Controls.Add(pictureBox1);
            DoubleBuffered = true;
            Name = "YoneticiGirisiYap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GİRİŞ";
            Load += YoneticiGirisi_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pictureBox1;
        private GroupBox groupBox1;
        private Label label1;
        private TextBox textBox2;
        private RadioButton rbYonetici;
        private RadioButton rbPersonel;
        private Label label2;
        private TextBox textBox1;
        private Button button1;
        private Label label3;
    }
}