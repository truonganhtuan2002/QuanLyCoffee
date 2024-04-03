using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Model
{
    public class Bill
    {
        string tablename, drinkname;
        int counts;
        string cashier;
        public Bill() { }
        public Bill(string tablename, string drinkname, int counts, string cashier)
        {
            this.tablename = tablename;
            this.drinkname = drinkname;
            this.counts = counts;
            this.cashier = cashier;
        }
        public Bill(DataRow row)
        {
                if (row != null)
                {
                    this.TableName = row["TableName"].ToString();
                    this.DrinkName = row["DrinkName"].ToString();
                    this.Counts = (int)row["Counts"];
                    this.Cashier = row["Cashier"].ToString();
                }
        }
        public string TableName
        {
            get { return tablename; }
            set { tablename = value; }
        }
        public string DrinkName
        {
            get { return drinkname; }
            set { drinkname = value; }
        }
        public int Counts
        {
            get { return counts; }
            set { counts = value; }
        }
        public string Cashier
        {
            get { return cashier; }
            set { cashier = value; }
        }
    }
}
