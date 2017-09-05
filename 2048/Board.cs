using System;
using System.Collections.Generic;

namespace _2048
{
    class Board
    {
        private Random rand;
        private int[,] m_board;
        public Board()
        {
            m_board = new int[4, 4];
            Initialize();
        }

        public void Initialize()
        {
            rand = new Random((int)DateTime.Now.Ticks);

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    m_board[i, j] = 0;

            MakeNewBlock();
        }

        public int[,] GetBoard()
        {
            return m_board;
        }

        private int BlockCount()
        {
            int count = 0;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    count += (m_board[i, j] != 0) ? 1 : 0;

            return count;
        }

        private int MoveUp()
        {
            Queue<int> num = new Queue<int>();
            int score = 0;
            for (int j = 0; j < 4; j++)
            {
                int idx = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (m_board[j, i] != 0)
                    {
                        num.Enqueue(m_board[j, i]);
                        m_board[j, i] = 0;
                    }
                }
                int one = 0, two = 0;
                if (num.Count != 0)
                    one = num.Dequeue();
                while (num.Count != 0)
                {
                    two = num.Dequeue();
                    if (one == two)
                    {
                        one = one * 2;
                        score += one;
                    }
                    else
                    {
                        m_board[j, idx++] = one;
                        one = two;
                    }
                }
                m_board[j, idx] = one;
            }
            return score;
        }

        private int MoveDown()
        {
            Queue<int> num = new Queue<int>();
            int score = 0;
            for (int j = 3; j >= 0; j--)
            {
                int idx = 3;
                for (int i = 3; i >= 0; i--)
                {
                    if (m_board[j, i] != 0)
                    {
                        num.Enqueue(m_board[j, i]);
                        m_board[j, i] = 0;
                    }
                }
                int one = 0, two = 0;
                if (num.Count != 0)
                    one = num.Dequeue();
                while (num.Count != 0)
                {
                    two = num.Dequeue();
                    if (one == two)
                    {
                        one = one * 2;
                        score += one;
                    }
                    else
                    {
                        m_board[j, idx--] = one;
                        one = two;
                    }
                }
                m_board[j, idx] = one;
            }
            return score;
        }

        private int MoveLeft()
        {
            Queue<int> num = new Queue<int>();
            int score = 0;
            for (int i = 0; i < 4; i++)
            {
                int idx = 0;
                for (int j = 0; j < 4; j++)
                {
                    if (m_board[j, i] != 0)
                    {
                        num.Enqueue(m_board[j, i]);
                        m_board[j, i] = 0;
                    }
                }
                int one = 0, two = 0;
                if (num.Count != 0)
                    one = num.Dequeue();
                while (num.Count != 0)
                {
                    two = num.Dequeue();
                    if (one == two)
                    {
                        one = one * 2;
                        score += one;
                    }
                    else
                    {
                        m_board[idx++, i] = one;
                        one = two;
                    }
                }
                m_board[idx, i] = one;
            }
            return score;
        }

        private int MoveRight()
        {
            Queue<int> num = new Queue<int>();
            int score = 0;
            for (int i = 3; i >= 0; i--)
            {
                int idx = 3;
                for (int j = 3; j >= 0; j--)
                {
                    if (m_board[j, i] != 0)
                    {
                        num.Enqueue(m_board[j, i]);
                        m_board[j, i] = 0;
                    }
                }
                int one = 0, two = 0;
                if (num.Count != 0)
                    one = num.Dequeue();
                while (num.Count != 0)
                {
                    two = num.Dequeue();
                    if (one == two)
                    {
                        one = one * 2;
                        score += one;
                    }
                    else
                    {
                        m_board[idx--, i] = one;
                        one = two;
                    }
                }
                m_board[idx, i] = one;
            }
            return score;
        }

        public void MakeNewBlock()
        {
            int col, row;
            do
            {
                col = rand.Next(4);
                row = rand.Next(4);
            } while (m_board[row, col] != 0);
            if (rand.NextDouble() > 0.9)
                m_board[row, col] = 4;
            else m_board[row, col] = 2;
        }

        private bool CheckEndGame()
        {
            bool hasAnswer = false;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (m_board[i, j] == m_board[i, j + 1] || m_board[i, j] == m_board[i + 1, j])
                        hasAnswer = true;

            for (int i = 0; i < 3; i++)
            {
                if (m_board[3, i] == m_board[3, i + 1])
                    hasAnswer = true;
                if (m_board[i, 3] == m_board[i + 1, 3])
                    hasAnswer = true;
            }

            if (!hasAnswer)
                return true;

            return false;
        }

        public int Update(Button key)
        {
            int score = 0;
            if (key == Button.Up) score = MoveUp();
            if (key == Button.Down) score = MoveDown();
            if (key == Button.Left) score = MoveLeft();
            if (key == Button.Right) score = MoveRight();

            int count = BlockCount();
            if (count == 15)
            {
                MakeNewBlock();
                if (CheckEndGame())
                    return -1;
            }
            else
            {
                if(count!=16)MakeNewBlock();
            }
            return score;
        }
    }
}
