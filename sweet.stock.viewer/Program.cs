using sweet.stock.client;
using sweet.stock.repository;
using sweet.stock.service;
using sweet.stock.viewer.Forms;
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

            //var result = client.Suggest("sz002017");

            //var stockInfo = client.MarketPrice(new []{"111","sz002017"});

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(new StockService(new SinaStockClient(), new XmlStockRepository(), new XmlSettingRepository())));
        }
    }
}