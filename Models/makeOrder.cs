using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NomNomScratch.Models
{
    public class makeOrder
    {
        private NomNomEntities1 db = new NomNomEntities1();
        public int OrderID { get; set; }
        public List<string> foodName = new List<string>();
        public List<int> qnty = new List<int>();
        public List<int> foodPrice = new List<int>();
        public int CookID { get; set; }
        public int DeliverymanID { get; set; }
        public string Date { get; set; }
        public int UserID { get; set; }
        public string UName { get; set; }
        public string UserAddress { get; set; }
        public string Mobile { get; set; }
        public int Total { get; set; }
        public string CookName { get; set; }
        public string DevName { get; set; }
        public int assign { get; set; }
        public void Input (int orderid,string info , int userid,string date,int cookid,int manid,int? pos) {

            if (pos == null)
                assign = 0;
            else 
            {
                assign = (int)pos;
            }

            OrderID = orderid;
            CookID = cookid;
            DeliverymanID = manid;
            Date = date;

            var data = db.UserRegisters.FirstOrDefault(acc => acc.UserID == userid);
            UserID = userid;
            UName = data.Name;
            UserAddress = data.Address;
            Mobile = data.Mobile.ToString();
            Mobile = '0' + Mobile;
            CookName = db.Staffs.FirstOrDefault(x => x.StaffID == cookid).Name;
            CookName = CookName + '(' + cookid.ToString() + ')';
            DevName = db.Staffs.FirstOrDefault(x => x.StaffID == DeliverymanID).Name;
            DevName = DevName + '(' + DeliverymanID.ToString() + ')';
            bool foodTake = true;
            bool numberTake = false;
            bool priceTake = false;

       
            String food = "";
            string cnt = "";
            string totPrice ="";
            int sub = 0;

            for(int i = 0; i < info.Length; i++)
            {
                if(info[i] == 'F' && info[i+1] == 'F')
                {
                    i += 2;
                    if (totPrice != "")
                    {
                        foodPrice.Add(int.Parse(totPrice));
                        sub += int.Parse(totPrice);
                    }
                    totPrice = "";
                    foodTake = true;
                    numberTake = false;
                    priceTake = false;

                }
                else if (info[i] == 'Q' && info[i + 1] == 'Q')
                {
                    i += 2;
                    foodName.Add(food);
                    food = "";
                    foodTake = false;
                    numberTake = true;
                    priceTake = false;

                }
               else  if (info[i] == 'P' && info[i + 1] == 'P')
                {
                    i += 2;
                    qnty.Add(int.Parse(cnt));
                    cnt = "";
                    foodTake = false;
                    numberTake = false;
                    priceTake = true;

                }
               else if (info[i] == 'E' && info[i + 1] == 'E')
                {
                    i += 2;
                    foodPrice.Add(int.Parse(totPrice));
                    totPrice = "";
                    foodTake = true;
                    numberTake = false;
                    priceTake = false;
                    break;
                }

                if (foodTake)
                    food = food + info[i];
                else if (numberTake)
                    cnt = cnt + info[i];
                else if (priceTake)
                    totPrice = totPrice + info[i];
            }
            Total = sub;
        }
    }

     






}