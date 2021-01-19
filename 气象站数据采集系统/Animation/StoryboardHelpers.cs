using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace 气象站数据采集系统
{
    /// <summary>
    /// Animation helpers for <see cref="StoryBoard"/>
    /// </summary>
    public static class StoryboardHelpers
    {

        #region Fade In/Out

        /// <summary>
        /// Adds a fade in animation to the storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add the animation to</param>
        /// <param name="seconds">The time the animation will take</param>
        public static void AddFadeIn(this Storyboard storyboard, float seconds, bool from = false)
        {
            // Create the margin animate from right 
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                To = 1,
            };

            // Animate from if requested
            if (from)
                animation.From = 0;

            // Set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));

            // Add this to the storyboard
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Adds a fade out animation to the storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add the animation to</param>
        /// <param name="seconds">The time the animation will take</param>
        public static void AddFadeOut(this Storyboard storyboard, float seconds)
        {
            // Create the margin animate from right 
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                To = 0,
            };

            // Set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));

            // Add this to the storyboard
            storyboard.Children.Add(animation);
        }

        #endregion
    }
}
