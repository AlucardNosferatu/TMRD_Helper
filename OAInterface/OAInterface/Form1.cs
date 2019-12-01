using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OAInterface
{
    public partial class Form1 : Form
    {
        HtmlDocument doc;
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
                Login();
        }
        void FillInTheForm()
        {

        }
        void AddApp()
        {
            this.doc = WB.Document;
            foreach (HtmlElement element in this.doc.GetElementsByTagName("div"))
            {
                if (element.InnerText != null)
                {
                    if (element.InnerText.Equals("新建"))
                    {
                        element.InvokeMember("click");
                    }
                }
            }
        }
        void SwitchFilter()
        {
            this.doc = WB.Document;
            foreach(HtmlElement element in doc.GetElementsByTagName("a"))
            {
                if (element.InnerText != null)
                {
                    if (element.InnerText.Equals("产品测试程序新增、修改变更申请单"))
                    {
                        if (element.OuterHtml.Contains("158667ffab5ce41a55dd5124b3dae668"))
                        {
                            element.InvokeMember("click");
                        }
                    }
                }
            }
        }
            void EnterDashboard()
        {
            this.doc = WB.Document;
            foreach (HtmlElement element in this.doc.Body.All)
            {
                if (element.GetAttribute("title").Equals("审批流程"))
                {
                    element.InvokeMember("click");
                }
            }
        }
        void Login()
        {
            this.doc = WB.Document;
            foreach (HtmlElement element in this.doc.All)
            {
                if (element.Name.Equals("j_username"))
                {
                    element.SetAttribute("value", "我又不是傻子");
                }
                if (element.Name.Equals("j_password"))
                {
                    element.SetAttribute("value", "你觉得我会写吗？");
                }
                if (element.Name.Equals("btn_submit"))
                {
                    element.InvokeMember("click");
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void WB_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void WB_NewWindow(object sender, CancelEventArgs e)
        {

        }
    }
}
