using System.Windows.Controls;
using System.Windows.Media;

namespace _2048
{
    class BoardBorder:Border
    {
        private Grid m_boardGrid;
        private bool m_initilized;
        public BoardBorder():base()
        {
            m_initilized = false;
        }

        public virtual void Initialize()
        {
            if (!m_initilized)
            {
                this.Height = 250;
                this.Width = 250;

                this.Background = new SolidColorBrush(Colors.AntiqueWhite);
                this.CornerRadius = new System.Windows.CornerRadius(10);
                this.BorderThickness = new System.Windows.Thickness(3);
                this.BorderBrush = new SolidColorBrush(Colors.Wheat);

                m_boardGrid = new Grid();

                for(int i = 0; i < 4; i++)
                {
                    ColumnDefinition cd = new ColumnDefinition();
                    cd.Width = new System.Windows.GridLength(60);
                    RowDefinition rd = new RowDefinition();
                    rd.Height = new System.Windows.GridLength(60);
                    m_boardGrid.ColumnDefinitions.Add(cd);
                    m_boardGrid.RowDefinitions.Add(rd);
                }

                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                        m_boardGrid.Children.Add(new BoardTile(0, i, j));

                m_boardGrid.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                m_boardGrid.VerticalAlignment = System.Windows.VerticalAlignment.Center;

                System.Windows.Thickness thick = new System.Windows.Thickness();
                thick.Top = 10;
                this.Margin = thick;

                this.Child = m_boardGrid;

                m_initilized = true;
            }
            this.Update(new int[4, 4]);
        }

        public void Update(int[,] boardData)
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    ((BoardTile)(m_boardGrid.Children[i * 4 + j])).Update(boardData[i, j]);
        }
    }
}
