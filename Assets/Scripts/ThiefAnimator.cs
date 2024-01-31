using UnityEngine;

[RequireComponent(typeof(Animator))]

public class ThiefAnimator : MonoBehaviour
{
    private const string IsWalk = nameof(IsWalk);

    [SerializeField] private Animator _animator;

    public void Walk()
    {
        _animator.SetBool(IsWalk, true);
    }

    public void Stay()
    {
        _animator.SetBool(IsWalk, false);
    }
}