using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 监控哪个窗体获取焦点
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int Width, int Height, int flags);
        
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();//获取当前激活窗口 

        [DllImport("user32", SetLastError = true)]
        public static extern int GetWindowText(
        IntPtr hWnd, //窗口句柄
        StringBuilder lpString, //标题
        int nMaxCount //最大值
        );
        [DllImport("user32 ")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32 ")]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [DllImport("user32.dll")]
        private static extern int GetClassName(
            IntPtr hWnd, //句柄
            StringBuilder lpString, //类名
            int nMaxCount //最大值
        );


        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            IntPtr myPtr = GetForegroundWindow(); // 窗口标题
            StringBuilder title = new StringBuilder(255);
            GetWindowText(myPtr, title, title.Capacity); // 窗口类名
            StringBuilder className = new StringBuilder(256);
            GetClassName(myPtr, className, className.Capacity); 
            label2.Text ="句柄值:"+ myPtr.ToString() + "\n" + "标题："+title.ToString() + "\n" +"窗体名："+ className.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //让窗体始终处于置顶状态
            //IntPtr hDeskTop = FindWindow("Progman", "Program Manager");
            //SetParent(this.Handle, hDeskTop);
            SetWindowPos(this.Handle, -1, 0, 0, 0, 0, 1 | 2); //最后参数也有用1 | 4　
        }
    }
}
