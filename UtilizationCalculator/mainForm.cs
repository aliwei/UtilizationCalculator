using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.ExcelEdit;
using testlistview;

namespace UtilizationCalculator
{
    public partial class UtilizationCalculator : Form
    {
        private EditableListView courselist;
        private EditableListView classlist;
        ExcelEdit ee = new ExcelEdit();
        AnalyzeCource calc1 = new AnalyzeCource();
        bool fileOpened = false;


        public void initCourceList()
        {
            ColumnHeader h1 = new ColumnHeader();
            h1.Text = "表格数据";
            h1.Width = 280;
            ColumnHeader h2 = new ColumnHeader();
            h2.Text = "课程名称";
            h2.Width = 200;
            ColumnHeader h3 = new ColumnHeader();
            h3.Text = "实验/实践";
            h3.Width = 70;
            ColumnHeader h4 = new ColumnHeader();
            h4.Text = "班级";
            h4.Width = 180;
            ColumnHeader h5 = new ColumnHeader();
            h5.Text = "人数";
            h5.Width = 70;
            ColumnHeader h6 = new ColumnHeader();
            h6.Text = "周数原始数据";
            h6.Width = 150;
            ColumnHeader h7 = new ColumnHeader();
            h7.Text = "周数";
            h7.Width = 100;
            ColumnHeader h8 = new ColumnHeader();
            h8.Text = "人时数";
            h8.Width = 100;

            courceview.Columns.AddRange(new ColumnHeader[] { h1, h2, h3, h4, h5, h6, h7, h8});
            courceview.View = View.Details;
            courselist = new EditableListView(courceview);
            courselist.TextBoxColumns = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            courselist.Submitting += new EditableListViewSubmitting(courseViewSaveEditHandler);
        }

        public void initClassList()
        {
            ColumnHeader h1 = new ColumnHeader();
            h1.Text = "班级";
            h1.Width = 300;
            ColumnHeader h2 = new ColumnHeader();
            h2.Text = "人数";
            h2.Width = 100;
            classview.Columns.AddRange(new ColumnHeader[] { h1, h2});
            classview.View = View.Details;
            classlist = new EditableListView(classview);
            classlist.TextBoxColumns = new int[] { 0, 1, 2};
            classlist.Submitting += new EditableListViewSubmitting(classViewSaveEditHandler); 
        }

        public UtilizationCalculator()
        {
            InitializeComponent();

            initCourceList();
            initClassList();
        }
        private void courseViewSaveEditHandler(object sender, EditableListViewSubmittingEventArgs e)
        {
            if (e.Cell == null)
            {
                return;
            }
            string value = e.Value;
            ListViewItem item = e.Cell.Item;
            int itemindex = e.Cell.Column.Index;
            item.SubItems[itemindex].Text = value;
        }

        private void classViewSaveEditHandler(object sender, EditableListViewSubmittingEventArgs e)
        {
            if (e.Cell == null)
            {
                return;
            }
            string value = e.Value;
            ListViewItem item = e.Cell.Item;
            int itemindex = e.Cell.Column.Index;
            item.SubItems[itemindex].Text = value;
        }

        private void openfile_Click(object sender, EventArgs e)
        {

            
        }

        private int findClassNameInClassView(string className)
        {
            for(int i=0; i<classview.Items.Count; i++)
            {
                string str = classview.Items[i].SubItems[0].Text.ToString();
                if (string.Compare(str, className) == 0)
                {
                    return i;
                }
            }
            return -1;
        }

        private string getStudentCountInClassView(string className)
        {
            int index = findClassNameInClassView(className);
            if(index == -1)
            {
                return "0";
            }

            string studentCount = classview.Items[index].SubItems[1].Text;
            return studentCount;
        }
        private void addToclassview(string classnName)
        {
            if(findClassNameInClassView(classnName) == -1)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = classnName;
                lvi.SubItems.Add("0");
                classview.Items.Add(lvi);
            }
        }

