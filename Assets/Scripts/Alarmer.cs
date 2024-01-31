using System.Collections;
using UnityEngine.Events;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarmer : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _speedChange = 0.5f;

    public static UnityAction<bool> AlarmStateChanged;

    private float _minVolume = 0;
    private float _maxVolume = 1;

    public void ChangeStatus(bool isPlay)
    {
        if (isPlay)
            StartCoroutine(ChangeVolume(_maxVolume));
        else
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