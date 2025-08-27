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
    public partial class UpgradePanel : UserControl
    {
        public UpgradePanel()
        {
            InitializeComponent();
        }
    }

	public class UpgradePanelViewModel : INotifyPropertyChanged
	{
		private int _level;

		public string Name { get; set; }
		public string Description { get; set; }

		public int Level
		{
			get => _level;
			set
			{
				if (_level != value)
				{
					_level = value;
					OnPropertyChanged();
				}
			}
		}

		public ICommand BuyCommand { get; }
		public ICommand SellCommand { get; }

		public UpgradePanelViewModel()
		{
			//BuyCommand = new RelayCommand(_ => Level++);
			//SellCommand = new RelayCommand(_ => Level--, _ => Level > 0);
		}

		public event PropertyChangedEventHandler? PropertyChanged;
		protected void OnPropertyChanged([CallerMemberName] string? name = null)
			=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
	}
}
