using System;

namespace CorpoIncremental
{
	public sealed class GameEvent : IDisposable
    {
        private readonly GameEventTrigger trigger;
        private readonly Action action;

        public GameEvent(GameEventTrigger trigger, Action action)
        {
            this.action = action;
            this.trigger = trigger;
			trigger.OnTriggered += Trigger_OnTriggered;
        }

		private void Trigger_OnTriggered()
		{
            trigger.OnTriggered -= Trigger_OnTriggered;
		    action.Invoke();
        }

        public void Dispose()
		{
			trigger.OnTriggered -= Trigger_OnTriggered;
		}
	}
}
