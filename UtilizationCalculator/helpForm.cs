using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UtilizationCalculator
{
    public partial class helpForm : Form
    {
        public helpForm()
        {
            InitializeComponent();
        }

        private void help_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            helpBox.Text = "1.点击文件->打开文件，选择实验室课程表文件，后缀名必须是\".xlsx\"或者\".xls\"\n";
            helpBox.Text += "2.从下拉列表选择对应实验室\n";
            helpBox.Text += "3.在班级人数表中输入对应班级的人数，点击确定按钮\n";
            helpBox.Text += "4.点击开始计算按钮\n";
        }
    }
}
