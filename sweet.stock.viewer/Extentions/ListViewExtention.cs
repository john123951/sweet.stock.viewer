using sweet.stock.core.Attribute;
using sweet.stock.core.Model;
using sweet.stock.utility.Extentions;
using sweet.stock.viewer.Configs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace sweet.stock.viewer.Extentions
{
    public static class ListViewExtention
    {
        private static PropertyInfo[] GetProperties(Type type)
        {
            if (type == typeof(StockInfo))
            {
                var settings = DataConfig.GetInstance().ShowHeaderSetting;

                var props = type.GetProperties()
                                .Where(x => x.GetCustomAttributes(typeof(ShowDescriptionAttribute), true).Any(attr =>
                                {
                                    var showAttribute = attr as ShowDescriptionAttribute;
                                    return showAttribute != null && settings.Single(setting => setting.Description == showAttribute.Description).IsShow;
                                }))
                                .ToArray();

                return props;
            }
            else
            {
                var props = type.GetProperties()
                                .Where(x => x.GetCustomAttributes(typeof(ShowDescriptionAttribute), true).Any(attr =>
                                {
                                    var showAttribute = attr as ShowDescriptionAttribute;
                                    return showAttribute != null && showAttribute.IsShow;
                                }))
                                .ToArray();

                return props;
            }
        }

        public static void ViewList<T>(this ListView listView, IEnumerable<T> modelList)
            where T : class
        {
            if (listView == null || !modelList.IsNotEmpty())
            {
                return;
            }
            var props = GetProperties(typeof(T));

            //设置
            //listView.View = View.Details;
            //listView.FullRowSelect = true;
            listView.Clear();

            //添加列
            Graphics graphics = listView.CreateGraphics();

            foreach (var propertyInfo in props)
            {
                var attr = propertyInfo.GetCustomAttributes(typeof(DescriptionAttribute), true).FirstOrDefault() as DescriptionAttribute;

                var columnName = attr == null ? string.Empty : attr.Description;
                var sizeF = graphics.MeasureString(columnName, listView.Font);
                listView.Columns.Add(propertyInfo.Name, columnName, (int)(Math.Ceiling(sizeF.Width) + 10), HorizontalAlignment.Left, 0);
            }

            //添加行
            listView.BeginUpdate();

            foreach (var model in modelList)
            {
                ListViewItem item = null;

                for (int i = 0; i < props.Length; i++)
                {
                    var propertyInfo = props[i];

                    var value = propertyInfo.GetValue(model, null) ?? "";
                    if (i == 0)
                    {
                        item = listView.Items.Add(value.ToString(), value.ToString(), 1);
                    }
                    else
                    {
                        item.SubItems.Add(value.ToString());
                    }
                    item.Tag = model;
                }
            }

            //if (listView.Items.Count > 1)
            //{
            //    listView.Items[listView.Items.Count - 1].EnsureVisible();//滚动到最后
            //}
            listView.EndUpdate();
        }

        public static void ModifyList<T>(this ListView listView, IEnumerable<T> modelList, Action<T, ListViewItem> modify = null)
            where T : class
        {
            if (listView == null || !modelList.IsNotEmpty())
            {
                return;
            }
            var props = GetProperties(typeof(T));

            listView.BeginUpdate();

            foreach (var model in modelList)
            {
                ListViewItem item = null;

                for (int i = 0; i < props.Length; i++)
                {
                    var propertyInfo = props[i];

                    var value = propertyInfo.GetValue(model, null) ?? "";
                    if (i == 0)
                    {
                        var key = value.ToString();

                        item = listView.Items.Find(key, false).FirstOrDefault();

                        if (item == null)
                        {
                            item = listView.Items.Add(value.ToString(), value.ToString(), 1);
                        }
                    }
                    else
                    {
                        if (item == null) { break; }
                        if (item.SubItems.Count <= i + 1)
                        {
                            item.SubItems.Add(value.ToString());
                        }
                        else
                        {
                            item.SubItems[i].Text = value.ToString();
                        }
                    }
                }
                item.Tag = model;

                if (modify != null) { modify(model, item); }
            }

            listView.EndUpdate();
        }

        public static void ModifyColor(this ListViewItem listViewItem, Color color)
        {
            if (listViewItem == null) { return; }

            listViewItem.ForeColor = color;

            foreach (ListViewItem.ListViewSubItem subItem in listViewItem.SubItems)
            {
                subItem.ForeColor = color;
            }
        }
    }
}