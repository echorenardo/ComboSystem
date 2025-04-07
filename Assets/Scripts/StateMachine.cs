using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T, S> where T : MonoBehaviour where S : State<T>
{
    private readonly T _owner;
    private readonly Dictionary<Type, S> _states = new();
    private S _currentState;

    public int StatesCount => _states.Count;

    public StateMachine(T owner)
    {
        _owner = owner;
    }

    public void AddState(S state)
    {
        _states[state.GetType()] = state;
    }

    public void SwitchState<TState>() where TState : S
    {
        Type type = typeof(TState);

        if (!_states.ContainsKey(type))
            throw new Exception("This state does not exist");

        S newState = _states[type];

        if (newState == _currentState)
            return;

        _currentState?.OnExit();
        _currentState = newState;
        _currentState.OnEnter();
    }

    public void Activate()
    {
        _currentState?.OnActivated();
    }

    public void SetInitialState<TState>() where TState : S
    {
        SwitchState<TState>();
    }
}

public abstract class State<T> where T : MonoBehaviour
{
    protected T _context;

    protected State(T context)
    {
        _context = context;
    }

    public virtual void OnEnter() { }
    public virtual void OnExit() { }
    public virtual void OnActivated() { }
}