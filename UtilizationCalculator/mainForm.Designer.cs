namespace UtilizationCalculator
{
    partial class UtilizationCalculator
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UtilizationCalculator));
            this.courcesFile = new System.Windows.Forms.OpenFileDialog();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.courceview = new System.Windows.Forms.ListView();
            this.classview = new System.Windows.Forms.ListView();
            this.exptimelabel = new System.Windows.Forms.Label();
            this.pratimelabel = new System.Windows.Forms.Label();
            this.plantimelabel = new System.Windows.Forms.Label();
            this.studenCountConfirm = new System.Windows.Forms.Button();
            this.calcbtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expTimeBox = new System.Windows.Forms.TextBox();
            this.praTimeBox = new System.Windows.Forms.TextBox();
            this.totalTimeBox = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // courcesFile
            // 
            this.courcesFile.FileName = "openFileDialog1";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(853, 666);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(259, 23);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // courceview
            // 
            this.courceview.FullRowSelect = true;
            this.courceview.GridLines = true;
            this.courceview.Location = new System.Drawing.Point(12, 32);
            this.courceview.Name = "courceview";
            this.courceview.Size = new System.Drawing.Size(1376, 605);
            this.courceview.TabIndex = 5;
            this.courceview.UseCompatibleStateImageBehavior = false;
            this.courceview.View = System.Windows.Forms.View.Details;
            // 
            // classview
            // 
            this.classview.FullRowSelect = true;
            this.classview.GridLines = true;
            this.classview.Location = new System.Drawing.Point(12, 666);
            this.classview.Name = "classview";
            this.classview.Size = new System.Drawing.Size(587, 217);
            this.classview.TabIndex = 9;
            this.classview.UseCompatibleStateImageBehavior = false;
            this.classview.View = System.Windows.Forms.View.Details;
            // 
            // exptimelabel
            // 
            this.exptimelabel.AutoSize = true;
            this.exptimelabel.Location = new System.Drawing.Point(850, 772);
            this.exptimelabel.Name = "exptimelabel";
            this.exptimelabel.Size = new System.Drawing.Size(98, 15);
            this.exptimelabel.TabIndex = 10;
            this.exptimelabel.Text = "实践课时数: ";
            // 
            // pratimelabel
            // 
            this.pratimelabel.AutoSize = true;
            this.pratimelabel.Location = new System.Drawing.Point(850, 821);
            this.pratimelabel.Name = "pratimelabel";
            this.pratimelabel.Size = new System.Drawing.Size(98, 15);
            this.pratimelabel.TabIndex = 11;
            this.pratimelabel.Text = "计划人时数: ";
            // 
            // plantimelabel
            // 
            this.plantimelabel.AutoSize = true;
            this.plantimelabel.Location = new System.Drawing.Point(850, 727);
            this.plantimelabel.Name = "plantimelabel";
            this.plantimelabel.Size = new System.Drawing.Size(90, 15);
            this.plantimelabel.TabIndex = 12;
            this.plantimelabel.Text = "实验课时数:";
            // 
            // studenCountConfirm
            // 
            this.studenCountConfirm.Location = new System.Drawing.Point(618, 666);
            this.studenCountConfirm.Name = "studenCountConfirm";
            this.studenCountConfirm.Size = new System.Drawing.Size(94, 217);
            this.studenCountConfirm.TabIndex = 14;
            this.studenCountConfirm.Text = "确定";
            this.studenCountConfirm.UseVisualStyleBackColor = true;
            this.studenCountConfirm.Click += new System.EventHandler(this.studenCountConfirm_Click);
            // 
            // calcbtn
            // 
            this.calcbtn.Location = new System.Drawing.Point(1218, 664);
            this.calcbtn.Name = "calcbtn";
            this.calcbtn.Size = new System.Drawing.Size(170, 217);
            this.calcbtn.TabIndex = 15;
            this.calcbtn.Text = "开始计算";
            this.calcbtn.UseVisualStyleBackColor = true;
            this.calcbtn.Click += new System.EventHandler(this.calcbtn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1400, 28);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.关闭文件ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.打开ToolStripMenuItem.Text = "打开文件";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // 关闭文件ToolStripMenuItem
            // 
            this.关闭文件ToolStripMenuItem.Name = "关闭文件ToolStripMenuItem";
            this.关闭文件ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.关闭文件ToolStripMenuItem.Text = "关闭文件";
            this.关闭文件ToolStripMenuItem.Click += new System.EventHandler(this.关闭文件ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.帮助ToolStripMenuItem1,
            this.关于ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 帮助ToolStripMenuItem1
            // 
            this.帮助ToolStripMenuItem1.Name = "帮助ToolStripMenuItem1";
            this.帮助ToolStripMenuItem1.Size = new System.Drawing.Size(181, 26);
            this.帮助ToolStripMenuItem1.Text = "帮助";
            this.帮助ToolStripMenuItem1.Click += new System.EventHandler(this.帮助ToolStripMenuItem1_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // expTimeBox
            // 
            this.expTimeBox.Location = new System.Drawing.Point(947, 717);
            this.expTimeBox.Name = "expTimeBox";
            this.expTimeBox.Size = new System.Drawing.Size(165, 25);
            this.expTimeBox.TabIndex = 18;
            // 
            // praTimeBox
            // 
            this.praTimeBox.Location = new System.Drawing.Point(947, 762);
            this.praTimeBox.Name = "praTimeBox";
            this.praTimeBox.Size = new System.Drawing.Size(165, 25);
            this.praTimeBox.TabIndex = 19;
            // 
            // totalTimeBox
            // 
            this.totalTimeBox.Location = new System.Drawing.Point(947, 811);
            this.totalTimeBox.Name = "totalTimeBox";
            this.totalTimeBox.Size = new System.Drawing.Size(165, 25);
            this.totalTimeBox.TabIndex = 20;
            // 
            // UtilizationCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 895);
            this.Controls.Add(this.totalTimeBox);
            this.Controls.Add(this.praTimeBox);
            this.Controls.Add(this.expTimeBox);
            this.Controls.Add(this.calcbtn);
            this.Controls.Add(this.studenCountConfirm);
            this.Controls.Add(this.plantimelabel);
            this.Controls.Add(this.pratimelabel);
            this.Controls.Add(this.exptimelabel);
            this.Controls.Add(this.classview);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.courceview);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "UtilizationCalculator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UtilizationCalculator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UtilizationCalculator_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog courcesFile;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ListView courceview;
        private System.Windows.Forms.ListView classview;
        private System.Windows.Forms.Label exptimelabel;
        private System.Windows.Forms.Label pratimelabel;
        private System.Windows.Forms.Label plantimelabel;
        private System.Windows.Forms.Button studenCountConfirm;
        private System.Windows.Forms.Button calcbtn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.TextBox expTimeBox;
        private System.Windows.Forms.TextBox praTimeBox;
        private System.Windows.Forms.TextBox totalTimeBox;
    }
}

