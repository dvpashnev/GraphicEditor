namespace GraphicEditor
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
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.новыйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.сохранитьПроектToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.сохранитьИзображениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.Figures = new System.Windows.Forms.ToolStripMenuItem();
      this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
      this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
      this.mainPictureBox = new System.Windows.Forms.PictureBox();
      this.menuStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.Figures,
            this.справкаToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(720, 24);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // файлToolStripMenuItem
      // 
      this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новыйToolStripMenuItem,
            this.открытьToolStripMenuItem,
            this.сохранитьПроектToolStripMenuItem,
            this.сохранитьИзображениеToolStripMenuItem,
            this.toolStripSeparator1,
            this.выходToolStripMenuItem});
      this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
      this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
      this.файлToolStripMenuItem.Text = "Файл";
      // 
      // новыйToolStripMenuItem
      // 
      this.новыйToolStripMenuItem.Name = "новыйToolStripMenuItem";
      this.новыйToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
      this.новыйToolStripMenuItem.Text = "Новый";
      this.новыйToolStripMenuItem.Click += new System.EventHandler(this.новыйToolStripMenuItem_Click);
      // 
      // открытьToolStripMenuItem
      // 
      this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
      this.открытьToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
      this.открытьToolStripMenuItem.Text = "Открыть";
      this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
      // 
      // сохранитьПроектToolStripMenuItem
      // 
      this.сохранитьПроектToolStripMenuItem.Name = "сохранитьПроектToolStripMenuItem";
      this.сохранитьПроектToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
      this.сохранитьПроектToolStripMenuItem.Text = "Сохранить проект";
      this.сохранитьПроектToolStripMenuItem.Click += new System.EventHandler(this.сохранитьПроектToolStripMenuItem_Click);
      // 
      // сохранитьИзображениеToolStripMenuItem
      // 
      this.сохранитьИзображениеToolStripMenuItem.Name = "сохранитьИзображениеToolStripMenuItem";
      this.сохранитьИзображениеToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
      this.сохранитьИзображениеToolStripMenuItem.Text = "Сохранить изображение";
      this.сохранитьИзображениеToolStripMenuItem.Click += new System.EventHandler(this.сохранитьИзображениеToolStripMenuItem_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(206, 6);
      // 
      // выходToolStripMenuItem
      // 
      this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
      this.выходToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
      this.выходToolStripMenuItem.Text = "Выход";
      this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
      // 
      // Figures
      // 
      this.Figures.Name = "Figures";
      this.Figures.Size = new System.Drawing.Size(62, 20);
      this.Figures.Text = "Фигуры";
      // 
      // справкаToolStripMenuItem
      // 
      this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1});
      this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
      this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
      this.справкаToolStripMenuItem.Text = "Справка";
      // 
      // toolStripComboBox1
      // 
      this.toolStripComboBox1.Name = "toolStripComboBox1";
      this.toolStripComboBox1.Size = new System.Drawing.Size(121, 23);
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.DefaultExt = "pro";
      this.openFileDialog1.FileName = "Project";
      this.openFileDialog1.Filter = "Projects (*.pro)|*.pro";
      this.openFileDialog1.Title = "Открыть файл проекта";
      // 
      // saveFileDialog1
      // 
      this.saveFileDialog1.DefaultExt = "pro";
      this.saveFileDialog1.FileName = "Project";
      this.saveFileDialog1.Filter = "Projects (*.pro)|*.pro";
      this.saveFileDialog1.Title = "Сохранить файл проекта";
      // 
      // saveFileDialog2
      // 
      this.saveFileDialog2.DefaultExt = "jpg";
      this.saveFileDialog2.FileName = "Pic";
      this.saveFileDialog2.Filter = "All files|*.*|Bitmap-image BMP|*.bmp|Image JPG|*.jpg|Image GIF|*.gif|Image TIF|*." +
    "tif|Image PNG|*.png|Image ICO|*.ico|Image EMF|*.emf|Image WMF|*.wmf";
      this.saveFileDialog2.FilterIndex = 3;
      // 
      // mainPictureBox
      // 
      this.mainPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.mainPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mainPictureBox.Location = new System.Drawing.Point(0, 24);
      this.mainPictureBox.Name = "mainPictureBox";
      this.mainPictureBox.Size = new System.Drawing.Size(720, 385);
      this.mainPictureBox.TabIndex = 1;
      this.mainPictureBox.TabStop = false;
      this.mainPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPictureBox_Paint);
      this.mainPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseDown);
      this.mainPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseUp);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(720, 409);
      this.Controls.Add(this.mainPictureBox);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "Form1";
      this.Text = "Графический редактор";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
      this.Load += new System.EventHandler(this.Form1_Load);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem новыйToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem сохранитьПроектToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem сохранитьИзображениеToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem Figures;
    private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    private System.Windows.Forms.SaveFileDialog saveFileDialog2;
    private System.Windows.Forms.PictureBox mainPictureBox;
  }
}

