using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TicTacToc
{
    class Board
    {
        public const int N = 3;
        public int Width { get; set; }
        public int Height { get; set; }
        public float SlotSize { get; set; }

        public Board( int width, int height )
        {
            Width = width;
            Height = height;
            float m = Math.Min(width, height);
            SlotSize = m / N;//슬롯 한칸의 사이즈
        }

        public void Darw(Graphics g)//보드에 선 그어주기
        {
            Pen pen = Pens.Black;
            float size = SlotSize * N;
            for(int i=0; i<=N; i++)
                g.DrawLine(pen, 0, i * SlotSize, size, i * SlotSize);
            for (int i = 0; i <= N; i++)
                g.DrawLine(pen,  i * SlotSize, 0, i * SlotSize, size);

        }

        public bool Contains(Point p)//보드판(슬롯들)을 눌렀는지 확인하기
        {
            float size = SlotSize * N;
            return 0 <= p.X && p.X <= size && 0 <= p.Y && p.Y <= size;
        }

        public Point Convert(Point p)//클릭한곳이 몇번째 돌인지 xy번호 가져오기
        {
            return new Point((int)(p.X / SlotSize), (int)(p.Y / SlotSize));
        }

        

    }
}
