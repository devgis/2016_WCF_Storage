using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EMS.BaseInfo
{
    public partial class frmStock : Form
    {

        DBSR.cStockInfo stockinfo = new DBSR.cStockInfo();//����cStockInfo��Ķ���
        int G_Int_addOrUpdate = 0;//�������/�޸Ĳ�����ʶ
        public frmStock()
        {
            InitializeComponent();
        }

        private void tlBtnAdd_Click(object sender, EventArgs e)
        {
            this.editEnabled();//���ø����ؼ��Ŀ���״̬
            this.clearText();//����ı���
            G_Int_addOrUpdate = 0;//����0Ϊ�������
            DataSet ds = null;//�������ݼ�����
            string P_Str_newTradeCode = "";//���ÿ����Ʒ���Ϊ��
            int P_Int_newTradeCode = 0;//��ʼ����Ʒ����е�������
            ds = PublicDim.client.GetAllStock("tb_stock");//��ȡ�����Ʒ��Ϣ
            if (ds.Tables[0].Rows.Count == 0)//�ж����ݼ����Ƿ���ֵ
            {
                txtTradeCode.Text = "T1001";//����Ĭ����Ʒ���
            }
            else
            {
                P_Str_newTradeCode = Convert.ToString(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["tradecode"]);//��ȡ�Ѿ����ڵ������
                P_Int_newTradeCode = Convert.ToInt32(P_Str_newTradeCode.Substring(1, 4)) + 1;//��ȡһ�����µ�������
                P_Str_newTradeCode = "T" + P_Int_newTradeCode.ToString();//��ȡ������Ʒ���
                txtTradeCode.Text = P_Str_newTradeCode;//����Ʒ�����ʾ���ı�����
            }
        }
        //���ø���ť�Ŀ���״̬
        private void editEnabled()
        {
            groupBox1.Enabled = true;
            tlBtnAdd.Enabled = false;
            tlBtnEdit.Enabled = false;
            tlBtnDelete.Enabled = false;
            tlBtnSave.Enabled = true;
            tlBtnCancel.Enabled = true;
        }
        //���ø���ť�Ŀ���״̬
        private void cancelEnabled()
        {
            groupBox1.Enabled = false;
            tlBtnAdd.Enabled = true;
            tlBtnEdit.Enabled = true;
            tlBtnDelete.Enabled = true;
            tlBtnSave.Enabled = false;
            tlBtnCancel.Enabled = false;
        }
        //����ı���
        private void clearText()
        {
            txtTradeCode.Text= string.Empty;
            txtFullName.Text = string.Empty;
            txtType.Text = string.Empty;
            txtStandard.Text = string.Empty;
            txtUnit.Text = string.Empty;
            txtProduce.Text = string.Empty;
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
            dgvStockList.Columns[8].HeaderText = "��Ʒ�۸񣨼�Ȩƽ���۸�";
            dgvStockList.Columns[9].Visible = false;
            dgvStockList.Columns[10].HeaderText = "�̵�����";
            dgvStockList.Columns[11].Visible = false;
            dgvStockList.Columns[12].Visible = false;
        }

        private void frmStock_Load(object sender, EventArgs e)
        {
            txtTradeCode.ReadOnly = true;//������Ʒ����ı���ֻ��
            this.cancelEnabled();//���ø���ť�Ŀ���״̬
            //��ʾ���п����Ʒ��Ϣ
            dgvStockList.DataSource = PublicDim.client.GetAllStock("tb_stock").Tables[0].DefaultView;
            this.SetdgvStockListHeadText();//����DataGridView�ؼ����б���
        }

        private void tlBtnSave_Click(object sender, EventArgs e)
        {
            //�ж�����ӻ����޸�����
            if (G_Int_addOrUpdate == 0)
            {
                try
                {
                    //�������
                    stockinfo.TradeCode = txtTradeCode.Text;
                    stockinfo.FullName = txtFullName.Text;
                    stockinfo.TradeType = txtType.Text;
                    stockinfo.Standard = txtStandard.Text;
                    stockinfo.Unit = txtUnit.Text;
                    stockinfo.Produce = txtProduce.Text;
                    //ִ����Ӳ���
                    int id = PublicDim.client.AddStock(stockinfo);
                    MessageBox.Show("����--�����Ʒ����--�ɹ���", "�ɹ���ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //�޸�����
                stockinfo.TradeCode = txtTradeCode.Text;
                stockinfo.FullName = txtFullName.Text;
                stockinfo.TradeType = txtType.Text;
                stockinfo.Standard = txtStandard.Text;
                stockinfo.Unit = txtUnit.Text;
                stockinfo.Produce = txtProduce.Text;
                //ִ���޸Ĳ���
                int id = PublicDim.client.UpdateStock(stockinfo);
                MessageBox.Show("�޸�--�����Ʒ����--�ɹ���", "�ɹ���ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dgvStockList.DataSource = PublicDim.client.GetAllStock("tb_stock").Tables[0].DefaultView;//��ʾ���µĿ����Ʒ��Ϣ
            this.SetdgvStockListHeadText();//����DataGridView�ؼ��б���
            this.cancelEnabled();//���ø�����ť�Ŀ���״̬
        }

        private void tlBtnEdit_Click(object sender, EventArgs e)
        {
            this.editEnabled();//���ø�����ť�Ŀ���״̬
            G_Int_addOrUpdate = 1;//����1Ϊ�޸�����
        }

        private void tlBtnFind_Click(object sender, EventArgs e)
        {
            if (tlCmbStockType.Text == string.Empty)//�жϲ�ѯ����Ƿ�Ϊ��
            {
                MessageBox.Show("��ѯ�����Ϊ�գ�", "������ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tlCmbStockType.Focus();//ʹ��ѯ��������б�����꽹��
                return;
            }
            else
            {
                if (tlTxtFindStock.Text.Trim() == string.Empty)//�жϲ�ѯ�ؼ����Ƿ�Ϊ��
                {
                    //��ʾ���п����Ʒ��Ϣ
                    dgvStockList.DataSource = PublicDim.client.GetAllStock("tb_stock").Tables[0].DefaultView;
                    this.SetdgvStockListHeadText();//����DataGridView�ؼ����б���
                    return;
                }
            }
            DataSet ds = null;//����DataSet����
            if (tlCmbStockType.Text == "��Ʒ����") //����Ʒ���ز�ѯ
            {
                stockinfo.Produce = tlTxtFindStock.Text;//��¼��Ʒ����
                ds = PublicDim.client.FindStockByProduce(stockinfo, "tb_Stock");//������Ʒ���ز�ѯ��Ʒ��Ϣ
                dgvStockList.DataSource = ds.Tables[0].DefaultView;//��ʾ��ѯ������Ϣ
            }
            else//����Ʒ���Ʋ�ѯ
            {
                stockinfo.FullName = tlTxtFindStock.Text;//��¼��Ʒ����
                ds = PublicDim.client.FindStockByFullName(stockinfo, "tb_stock");//������Ʒ���Ʋ�ѯ��Ʒ��Ϣ
                dgvStockList.DataSource = ds.Tables[0].DefaultView;//��ʾ��ѯ������Ϣ
            }
            this.SetdgvStockListHeadText();//����DataGridView�ؼ��б���
        }

        private void tlBtnDelete_Click(object sender, EventArgs e)
        {
            if (txtTradeCode.Text.Trim() == string.Empty)//�ж��Ƿ�ѡ������Ʒ���
            {
                MessageBox.Show("ɾ��--�����Ʒ����--ʧ�ܣ�", "������ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            stockinfo.TradeCode = txtTradeCode.Text;//��¼��Ʒ���
            int id = PublicDim.client.DeleteStock(stockinfo);//ִ��ɾ������
            MessageBox.Show("ɾ��--�����Ʒ����--�ɹ���", "�ɹ���ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvStockList.DataSource = PublicDim.client.GetAllStock("tb_stock").Tables[0].DefaultView;//��ʾ���µĿ����Ʒ��Ϣ
            this.SetdgvStockListHeadText();//����DataGridView�ؼ��б���
            this.clearText();//����ı���
        }

        private void tlBtnCancel_Click(object sender, EventArgs e)
        {
            this.cancelEnabled();//���ø�����ť�Ŀ���״̬
        }

        private void dgvStockList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTradeCode.Text = this.dgvStockList[0, dgvStockList.CurrentCell.RowIndex].Value.ToString();//��ʾ��Ʒ���
            txtFullName.Text = this.dgvStockList[1, dgvStockList.CurrentCell.RowIndex].Value.ToString();//��ʾ��Ʒȫ��
            txtType.Text = this.dgvStockList[2, dgvStockList.CurrentCell.RowIndex].Value.ToString();//��ʾ��Ʒ�ͺ�
            txtStandard.Text = this.dgvStockList[3, dgvStockList.CurrentCell.RowIndex].Value.ToString();//��ʾ��Ʒ���
            txtUnit.Text = this.dgvStockList[4, dgvStockList.CurrentCell.RowIndex].Value.ToString();//��ʾ��Ʒ��λ
            txtProduce.Text = this.dgvStockList[5, dgvStockList.CurrentCell.RowIndex].Value.ToString();//��ʾ��Ʒ����
        }

        private void tlBtnExit_Click(object sender, EventArgs e)
        {
            this.Close();//�رյ�ǰ����
        }
    }
}