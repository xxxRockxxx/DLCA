using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLCA
{
    class Dlca:Matrix
    {
        private void Work()
        {
            while (true)
            {
                MoveCell();
                Show show = new Show();
                show.DrawMatrix(_Matrix);
            }
        }
        public Dlca(int Radius) : base(Radius)
        {
            GenerateCircle(Radius, _lengthX / 2, _lengthY / 2);
            Work();
        }

        private void GenerateCircle(int Radius, int centerX, int centerY)
        {
            //Сейчас у вас эта штука генерируется строго по центру матрицы
            //int rd = Radius;
            //int minus = 1;
            //int UpY = _lengthY / 2;
            //int DownY = _lengthY / 2;
            //int rightx = _lengthX / 2;
            //int leftx = _lengthX / 2;
            Id++;
            cell.Add(Id, 1);
            for (int y = centerY - Radius; y <= centerY + Radius; y++)
                for (int x = centerX - Radius; x <= centerX + Radius; x++)
                {
                    if ((x-centerX)* (x - centerX) + (y - centerY) * (y - centerY)<=Radius*Radius)                    
                        _Matrix[x, y] = Id;
                }

            //while (minus <= Radius)
            //{
            //    rd -= minus;
            //    if (UpY != DownY & rd<=0)
            //    {
            //        _Matrix[DownY, rightx] = Id;
            //        _Matrix[DownY, leftx] = Id;
            //    }

            //    if (rd <= 0)
            //    {
            //        _Matrix[UpY, rightx] = Id;
            //        _Matrix[UpY, leftx] = Id;
            //    }
                
            //    if (rd <= 0)
            //    {
            //        rd = Radius;
            //        minus++;
            //        UpY--;
            //        DownY++;
            //        rightx = _lengthX / 2;
            //        leftx = _lengthX / 2;
            //    }
            //    else
            //    {
            //        rightx++;
            //        leftx--;
            //    }
                
            //}

        }
    }
}
