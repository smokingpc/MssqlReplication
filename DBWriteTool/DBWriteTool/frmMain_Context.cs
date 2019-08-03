using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBWriteTool
{
    public partial class frmMain
    {
        private CAppContext Context = new CAppContext()
        {
            ConnType = DB_CONN_TYPE.TCPIP,
            Target = "SQLEXPRESS",
            ModifyData = false,
            ReadData = true,
            WriteData = true,
            Interval = 3,
        };

        private void BindContext()
        {
            //combobox 的binding比較特別一點...
            comboBox1.DataBindings.Add("SelectedItem", this.Context, "ConnType", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
            textBox1.DataBindings.Add("Text", this.Context, "Target");
            checkBox1.DataBindings.Add("Checked", this.Context, "ReadData");
            checkBox2.DataBindings.Add("Checked", this.Context, "WriteData");
            checkBox3.DataBindings.Add("Checked", this.Context, "ModifyData");
            textBox2.DataBindings.Add("Text", this.Context, "Interval");
        }

        private void UnbindContext()
        {
            comboBox1.DataBindings.Clear();
            textBox1.DataBindings.Clear();
            textBox2.DataBindings.Clear();
            checkBox1.DataBindings.Clear();
            checkBox2.DataBindings.Clear();
            checkBox3.DataBindings.Clear();
        }

        private void WriteContext()
        {
            //讓所有跟 Context 物件綁定的資料源去UI元件撈資料回來更新
            this.BindingContext[this.Context].EndCurrentEdit();
        }
    }

    internal class CAppContext
    {
        public DB_CONN_TYPE ConnType { get; set; }
        public string Target { get; set; }
        public bool ReadData { get; set; }
        public bool WriteData { get; set; }
        public bool ModifyData { get; set; }
        public int Interval  { get; set; }

        public string DSN
        {
            get
            {
                string db_addr = "";
                string dsn = string.Format("Initial Catalog={0};Connection Timeout={1};User ID={2};Password={3}",
                                            CONST.DB_Name, CONST.DB_Timeout, CONST.DB_UID, CONST.DB_PWD);
                if (ConnType == DB_CONN_TYPE.TCPIP)
                    db_addr = Target;
                else
                    db_addr = string.Format("localhost\\{0}" , Target);

                return string.Format("Data Source={0};{1}", db_addr, dsn);
            }
        }
    }
}
