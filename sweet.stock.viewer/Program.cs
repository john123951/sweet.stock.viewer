using System;
using System.Windows.Forms;

namespace sweet.stock.viewer
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            //var client = new SinaStockClient();

            //var result = client.Suggest("002017");

            //var stockInfo = client.MarketPrice(result.Select(x => x.StockId).ToArray());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}