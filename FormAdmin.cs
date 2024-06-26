﻿using System;
using System.Data;
using System.Windows.Forms;
using Model;
using BusinessLayer;

namespace GUILayer
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }
        private void FormAdmin_Load(object sender, EventArgs e)
        {
            Display.FormatTable(dgvAccount);
            Display.FormatTable(dgvTable);
            Display.FormatTable(dgvDrink);
            Display.FormatTable(dgvDrinkType);
        }
        /*--------------------------ACCOUNT----------------------------------------*/
        // Đọc dữ liệu của hàng được chọn vào biến 
        private void dgvAccount_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvAccount.SelectedRows)
            {
                txbUserName.Text = row.Cells[0].Value.ToString();
                txbDisplayName.Text = row.Cells[1].Value.ToString();
                txbPassWord.Text = row.Cells[2].Value.ToString();
                cbType.Text = row.Cells[3].Value.ToString();
            }
        }

        //Nút Show cũng xem như nút Reset Bảng, xoá hết rồi mới thêm lại
        private void btnShowAccount_Click(object sender, EventArgs e)
        {
            BUS_Account.Instance.ShowDGV(dgvAccount);
            //Cho phép các Button khác chạy
            btnEditAccount.Enabled = true;
            btnDeleteAccount.Enabled = true;
            btnAddAccount.Enabled = true;
        }

        // Thêm Account
        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string newUserName = txbUserName.Text;
            string newDisplayName = txbDisplayName.Text;
            string newPassWord = txbPassWord.Text;
            string newType = cbType.Text;
            //Tạo đối tượng mới rồi thêm vào Danh Sách Tài Khoản
            Account newAccount = new Account(newUserName, newDisplayName, newPassWord, newType);
            //Cập nhật lại Database
            BUS_Account.Instance.Create(newAccount);
            btnShowAccount.PerformClick();
        }

        //Xoá tài khoản được chọn
        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn xoá ?", "Cảnh báo !", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //Không khởi tạo giá trị trình biên dịch nó báo lỗi
                string deleteUserName = "";
                //Xoá trong Table
                foreach (DataGridViewRow row in dgvAccount.SelectedRows)
                {
                    deleteUserName = row.Cells[0].Value.ToString();
                }
                //Xoá trong Database
                BUS_Account.Instance.Delete(deleteUserName);
                btnShowAccount.PerformClick();
            }
        }

        //Update Account
        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            string oldUserName = "", newUserName, newDisplayName, newPassWord, newType;
            //Dữ liệu cũ thì lấy từ Hàng được chọn, chỉ cần Khoá chính là đủ
            foreach (DataGridViewRow row in dgvAccount.SelectedRows)
            {
                oldUserName = row.Cells[0].Value.ToString();
            }
            //Dữ liệu mới thì lấy từ TextBox
            newUserName = txbUserName.Text;
            newDisplayName = txbDisplayName.Text;
            newPassWord = txbPassWord.Text;
            newType = cbType.Text;
            Account updateAccount = new Account(newUserName, newDisplayName, newPassWord, newType);
            //Sửa Database            
            BUS_Account.Instance.Update(updateAccount, oldUserName);
            //Sửa trong List
            btnShowAccount.PerformClick();
        }

        /*--------------------------TABLE----------------------------------------*/
        private void btnShowTable_Click(object sender, EventArgs e)
        {
            BUS_Table.Instance.ShowDGV(dgvTable);
            dgvTable.Columns["Status"].Visible = false;
            dgvTable.Columns["Total"].Visible = false;
            //Cho phép các Button khác chạy
            btnAddTable.Enabled = true;
            btnEditTable.Enabled = true;
            btnDeleteTable.Enabled = true;
        }

        private void dgvTable_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvTable.SelectedRows)
            {
                txbTableID.Text = row.Cells[0].Value.ToString();
                txbTableName.Text = row.Cells[1].Value.ToString();
            }
        }

        private void btnEditTable_Click(object sender, EventArgs e)
        {
            int oldID = 0;
            foreach (DataGridViewRow row in dgvTable.SelectedRows)
            {
                oldID = Int32.Parse(row.Cells[0].Value.ToString());
            }
            int newID = Int32.Parse(txbTableID.Text);
            string newTableName = txbTableName.Text;
            Table updateTable = new Table(newID, newTableName, "Empty", 0);
            //Sửa Database            
            BUS_Table.Instance.Update(updateTable, oldID);
            btnShowTable.PerformClick();
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            int newTableID = Int32.Parse(txbTableID.Text);
            string newTableName = txbTableName.Text;
            Table newTable = new Table(newTableID, newTableName, "Empty", 0);
            //Cập nhật lại Database
            BUS_Table.Instance.Create(newTable);
            btnShowTable.PerformClick();
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn xoá ?", "Cảnh báo !", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int deleteTableID = 0;
                //Xoá trong Table
                foreach (DataGridViewRow row in dgvTable.SelectedRows)
                {
                    deleteTableID = Int32.Parse(row.Cells[0].Value.ToString());
                }
                //Xoá trong Database
                BUS_Table.Instance.Delete(deleteTableID);
                btnShowTable.PerformClick();
            }
        }

        /*--------------------------DRINK----------------------------------------*/
        private void LoadDrinkTypeToComboBox()
        {
            ManageList<DrinkType> listType = new ManageList<DrinkType>();
            BUS_DrinkType.Instance.GetList(listType);
            BUS_DrinkType.Instance.LoadDrinkTypeToComboBox(listType, cbDrinkType);
        }

        private void btnShowDrink_Click(object sender, EventArgs e)
        {
            BUS_Drink.Instance.ShowDGV(dgvDrink);
            LoadDrinkTypeToComboBox();
            //Cho phép các Button khác chạy
            btnAddDrink.Enabled = true;
            btnEditDrink.Enabled = true;
            btnDeleteDrink.Enabled = true;
        }

        private void dgvDrink_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDrink.SelectedRows)
            {
                txbDrinkID.Text = row.Cells[0].Value.ToString();
                txbDrinkName.Text = row.Cells[1].Value.ToString();
                cbDrinkType.Text = row.Cells[2].Value.ToString();
                nmDrinkPrice.Text = row.Cells[3].Value.ToString();
            }
        }

        private void btnEditDrink_Click(object sender, EventArgs e)
        {
            int oldDrinkID = 0, newDrinkID = 0, newDrinkPrice = 0;
            string newDrinkName = "", newDrinkType = "";
            //Dữ liệu cũ thì lấy từ Hàng được chọn, chỉ cần Khoá chính là đủ
            foreach (DataGridViewRow row in dgvDrink.SelectedRows)
            {
                oldDrinkID = Int32.Parse(row.Cells[0].Value.ToString());
            }
            //Dữ liệu mới thì lấy từ TextBox
            newDrinkID = Int32.Parse(txbDrinkID.Text);
            newDrinkName = txbDrinkName.Text;
            newDrinkType = cbDrinkType.Text;
            newDrinkPrice = Int32.Parse(nmDrinkPrice.Value.ToString());
            Drink updateDrink = new Drink(newDrinkID, newDrinkName, newDrinkType, newDrinkPrice);
            //Sửa Database            
            BUS_Drink.Instance.Update(updateDrink, oldDrinkID);
            btnShowDrink.PerformClick();
        }

        private void btnAddDrink_Click(object sender, EventArgs e)
        {
            int newDrinkID = Int32.Parse(txbDrinkID.Text);
            string newDrinkName = txbDrinkName.Text;
            string newDrinkType = cbDrinkType.Text;
            float newDrinkPrice = float.Parse(nmDrinkPrice.Value.ToString());
            Drink newDrink = new Drink(newDrinkID, newDrinkName, newDrinkType, newDrinkPrice);
            //Cập nhật lại Database
            BUS_Drink.Instance.Create(newDrink);
            btnShowDrink.PerformClick();
        }

        private void btnDeleteDrink_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn xoá ? ", "Cảnh báo!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int deleteDrinkID = 0;
                //Xoá trong Table
                foreach (DataGridViewRow row in dgvDrink.SelectedRows)
                {
                    deleteDrinkID = Int32.Parse(row.Cells[0].Value.ToString());
                }
                //Xoá trong Database
                BUS_Drink.Instance.Delete(deleteDrinkID);
                btnShowDrink.PerformClick();
            }
        }
        //Tim kiem 
        private void txbSearchDrinkName_TextChanged(object sender, EventArgs e)
        {
            BUS_Drink.Instance.SearchDrink(txbSearchDrinkName.Text, dgvDrink);
        }
        /*--------------------------DRINKTYPE------------------------------------*/
        private void dgvDrinkType_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDrinkType.SelectedRows)
            {
                txbDrinkTypeID.Text = row.Cells[0].Value.ToString();
                txbDrinkTypeName.Text = row.Cells[1].Value.ToString();
            }
        }
        private void btnShowDrinkType_Click(object sender, EventArgs e)
        {
            BUS_DrinkType.Instance.ShowDGV(dgvDrinkType);
            //Cho phép các Button khác chạy
            btnAddDrinkType.Enabled = true;
            btnEditDrinkType.Enabled = true;
            btnDeleteDrinkType.Enabled = true;
        }

        private void btnAddDrinkType_Click(object sender, EventArgs e)
        {
            int newDrinkTypeID = Int32.Parse(txbDrinkTypeID.Text);
            string newDrinkTypeName = txbDrinkTypeName.Text;
            DrinkType newDrinkType = new DrinkType(newDrinkTypeID, newDrinkTypeName);
            //Cập nhật lại Database
            BUS_DrinkType.Instance.Create(newDrinkType);
            btnShowDrinkType.PerformClick();
        }

        private void btnEditDrinkType_Click(object sender, EventArgs e)
        {
            int oldDrinkTypeID = 0, newDrinkTypeID = 0;
            string newDrinkTypeName = "";
            //Dữ liệu cũ thì lấy từ Hàng được chọn, chỉ cần Khoá chính là đủ
            foreach (DataGridViewRow row in dgvDrinkType.SelectedRows)
            {
                oldDrinkTypeID = Int32.Parse(row.Cells[0].Value.ToString());
            }
            //Dữ liệu mới thì lấy từ TextBox
            newDrinkTypeID = Int32.Parse(txbDrinkTypeID.Text);
            newDrinkTypeName = txbDrinkTypeName.Text;
            DrinkType updateDrinkType = new DrinkType(newDrinkTypeID, newDrinkTypeName);
            //Sửa Database            
            BUS_DrinkType.Instance.Update(updateDrinkType, oldDrinkTypeID);
            btnShowDrinkType.PerformClick();
        }

        private void btnDeleteDrinkType_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn xoá ?", "Cảnh báo !", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int deleteDrinkTypeID = 0;
                //Xoá trong Table
                foreach (DataGridViewRow row in dgvDrinkType.SelectedRows)
                {
                    deleteDrinkTypeID = Int32.Parse(row.Cells[0].Value.ToString());
                }
                //Xoá trong Database
                BUS_DrinkType.Instance.Delete(deleteDrinkTypeID);
                btnShowDrinkType.PerformClick();
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        //private void label7_Click(object sender, EventArgs e)
        //{

        //}
    }
}
