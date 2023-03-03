using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToc
{
    class StoneManager
    {
        public const int N = 3;
        private int turn;
        private Stone[,] stones;

        public StoneManager(Board board)
        {
            stones = new Stone[N, N];
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    stones[i, j] = new Stone(i, j, board.SlotSize);
            turn = Stone.BLACK;
        }

        public void DrawStones(Graphics g)
        {
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    stones[i, j].Draw(g);
        }

        public bool Finish()//승리체크
        {
            bool win = true;
            for (int i = 0; i < N; i++)//가로열로 승리체크
            {
                win = true;
                for (int j = 0; j < N; j++)
                    if (stones[i, j].Type != turn)
                        win = false;
                if (win) return true;
            }
            for (int i = 0; i < N; i++)//세로열로 승리체크
            {
                win = true;
                for (int j = 0; j < N; j++)
                    if (stones[j, i].Type != turn)
                        win = false;
                if (win) return true;
            }

            win = true;
            for (int i = 0; i < N; i++)//우하향대각선 승리체크
                if (stones[i, i].Type != turn)
                    win = false;
                if (win) return true;

            win = true;
            for (int i = 0; i < N; i++)//우상향대각선 승리체크
                if (stones[N-1-i, i].Type != turn)
                    win = false;
            if (win) return true;

            return false;
        }

        public int PutStone(int i, int j)//돌두기
        {
            int winner=Stone.EMPTY;
            if (turn == Stone.BLACK && stones[i, j].Type == Stone.EMPTY)
            {
                stones[i, j].Type = Stone.BLACK;//검은돌 두기
                if (Finish())
                {
                    winner = Stone.BLACK;
                }
                turn = Stone.WHITE;
            }
            else if (turn == Stone.WHITE && stones[i, j].Type == Stone.EMPTY)
            {
                stones[i, j].Type = Stone.WHITE;//하얀돌 두기
                if (Finish())
                {
                    winner = Stone.WHITE;
                }
                turn = Stone.BLACK;
            }
            return winner;
        }
    }
}
