using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogRaceDay
{
    class Bet
    {
        public int Amount;
        public int Dog;
        public Guy Bettor;

        //返回Bets信息栏文本信息
        public string GetDescription()
        {
            return Bettor.Name + " bets " + Amount.ToString() + " bucks on dog #" + Dog.ToString();
        }

        //返回输赢金额
        public int PayOut(int Winner)
        {
            if (Winner == Dog)
            {
                return Amount;
            }
            else
            {
                return -Amount;
            }
        }
    }
}
