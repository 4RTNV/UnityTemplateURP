using System;
using System.Collections.Generic;
using _Project.CurrentLevelProgress;
using _Project.Factory;
using _Project.PersistentProgress;
using _Project.SaveLoad;
using _Project.SceneLoader;
using _Project.StaticData;
using _Project.TimeService;
using _Project.UI.Services.Factory;
using UnityEngine;

namespace _Project.States
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _currentState;

        public GameStateMachine(IPersistentProgress persistentProgress, ISaveLoad saveLoad, IGameFactory gameFactory,
            IUIFactory uiFactory, IStaticData staticData, ILevelProgress levelProgress, IInGameTimeService timeService,
            IEnumerable<ISavedProgressReader> saveReaderServices, ISceneLoader sceneLoader)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader),
                [typeof(LoadProgressState)] = new LoadProgressState(this, persistentProgress, saveLoad),
                [typeof(LoadHubState)] = new LoadHubState(this, sceneLoader),
                [typeof(HubState)] = new HubState(this, saveReaderServices),
                [typeof(LoadLevelState)] = new LoadLevelState(this, gameFactory, persistentProgress, staticData, uiFactory, levelProgress),
                [typeof(LoopLevelState)] = new LoopLevelState(this, saveLoad, levelProgress),
                [typeof(FinishedLevelState)] = new FinishedLevelState(this, timeService)
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            // The first state could be null on program start 
            _currentState?.Exit();
            TState state = GetState<TState>();
            Debug.Log($"State changed: {_currentState?.ToString() ?? "None"} => {state}");
            _currentState = state;
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState
            => _states[typeof(TState)] as TState;
    }
}