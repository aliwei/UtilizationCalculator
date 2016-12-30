///可编辑listview类EditableListView.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;

namespace testlistview
{
    public class ListViewCell
    {
        ///
        /// 单元格所在的行。
        ///
        public ListViewItem Item { get; set; }
        ///
        /// Item 的 Index 值会变成 -1，暂时未找到原因，用这个代替。
        ///
        public int ItemIndex { get; set; }
        ///
        /// 单元格所在的列。
        ///
        public ColumnHeader Column { get; set; }
        ///
        /// 单元格相对于 ListView 的大小和位置。
        ///
        public Rectangle Bounds { get; set; }
    }


    public class ListViewCellLocator
    {
        [DllImport("user32")]
        public static extern int GetScrollPos(int hwnd, int nBar);


        ///
        /// 根据位置 x、y 获得 ListViewCell。
        ///
        ///
        /// 工作区坐标表示的 x 轴坐标。
        /// 工作区坐标表示的 y 轴坐标。
        ///
        public static ListViewCell GetCell(ListView listView, int x, int y)
        {
            ListViewCell cell = new ListViewCell();

            // 获得单元格所在的行。
            cell.Item = listView.GetItemAt(x, y);
            if (cell.Item == null)
            {
                return null;
            }
            cell.ItemIndex = cell.Item.Index; // 现在 Item.Index 还能用

            // 根据各列宽度，获得单元格所在的列，以及 Bounds。
            int currentX = cell.Item.GetBounds(ItemBoundsPortion.Entire).Left; // 依次循环各列，表示各列的起点值
            int scrollLeft = GetScrollPos(listView.Handle.ToInt32(), 0); // 可能出现了横向滚动条，左边隐藏起来的宽度
            for (int i = 0; i < listView.Columns.Count; i++)
            {
                if (scrollLeft + x >= currentX &&
                    scrollLeft + x < currentX + listView.Columns[i].Width)
                {
                    cell.Column = listView.Columns[i]; // 列找到了
                    Rectangle itemBounds = cell.Item.GetBounds(ItemBoundsPortion.Entire);
                    cell.Bounds = new Rectangle(currentX,
                        itemBounds.Y,
                        listView.Columns[i].Width,
                        itemBounds.Height);
                    break;
                }
                currentX += listView.Columns[i].Width;
            }

            if (cell.Column == null)
            {
                return null;
            }
            return cell;
        }
    }
    public class EditableListViewSubmittingEventArgs : EventArgs
    {
        public ListViewCell Cell { get; set; }
        public string Value { get; set; }
    }
    public delegate void EditableListViewSubmitting(object sender, EditableListViewSubmittingEventArgs e);
    class EditableListView
    {
        public event EditableListViewSubmitting Submitting;

        private ListView ListView { get; set; }
        private Point MousePosition = new Point();
        private TextBox EditBox { get; set; }
        public int[] TextBoxColumns { get; set; }

        public EditableListView(ListView listView)
        {
            // 初始化 EditBox
            EditBox = new TextBox();
            EditBox.Visible = false;
            EditBox.KeyUp += new KeyEventHandler(KeyUpHandle);
            EditBox.LostFocus += new EventHandler(EditBox_LostForcus);
            // 设置 ListView
            ListView = listView;
            ListView.MouseMove += new MouseEventHandler(delegate (object sender, MouseEventArgs e)
            {
                // 记录鼠标位置，便于在鼠标动作中使用（有些鼠标动作，比如双击，事件中并不传递鼠标双击时的位置）。
                MousePosition.X = e.X;
                MousePosition.Y = e.Y;
            });

            EditBox.Parent = ListView;

            // 事件
            ListView.DoubleClick += new EventHandler(EditItem);
        }

        private void KeyUpHandle(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                LeaveEdit();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                SaveEdit();
            }
        }
        private void EditBox_LostForcus(object sender, EventArgs e)
        {
            SaveEdit();
        }
        private void SaveEdit()
        {
            if (Submitting != null)
            {
                EditableListViewSubmittingEventArgs args = new EditableListViewSubmittingEventArgs();
                if (EditBox.Tag != null)
                {
                    args.Cell = (ListViewCell)EditBox.Tag;
                }
                else
                {
                    args.Cell = null;
                }
                args.Value = EditBox.Text;
                LeaveEdit();
                Submitting(ListView, args);
            }
        }

        private void EditItem(object sender, EventArgs e)
        {
            ListViewCell cell = ListViewCellLocator.GetCell(this.ListView, MousePosition.X, MousePosition.Y);

            if (cell == null)
            {
                return;
            }

            if (TextBoxColumns.Contains(cell.Column.Index))
            {
                // 设置 EditBox 的位置、大小、内容、可显示等。
                EditBox.Bounds = cell.Bounds;
                EditBox.Text = cell.Item.SubItems[cell.Column.Index].Text;
                EditBox.Visible = true;
                EditBox.Focus();
                EditBox.Tag = cell;
            }
        }

        public bool IsEditableColumn(int columnIndex)
        {
            if (TextBoxColumns.Contains(columnIndex))
            {
                return true;
            }

            return false;
        }


        public void LeaveEdit()
        {
            EditBox.Visible = false;
            EditBox.Tag = null;
        }
    }
}