using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DogRaceDay
{
    class Guy
    {
        //姓名
        public string Name;
        //下注对象
        public Bet MyBet = new Bet();
        //剩余金额
        public int Cash;
        
        public RadioButton MyRadioButton;
        public Label MyLabel;

        public void UpdateRadio()
        {
            MyRadioButton.Text = string.Format("{0} has {1} bucks", this.Name, this.Cash.ToString());
        }

        public void ClearBet()
        {
            MyLabel.Text = string.Format("{0} has't placed a bet", this.Name);
        }

        public bool PlaceBet(int Amount,int Dog)
        {

            if (Amount > this.Cash)
                return false;
            this.MyBet.Amount = Amount;
            this.MyBet.Dog = Dog;
            this.MyBet.Bettor = this;
            MyLabel.Text = MyBet.GetDescription();
            return true;

        }

        public void Collect(int Winner)
        {
            this.Cash += this.MyBet.PayOut(Winner);
            UpdateRadio();
            ClearBet();
        }
       
    }
}
