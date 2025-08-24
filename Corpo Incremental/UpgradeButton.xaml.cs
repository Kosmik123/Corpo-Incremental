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

namespace CorpoIncremental
{
	/// <summary>
	/// Interaction logic for UpgradeButton.xaml
	/// </summary>
	public partial class UpgradeButton : UserControl
	{
		public UpgradeButton()
		{
			InitializeComponent();
		}

		public string BuyButtonText
		{
			get => (string)GetValue(BuyButtonTextProperty); 
			set => SetValue(BuyButtonTextProperty, value);
		}

		public static readonly DependencyProperty BuyButtonTextProperty =
			DependencyProperty.Register(nameof(BuyButtonText), typeof(string), typeof(UpgradeButton), new PropertyMetadata("Buy"));

		public Visibility SellButtonVisibility
		{
			get => (Visibility)GetValue(SellButtonVisibilityProperty); 
			set => SetValue(SellButtonVisibilityProperty, value);
		}

		public static readonly DependencyProperty SellButtonVisibilityProperty =
			DependencyProperty.Register(nameof(SellButtonVisibility), typeof(Visibility), typeof(UpgradeButton), new PropertyMetadata(Visibility.Collapsed));
	}
}
