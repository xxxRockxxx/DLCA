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
        protected static Dictionary<int, int> cell = new Dictionary<int, int>();//Пардон, а это словарь чего от чего?) Вторая половина зачем нужна?
        protected static int Id;        
        private int _x;
        private int _y;
        private int _direction;

        public int[,] GetMatrix()
        {
            return _Matrix;//Как заготовка нормально, но надо понимать, что массив всегда передается по ссылке, поэтому вы этим
            //гетом возвращаете сам массив, и это то же самое, что делать его публичным. Чтобы копировать массив, надо переопределять метод Clone
        }

        protected Matrix(int Radius)
        {
            //Откуда волшебное число 4?))
            //Когда начисто будете делать, то надо понимать, что для DLCA нет расширяющегося поля, там все глобулы по заранее
            //заданному полю расставляются
            _lengthX = Radius * 4;
            _lengthY = Radius * 4;
            _Matrix=new int[Radius * 4, Radius * 4];
            //secondMatrix зависит от _Matrix, поэтому мы задаем размерность не отдельно, а привязываем к размерности Matrix. 
            //Это может быть не так важным, но при неаккуратном обращении могут появиться мерзкие мелкие ошибки
            _secondMatrix = new int[_Matrix.GetLength(0), _Matrix.GetLength(1)];
        }

        protected void MoveCell()
        {
            foreach (var el in cell.Keys)//Можно прямо сразу идти не целиком по словарю, а только по ключам
            {                
                Move(el);
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
                    _direction = GenerateNumber();
                    
                    can = true;
                }
                if (_Matrix[i, j] == ID)
                {
                    _y = i;
                    _x = j;
                    ChooseMotion(_direction);                    
                    //Матрицу на айдишники здесь нет смысла проверять, потому что вы на эту ветку идете только в том случае, если в матрице ID
                    //if (((_x >= 0 & _x <= (_lengthX - 1)) & (_y >= 0 & _y <= (_lengthY - 1)) && (_Matrix[_y, _x] == ID|| _Matrix[_y, _x] == 0)))
                    //{

                    //}
                    //else
                    //{
                    //    can = false;
                    //}

                    //Выше правильно, но такую структуру не рекомендуют делать, потому что у вас структура формата
                    //Если НЕ выходим за границу, то не делаем ничего, если выходим - то can = false.
                    //То есть, мы что-то делаем только на else. Поэтому лучше перевернуть условия - если вышли за границу - то...
                    //А второй половины не надо
                    if (_x < 0 || _x > _lengthX - 1 || _y < 0 || _y > _lengthY - 1)
                        can = false;
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
                        ChooseMotion(_direction);
                        _secondMatrix[_y, _x] = _Matrix[i, j];
                    }

                }

            }
            for (int i = 0; i < _Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _Matrix.GetLength(1); j++)
                {
                    //Когда будет несколько глобул, то все, кроме одной, будут зануляться
                    _Matrix[i, j] = _secondMatrix[i, j];
                    _secondMatrix[i, j] = 0;                                        
                }
            }
        }


        private int GenerateNumber()
        {
            Random rnd = new Random();
            return rnd.Next(0, 8);
        }

        private void ChooseMotion(int direction)
        {
            switch (direction)
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
