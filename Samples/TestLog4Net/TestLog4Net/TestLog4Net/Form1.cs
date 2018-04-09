using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestLog4Net
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //第一种记录用法
            //（1）FormMain是类名称
            //（2）第二个参数是字符串信息
            LogHelper.WriteLog(typeof(FormMain), "测试Log4Net日志是否写入" + "\r\n" +"test haha");


            //第二种记录用法
            //（1）FormMain是类名称
            //（2）第二个参数是需要捕捉的异常块
            //try { 
            
            //}catch(Exception ex){

            //    LogHelper.WriteLog(typeof(FormMain), ex);

            //}
          

        }
    }
}
