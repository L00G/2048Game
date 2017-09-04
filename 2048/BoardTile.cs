using System.Windows.Controls;
using System.Windows.Media;


namespace _2048
{
    class BoardTile : TextBlock
    {
        public BoardTile(int Type, int col, int row) : base()
        {
            if(Type != 0)
                this.Text = Type.ToString();
            this.FontSize = 20;
            this.Width = 55;
            this.Height = 55;

            System.Windows.Thickness thick = new System.Windows.Thickness();
            thick.Top = 10;

            this.Padding = thick;

            this.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            this.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            this.TextAlignment = System.Windows.TextAlignment.Center;

            this.Background = new SolidColorBrush(_2048.Style.GetInstance().GetBackgroundColor(Type));
            this.Foreground = new SolidColorBrush(_2048.Style.GetInstance().GetForegroundColor(Type));

            Grid.SetColumn(this, col);
            Grid.SetRow(this,row); 
        }

        public void Update(int Type)
        {
            if (Type != 0)
                this.Text = Type.ToString();
            this.Background = new SolidColorBrush(_2048.Style.GetInstance().GetBackgroundColor(Type));
            this.Foreground = new SolidColorBrush(_2048.Style.GetInstance().GetForegroundColor(Type));
        }
    }
}
