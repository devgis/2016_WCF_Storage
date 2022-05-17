using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EMS.SelectDataDialog
{
    public partial class frmSetStockLimit : Form
    {
        public frmSetStockLimit()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //��֤������ı�����Ϊ���������֡�
            for (int i = 0; i < txtUpperLimit.Text.Length; i++)
            {
                if (!Char.IsNumber(txtUpperLimit.Text, i))
                {
                    MessageBox.Show("����������ñ���Ϊ���������֣�", "������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            for (int i = 0; i < txtLowerLimit.Text.Length; i++)
            {
                if (!Char.IsNumber(txtLowerLimit.Text,i))
                {
                    MessageBox.Show("����������ñ���Ϊ���������֣�", "������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            //��������

            DBSR.cStockInfo stock = new DBSR.cStockInfo();
            stock.TradeCode = groupBox1.Text.Substring(1, 5);
            stock.UpperLimit = Convert.ToSingle(txtUpperLimit.Text);
            stock.LowerLimit = Convert.ToSingle(txtLowerLimit.Text);
            int d = PublicDim.client.UpdateStockLimit(stock);
            MessageBox.Show("������������óɹ���", "�ɹ���ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}