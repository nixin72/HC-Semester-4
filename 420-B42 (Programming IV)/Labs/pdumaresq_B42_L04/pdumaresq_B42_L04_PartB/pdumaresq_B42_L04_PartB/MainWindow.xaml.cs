using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pdumaresq_B42_L04_PartB {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        Color gradColor1;
        Color gradColor2;

        public MainWindow() {
            InitializeComponent();
        }

        protected void mitmR_Click(object sender, EventArgs e) {
            if (mitmR.IsChecked) {
                gradColor1 = Colors.Red;
                mitmB.IsChecked = false;
                mitmG.IsChecked = false;
                mitmY.IsChecked = false;
            }
            checkColor2(gradColor1);
        }

        protected void mitmB_Click(object sender, EventArgs e) {
            if (mitmB.IsChecked) {
                gradColor1 = Colors.Red;
                mitmR.IsChecked = false;
                mitmG.IsChecked = false;
                mitmY.IsChecked = false;
            }
            gradColor1 = Colors.Blue;
            checkColor2(gradColor1);
        }

        protected void mitmG_Click(object sender, EventArgs e) {
            if (mitmG.IsChecked) {
                gradColor1 = Colors.Red;
                mitmR.IsChecked = false;
                mitmB.IsChecked = false;
                mitmY.IsChecked = false;
            }
            gradColor1 = Colors.Green;
            checkColor2(gradColor1);
        }

        protected void mitmY_Click(object sender, EventArgs e) {
            if (mitmY.IsChecked) {
                gradColor1 = Colors.Red;
                mitmR.IsChecked = false;
                mitmB.IsChecked = false;
                mitmG.IsChecked = false;
            }
            gradColor1 = Colors.Yellow;
            checkColor2(gradColor1);
        }

        protected void checkColor2(Color color1) {
            if (gradColor2 != null) {
                FillRectLinearGrad(color1, gradColor2);
            }
            else {
                fillRectSolid(color1);
            }
        }

        /*
         * Color 2 for Gradient
         */
        private void mitmR2_Click(object sender, RoutedEventArgs e) {
            if (mitmR2.IsChecked) {
                gradColor1 = Colors.Red;
                mitmY2.IsChecked = false;
                mitmB2.IsChecked = false;
                mitmG2.IsChecked = false;
            }
            gradColor2 = Colors.Red;
            checkColor1(gradColor2);
        }

        private void mitmB2_Click(object sender, RoutedEventArgs e) {
            if (mitmB2.IsChecked) {
                gradColor1 = Colors.Red;
                mitmY2.IsChecked = false;
                mitmR2.IsChecked = false;
                mitmG2.IsChecked = false;
            }
            gradColor2 = Colors.Blue;
            checkColor1(gradColor2);
        }

        private void mitmG2_Click(object sender, RoutedEventArgs e) {
            if (mitmG2.IsChecked) {
                gradColor1 = Colors.Red;
                mitmY2.IsChecked = false;
                mitmR2.IsChecked = false;
                mitmB2.IsChecked = false;
            }
            gradColor2 = Colors.Green;
            checkColor1(gradColor2);
        }

        private void mitmY2_Click(object sender, RoutedEventArgs e) {
            if (mitmY2.IsChecked) {
                gradColor1 = Colors.Red;
                mitmG2.IsChecked = false;
                mitmR2.IsChecked = false;
                mitmB2.IsChecked = false;
            }
            gradColor2 = Colors.Yellow;
            checkColor1(gradColor2);
        }

        protected void checkColor1(Color color2) {
            if (gradColor1 != null) {
                FillRectLinearGrad(gradColor1, color2);
            }
            else {
                fillRectSolid(color2);
            }
        }

        private void FillRectLinearGrad(Color fillColor1, Color fillColor2) {
            LinearGradientBrush grad = new LinearGradientBrush();
            grad.StartPoint = new Point(0, 0.5);
            grad.EndPoint = new Point(1, 0.5);
            grad.GradientStops.Add(new GradientStop(fillColor1, 0.0));
            grad.GradientStops.Add(new GradientStop(fillColor2, 1.0));
            
            rectFill.Fill = grad;
        }


        /*
         * Solid Color methods
         */
        private void tlbRed_Click(object sender, RoutedEventArgs e) {
            unselectGradientColors();
            fillRectSolid(Colors.Red);
        }

        private void tlbBlue_Click(object sender, RoutedEventArgs e) {
            unselectGradientColors();
            fillRectSolid(Colors.Blue);
        }

        private void tlbGreen_Click(object sender, RoutedEventArgs e) {
            unselectGradientColors();
            fillRectSolid(Colors.Green);
        }

        private void tlbYellow_Click(object sender, RoutedEventArgs e) {
            unselectGradientColors();
            fillRectSolid(Colors.Yellow);
        }

        private void unselectGradientColors() {
            mitmR.IsChecked = false;
            mitmB.IsChecked = false;
            mitmG.IsChecked = false;
            mitmY.IsChecked = false;

            mitmR2.IsChecked = false;
            mitmB2.IsChecked = false;
            mitmG2.IsChecked = false;
            mitmY2.IsChecked = false;
        }

        private void fillRectSolid(Color solidFill) {
            SolidColorBrush color = new SolidColorBrush();
            color.Color = solidFill;

            rectFill.Fill = color;
        }

    }
}
