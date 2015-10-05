using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Plagins;
using Projects;


namespace GraphicEditor
{
  public partial class Form1 : Form
  {
    Dictionary<string, IPlagin> plagins = new Dictionary<string, IPlagin>(); //Загруженные плагины

    Project pro = new Project(); //Текущий проект

    private Graphics g; // Graphics, в котором будет всё рисоваться
    private Image img;

    private string _currentPlagin = String.Empty; //Текущий плагин

    List<object> lo = new List<object>(); //Список объектов для считывания параметров фигуры из разных источников

    public Form1()
    {
      InitializeComponent();
      img = new Bitmap(mainPictureBox.Size.Width, mainPictureBox.Size.Height);
      mainPictureBox.Image = img;
      //g = Graphics.FromImage(mainPictureBox.Image);
      //g = mainPictureBox.CreateGraphics();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      DirectoryInfo rootDir = new DirectoryInfo("Plagins");
      FileInfo[] files = rootDir.GetFiles();

      if (files.Length > 0)
      {
        foreach (var f in files)
        {
          Assembly asmbl = Assembly.LoadFrom(@"Plagins\" + f.Name);

          IPlagin plagin = (IPlagin)Activator.CreateInstance(asmbl.GetExportedTypes()[0]);

          //IPlagin.IPlagin plaginGeneric = (IPlagin.IPlagin)Activator.CreateInstance(asmbl.GetExportedTypes()[0].MakeGenericType(new Type[] { typeof(int) }));//for generic types

          plagins.Add(plagin.GetName(), plagin);

          ToolStripMenuItem newMenuItem = plagin.GetMenuItem();

          newMenuItem.DropDownItems[newMenuItem.DropDownItems.Count - 1].Click += new EventHandler(delegate(Object o, EventArgs a)
          {
            _currentPlagin = (o as ToolStripMenuItem).OwnerItem.Text;
            MessageBox.Show("Кликните на клиентской области окна и, не отпуская кнопки, обозначьте прямоугольную область для фигуры");
          });

          (menuStrip1.Items["Figures"] as ToolStripMenuItem).DropDownItems.Add(newMenuItem);
        }
      }
    }

    private void выходToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
    {
      openFileDialog1.InitialDirectory = Application.StartupPath + @"\Projects";

      if (pro.Figures.Count > 0)
      {
        DialogResult dr = MessageBox.Show(@"Сохранить текущий проект?", @"Сохранение", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        if (dr == DialogResult.Yes)
        {
          сохранитьПроектToolStripMenuItem_Click(сохранитьПроектToolStripMenuItem, new EventArgs());
        }
        else if (dr == DialogResult.Cancel)
        {
          return;
        }
      }

      if (openFileDialog1.ShowDialog() == DialogResult.OK)
      {
        FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open);
        BinaryFormatter bf = new BinaryFormatter();
        pro = (Project)bf.Deserialize(fs);
        mainPictureBox.Invalidate();
      }
    }

    private void сохранитьПроектToolStripMenuItem_Click(object sender, EventArgs e)
    {
      saveFileDialog1.InitialDirectory = Application.StartupPath + @"\Projects";

      if (saveFileDialog1.ShowDialog() == DialogResult.OK)
      {
        FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(fs, pro);
        fs.Close();
      }
    }

    private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (pro.Figures.Count > 0)
      {
        DialogResult dr = MessageBox.Show(@"Сохранить текущий проект?", @"Сохранение", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        if (dr == DialogResult.OK)
        {
          сохранитьПроектToolStripMenuItem_Click(сохранитьПроектToolStripMenuItem, new EventArgs());
        }
        else if (dr == DialogResult.Cancel)
        {
          return;
        }
      }

      pro = new Project();
      mainPictureBox.Invalidate();
    }

    private void сохранитьИзображениеToolStripMenuItem_Click(object sender, EventArgs e)
    {
      saveFileDialog2.InitialDirectory = Application.StartupPath + @"\Pics";

      if (saveFileDialog2.ShowDialog() == DialogResult.OK)
      {
        using (var bmp = new Bitmap(mainPictureBox.Width, mainPictureBox.Height))
        {
          mainPictureBox.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
          switch (saveFileDialog2.FilterIndex)
          {
            case 1://All files|*.*
              bmp.Save(saveFileDialog2.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
              break;
            case 2://Bitmap-image BMP|*.bmp
              bmp.Save(saveFileDialog2.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
              break;
            case 3://Image JPG|*.jpg
              bmp.Save(saveFileDialog2.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
              break;
            case 4://Image GIF|*.gif
              bmp.Save(saveFileDialog2.FileName, System.Drawing.Imaging.ImageFormat.Gif);
              break;
            case 5://Image TIF|*.tif
              bmp.Save(saveFileDialog2.FileName, System.Drawing.Imaging.ImageFormat.Tiff);
              break;
            case 6://Image PNG|*.png
              bmp.Save(saveFileDialog2.FileName, System.Drawing.Imaging.ImageFormat.Png);
              break;
            case 7://Image ICO|*.ico
              bmp.Save(saveFileDialog2.FileName, System.Drawing.Imaging.ImageFormat.Icon);
              break;
            case 8://Image EMF|*.emf
              bmp.Save(saveFileDialog2.FileName, System.Drawing.Imaging.ImageFormat.Emf);
              break;
            case 9://Image WMF|*.wmf
              bmp.Save(saveFileDialog2.FileName, System.Drawing.Imaging.ImageFormat.Wmf);
              break;
          }
        }
      }
    }

    private void mainPictureBox_Paint(object sender, PaintEventArgs e)
    {
      g = e.Graphics;
      if (pro.Figures.Count > 0)
      {
        foreach (object[] prmtrs in pro.Figures)
        {
          plagins[(string)prmtrs[0]].Draw(g, prmtrs);
        }
      }
    }

    private void mainPictureBox_MouseDown(object sender, MouseEventArgs e)
    {
      if (!(_currentPlagin == String.Empty))
      {
        lo.Add(_currentPlagin);
        lo.Add(e.X);
        lo.Add(e.Y);
      }
    }

    private void mainPictureBox_MouseUp(object sender, MouseEventArgs e)
    {
      if (!(_currentPlagin == String.Empty))
      {
        lo.Add(e.X);
        lo.Add(e.Y);

        ToolStripMenuItem mi = menuStrip1.Items["Figures"] as ToolStripMenuItem;

        ToolStripMenuItem curMi = null;

        foreach (ToolStripMenuItem tscb in mi.DropDownItems)
        {
          if (tscb.ToString() == _currentPlagin)
          {
            curMi = tscb;
            break;
          }
        }

        foreach (ToolStripMenuItem tscb in curMi.DropDownItems)
        {
          if (tscb.DropDownItems.Count > 0)
          {
            if (tscb.DropDownItems[0] is ToolStripComboBox)
            {
              lo.Add((tscb.DropDownItems[0] as ToolStripComboBox).SelectedItem);
            }
            if (tscb.DropDownItems[0] is ToolStripTextBox)
            {
              lo.Add((tscb.DropDownItems[0] as ToolStripTextBox).Text);
            }
            if (tscb.DropDownItems[0] is ToolStripMenuItem)
            {
              foreach (ToolStripMenuItem tsmi in tscb.DropDownItems)
              {
                if (tsmi.Checked)
                {
                  lo.Add(tsmi.Text);
                }
              }
            }
          }
        }

        object[] prmtrs = lo.ToArray();

        pro.Figures.Add(prmtrs);

        mainPictureBox.Invalidate();
        //mainPictureBox_Paint(mainPictureBox, new PaintEventArgs(mainPictureBox.CreateGraphics(), new Rectangle(mainPictureBox.Location, mainPictureBox.Size)));

        //Invalidate(new Rectangle(mainPictureBox.Location, mainPictureBox.Size), true);

        lo.Clear();

        _currentPlagin = String.Empty;
      }
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (pro.Figures.Count > 0)
      {
        DialogResult dr = MessageBox.Show(@"Сохранить текущий проект?", @"Сохранение", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        if (dr == DialogResult.Yes)
        {
          сохранитьПроектToolStripMenuItem_Click(сохранитьПроектToolStripMenuItem, new EventArgs());
        }
        else if (dr == DialogResult.Cancel)
        {
          e.Cancel = true;
        }
      }
    }
  }
}
