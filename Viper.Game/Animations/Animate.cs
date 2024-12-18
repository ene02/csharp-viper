﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Color = System.Windows.Media.Color;
using Point = System.Windows.Point;
using Vector = System.Windows.Vector;

namespace Viper.Game.Animations
{
    public static class Animate
    {
		/// <summary>
        /// For properties that use double values.
        /// </summary>
        /// <param name="targetElement"></param>
        /// <param name="property"></param>
        /// <param name="toValue"></param>
        /// <param name="duration"></param>
        /// <param name="easing"></param>
        /// <param name="fromValue"></param>
        public static void Double(DependencyObject targetElement, DependencyProperty property, double toValue, TimeSpan duration, IEasingFunction? easing = null, double? fromValue = null)
        {
            if (targetElement != null && property != null)
            {
                var currentValue = (double)targetElement.GetValue(property);

                if (fromValue != null)
                {
                    currentValue = (double)fromValue;
                }

                DoubleAnimation animation = new()
                {
                    From = currentValue,
                    To = toValue,
                    Duration = duration
                };

                if (easing != null)
                {
                    animation.EasingFunction = easing;
                }

                StartAnimation(targetElement, property, animation);
            }
        }

        // For color properties.
        public static void Color(DependencyObject targetElement, DependencyProperty property, Color toColor, TimeSpan duration, IEasingFunction? easing = null, Color? fromValue = null)
        {
            if (targetElement != null && property != null && targetElement is Animatable)
            {
                var currentValue = (Color)targetElement.GetValue(property);

                if (fromValue != null)
                {
                    currentValue = (Color)fromValue;
                }

                ColorAnimation animation = new()
                {
                    From = currentValue,
                    To = toColor,
                    Duration = duration
                };

                if (easing != null)
                {
                    animation.EasingFunction = easing;
                }

                StartAnimation(targetElement, property, animation);
            }
        }

        /// <summary>
        /// For properties that use points.
        /// </summary>
        /// <param name="targetElement"></param>
        /// <param name="property"></param>
        /// <param name="toPoint"></param>
        /// <param name="duration"></param>
        /// <param name="easing"></param>
        /// <param name="fromValue"></param>
        public static void Point(DependencyObject targetElement, DependencyProperty property, Point toPoint, Duration duration, IEasingFunction? easing = null, Point? fromValue = null)
        {
            if (targetElement != null && property != null && targetElement is Animatable)
            {
                var currentValue = (Point)targetElement.GetValue(property);

                if (fromValue != null)
                {
                    currentValue = (Point)fromValue;
                }

                PointAnimation animation = new PointAnimation
                {
                    From = currentValue,
                    To = toPoint,
                    Duration = duration
                };

                if (easing != null)
                {
                    animation.EasingFunction = easing;
                }

                StartAnimation(targetElement, property, animation);
            }
        }

        public static void RectValue(DependencyObject targetElement, DependencyProperty property, Rect toValue, Duration duration, IEasingFunction? easing = null, Rect? fromValue = null)
        {
            if (targetElement != null && property != null)
            {
                var currentValue = (Rect)targetElement.GetValue(property);

                if (fromValue != null)
                {
                    currentValue = (Rect)fromValue;
                }

                RectAnimation animation = new RectAnimation
                {
                    From = currentValue,
                    To = toValue,
                    Duration = duration
                };

                if (easing != null)
                {
                    animation.EasingFunction = easing;
                }

                StartAnimation(targetElement, property, animation);
            }
        }

        /// <summary>
        /// Use for whatever that makes use of "Thickness"
        /// </summary>
        /// <param name="targetElement"></param>
        /// <param name="property"></param>
        /// <param name="toValue"></param>
        /// <param name="duration"></param>
        /// <param name="easing"></param>
        /// <param name="fromValue"></param>
        public static void ThicknessValue(DependencyObject targetElement, DependencyProperty property, Thickness toValue, Duration duration, IEasingFunction? easing = null, Thickness? fromValue = null)
        {
            if (targetElement != null && property != null)
            {
                var currentValue = (Thickness)targetElement.GetValue(property);

                if (fromValue != null)
                {
                    currentValue = (Thickness)fromValue;
                }

                ThicknessAnimation animation = new ThicknessAnimation
                {
                    From = currentValue,
                    To = toValue,
                    Duration = duration
                };

                if (easing != null)
                {
                    animation.EasingFunction = easing;
                }

                StartAnimation(targetElement, property, animation);
            }
        }

        // A method that verifies that the target element to animate is actually animatable.
        private static void StartAnimation(DependencyObject dependencyObject, DependencyProperty dependencyProperty, AnimationTimeline animation)
        {
            switch (dependencyObject)
            {
                case UIElement uiElement:
                    uiElement.BeginAnimation(dependencyProperty, animation);
                    break;
                case Geometry geometry:
                    geometry.BeginAnimation(dependencyProperty, animation);
                    break;
                case Brush brush:
                    brush.BeginAnimation(dependencyProperty, animation);
                    break;
                case Transform transform:
                    transform.BeginAnimation(dependencyProperty, animation);
                    break;
                case Animatable animatable:
                    animatable.BeginAnimation(dependencyProperty, animation);
                    break;
                default:
                    break;
            }
        }
    }
}
