using System.Drawing.Text;
using Plagins;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Text
{
    public class Text : IPlagin
    {
      private string _txt;

      private Font _font;

      public string GetName()
      {
        return "Текст";
      }

      public ToolStripMenuItem GetMenuItem()
      {
        ToolStripMenuItem textMenuItem = new ToolStripMenuItem("Текст");

        textMenuItem.DropDownItems.Add(new ToolStripMenuItem("Цвет"));//5
        textMenuItem.DropDownItems.Add(new ToolStripMenuItem("Шрифт"));//6
        textMenuItem.DropDownItems.Add(new ToolStripMenuItem("Размер шрифта"));//7
        textMenuItem.DropDownItems.Add(new ToolStripMenuItem("Стиль шрифта"));//8
        textMenuItem.DropDownItems.Add(new ToolStripMenuItem("Введите текст"));//9

        textMenuItem.DropDownItems.Add(new ToolStripMenuItem("Нарисовать"));

        ToolStripComboBox colorMenuItemComboBox = new ToolStripComboBox("textColor");

        String[] colorNames = Enum.GetNames(typeof(KnownColor));

        foreach (var color in colorNames)
        {
          colorMenuItemComboBox.Items.Add(color);
        }

        colorMenuItemComboBox.SelectedItem = "Black";

        (textMenuItem.DropDownItems[0] as ToolStripMenuItem).DropDownItems.Add(colorMenuItemComboBox);

        ToolStripComboBox textFontMenuItemComboBox = new ToolStripComboBox("textFont");

        FontFamily[] fontFamilies;

        InstalledFontCollection installedFontCollection = new InstalledFontCollection();

        fontFamilies = installedFontCollection.Families;

        int count = fontFamilies.Length;
        for (int j = 0; j < count; ++j)
        {
          textFontMenuItemComboBox.Items.Add(fontFamilies[j].Name);
        }

        textFontMenuItemComboBox.SelectedItem = "Times New Roman";

        (textMenuItem.DropDownItems[1] as ToolStripMenuItem).DropDownItems.Add(textFontMenuItemComboBox);

        ToolStripComboBox fontSizeMenuItemComboBox = new ToolStripComboBox("fontSize");

        for (int j = 0; j < 72; ++j)
        {
          fontSizeMenuItemComboBox.Items.Add(j);
        }

        fontSizeMenuItemComboBox.SelectedItem = 14;

        (textMenuItem.DropDownItems[2] as ToolStripMenuItem).DropDownItems.Add(fontSizeMenuItemComboBox);


        String[] fontStyleNames = Enum.GetNames(typeof(FontStyle));

        foreach (var fontStyle in fontStyleNames)
        {
          ToolStripMenuItem fontStyleItemCheckBox = new ToolStripMenuItem(fontStyle);
          fontStyleItemCheckBox.CheckOnClick = true;
          (textMenuItem.DropDownItems[3] as ToolStripMenuItem).DropDownItems.Add(fontStyleItemCheckBox);
        }

        ToolStripTextBox someTextMenuItem = new ToolStripTextBox("someText");

        someTextMenuItem.Text = "Text";

        (textMenuItem.DropDownItems[4] as ToolStripMenuItem).DropDownItems.Add(someTextMenuItem);

        return textMenuItem;
      }

      public void Draw(Graphics g, object[] values)
      {
        KnownColor kc;

        if (!KnownColor.TryParse((string)values[5], out kc))
        {
          kc = KnownColor.Black;
        }

        Color c = Color.FromName(kc.ToString());

        FontStyle fs;
        if (!FontStyle.TryParse((string) values[8], out fs))
        {
          fs = FontStyle.Regular;
        }

        for (int i = 9; i < values.Length-1; i++)
        {
          FontStyle fsNext;
          if (FontStyle.TryParse((string) values[i], out fsNext))
          {
            fs = fs | fsNext;
          }
        }

        g.DrawString((string)values[values.Length-1], new Font((string)values[6], (int)values[7], fs), new SolidBrush(c), new RectangleF((int)values[1], (int)values[2], (int)values[3], (int)values[4]));
      }
    }
}
