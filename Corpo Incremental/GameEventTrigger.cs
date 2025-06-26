namespace CorpoIncremental
{
	public abstract class GameEventTrigger
    { 
        public event System.Action OnTriggered = delegate { };
    
		protected void Invoke() => OnTriggered.Invoke();
	}

    public class MoneyAchievedTrigger : GameEventTrigger
	{
		private readonly Player _player;
		private readonly double _targetMoney;

		public MoneyAchievedTrigger(Player player, double targetMoney)
		{
			_player = player;
			_targetMoney = targetMoney;
			_player.OnMoneyChanged += CheckTrigger;
		}

		private void CheckTrigger()
		{
			if (_player.Money >= _targetMoney)
			{
				_player.OnMoneyChanged -= CheckTrigger; 
				Invoke();
			}
		}
	}
}
