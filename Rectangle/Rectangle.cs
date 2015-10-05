using System;
using System.Drawing;
using System.Windows.Forms;
using Plagins;

namespace Rectangle
{
  public class Rectangle : IPlagin
    {
    public string GetName()
    {
      return "Прямоугольник";
    }

    public ToolStripMenuItem GetMenuItem()
    {
      ToolStripMenuItem rectangleMenuItem = new ToolStripMenuItem("Прямоугольник");

      rectangleMenuItem.DropDownItems.Add(new ToolStripMenuItem("Цвет"));
      rectangleMenuItem.DropDownItems.Add(new ToolStripMenuItem("Нарисовать"));
      
      ToolStripComboBox colorMenuItemComboBox = new ToolStripComboBox("rectangleColor");

      String[] colorNames = Enum.GetNames(typeof(KnownColor));

      foreach (var color in colorNames)
      {
        colorMenuItemComboBox.Items.Add(color);
      }

      colorMenuItemComboBox.SelectedItem = "Black";

      (rectangleMenuItem.DropDownItems[0] as ToolStripMenuItem).DropDownItems.Add(colorMenuItemComboBox);
      
      return rectangleMenuItem;
    }

    public void Draw(Graphics g, object[] values)
    {
      KnownColor kc;

      if (!KnownColor.TryParse((string)values[5], out kc))
      {
        kc = KnownColor.Black;
      }

      Color c = Color.FromName(kc.ToString());

      g.DrawRectangle(new Pen(c), (int)values[1], (int)values[2], (int)values[3] - (int)values[1], (int)values[4] - (int)values[2]);
    }
    }
}
