using System.Collections;
using UnityEngine.Events;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _speedChange = 0.5f;

    public static UnityAction<bool> AlarmStateChanged;

    private float _minVolume = 0;
    private float _maxVolume = 1;

    private void OnTriggerEnter(Collider other)
    {
        Thief theif = other.GetComponent<Thief>();

        if (theif != null)
            StartCoroutine(ChangeVolume(_maxVolume));
    }

    private void OnTriggerExit(Collider other)
    {
        Thief thief = other.GetComponent<Thief>();

        if (thief != null)
            StartCoroutine(ChangeVolume(_minVolume));
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _speedChange * Time.deltaTime);
            yield return null;
        }

        AlarmStateChanged?.Invoke(_audioSource.volume > 0);
    }
}