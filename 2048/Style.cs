using System.Collections.Generic;
using System.Windows.Media;

namespace _2048
{
    class Style
    {
        static Dictionary<int, Color> backColorSet = new Dictionary<int, Color>();
        static Dictionary<int, Color> foreColorSet = new Dictionary<int, Color>();
        static Style instance;
        private Style()
        {
            backColorSet.Add(0, Colors.LightYellow);
            backColorSet.Add(2, Colors.Yellow);
            backColorSet.Add(4, Colors.Gray);
            backColorSet.Add(8, Colors.DimGray);
            backColorSet.Add(16, Colors.Black);
            backColorSet.Add(32, Colors.LightPink);
            backColorSet.Add(64, Colors.Silver);
            backColorSet.Add(128, Colors.Olive);
            backColorSet.Add(256, Colors.Gold);
            backColorSet.Add(512, Colors.Brown);
            backColorSet.Add(1024, Colors.OrangeRed);
            backColorSet.Add(2048, Colors.BlueViolet);

            foreColorSet.Add(2, Colors.Silver);
            foreColorSet.Add(4, Colors.FloralWhite);
            foreColorSet.Add(8, Colors.FloralWhite);
            foreColorSet.Add(16, Colors.FloralWhite);
            foreColorSet.Add(32, Colors.FloralWhite);
            foreColorSet.Add(64, Colors.FloralWhite);
            foreColorSet.Add(128, Colors.FloralWhite);
            foreColorSet.Add(256, Colors.FloralWhite);
            foreColorSet.Add(512, Colors.FloralWhite);
            foreColorSet.Add(1024, Colors.FloralWhite);
            foreColorSet.Add(2048, Colors.FloralWhite);
        }
        public static Style GetInstance()
        {
            if (instance == null) instance = new Style();
            return instance;
        }
        public Color GetBackgroundColor(int number)
        {
            backColorSet.TryGetValue(number, out Color color);
            return color;
        }
        public Color GetForegroundColor(int number)
        {
            foreColorSet.TryGetValue(number, out Color color);
            return color;
        }
    }
}