        private void addTocourceview(string str, courceInfo info)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Text = str;
            lvi.SubItems.Add(info.courcename);
            lvi.SubItems.Add(info.courcetype);
            lvi.SubItems.Add(info.classname);
            lvi.SubItems.Add("0");
            lvi.SubItems.Add(info.timestr);
            lvi.SubItems.Add(info.weeks.ToString());
            lvi.SubItems.Add("0");
            courceview.Items.Add(lvi);
        }
        private string rngToStr(Microsoft.Office.Interop.Excel.Range rng)
        {
            if (rng.Value == null)
            {
                return null;
            }

            if (calc1.isValid(rng.Value.ToString()) == false)
            {
                return null;
            }

            return rng.Value.ToString();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            courceview.Items.Clear();
            classview.Items.Clear();
            ee.ws = ee.wb.Worksheets.get_Item(comboBox1.SelectedIndex+1);

            int rows = 4;
            char columns = 'c';
            for (columns = 'c'; columns <= 'i'; columns++)
            {
                for (rows = 4; rows <= 9; rows++)
                {
                    Microsoft.Office.Interop.Excel.Range rng1 = ee.ws.Cells.get_Range(columns.ToString() + rows.ToString(), Type.Missing);

                    string str = rngToStr(rng1);
                    if(str == null)
                    {
                        continue;
                    }

                    string[] courcess = str.Split(new Char[] { '\n' });

                    foreach (string cource in courcess)
                    {
                        calc1.analyze(cource);

                        addToclassview(calc1.info.classname);
                        addTocourceview(str, calc1.info);
                    }
                }//end for
            }//end for

        }

        private void clearView()
        {
            courceview.Items.Clear();
            classview.Items.Clear();
            comboBox1.Text = "";
            comboBox1.Items.Clear();
            expTimeBox.Text = "0";
            praTimeBox.Text = "0";
            totalTimeBox.Text = "0";
        }

        private void calcbtn_Click(object sender, EventArgs e)
        {
            int exptime = 0;
            int practicetime = 0;
            int plantime = 0;
            int studenCount = 0;
            int studenTime = 0;

            int week = 0;

            for (int i = 0; i < courceview.Items.Count; i++)
            {
                studenCount = int.Parse(courceview.Items[i].SubItems[4].Text);
                week = int.Parse(courceview.Items[i].SubItems[6].Text);
                studenTime = studenCount* week * 2;

                plantime += studenTime;
                courceview.Items[i].SubItems[7].Text = studenTime.ToString();

                if (string.Compare(courceview.Items[i].SubItems[2].Text, "实验") == 0)
                {
                    exptime += week*2;
                }
                else
                {
                    practicetime += week*2;
                }
            }

            expTimeBox.Text = exptime.ToString();
            praTimeBox.Text = practicetime.ToString() ;
            totalTimeBox.Text = plantime.ToString();
        }

        private void studenCountConfirm_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < courceview.Items.Count; i++)
            {
                courceview.Items[i].SubItems[4].Text = getStudentCountInClassView(courceview.Items[i].SubItems[3].Text);
            }
        }

        private bool isValidFile(ExcelEdit ee)
        {
            if(ee.wb.Worksheets.Count <= 0)
            {
                return false;
            }
            
            ee.ws = ee.wb.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range rng1 = ee.ws.Cells.get_Range("c3", Type.Missing);

            if (rng1.Value == null)
            {
                return false;
            }

            string str = rng1.Value;
            if (str == null)
            {
                return false;
            }

            if (str.IndexOf("星期一") == -1)
            {
                return false;
            }

            return true;
        }
        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(fileOpened == true)
            {
                closeFile();
            }
            
            if (courcesFile.ShowDialog() == DialogResult.OK)
            {
                string fileName = courcesFile.FileName;
                int index = fileName.IndexOf(".xlsx") + fileName.IndexOf(".xls");
                if (index > -1)
                {
                    ee.Open(fileName);
                    if (isValidFile(ee) == false)
                    {
                        MessageBox.Show("该文件不是有效的实验实践课表文件!");
                        closeFile();
                    }
                    else
                    {
                        for (int i = 1; i <= ee.wb.Worksheets.Count; i++)
                        {
                            string str = ee.wb.Worksheets.get_Item(i).Name.ToString();
                            comboBox1.Items.Add(str);
                        }
                        comboBox1.SelectedIndex = 0;
                        fileOpened = true;
                    }
                }
                else
                {
                    MessageBox.Show("文件格式错误! 请选择后缀名为\".xlsx\"或\".xls\"格式的文件！");
                }
            }
        }

        private void closeFile()
        {
            if(fileOpened == true)
            {
                fileOpened = false;
                ee.Close();
                clearView();
            }
        }
        private void 关闭文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeFile();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeFile();
            System.Environment.Exit(0);
        }

        private void 帮助ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            helpForm help = new helpForm();
            help.Show();
        }
    }
}
