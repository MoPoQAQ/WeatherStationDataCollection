using System;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace 气象站数据采集系统
{
    public class BasePage : Page
    {
        private PageAnimation PageLoadAnmiation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        private PageAnimation PageUnLoadAnmiation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        private double SlidSeconds { get; set; } = 0.8f;

        public BasePage()
        {
            this.Loaded += BasePage_Loaded;
        }

        private async void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
            await AnimationIn();
        }

        public async Task AnimationIn()
        {
            switch (this.PageLoadAnmiation)
            {
                case PageAnimation.SlideAndFadeInFromRight:

                    var sb = new Storyboard();
                    var slidaAnmiation = new ThicknessAnimation
                    {
                        Duration = new Duration(TimeSpan.FromSeconds(this.SlidSeconds)),
                        From = new Thickness(this.WindowWidth, 0, this.WindowHeight, 0),
                        To = new Thickness(0),
                        DecelerationRatio = 0.9f,
                    };

                    Storyboard.SetTargetProperty(slidaAnmiation, new PropertyPath("Margin"));
                    sb.Children.Add(slidaAnmiation);
                    sb.Begin(this);

                    await Task.Delay((int)this.SlidSeconds * 3000);

                    break;

                case PageAnimation.SlideAndFadeOutToLeft:

                    break;
            }
        }
    }
}
