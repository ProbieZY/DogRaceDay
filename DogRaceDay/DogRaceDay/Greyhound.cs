using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace DogRaceDay
{
    class Greyhound
    {
        //起始位置
        public Point StartingPosition;
        //赛道长度
        public int RacetrackLength;
        //PictureBox对象
        public PictureBox MyPictureBox=null;
        //赛道上的位置
        public int Location = 0;
        //随机距离对象
        public Random Randomizer;
        public int Index;


        public Greyhound(PictureBox picDog)
        {
            MyPictureBox = picDog;
        }

        public bool Run()
        {
            //向前移动随机一个距离
            int distance = Randomizer.Next(1,4);
            Point p = MyPictureBox.Location;
            p.X += distance;
            //更新PictureBox在窗体的位置
            MyPictureBox.Location = p;
            //返回是否赢得比赛
            Thread.Sleep(5);
            Location = p.X;
            if (Location >= RacetrackLength)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //重置、初始化狗的位置
        public void TakeStartingPosition()
        {
            StartingPosition = MyPictureBox.Location;
        }
    }
}
