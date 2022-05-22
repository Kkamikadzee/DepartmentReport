namespace RepostWinForms
{
    partial class ReportWinForm
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
            this.department = new System.Windows.Forms.ComboBox();
            this.practicePage = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.practiceTemplateFile = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.practiceBase = new System.Windows.Forms.TextBox();
            this.practiceHeadmaster = new System.Windows.Forms.ComboBox();
            this.practiceType = new System.Windows.Forms.ComboBox();
            this.practiceKind = new System.Windows.Forms.ComboBox();
            this.practiceEndDate = new System.Windows.Forms.DateTimePicker();
            this.practiceStartDate = new System.Windows.Forms.DateTimePicker();
            this.practiceGroup = new System.Windows.Forms.ComboBox();
            this.fqwPage = new System.Windows.Forms.TabPage();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.label9 = new System.Windows.Forms.Label();
            this.fqwTemplateFile = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.fqlGroup = new System.Windows.Forms.ComboBox();
            this.fqwGenerateButton = new System.Windows.Forms.Button();
            this.practiceGenerateButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.practicePage.SuspendLayout();
            this.fqwPage.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // department
            // 
            this.department.FormattingEnabled = true;
            this.department.Location = new System.Drawing.Point(12, 12);
            this.department.Name = "department";
            this.department.Size = new System.Drawing.Size(121, 21);
            this.department.TabIndex = 0;
            this.department.Text = "Кафедра";
            // 
            // practicePage
            // 
            this.practicePage.Controls.Add(this.practiceGenerateButton);
            this.practicePage.Controls.Add(this.label8);
            this.practicePage.Controls.Add(this.practiceTemplateFile);
            this.practicePage.Controls.Add(this.label7);
            this.practicePage.Controls.Add(this.label6);
            this.practicePage.Controls.Add(this.label5);
            this.practicePage.Controls.Add(this.label4);
            this.practicePage.Controls.Add(this.label3);
            this.practicePage.Controls.Add(this.label2);
            this.practicePage.Controls.Add(this.label1);
            this.practicePage.Controls.Add(this.practiceBase);
            this.practicePage.Controls.Add(this.practiceHeadmaster);
            this.practicePage.Controls.Add(this.practiceType);
            this.practicePage.Controls.Add(this.practiceKind);
            this.practicePage.Controls.Add(this.practiceEndDate);
            this.practicePage.Controls.Add(this.practiceStartDate);
            this.practicePage.Controls.Add(this.practiceGroup);
            this.practicePage.Location = new System.Drawing.Point(4, 22);
            this.practicePage.Name = "practicePage";
            this.practicePage.Padding = new System.Windows.Forms.Padding(3);
            this.practicePage.Size = new System.Drawing.Size(297, 249);
            this.practicePage.TabIndex = 1;
            this.practicePage.Text = "Practice";
            this.practicePage.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Файл шаблона";
            // 
            // practiceTemplateFile
            // 
            this.practiceTemplateFile.FormattingEnabled = true;
            this.practiceTemplateFile.Location = new System.Drawing.Point(89, 6);
            this.practiceTemplateFile.Name = "practiceTemplateFile";
            this.practiceTemplateFile.Size = new System.Drawing.Size(200, 21);
            this.practiceTemplateFile.TabIndex = 15;
            this.practiceTemplateFile.Text = "Файл шаблона";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "База";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Руководитель";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Тип";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Вид";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Дата конца";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Дата начала";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Группа";
            // 
            // practiceBase
            // 
            this.practiceBase.Location = new System.Drawing.Point(43, 192);
            this.practiceBase.Name = "practiceBase";
            this.practiceBase.Size = new System.Drawing.Size(246, 20);
            this.practiceBase.TabIndex = 7;
            this.practiceBase.Text = "База практики";
            // 
            // practiceHeadmaster
            // 
            this.practiceHeadmaster.FormattingEnabled = true;
            this.practiceHeadmaster.Location = new System.Drawing.Point(89, 165);
            this.practiceHeadmaster.Name = "practiceHeadmaster";
            this.practiceHeadmaster.Size = new System.Drawing.Size(200, 21);
            this.practiceHeadmaster.TabIndex = 6;
            this.practiceHeadmaster.Text = "Руководитель практики";
            // 
            // practiceType
            // 
            this.practiceType.FormattingEnabled = true;
            this.practiceType.Location = new System.Drawing.Point(37, 138);
            this.practiceType.Name = "practiceType";
            this.practiceType.Size = new System.Drawing.Size(252, 21);
            this.practiceType.TabIndex = 5;
            this.practiceType.Text = "Тип практики";
            // 
            // practiceKind
            // 
            this.practiceKind.FormattingEnabled = true;
            this.practiceKind.Location = new System.Drawing.Point(37, 111);
            this.practiceKind.Name = "practiceKind";
            this.practiceKind.Size = new System.Drawing.Size(252, 21);
            this.practiceKind.TabIndex = 4;
            this.practiceKind.Tag = "";
            this.practiceKind.Text = "Вид практики";
            // 
            // practiceEndDate
            // 
            this.practiceEndDate.Location = new System.Drawing.Point(77, 85);
            this.practiceEndDate.Name = "practiceEndDate";
            this.practiceEndDate.Size = new System.Drawing.Size(212, 20);
            this.practiceEndDate.TabIndex = 3;
            // 
            // practiceStartDate
            // 
            this.practiceStartDate.Location = new System.Drawing.Point(82, 60);
            this.practiceStartDate.Name = "practiceStartDate";
            this.practiceStartDate.Size = new System.Drawing.Size(207, 20);
            this.practiceStartDate.TabIndex = 2;
            // 
            // practiceGroup
            // 
            this.practiceGroup.FormattingEnabled = true;
            this.practiceGroup.Location = new System.Drawing.Point(53, 33);
            this.practiceGroup.Name = "practiceGroup";
            this.practiceGroup.Size = new System.Drawing.Size(236, 21);
            this.practiceGroup.TabIndex = 1;
            this.practiceGroup.Text = "Группа";
            // 
            // fqwPage
            // 
            this.fqwPage.Controls.Add(this.fqwGenerateButton);
            this.fqwPage.Controls.Add(this.label9);
            this.fqwPage.Controls.Add(this.fqwTemplateFile);
            this.fqwPage.Controls.Add(this.label10);
            this.fqwPage.Controls.Add(this.fqlGroup);
            this.fqwPage.Location = new System.Drawing.Point(4, 22);
            this.fqwPage.Name = "fqwPage";
            this.fqwPage.Padding = new System.Windows.Forms.Padding(3);
            this.fqwPage.Size = new System.Drawing.Size(309, 249);
            this.fqwPage.TabIndex = 0;
            this.fqwPage.Text = "Fqw";
            this.fqwPage.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.fqwPage);
            this.tabControl.Controls.Add(this.practicePage);
            this.tabControl.Location = new System.Drawing.Point(12, 39);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(305, 275);
            this.tabControl.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Файл шаблона";
            // 
            // fqwTemplateFile
            // 
            this.fqwTemplateFile.FormattingEnabled = true;
            this.fqwTemplateFile.Location = new System.Drawing.Point(92, 6);
            this.fqwTemplateFile.Name = "fqwTemplateFile";
            this.fqwTemplateFile.Size = new System.Drawing.Size(200, 21);
            this.fqwTemplateFile.TabIndex = 19;
            this.fqwTemplateFile.Text = "Файл шаблона";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Группа";
            // 
            // fqlGroup
            // 
            this.fqlGroup.FormattingEnabled = true;
            this.fqlGroup.Location = new System.Drawing.Point(56, 33);
            this.fqlGroup.Name = "fqlGroup";
            this.fqlGroup.Size = new System.Drawing.Size(236, 21);
            this.fqlGroup.TabIndex = 17;
            this.fqlGroup.Text = "Группа";
            // 
            // fqwGenerateButton
            // 
            this.fqwGenerateButton.Location = new System.Drawing.Point(11, 220);
            this.fqwGenerateButton.Name = "fqwGenerateButton";
            this.fqwGenerateButton.Size = new System.Drawing.Size(151, 23);
            this.fqwGenerateButton.TabIndex = 21;
            this.fqwGenerateButton.Text = "Генерировать";
            this.fqwGenerateButton.UseVisualStyleBackColor = true;
            // 
            // practiceGenerateButton
            // 
            this.practiceGenerateButton.Location = new System.Drawing.Point(8, 218);
            this.practiceGenerateButton.Name = "practiceGenerateButton";
            this.practiceGenerateButton.Size = new System.Drawing.Size(151, 23);
            this.practiceGenerateButton.TabIndex = 22;
            this.practiceGenerateButton.Text = "Генерировать";
            this.practiceGenerateButton.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 315);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(320, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(188, 17);
            this.toolStripStatusLabel1.Text = "Строка со статусом приложения";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 337);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.department);
            this.Controls.Add(this.tabControl);
            this.Name = "Form1";
            this.Text = "Генератор отчётов кафедры";
            this.practicePage.ResumeLayout(false);
            this.practicePage.PerformLayout();
            this.fqwPage.ResumeLayout(false);
            this.fqwPage.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox department;
        private System.Windows.Forms.TabPage practicePage;
        private System.Windows.Forms.TabPage fqwPage;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox practiceBase;
        private System.Windows.Forms.ComboBox practiceHeadmaster;
        private System.Windows.Forms.ComboBox practiceType;
        private System.Windows.Forms.ComboBox practiceKind;
        private System.Windows.Forms.DateTimePicker practiceEndDate;
        private System.Windows.Forms.DateTimePicker practiceStartDate;
        private System.Windows.Forms.ComboBox practiceGroup;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox practiceTemplateFile;
        private System.Windows.Forms.Button fqwGenerateButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox fqwTemplateFile;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox fqlGroup;
        private System.Windows.Forms.Button practiceGenerateButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

