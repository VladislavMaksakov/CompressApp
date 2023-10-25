using System.Windows.Forms;

namespace MyApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private OpenFileDialog openFileDialog1;

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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ChangeFile = new System.Windows.Forms.Button();
            this.label_Path = new System.Windows.Forms.Label();
            this.Label_Method = new System.Windows.Forms.Label();
            this.btn_stysnuty = new System.Windows.Forms.Button();
            this.btn_decod = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ChangeFile
            // 
            this.ChangeFile.Location = new System.Drawing.Point(1273, 12);
            this.ChangeFile.Name = "ChangeFile";
            this.ChangeFile.Size = new System.Drawing.Size(325, 70);
            this.ChangeFile.TabIndex = 0;
            this.ChangeFile.Text = "Оберіть файл";
            this.ChangeFile.UseVisualStyleBackColor = true;
            this.ChangeFile.Click += new System.EventHandler(this.ChangeFile_Click);
            // 
            // label_Path
            // 
            this.label_Path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Path.Location = new System.Drawing.Point(27, 12);
            this.label_Path.Name = "label_Path";
            this.label_Path.Size = new System.Drawing.Size(1229, 70);
            this.label_Path.TabIndex = 1;
            this.label_Path.Text = "...";
            this.label_Path.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_Method
            // 
            this.Label_Method.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label_Method.Location = new System.Drawing.Point(27, 194);
            this.Label_Method.Name = "Label_Method";
            this.Label_Method.Size = new System.Drawing.Size(1571, 70);
            this.Label_Method.TabIndex = 2;
            this.Label_Method.Text = "Метод стиснення: ";
            this.Label_Method.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_stysnuty
            // 
            this.btn_stysnuty.Location = new System.Drawing.Point(28, 104);
            this.btn_stysnuty.Name = "btn_stysnuty";
            this.btn_stysnuty.Size = new System.Drawing.Size(788, 70);
            this.btn_stysnuty.TabIndex = 4;
            this.btn_stysnuty.Text = "Стиснути";
            this.btn_stysnuty.UseVisualStyleBackColor = true;
            this.btn_stysnuty.Click += new System.EventHandler(this.btn_stysnuty_Click);
            // 
            // btn_decod
            // 
            this.btn_decod.Location = new System.Drawing.Point(822, 104);
            this.btn_decod.Name = "btn_decod";
            this.btn_decod.Size = new System.Drawing.Size(776, 70);
            this.btn_decod.TabIndex = 5;
            this.btn_decod.Text = "Декодувати";
            this.btn_decod.UseVisualStyleBackColor = true;
            this.btn_decod.Click += new System.EventHandler(this.btn_decod_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1617, 529);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_decod);
            this.Controls.Add(this.btn_stysnuty);
            this.Controls.Add(this.Label_Method);
            this.Controls.Add(this.label_Path);
            this.Controls.Add(this.ChangeFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "MaksakovApp";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ChangeFile;
        private System.Windows.Forms.Label label_Path;
        private Label Label_Method;
        private Button btn_stysnuty;
        private Button btn_decod;
        private Button button1;
    }
}

