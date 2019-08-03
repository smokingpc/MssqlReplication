using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBWriteTool
{
    public partial class frmMain
    {
        private void InitUI()
        {
            comboBox1.Items.Add(DB_CONN_TYPE.TCPIP);
            comboBox1.Items.Add(DB_CONN_TYPE.SHARE_MEM);
            comboBox1.SelectedIndex = 0;

            BindContext();
        }

        private void UpdateUI()
        {
            if (State == APP_STATE.STOPPED)
            {
                comboBox1.Enabled = true;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;

                button1.Text = "Start";
            }
            else if (State == APP_STATE.RUNNING)
            {
                comboBox1.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;

                button1.Text = "Stop";
            }
        }
    }
}
