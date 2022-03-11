using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLCA
{
    class Matrix
    {
        protected int[,] _Matrix;
        private int[,] _secondMatrix;
        protected int _lengthX;
        protected int _lengthY;
        protected static Dictionary<int, int> cell = new Dictionary<int, int>();
        protected static int Id;
        private int _direction;
        private int _x;
        private int _y;

        public int[,] GetMatrix()
        {
            return _Matrix;
        }

        protected Matrix(int Radius)
        {
            _lengthX = Radius * 4;
            _lengthY = Radius * 4;
            _Matrix=new int[Radius * 4, Radius * 4];
            _secondMatrix = new int[(Radius * 4), (Radius * 4)];
        }

        protected void MoveCell()
        {
            foreach (var el in cell)
            {
                int ID = el.Key;
                Move(ID);
            }
        }

        protected void Move(int ID)
        {
            int i = 0;
            int j = 0;
            bool can = false;
            while (i != _lengthY)
            {
                if (can == false)
                {
                    i = 0;
                    j = 0;
                    GenerateNumber();
                    can = true;
                }
                if (_Matrix[i, j] == ID)
                {
                    _y = i;
                    _x = j;
                    ChooseMotion();
                    if (((_x >= 0 & _x <= (_lengthX - 1)) & (_y >= 0 & _y <= (_lengthY - 1)) && (_Matrix[_y, _x] == ID|| _Matrix[_y, _x] == 0)))
                    {

                    }
                    else
                    {
                        can = false;
                    }
                }
                j++;
                if (j == _lengthX)
                {
                    j = 0;
                    i++;
                }

            }
            RewriteMatrix(ID);
        }

        private void RewriteMatrix(int ID)
        {
            for (int i = 0; i < _Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _Matrix.GetLength(1); j++)
                {
                    if (_Matrix[i, j] == ID)
                    {
                        _y = i;
                        _x = j;
                        ChooseMotion();
                        _secondMatrix[_y, _x] = _Matrix[i, j];
                    }
                    
                }

            }
            for (int i = 0; i < _Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _Matrix.GetLength(1); j++)
                {
                    _Matrix[i, j] = _secondMatrix[i , j];
                    _secondMatrix[i, j] = 0;
                }
            }
        }


        private void GenerateNumber()
        {
            Random rnd = new Random();
            _direction = rnd.Next(0, 8);
        }

        private void ChooseMotion()
        {
            switch (_direction)
            {
                case 0:
                    {
                        _y--;
                        break;
                    }

                case 1:
                    {
                        _y++;
                        break;
                    }
                    
                case 2:
                    {
                        _x--;
                        break;
                    }
                    
                case 3:
                    {
                        _x++;
                        break;
                    }
                    
                case 4:
                    {
                        _x++;
                        _y++;
                        break;
                    }
                    
                case 5:
                    {
                        _y++;
                        _x--;
                        break;
                    }
                    
                case 6:
                    {
                        _x--;
                        _y--;
                        break;
                    }
                    
                case 7:
                    {
                        _x++;
                        _y--;
                        break;
                    }
            }
        }


    }
}
