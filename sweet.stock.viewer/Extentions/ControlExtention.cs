using System.Drawing;
using System.Windows.Forms;

namespace sweet.stock.viewer.Extentions
{
    public static class ControlExtention
    {
        /// <summary>
        /// 返回当前控件相对于窗体的坐标
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static Point PointToForm(this Control control)
        {
            var targetControl = control;

            var form = targetControl.FindForm();
            var screenPoint = targetControl.Parent.PointToScreen(targetControl.Location);
            var point = form.PointToClient(screenPoint);

            return point;
        }
    }
}