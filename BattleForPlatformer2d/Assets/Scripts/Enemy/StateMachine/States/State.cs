using Enemies;
using System;
using System.Collections.Generic;
using Transitions;

namespace States
{
    public abstract class State
    {
        protected List<Transition> _transitions = new();

        public event Action<State> Changed;

        public State(List<Transition> transitions)
        {
            _transitions = transitions;
        }

        public virtual void Enter() 
        {
        }

        public virtual void Exit() 
        {
        }

        public void Update() 
        {
            foreach (Transition transition in _transitions) 
            {
                if (transition.IsNeedTransit())
                {
                    Changed.Invoke(transition.NextState);

                    break;
                }
            }
        }

        public virtual void OnUpdate() 
        {
        }
    }
}