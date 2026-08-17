using System;
using System.Collections.Generic;
using Reflex.Core;
using Reflex.Injectors;
using UnityEngine;

namespace _Project.StateMachines
{
    public sealed class AppStateMachine
    {
        private readonly Dictionary<Type, IExitableAppState> _states;
        private IExitableAppState _currentState;

        public AppStateMachine(Container container)
        {
            _states = new Dictionary<Type, IExitableAppState>
            {
                [typeof(BootstrapState)] =
                    ConstructorInjector.Construct(typeof(BootstrapState), container) as BootstrapState,
                [typeof(LoadProgressState)] =
                    ConstructorInjector.Construct(typeof(LoadProgressState), container) as LoadProgressState,
                [typeof(LoadMainMenuState)] =
                    ConstructorInjector.Construct(typeof(LoadMainMenuState), container) as LoadMainMenuState,
                [typeof(LoadLevelState)] =
                    ConstructorInjector.Construct(typeof(LoadLevelState), container) as LoadLevelState,
            };
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
