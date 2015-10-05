using System.Drawing;
using System.Windows.Forms;

namespace Plagins
{
  public interface IPlagin
  {
    string GetName();
    ToolStripMenuItem GetMenuItem(); //Конструирует пункт меню для плагина
    void Draw(Graphics g, object[] values); //Рисует фигуру в указанном Graphics
  }
}
