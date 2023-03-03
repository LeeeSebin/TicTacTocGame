using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TicTacToc
{
    class Stone
    {
        public const int EMPTY = 0;
        public const int BLACK = 1;
        public const int WHITE = 2;

        public const int offset = 35;//돌을 뒀을때 슬롯의 빈칸 길이. 이게 커질수록 돌은 작아짐

        public static float radius;

        public int Type { get; set; }
        public float X { get; set; }
        public float Y { get; set; }

        public Stone()
        {
            Type = EMPTY;
        }
        public Stone( int i, int j, float slotSize )//가로,세로 번호, 보드의 슬롯 한칸 사이즈
        {
            X = i * slotSize;//돌의 X,Y시작 좌표
            Y = j * slotSize;
        }

        public void Draw(Graphics g)//돌 그려주기
        {
            if (Type == EMPTY)
                return;
            Brush brush = Type == WHITE ? Brushes.White : Brushes.Black;
                g.FillEllipse(brush, X+ offset, Y+ offset, 2 * (radius- offset), 2 * (radius- offset));
        }
    }
}
