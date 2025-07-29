using States;
using System;

namespace Transitions
{
    public abstract class Transition
    {
        public State NextState { get; private set; }

        public Transition(State targetState) 
        {
            NextState = targetState;
        }

        public abstract bool IsNeedTransit();
    }
}
