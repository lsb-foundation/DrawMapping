
namespace DrawMapping
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.fillTextBox = new System.Windows.Forms.TextBox();
            this.genButton = new System.Windows.Forms.Button();
            this.yTextBox = new System.Windows.Forms.TextBox();
            this.xTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.fillButton = new System.Windows.Forms.Button();
            this.cmbDirection = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mapping = new DrawMapping.Mapping();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.fillButton);
            this.panel1.Controls.Add(this.cmbDirection);
            this.panel1.Controls.Add(this.fillTextBox);
            this.panel1.Controls.Add(this.genButton);
            this.panel1.Controls.Add(this.yTextBox);
            this.panel1.Controls.Add(this.xTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1217, 101);
            this.panel1.TabIndex = 0;
            // 
            // fillTextBox
            // 
            this.fillTextBox.Location = new System.Drawing.Point(531, 13);
            this.fillTextBox.Multiline = true;
            this.fillTextBox.Name = "fillTextBox";
            this.fillTextBox.Size = new System.Drawing.Size(252, 71);
            this.fillTextBox.TabIndex = 5;
            // 
            // genButton
            // 
            this.genButton.ForeColor = System.Drawing.Color.Black;
            this.genButton.Location = new System.Drawing.Point(374, 13);
            this.genButton.Name = "genButton";
            this.genButton.Size = new System.Drawing.Size(136, 73);
            this.genButton.TabIndex = 4;
            this.genButton.Text = "Generate";
            this.genButton.UseVisualStyleBackColor = true;
            this.genButton.Click += new System.EventHandler(this.genButton_Click);
            // 
            // yTextBox
            // 
            this.yTextBox.Location = new System.Drawing.Point(62, 52);
            this.yTextBox.Name = "yTextBox";
            this.yTextBox.Size = new System.Drawing.Size(100, 31);
            this.yTextBox.TabIndex = 3;
            // 
            // xTextBox
            // 
            this.xTextBox.Location = new System.Drawing.Point(62, 10);
            this.xTextBox.Name = "xTextBox";
            this.xTextBox.Size = new System.Drawing.Size(100, 31);
            this.xTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Y:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "X:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.mapping);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 101);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1217, 782);
            this.panel2.TabIndex = 1;
            // 
            // fillButton
            // 
            this.fillButton.ForeColor = System.Drawing.Color.Black;
            this.fillButton.Location = new System.Drawing.Point(802, 10);
            this.fillButton.Name = "fillButton";
            this.fillButton.Size = new System.Drawing.Size(136, 71);
            this.fillButton.TabIndex = 5;
            this.fillButton.Text = "Fill";
            this.fillButton.UseVisualStyleBackColor = true;
            this.fillButton.Click += new System.EventHandler(this.fillButton_Click);
            // 
            // cmbDirection
            // 
            this.cmbDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDirection.FormattingEnabled = true;
            this.cmbDirection.Items.AddRange(new object[] {
            "Left Bottom",
            "Right Bottom",
            "Left Top",
            "Right Top"});
            this.cmbDirection.Location = new System.Drawing.Point(185, 53);
            this.cmbDirection.Name = "cmbDirection";
            this.cmbDirection.Size = new System.Drawing.Size(167, 29);
            this.cmbDirection.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(186, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 21);
            this.label3.TabIndex = 7;
            this.label3.Text = "Direction:";
            // 
            // mapping
            // 
            this.mapping.AutoSize = true;
            this.mapping.BorderWidth = 3F;
            this.mapping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapping.FilledColor = System.Drawing.Color.DarkGreen;
            this.mapping.FocusedColor = System.Drawing.Color.YellowGreen;
            this.mapping.HorizontalSpace = 10;
            this.mapping.InitializedColor = System.Drawing.Color.DeepSkyBlue;
            this.mapping.Location = new System.Drawing.Point(0, 0);
            this.mapping.Name = "mapping";
            this.mapping.Size = new System.Drawing.Size(1217, 782);
            this.mapping.StartDirection = DrawMapping.StartDirection.LeftBottom;
            this.mapping.TabIndex = 0;
            this.mapping.VerticalSpace = 20;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 883);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button genButton;
        private System.Windows.Forms.TextBox yTextBox;
        private System.Windows.Forms.TextBox xTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private Mapping mapping;
        private System.Windows.Forms.Button fillButton;
        private System.Windows.Forms.TextBox fillTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbDirection;
    }
}

