using System;
using System.Drawing;
using System.Windows.Forms;
using Plagins;

namespace Ellipse
{
  public class Ellipse : IPlagin
  {
    public string GetName()
    {
      return "Эллипс";
    }

    public ToolStripMenuItem GetMenuItem()
    {
      ToolStripMenuItem ellipseMenuItem = new ToolStripMenuItem("Эллипс");

      ellipseMenuItem.DropDownItems.Add(new ToolStripMenuItem("Цвет"));
      ellipseMenuItem.DropDownItems.Add(new ToolStripMenuItem("Нарисовать"));

      ToolStripComboBox colorMenuItemComboBox = new ToolStripComboBox("ellipseColor");

      String[] colorNames = Enum.GetNames(typeof(KnownColor));

      foreach (var color in colorNames)
      {
        colorMenuItemComboBox.Items.Add(color);
      }

      colorMenuItemComboBox.SelectedItem = "Black";

      (ellipseMenuItem.DropDownItems[0] as ToolStripMenuItem).DropDownItems.Add(colorMenuItemComboBox);

      return ellipseMenuItem;
    }

    public void Draw(Graphics g, object[] values)
    {
      KnownColor kc;

      if (!KnownColor.TryParse((string)values[5], out kc))
      {
        kc = KnownColor.Black;
      }

      Color c = Color.FromName(kc.ToString());

      g.DrawEllipse(new Pen(c), (int)values[1], (int)values[2], (int)values[3] - (int)values[1], (int)values[4] - (int)values[2]);
    }
  }
}
