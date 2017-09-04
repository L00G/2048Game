using System.Windows.Controls;
using System.Windows.Media;

namespace _2048
{
    class Score : StackPanel
    {
        private TextBlock m_scoreBlock;
        private TextBlock m_bestScoreBlock;
        private bool m_initialized;
        public Score() : base()
        {
            m_scoreBlock = null;
            m_bestScoreBlock = null;

            m_initialized = false;
        }

        public void Initialize()
        {
            if (!m_initialized)
            {
                this.Orientation = Orientation.Horizontal;

                m_scoreBlock = new TextBlock();
                Border grid = CreateScoreBorder("SCORE", m_scoreBlock);
                grid.Width = 80;
                this.Children.Add(grid);

                m_bestScoreBlock = new TextBlock();
                grid = CreateScoreBorder("BEST SCORE", m_bestScoreBlock);
                grid.Width = 100;

                System.Windows.Thickness thick = new System.Windows.Thickness();
                thick.Top = 10;
                thick.Right = 15;
                this.Margin = thick;
                this.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;

                this.Children.Add(grid);

                m_initialized = true;
            }

            Update(0);
        }

        public Border CreateScoreBorder(string textMessage, TextBlock block)
        {
            Border border = new Border();

            Grid grid = new Grid();

            RowDefinition rd1 = new RowDefinition();
            rd1.Height = new System.Windows.GridLength(25);
            RowDefinition rd2 = new RowDefinition();
            rd2.Height = new System.Windows.GridLength(30);

            grid.RowDefinitions.Add(rd1);
            grid.RowDefinitions.Add(rd2);

            TextBlock text = new TextBlock
            {
                Text = textMessage,
                Foreground = new SolidColorBrush(Colors.White),
                FontSize = 15,
                TextAlignment = System.Windows.TextAlignment.Center,
                VerticalAlignment = System.Windows.VerticalAlignment.Bottom
            };

            Grid.SetColumn(text, 0);
            Grid.SetRow(text, 0);

            block.Text = "0";
            block.Foreground = new SolidColorBrush(Colors.White);
            block.FontSize = 25;
            block.TextAlignment = System.Windows.TextAlignment.Center;
            block.VerticalAlignment = System.Windows.VerticalAlignment.Center;

            Grid.SetColumn(block, 0);
            Grid.SetRow(block, 1);

            grid.Children.Add(text);
            grid.Children.Add(block);

            border.Child = grid;

            border.CornerRadius = new System.Windows.CornerRadius(15);
            border.BorderBrush = new SolidColorBrush(Colors.LightYellow);
            border.BorderThickness = new System.Windows.Thickness(2);
            border.Background = new SolidColorBrush(Colors.Wheat);

            System.Windows.Thickness thick= new System.Windows.Thickness();
            thick.Left = 30;
            border.Margin = thick;
            
            return border;
        }

        public void Update(int score,int bestScore = 0)
        {
            m_scoreBlock.Text = score.ToString();
            if(bestScore!=0)
                m_bestScoreBlock.Text = bestScore.ToString();
        }
    }
}
