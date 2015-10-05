using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Plagins;

namespace Line
{
    public class Line : IPlagin
    {
      public string GetName()
      {
        return "Линия";
      }

      public ToolStripMenuItem GetMenuItem()
      {
        ToolStripMenuItem lineMenuItem = new ToolStripMenuItem("Линия");

        lineMenuItem.DropDownItems.Add(new ToolStripMenuItem("Цвет"));
        lineMenuItem.DropDownItems.Add(new ToolStripMenuItem("Нарисовать"));

        ToolStripComboBox colorMenuItemComboBox = new ToolStripComboBox("lineColor");

        String[] colorNames = Enum.GetNames(typeof(KnownColor));

        foreach (var color in colorNames)
        {
          colorMenuItemComboBox.Items.Add(color);
        }

        colorMenuItemComboBox.SelectedItem = "Black";

        (lineMenuItem.DropDownItems[0] as ToolStripMenuItem).DropDownItems.Add(colorMenuItemComboBox);

        return lineMenuItem;
      }

      public void Draw(Graphics g, object[] values)
      {
        KnownColor kc;

        if (!KnownColor.TryParse((string)values[5], out kc))
        {
          kc = KnownColor.Black;
        }

        Color c = Color.FromName(kc.ToString());

        g.DrawLine(new Pen(c), (int)values[1], (int)values[2], (int)values[3], (int)values[4]);
      }
    }
}
