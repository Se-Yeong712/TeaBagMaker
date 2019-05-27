using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TeaBagMaker
{
    public partial class Form1 : Form
    {

        string[] teaList = new String[] { "홍차 2분", "녹차 3분", "루이보스차 5분", "국화차 2분" };
        int[] timeList = new int[] { 2, 3, 5, 2 };
        string orgTea = "";
        int orgTime = 0;
        int Count = 0;


        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < this.teaList.Length; i++)
            {
                this.cbList.Items.Add(this.teaList[i]);
            }

            this.cbList.SelectedIndex = 0;
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            if (Maker())
            {
                this.timer1.Enabled = true;
            }


            
        }

        private bool Maker()
        {
            this.orgTea = this.cbList.Text;
            for (int i = 0; i < teaList.Length; i++)
            {
                if (this.orgTea.Equals(teaList[i]))
                {
                    this.Count = timeList[i]*60;
                    return true;
                }
            }
            return false;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (this.Count < 1)
            {
                this.timer1.Enabled=false;
                MessageBox.Show("티백을 건지세요!", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttime.Text = "";
                cbList.Focus();
            }
            else
            {
                this.Count = this.Count - 1;
                string result = "";
                if (Count >= 60)
                {
                    result = (Count / 60) + "분 " + (Count % 60) + "초 남았습니다";

                }
                else
                {
                    result = (Count % 60) + "초 남았습니다";
                }
                this.txttime.Text = result;
            }
        }
    }
}
