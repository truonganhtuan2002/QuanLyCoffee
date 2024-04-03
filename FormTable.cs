using System;
using Model;
using System.Data;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BusinessLayer;

namespace GUILayer
{
    public partial class FormTable : Form
    {
        private ManageList<DrinkType> listDrinkType = new ManageList<DrinkType>();
        private ManageList<Drink> listDrink = new ManageList<Drink>();
        private ManageList<Table> listTable = new ManageList<Table>();
        private ManageList<Bill> listBill = new ManageList<Bill>();
        string strBill, strCashier;
        public FormTable()
        {
            InitializeComponent();
            LoadTable();
            LoadBill();
        }
        // An 2 group box chuc nang
        private void HideGroupBox()
        {
            grbAddDrink.Visible = false;
            grbSwitchTable.Visible = false;
        }
        /*---------------------------------TABLE + BILL-----------------------------------------------*/

        // Load danh sach Table
        private void LoadTable()
        {
            try
            {
                pnlTable.Controls.Clear();
                BUS_Table.Instance.GetList(listTable);
                int x = 10;
                int y = 10;
                for (int i = 0; i < listTable.Count; i++)
                {
                    Button btn = new Button()
                    {
                        Name = "btnTable" + (i + 1),
                        Text = listTable[i].Name,
                        Tag = listTable[i].Total.ToString(),
                        Width = 100,
                        Height = 50,
                        Location = new Point(x, y),
                    };
                    if (listTable[i].Status == "Empty")
                    {
                        btn.BackColor = ColorTranslator.FromHtml("snow");
                    }
                    else if (listTable[i].Status == "Online")
                    {
                        btn.BackColor = ColorTranslator.FromHtml("red");
                    }
                    if (x < pnlTable.Width - 220)
                    {
                        x += 110;
                    }
                    else
                    {
                        x = 10;
                        y += 60;
                    }
                    btn.MouseClick += new MouseEventHandler(btnTable_MouseClick);
                    pnlTable.Controls.Add(btn);
                }
            }
            catch
            {
                MessageBox.Show("Không có thông tin ! ");
            }
        }

        //


        //

        // Load Bill        
        private void LoadBill()
        {
            try
            {
                pnlBill.Controls.Clear();
                strBill = " ";
                BUS_Bill.Instance.GetList(listBill, txtNameTable.Text);
                int y = 10;
                for (int i = 0; i < listBill.Count; i++)
                {
                    strBill += (i + 1) + ".     " + listBill[i].DrinkName + "  X  " + listBill[i].Counts.ToString() + "\n";
                    Label lbl = new Label()
                    {
                        //Name = "btnFB" + i,
                        //Text = "         " + (i + 1) + ".     " + listBill[i].DrinkName + "  X  " + listBill[i].Counts.ToString(),
                        Name = "lblBillItem" + i,
                        Text = $"{(i + 1)}. {listBill[i].DrinkName}  X  {listBill[i].Counts}",
                        //
                        Width = pnlBill.Width - 20,
                        Height = 20,
                        Location = new Point(5, y),
                        BackColor = Color.Red,
                        ForeColor = Color.Green,
                    };
                    y += 25;
                    strCashier = listBill[i].Cashier;
                    pnlBill.Controls.Add(lbl);
                }
            }
            catch
            {
                MessageBox.Show("Hoá đơn này không có sẵn");
            }
        }

        //Khi Click vao Table
        private void btnTable_MouseClick(object sender, EventArgs e)
        {
            //tra ve trang thai ban theo mau sac cua btnTable
            if (((Button)sender).BackColor.ToString() == "Color [Snow]")
            {
                txtSTT.Text = "Empty";
            }
            else if (((Button)sender).BackColor.ToString() == "Color [Red]")
            {
                txtSTT.Text = "Online";
            }
            //tra ve ten ban
            txtNameTable.Text = ((Button)sender).Text;
            //Tra ve tong tien
            txtTotal.Text = ((Button)sender).Tag.ToString();
            LoadBill();
        }
        /*---------------------------------ADD DRINK-----------------------------------------------*/

