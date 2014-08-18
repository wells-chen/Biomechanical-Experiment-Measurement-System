using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication1;
using System.IO;

namespace tester1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void open_folder_Click(object sender, EventArgs e)
        {

            var dialog = new OpenFileDialog();
            dialog.ShowDialog();
        }

        private void Save_bt_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            //设置文件保存类型
            sf.Filter = "txt文件|*.txt|所有文件|*.*";
            //如果用户没有输入扩展名，自动追加后缀
            sf.AddExtension = true;
            //设置标题
            sf.Title = "写文件";
            //如果用户点击了保存按钮
            if (sf.ShowDialog() == DialogResult.OK)
            {
                //实例化一个文件流--->与写入文件相关联
                FileStream fs = new FileStream(sf.FileName, FileMode.Create);
                //获得字节数组
                byte[] data = new UTF8Encoding().GetBytes(this.Status_Position_tb.Text);
                //开始写入
                fs.Write(data, 0, data.Length);
                //清空缓冲区、关闭流
                fs.Flush();
                fs.Close();

            }

        }

     
   
    }
}
