
namespace _2048
{
    class Game
    {
        private Board m_board;
        private BoardBorder m_boardBorder;
        private Score m_scorePanel;

        private int m_score;
        private int m_bestSocre;
        private bool m_play;

        public Game( )
        {
            m_bestSocre = 0;
            m_board = new Board();
            m_boardBorder = new BoardBorder();
            m_scorePanel = new Score();
            Initialize();
        }

        public void Initialize()
        {
            m_play = true;
            m_score = 0;
            m_board.Initialize();
            m_boardBorder.Initialize();
            m_scorePanel.Initialize();
            Render();
        }
        
        public void Update(Button key)
        {
            if (m_play)
            {
                int score = m_board.Update(key);
                if (score == -1)
                    m_play = false;
                else
                {
                    if (score == 2048)
                        m_play = false;
                    m_score += score;
                }
                if (m_bestSocre < m_score) m_bestSocre = m_score;
            }
            else
            {
                Initialize();
            }
        }

        public void Render()
        {
            m_boardBorder.Update(m_board.GetBoard());
            if (!m_play)
                m_scorePanel.Update(m_score, m_bestSocre);
            else m_scorePanel.Update(m_score);
        }

        public System.Windows.Controls.StackPanel GetGamePanel()
        {
            System.Windows.Controls.StackPanel sp = new System.Windows.Controls.StackPanel();

            sp.Children.Add(m_scorePanel);
            sp.Children.Add(m_boardBorder);
            return sp;
        }
    }
}
