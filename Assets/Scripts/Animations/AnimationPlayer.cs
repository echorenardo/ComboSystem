using System;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    public event Action AnimationCompleted;

    [SerializeField] private Animator _animator;

    public void Play(int animationHash)
    {
        _animator.SetTrigger(animationHash);
    }

    private void OnAnimationCompleted()
    {
        AnimationCompleted?.Invoke();
    }
}
