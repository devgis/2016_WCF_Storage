using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EMS.Stock
{
    public partial class frmCheckStock : Form
    {
        DBSR.cStockInfo stockinfo = new DBSR.cStockInfo();//����cStockInfo��Ķ���
        string G_Str_tradecode = "";//��¼Ҫ�̵����Ʒ���

        public frmCheckStock()
        {
            InitializeComponent();
        }
        //����DataGridView�б���
        private void SetdgvStockListHeadText()
        {
            dgvStockList.Columns[0].HeaderText = "��Ʒ���";
            dgvStockList.Columns[1].HeaderText = "��Ʒ����";
            dgvStockList.Columns[2].HeaderText = "��Ʒ�ͺ�";
            dgvStockList.Columns[3].HeaderText = "��Ʒ���";
            dgvStockList.Columns[4].HeaderText = "��Ʒ��λ";
            dgvStockList.Columns[5].HeaderText = "��Ʒ����";
            dgvStockList.Columns[6].HeaderText = "�������";
            dgvStockList.Columns[7].Visible = false;
            dgvStockList.Columns[8].Visible = false;
            dgvStockList.Columns[9].Visible = false;
            dgvStockList.Columns[10].HeaderText = "�̵�����";
            dgvStockList.Columns[11].Visible = false;
            dgvStockList.Columns[12].Visible = false;
        }
        private void tlBtnFind_Click(object sender, EventArgs e)
        {
            if (tlCmbStockType.Text == string.Empty)//�жϲ�ѯ����Ƿ�Ϊ��
            {
                MessageBox.Show("��ѯ�����Ϊ�գ�", "������ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tlCmbStockType.Focus();//ʹ��ѯ��������б������꽹��
                return;
            }
            else
            {
                if (tlTxtFindStock.Text.Trim() == string.Empty)//�ж��Ƿ������˲�ѯ�ؼ���
                {
                    dgvStockList.DataSource = PublicDim.client.GetAllStock("tb_stock").Tables[0].DefaultView;//��ȡ������Ʒ��Ϣ����ʾ
                    this.SetdgvStockListHeadText();//����DataGridView�ؼ��б���
                    return;
                }
            }
            DataSet ds = null;//����DataSet����
            if (tlCmbStockType.Text == "��Ʒ����")//����Ʒ���ز�ѯ
            {
                stockinfo.Produce = tlTxtFindStock.Text;//��¼��Ʒ����
                ds = PublicDim.client.FindStockByProduce(stockinfo, "tb_stock");//������Ʒ���ز�ѯ��Ϣ
                dgvStockList.DataSource = ds.Tables[0].DefaultView;//��ʾ��ѯ������Ϣ
            }
            else//����Ʒ���Ʋ�ѯ
            {
                stockinfo.FullName = tlTxtFindStock.Text;//��¼��Ʒ����
                ds = PublicDim.client.FindStockByFullName(stockinfo, "tb_stock");//������Ʒ���Ʋ�ѯ��Ϣ
                dgvStockList.DataSource = ds.Tables[0].DefaultView;//��ʾ��ѯ������Ϣ
            }
            this.SetdgvStockListHeadText();//����DataGridView�ؼ��б���
        }

        private void frmCheckStock_Load(object sender, EventArgs e)
        {
            dgvStockList.DataSource = PublicDim.client.GetAllStock("tb_stock").Tables[0].DefaultView;//��ʾ������Ʒ��Ϣ
            this.SetdgvStockListHeadText();//����DataGridView�ؼ��б���
        }

        private void dgvStockList_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            tltxtFullName.Text = dgvStockList[1, e.RowIndex].Value.ToString();//��ʾ��Ʒ����
            G_Str_tradecode = dgvStockList[0, e.RowIndex].Value.ToString();//��¼��Ʒ���
        }

        private void tlbtnCheckStock_Click(object sender, EventArgs e)
        {
            if (tltxtCheckStock.Text == string.Empty)//�ж��Ƿ��������̵�����
            {
                MessageBox.Show("�̵���������Ϊ�գ�","������ʾ",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            //��֤������ı�����Ϊ����������
            for (int i = 0; i < tltxtCheckStock.Text.Length; i++)
            {
                if (!Char.IsNumber(tltxtCheckStock.Text, i))//�ж��Ƿ�Ϊ����
                {
                    MessageBox.Show("����������ñ���Ϊ���������֣�", "������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            stockinfo.TradeCode = G_Str_tradecode;//������Ʒ���
            stockinfo.Check = Convert.ToSingle(tltxtCheckStock.Text);//�����̵�����
            int d = PublicDim.client.CheckStock(stockinfo);//ִ�п���̵����
            dgvStockList.DataSource = PublicDim.client.GetAllStock("tb_stock").Tables[0].DefaultView;//��ʾ���µĿ����Ʒ��Ϣ
            this.SetdgvStockListHeadText();//����DataGridView�ؼ��б���
            MessageBox.Show("��������Ʒ�̵�ɹ���","�ɹ���ʾ",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void tlBtnExit_Click(object sender, EventArgs e)
        {
            this.Close();//�رյ�ǰ����
        }
    }
}