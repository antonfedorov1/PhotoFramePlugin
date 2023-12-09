namespace PhotoFramePlugin.View
{
    internal partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.OptionsPanel = new System.Windows.Forms.Panel();
            this.ParameterLimitations = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ParameterValues = new System.Windows.Forms.Panel();
            this.FrameRoundingTextBox = new System.Windows.Forms.TextBox();
            this.FrameThicknessTextBox = new System.Windows.Forms.TextBox();
            this.FrameHeightTextBox = new System.Windows.Forms.TextBox();
            this.FrameWidthTextBox = new System.Windows.Forms.TextBox();
            this.HeightInsideFrameTextBox = new System.Windows.Forms.TextBox();
            this.WidthInsideFrameTextBox = new System.Windows.Forms.TextBox();
            this.NameOfParameters = new System.Windows.Forms.Panel();
            this.EllipseFrameCheckBox = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.FrameRoundingCheckBox = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BuildFigure = new System.Windows.Forms.Button();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.ErrorsToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.OptionsPanel.SuspendLayout();
            this.ParameterLimitations.SuspendLayout();
            this.ParameterValues.SuspendLayout();
            this.NameOfParameters.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // OptionsPanel
            // 
            this.OptionsPanel.Controls.Add(this.ParameterLimitations);
            this.OptionsPanel.Controls.Add(this.ParameterValues);
            this.OptionsPanel.Controls.Add(this.NameOfParameters);
            this.OptionsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.OptionsPanel.Location = new System.Drawing.Point(0, 0);
            this.OptionsPanel.Name = "OptionsPanel";
            this.OptionsPanel.Size = new System.Drawing.Size(458, 193);
            this.OptionsPanel.TabIndex = 3;
            // 
            // ParameterLimitations
            // 
            this.ParameterLimitations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ParameterLimitations.Controls.Add(this.label12);
            this.ParameterLimitations.Controls.Add(this.label10);
            this.ParameterLimitations.Controls.Add(this.label8);
            this.ParameterLimitations.Controls.Add(this.label6);
            this.ParameterLimitations.Controls.Add(this.label4);
            this.ParameterLimitations.Controls.Add(this.label2);
            this.ParameterLimitations.Location = new System.Drawing.Point(309, 12);
            this.ParameterLimitations.Name = "ParameterLimitations";
            this.ParameterLimitations.Size = new System.Drawing.Size(137, 181);
            this.ParameterLimitations.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label12.Location = new System.Drawing.Point(3, 131);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 19);
            this.label12.TabIndex = 7;
            this.label12.Text = "1-8 мм";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label10.Location = new System.Drawing.Point(3, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 19);
            this.label10.TabIndex = 6;
            this.label10.Text = "10-30 мм";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label8.Location = new System.Drawing.Point(3, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 19);
            this.label8.TabIndex = 5;
            this.label8.Text = "110-1210 мм";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label6.Location = new System.Drawing.Point(3, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 19);
            this.label6.TabIndex = 4;
            this.label6.Text = "110-1210 мм";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label4.Location = new System.Drawing.Point(3, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "100-1200 мм";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "100-1200 мм";
            // 
            // ParameterValues
            // 
            this.ParameterValues.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.ParameterValues.Controls.Add(this.FrameRoundingTextBox);
            this.ParameterValues.Controls.Add(this.FrameThicknessTextBox);
            this.ParameterValues.Controls.Add(this.FrameHeightTextBox);
            this.ParameterValues.Controls.Add(this.FrameWidthTextBox);
            this.ParameterValues.Controls.Add(this.HeightInsideFrameTextBox);
            this.ParameterValues.Controls.Add(this.WidthInsideFrameTextBox);
            this.ParameterValues.Location = new System.Drawing.Point(214, 12);
            this.ParameterValues.Name = "ParameterValues";
            this.ParameterValues.Size = new System.Drawing.Size(89, 181);
            this.ParameterValues.TabIndex = 1;
            // 
            // FrameRoundingTextBox
            // 
            this.FrameRoundingTextBox.BackColor = System.Drawing.Color.White;
            this.FrameRoundingTextBox.Enabled = false;
            this.FrameRoundingTextBox.Location = new System.Drawing.Point(3, 132);
            this.FrameRoundingTextBox.Name = "FrameRoundingTextBox";
            this.FrameRoundingTextBox.Size = new System.Drawing.Size(83, 20);
            this.FrameRoundingTextBox.TabIndex = 7;
            this.FrameRoundingTextBox.Text = "1";
            this.FrameRoundingTextBox.TextChanged += new System.EventHandler(this.FrameRoundingTextBox_TextChanged);
            // 
            // FrameThicknessTextBox
            // 
            this.FrameThicknessTextBox.BackColor = System.Drawing.Color.White;
            this.FrameThicknessTextBox.Location = new System.Drawing.Point(3, 106);
            this.FrameThicknessTextBox.Name = "FrameThicknessTextBox";
            this.FrameThicknessTextBox.Size = new System.Drawing.Size(83, 20);
            this.FrameThicknessTextBox.TabIndex = 6;
            this.FrameThicknessTextBox.Text = "10";
            this.FrameThicknessTextBox.TextChanged += new System.EventHandler(this.FrameThicknessTextBox_TextChanged);
            this.FrameThicknessTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrameThicknessTextBox_KeyPress);
            // 
            // FrameHeightTextBox
            // 
            this.FrameHeightTextBox.BackColor = System.Drawing.Color.White;
            this.FrameHeightTextBox.Location = new System.Drawing.Point(3, 80);
            this.FrameHeightTextBox.Name = "FrameHeightTextBox";
            this.FrameHeightTextBox.Size = new System.Drawing.Size(83, 20);
            this.FrameHeightTextBox.TabIndex = 5;
            this.FrameHeightTextBox.Text = "110";
            this.FrameHeightTextBox.TextChanged += new System.EventHandler(this.FrameHeightTextBox_TextChanged);
            this.FrameHeightTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrameHeightTextBox_KeyPress);
            // 
            // FrameWidthTextBox
            // 
            this.FrameWidthTextBox.BackColor = System.Drawing.Color.White;
            this.FrameWidthTextBox.Location = new System.Drawing.Point(3, 54);
            this.FrameWidthTextBox.Name = "FrameWidthTextBox";
            this.FrameWidthTextBox.Size = new System.Drawing.Size(83, 20);
            this.FrameWidthTextBox.TabIndex = 4;
            this.FrameWidthTextBox.Text = "110";
            this.FrameWidthTextBox.TextChanged += new System.EventHandler(this.FrameWidthTextBox_TextChanged);
            this.FrameWidthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrameWidthTextBox_KeyPress);
            // 
            // HeightInsideFrameTextBox
            // 
            this.HeightInsideFrameTextBox.BackColor = System.Drawing.Color.White;
            this.HeightInsideFrameTextBox.Location = new System.Drawing.Point(3, 29);
            this.HeightInsideFrameTextBox.Name = "HeightInsideFrameTextBox";
            this.HeightInsideFrameTextBox.Size = new System.Drawing.Size(83, 20);
            this.HeightInsideFrameTextBox.TabIndex = 3;
            this.HeightInsideFrameTextBox.Text = "100";
            this.HeightInsideFrameTextBox.TextChanged += new System.EventHandler(this.HeightInsideFrameTextBox_TextChanged);
            this.HeightInsideFrameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HeightInsideFrameTextBox_KeyPress);
            // 
            // WidthInsideFrameTextBox
            // 
            this.WidthInsideFrameTextBox.BackColor = System.Drawing.Color.White;
            this.WidthInsideFrameTextBox.Location = new System.Drawing.Point(3, 3);
            this.WidthInsideFrameTextBox.Name = "WidthInsideFrameTextBox";
            this.WidthInsideFrameTextBox.Size = new System.Drawing.Size(83, 20);
            this.WidthInsideFrameTextBox.TabIndex = 2;
            this.WidthInsideFrameTextBox.Text = "100";
            this.WidthInsideFrameTextBox.TextChanged += new System.EventHandler(this.WidthInsideFrameTextBox_TextChanged);
            this.WidthInsideFrameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.WidthInsideFrameTextBox_KeyPress);
            // 
            // NameOfParameters
            // 
            this.NameOfParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.NameOfParameters.Controls.Add(this.EllipseFrameCheckBox);
            this.NameOfParameters.Controls.Add(this.label13);
            this.NameOfParameters.Controls.Add(this.FrameRoundingCheckBox);
            this.NameOfParameters.Controls.Add(this.label11);
            this.NameOfParameters.Controls.Add(this.label9);
            this.NameOfParameters.Controls.Add(this.label7);
            this.NameOfParameters.Controls.Add(this.label5);
            this.NameOfParameters.Controls.Add(this.label3);
            this.NameOfParameters.Controls.Add(this.label1);
            this.NameOfParameters.Location = new System.Drawing.Point(12, 12);
            this.NameOfParameters.Name = "NameOfParameters";
            this.NameOfParameters.Size = new System.Drawing.Size(196, 181);
            this.NameOfParameters.TabIndex = 0;
            // 
            // EllipseFrameCheckBox
            // 
            this.EllipseFrameCheckBox.AutoSize = true;
            this.EllipseFrameCheckBox.Location = new System.Drawing.Point(175, 159);
            this.EllipseFrameCheckBox.Name = "EllipseFrameCheckBox";
            this.EllipseFrameCheckBox.Size = new System.Drawing.Size(15, 14);
            this.EllipseFrameCheckBox.TabIndex = 9;
            this.EllipseFrameCheckBox.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(3, 155);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(156, 19);
            this.label13.TabIndex = 8;
            this.label13.Text = "Рамка в виде эллипса";
            // 
            // FrameRoundingCheckBox
            // 
            this.FrameRoundingCheckBox.AutoSize = true;
            this.FrameRoundingCheckBox.Location = new System.Drawing.Point(175, 135);
            this.FrameRoundingCheckBox.Name = "FrameRoundingCheckBox";
            this.FrameRoundingCheckBox.Size = new System.Drawing.Size(15, 14);
            this.FrameRoundingCheckBox.TabIndex = 7;
            this.FrameRoundingCheckBox.UseVisualStyleBackColor = true;
            this.FrameRoundingCheckBox.CheckedChanged += new System.EventHandler(this.FrameRoundingCheckBox_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(3, 131);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(132, 19);
            this.label11.TabIndex = 6;
            this.label11.Text = "Скругление рамки";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(3, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 19);
            this.label9.TabIndex = 5;
            this.label9.Text = "Толщина рамки";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(3, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(168, 19);
            this.label7.TabIndex = 4;
            this.label7.Text = "Высота внешней рамки";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(3, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 19);
            this.label5.TabIndex = 3;
            this.label5.Text = "Ширина внешней рамки";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Высота внутри рамки";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ширина внутри рамки";
            // 
            // BuildFigure
            // 
            this.BuildFigure.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BuildFigure.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BuildFigure.Location = new System.Drawing.Point(187, 199);
            this.BuildFigure.Name = "BuildFigure";
            this.BuildFigure.Size = new System.Drawing.Size(113, 30);
            this.BuildFigure.TabIndex = 0;
            this.BuildFigure.Text = "Построить";
            this.BuildFigure.UseVisualStyleBackColor = true;
            this.BuildFigure.Click += new System.EventHandler(this.BuildFigureClick);
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.BuildFigure);
            this.MainPanel.Controls.Add(this.OptionsPanel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(458, 241);
            this.MainPanel.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(458, 241);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(474, 280);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(474, 280);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Photo Frame Plagin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.OptionsPanel.ResumeLayout(false);
            this.ParameterLimitations.ResumeLayout(false);
            this.ParameterLimitations.PerformLayout();
            this.ParameterValues.ResumeLayout(false);
            this.ParameterValues.PerformLayout();
            this.NameOfParameters.ResumeLayout(false);
            this.NameOfParameters.PerformLayout();
            this.MainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel OptionsPanel;
        private System.Windows.Forms.Panel ParameterLimitations;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel ParameterValues;
        private System.Windows.Forms.TextBox FrameThicknessTextBox;
        private System.Windows.Forms.TextBox FrameHeightTextBox;
        private System.Windows.Forms.TextBox FrameWidthTextBox;
        private System.Windows.Forms.TextBox HeightInsideFrameTextBox;
        private System.Windows.Forms.TextBox WidthInsideFrameTextBox;
        private System.Windows.Forms.Panel NameOfParameters;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BuildFigure;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.ToolTip ErrorsToolTip;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox FrameRoundingTextBox;
        private System.Windows.Forms.CheckBox EllipseFrameCheckBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox FrameRoundingCheckBox;
        private System.Windows.Forms.Label label11;
    }
}

