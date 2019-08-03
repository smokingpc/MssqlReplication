using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBWriteTool
{
    public partial class frmMain : Form
    {
        private APP_STATE State = APP_STATE.STOPPED;

        public frmMain()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (State == APP_STATE.STOPPED)
                Start();
            else if (State == APP_STATE.RUNNING)
                Stop();

            UpdateUI();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'testDBDataSet1.CUSTOMER' table. You can move, or remove it, as needed.
            //var table = new TestDBDataSet.CUSTOMERDataTable();
            //CustomerTableAdapter.Fill(table);
            InitUI();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnbindContext();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            DoJob();
        }
    }
}
