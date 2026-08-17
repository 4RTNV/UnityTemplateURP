using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Project.StateMachines
{
    public sealed class AppStateMachine
    {
        private readonly Dictionary<Type, IExitableAppState> _states;
        private IExitableAppState _currentState;

        public AppStateMachine(IAppStateFactory stateFactory)
        {
            _states = stateFactory.CreateStates(this).ToDictionary(state => state.GetType());
        }

        public void Enter<TState>() where TState : class, IAppState
        {
            IAppState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedAppState<TPayload>
        {
            var state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableAppState
        {
            // The first state could be null on program start
            _currentState?.Exit();
            var state = GetState<TState>();
            Debug.Log($"State changed: {_currentState?.ToString() ?? "None"} => {state}");
            _currentState = state;
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableAppState
        {
            return _states[typeof(TState)] as TState;
        }
    }
}
