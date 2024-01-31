using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ThiefAnimator))]

public class Thief : MonoBehaviour
{
    [SerializeField] private ThiefAnimator _animator;
    [SerializeField] private Transform _dangerZone;
    [SerializeField] private Transform _safeZone;
    [SerializeField] private float _speed;

    private void OnEnable()
    {
        AlarmSystem.AlarmStateChanged += Move;
    }

    private void OnDisable()
    {
        AlarmSystem.AlarmStateChanged -= Move;
    }

    private void Start()
    {
        StartCoroutine(Walk(_dangerZone.position));
    }

    private void Move(bool isDanger)
    {
        StopAllCoroutines();

        if (isDanger)
            StartCoroutine(Walk(_safeZone.position));
        else
            StartCoroutine(Walk(_dangerZone.position));
    }

    private IEnumerator Walk(Vector3 target)
    {
        transform.LookAt(target);
        _animator.Walk();

        while (transform.position != target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);
            yield return null;
        }

        _animator.Stay();
    }
}