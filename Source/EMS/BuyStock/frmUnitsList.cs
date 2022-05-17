using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EMS.BuyStock
{
    public partial class frmUnitsList : Form
    {
        public frmUnitsList()
        {
            InitializeComponent();
        }

        private void frmUnitsList_Load(object sender, EventArgs e)
        {
            DataSet ds = null;
            ds = PublicDim.client.GetUnitsList();
            dgvUnitsList.DataSource = ds.Tables[0].DefaultView;
            dgvUnitsList.Columns[0].Width = 200;
        }

        private void dgvUnitsList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectDataDialog.frmSelectDateTime selectDateTime = new EMS.SelectDataDialog.frmSelectDateTime();
            selectDateTime.M_Str_units = dgvUnitsList[0, e.RowIndex].Value.ToString();
            selectDateTime.Show();
        }
    }
}