        //Xu lu khi chon chuc nang Add Drink
        private void btnAddDrink_Click(object sender, EventArgs e)
        {
            HideGroupBox();
            try
            {
                if (txtSTT.Text == "Online")
                {
                    grbAddDrink.Visible = true;
                    LoadDataForAddDrinkGRB();
                }
                else if (txtSTT.Text == "Empty")
                {
                    DialogResult ms = MessageBox.Show("Bạn có muốn mở bàn này ?", "Mở bàn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ms == DialogResult.Yes)
                    {
                        grbAddDrink.Visible = true;
                        LoadDataForAddDrinkGRB();
                    }
                }
            }
            catch { }
        }

        private void cbbDrinkTypeAD_SelectedIndexChanged(object sender, EventArgs e)
        {
            BUS_Drink.Instance.GetList(listDrink);
            BUS_Drink.Instance.AddDrinkToComboBoxFromType(listDrink, cbbDrinkAD, cbbDrinkTypeAD.Text);
        }

        //Xu ly trong GroupBox Add Drink        
        private void LoadDataForAddDrinkGRB()
        {
            txtTableAD.Text = txtNameTable.Text;
            BUS_DrinkType.Instance.GetList(listDrinkType);
            BUS_DrinkType.Instance.LoadDrinkTypeToComboBox(listDrinkType, cbbDrinkTypeAD);
        }

        //Chuyen trang thai Table sang Online
        private void SetTableOnline()
        {
            BUS_Table.Instance.SetTableOnline(txtNameTable.Text);
        }

        //Tinh tong tien
        private void setTotal()
        {
            float DrinkTotal = getPrice() * float.Parse(nUDQuantityAD.Value.ToString());
            BUS_Table.Instance.SetTotal(txtNameTable.Text, DrinkTotal);
        }

        //Them do uong moi
        private void AddNewDrink()
        {
            Bill bill = new Bill(txtTableAD.Text, cbbDrinkAD.Text, Int32.Parse(nUDQuantityAD.Value.ToString()), FormLogin.Cashier);
            BUS_Bill.Instance.Create(bill);
            setTotal();
        }

        //Tang so do uong
        private void IncreaseDrink()
        {
            Bill bill = new Bill(txtTableAD.Text, cbbDrinkAD.Text, Int32.Parse(nUDQuantityAD.Value.ToString()), FormLogin.Cashier);
            BUS_Bill.Instance.Update(bill, "");
            setTotal();
        }

        //Lay gia do uong
        private float getPrice()
        {
            BUS_Drink.Instance.GetList(listDrink);
            return BUS_Drink.Instance.getPrice(listDrink, cbbDrinkAD.Text);
        }

        bool isDrink = false;
        //Kiem tra xem mon da ton tai chua , neu co roi thi true
        public void isCountDrink()
        {
            try
            {
                int CountDrink = BUS_Bill.Instance.GetCountDrink(txtTableAD.Text, cbbDrinkAD.Text);
                if (CountDrink > 0)
                {
                    isDrink = true;
                }
            }
            catch
            {
                isDrink = false;
            }
        }

        //Submit AddDrink GRB
        private void btnAddAD_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSTT.Text == "Empty")
                {
                    SetTableOnline();
                    AddNewDrink();
                }
                else if (txtSTT.Text == "Online")
                {
                    //Ban dang hoat dong. chi them mon
                    isCountDrink();
                    if (isDrink == false)
                    {
                        //Neu mon chua co thi them mon
                        AddNewDrink();
                    }
                    else
                    {
                        //Neu mon co roi thi tang so luong
                        IncreaseDrink();
                    }
                }
                HideGroupBox();
                LoadTable();
                LoadBill();
                //Do khong the goi duoc phuong thuc ClickTable de cap nhat lai Total Price
                float DrinkTotal = float.Parse(txtTotal.Text) + getPrice() * float.Parse(nUDQuantityAD.Value.ToString());
                txtTotal.Text = DrinkTotal.ToString();
                txtSTT.Text = "Online";
                MessageBox.Show("Thêm đồ uống thành công ! ", "Tuyệt vời", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Thêm thất bại , hãy thử lại!", "Đã có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /*---------------------------------SWITCH TABLE--------------------------------------------*/
        private void LoadDataForSwitchTableGRB()
        {
            txtFromTable.Text = txtNameTable.Text;
            BUS_Table.Instance.GetList(listTable);
            //Chi cho phep nhung ban khac Ban hien tai va hien dang Empty
            BUS_Table.Instance.getAvailableTable(listTable, cbbToTable);
        }

        private void btnSwitchTable_Click(object sender, EventArgs e)
        {
            HideGroupBox();
            try
            {
                if (txtSTT.Text == "Online")
                {
                    grbSwitchTable.Visible = true;
                    LoadDataForSwitchTableGRB();
                }
                else if (txtSTT.Text == "Empty")
                {
                    MessageBox.Show("Bàn này hiện đang trống !", "Đã cõ lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch { }
        }

        private void MoveTable()
        {            
            string TableFrom = txtFromTable.Text;
            string TableTo = cbbToTable.Text;
            float TotalSWT = BUS_Table.Instance.getTotal(listTable, TableFrom);
            BUS_Bill.Instance.UpdateTableInBill(TableFrom, TableTo);
            BUS_Table.Instance.MoveTable(TableFrom, TableTo, TotalSWT);
        }
        //Submit chuyen ban
        private void btnAcceptSwitch_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult ms = MessageBox.Show("Bạn có muốn chuyển từ  " + txtFromTable.Text + " sang " + cbbToTable.Text + " ?", "Thông báo", MessageBoxButtons.YesNo);
                if (ms == DialogResult.Yes)
                {
                    MoveTable();
                    HideGroupBox();
                    LoadTable();
                    LoadBill();
                    MessageBox.Show("Chuyển bàn thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Chuyển bàn thất bại !", "Đã có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*---------------------------------PURCHASE------------------------------------------------*/

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            HideGroupBox();
            try
            {
                if (txtSTT.Text == "Online")
                {
                    DialogResult ms = MessageBox.Show("Xác nhận thanh toán : " + txtNameTable.Text + "\n\nTổng giá: " + txtTotal.Text + " VND", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.None);
                    if (ms == DialogResult.Yes)
                    {
                        BUS_Table.Instance.ClearTable(txtNameTable.Text);
                        BUS_Bill.Instance.Delete(txtNameTable.Text);
                        txtSTT.Text = "Empty";
                        txtTotal.Text = "0";
                        //MessageBox.Show("Thanh toán thành công !  " + txtNameTable.Text, "Tuyệt vời", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show("Thanh toán thành công !  ","Tuyệt vời", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    LoadTable();
                    LoadBill();
                }
                else if (txtSTT.Text == "Empty")
                {
                    MessageBox.Show("Bàn này hiện đang trống !", "Đã có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch { }
        }
        /*-------------------------------PRINT BILL------------------------------------------------*/
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                printDialogBill.Document = printDocumentBill;
                if (printDialogBill.ShowDialog() == DialogResult.OK)
                {
                    printDocumentBill.Print();
                }
            }
            catch
            {
                MessageBox.Show("In hoá đơn không thành công !", "Đã có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocumentBill_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            DateTimePicker datetime = new DateTimePicker();
            string HoaDon = "";
            HoaDon += "\n" + "Dutra Coffee" + "\n";
            HoaDon += "\n" + "Địa chỉ : 553 Nguyễn Công Hoan - Đồng Quang - Thành phố Thái Nguyên - Thái Nguyên" + "\n\n\n";
            HoaDon += "\n" + "Hoá đơn " + txtNameTable.Text + "        \n\n\n";
            HoaDon += strBill;
            HoaDon += "\n\n\nThời gian: " + datetime.Value.ToShortTimeString() + ". " + datetime.Value.ToShortDateString() + "\n";
            HoaDon += "Nhân viên : " + strCashier + "\n";
            HoaDon += "\nThành tiền : " + txtTotal.Text + " VNĐ\n";
            e.Graphics.DrawString(HoaDon, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, 100, 200);
        }

        private void FormTable_Load(object sender, EventArgs e)
        {

        }

        private void pnlBill_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtTotal_Click(object sender, EventArgs e)
        {

        }

        private void grbInfo_MouseCaptureChanged(object sender, EventArgs e)
        {
            label14.Hide();
            //label15.Text = FormLogin.Cashier;
            //label16.Hide();
            //pictureBox1.Hide();
            //pictureBox2.Hide();
            //pictureBox3.Hide();
        }
    }
}
