using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace _2048
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    enum Button
    {
        None,
        Up,
        Down,
        Left,
        Right
    }
    public partial class MainWindow : Window
    {
        private Game oGame;

        public MainWindow()
        {
            InitializeComponent();

            this.Title = "2048";

            this.Width = 300;
            this.Height = 400;

            this.Background = new SolidColorBrush(Colors.Beige);

            this.ResizeMode = ResizeMode.NoResize|ResizeMode.CanMinimize;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            oGame = new Game();

            this.AddChild(oGame.GetGamePanel());

            this.KeyDown += OnKeyDownHandler;
            this.Focus();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
                oGame.Update(Button.Up);
            if (e.Key == Key.Down)
                oGame.Update(Button.Down);
            if (e.Key == Key.Left)
                oGame.Update(Button.Left);
            if (e.Key == Key.Right)
                oGame.Update(Button.Right);
            oGame.Render();
        }
    }
}
