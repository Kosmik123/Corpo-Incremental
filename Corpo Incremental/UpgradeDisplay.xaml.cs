using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace CorpoIncremental
{
    /// <summary>
    /// Interaction logic for UpgradePanel.xaml
    /// </summary>
    public partial class UpgradeDisplay: UserControl
    {
        public UpgradeDisplay()
        {
            InitializeComponent();
        }

        public Button SellButton => sellButton;
        public Button BuyButton => buyButton;
        public TextBlock HeaderBlock => headerBlock;
        public TextBlock LevelBlock => levelBlock;
        public TextBlock DescriptionBlock => descriptionBlock;


    }
}
