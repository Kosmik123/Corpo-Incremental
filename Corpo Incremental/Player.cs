namespace CorpoIncremental
{
    public class Player
    {
        public event System.Action OnMoneyChanged = delegate { };

        public double Money
        {
            get => _money;
            private set
            {
                if (_money != value)
                {
                    _money = value;
                    OnMoneyChanged.Invoke();
                }
            }
        }

        public Player(double money = 0)
        {
            _money = money;
        }

        public void DoWork(double value)
        {
            Money += value;
        }

        private double _money;
    }
}
