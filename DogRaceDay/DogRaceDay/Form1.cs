using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DogRaceDay
{
    public partial class Form1 : Form
    {
        //初始化对象
        Random random = new Random();
        Greyhound[] Dog = new Greyhound[4];
        PictureBox[] picDog = new PictureBox[4];
        Bet[] bet = new Bet[3];
        Guy[] guyArray = new Guy[3];
        public Form1()
        {
            InitializeComponent();
            
            //初始化窗体
            picDog[0] = picDog1;
            picDog[1] = picDog2;
            picDog[2] = picDog3;
            picDog[3] = picDog4;
            for (int i = 0; i < 4; i++)
            {
                Dog[i] = new Greyhound(picDog[i]);
                Dog[i].Index = i + 1;
                Dog[i].RacetrackLength = 425;
                Dog[i].Randomizer = random;
                Dog[i].TakeStartingPosition();
            }
            guyArray[0] = new Guy() { Name = "Joe", Cash = 50, MyRadioButton = rbtnJoe, MyLabel = labJoe };
            guyArray[1] = new Guy() { Name = "Bob", Cash = 75, MyRadioButton = rbtnBob, MyLabel = labBob };
            guyArray[2] = new Guy() { Name = "Al", Cash = 45, MyRadioButton = rbtnAl, MyLabel = labAl };

            labMinimumBet.Text = "Minimum bet: " + numberMoney.Minimum.ToString() + " bucks!";
            foreach (Guy guy in guyArray)
            {
                //初始化Bets栏信息
                guy.ClearBet();

                //此处如果执行下面的初始化，radioButton1_CheckedChanged里面则不能使用substring截取名字信息
                //因为Al只有两个字符
                //guy.UpdateRadio();
            }
        }

        //更新Label4的值
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rd = sender as RadioButton;
            label4.Text = rd.Text;
        
            //label4.Text = rd.Text.Substring(0, 3);
        }

        //Bets按钮功能
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Guy guy in guyArray)
            {
                if (guy.MyRadioButton.Checked)
                {
                    //更新Bets信息栏文本信息
                    guy.PlaceBet((int)numberMoney.Value, (int)numberDog.Value);
                    //更新单选按钮文本信息
                    guy.UpdateRadio();
                }
            }
        }


        private void EndRace(int Winner)
        {
            foreach (Greyhound greyhound in Dog)
            {
                greyhound.TakeStartingPosition();
            }
            foreach (Guy guy in guyArray)
            {
                guy.Collect(Winner);
            }
            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            while (true)
            {
                foreach (Greyhound greyhound in Dog)
                {
                    if (greyhound.Run())
                    {
                        MessageBox.Show(greyhound.Index.ToString() + "号猎犬赢得比赛！");
                        EndRace(greyhound.Index);
                        return;
                    }
                    else
                    {
                        //暂停循环，刷新窗体
                        Application.DoEvents();
                    }
                }
            }
        }
    }
}

 