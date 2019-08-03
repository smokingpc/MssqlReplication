using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DBWriteTool
{
    public partial class frmMain
    {
        private void Start()
        {
            WriteContext();

            State = APP_STATE.RUNNING;
            timer1.Interval = Context.Interval * CONST.SecToMSec;
            timer1.Enabled = true;
        }

        private void Stop()
        {
            State = APP_STATE.STOPPED;
            timer1.Enabled = false;
        }

        private void DoJob()
        {
            CustomerTableAdapter.Connection = new SqlConnection(Context.DSN);
            TestDBDataSet.CUSTOMERDataTable table = new TestDBDataSet.CUSTOMERDataTable();

            if (Context.ReadData || Context.ModifyData)
            {
                CustomerTableAdapter.Fill(table);
            }

            if (Context.WriteData)
            {
                string name = "";
                for (int i = 0; i < 4; i++)
                    name = name + GenerateRandomASCII();

                int phone = GenerateRandomInt();
                CustomerTableAdapter.Insert(name, phone.ToString());
            }
            if (Context.ModifyData)
            {
                int phone = GenerateRandomInt();
                string name = "";
                //for (int i = 0; i < 4; i++)
                //    name = name + GenerateRandomASCII();

                Random rand = new Random();
                int id = rand.Next(1, table.Rows.Count-1);
                var row = table.FindByID(id);

                if (row != null)
                {
                    row["PHONE"] = phone;
                }

                CustomerTableAdapter.Update(table);
            }

            if (Context.ReadData)
                dataGridView1.DataSource = table;
        }

        private char GenerateRandomASCII()
        {
            Random rand = new Random();
            var ascii = (char) rand.Next(65, 122);

            return ascii;
        }

        private int GenerateRandomInt()
        {
            Random rand = new Random();
            int data = rand.Next(1000000, int.MaxValue);
            return data;
        }
    }
}
