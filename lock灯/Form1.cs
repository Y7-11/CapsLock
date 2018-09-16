using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
namespace lock灯
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            Task.Run(() => {

                System.Timers.Timer t = new System.Timers.Timer(500);
                t.Elapsed += t_Elapsed;
                t.Start();
            });

        }

        void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                notifyIcon1.Icon = new Icon("red.ico");
          
            }
            else
            {
                notifyIcon1.Icon = new Icon("green.ico");
            }
        }

        private void Form1_ClientSizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
            }
        }

        private void 退出ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确认退出程序？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Dispose();
                this.Close();
            }
        }
    }
}
