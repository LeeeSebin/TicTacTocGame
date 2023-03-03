using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToc
{
    public partial class Form1 : Form
    {
        private const int N = 3;

        private StoneManager stoneMgr;
        private Board board;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            board = new Board(boardPanel.Width, boardPanel.Height);
            stoneMgr = new StoneManager(board);
            Stone.radius = board.SlotSize / 2;
            
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void start_Click(object sender, EventArgs e)
        {

        }

        private void boardPanel_Paint(object sender, PaintEventArgs e)
        {
            board.Darw(e.Graphics);
            stoneMgr.DrawStones(e.Graphics);
        }

        private void boardPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (board.Contains(e.Location))
            {
                Point p = board.Convert(e.Location);
                int winner = stoneMgr.PutStone(p.X, p.Y);
                boardPanel.Invalidate();
                if (winner != Stone.EMPTY)
                    MarkWinner(winner);
            }
        }

        private void MarkWinner(int winner)//승리창 출력
        {
            string str = winner == Stone.BLACK ? "Black" : "White";
            MessageBox.Show(str + "win!!!");
        }

    }
}
