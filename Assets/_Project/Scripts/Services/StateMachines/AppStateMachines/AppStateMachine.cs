using System;
using System.Collections.Generic;
using _Project.CurrentLevelProgress;
using _Project.Factory;
using _Project.PersistentProgress;
using _Project.SaveLoad;
using _Project.SceneLoader;
using _Project.States;
using _Project.StaticData;
using _Project.TimeService;
using _Project.UI.Factory;
using UnityEngine;

namespace _Project.StateMachines
{
    public sealed class AppStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _currentState;

        public AppStateMachine(IPersistentProgress persistentProgress, ISaveLoad saveLoad, IGameFactory gameFactory,
            IUIFactory uiFactory, IStaticData staticData, ILevelProgress levelProgress, IInGameTimeService timeService,
            IEnumerable<ISavedProgressReader> saveReaderServices, ISceneLoader sceneLoader)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader),
                [typeof(LoadProgressState)] = new LoadProgressState(this, persistentProgress, saveLoad),
                [typeof(LoadMainMenuState)] = new LoadMainMenuState(this, sceneLoader),
                [typeof(LoadLevelState)] = new LoadLevelState(this, gameFactory, persistentProgress, staticData,
                    uiFactory, levelProgress),
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            var state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            // The first state could be null on program start
            _currentState?.Exit();
            var state = GetState<TState>();
            Debug.Log($"State changed: {_currentState?.ToString() ?? "None"} => {state}");
            _currentState = state;
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState
        {
            return _states[typeof(TState)] as TState;
        }
    }
}
