using UnityEngine;
using UnityEngine.Audio;

public class BGM_M : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _bgmGroup;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.outputAudioMixerGroup = _bgmGroup;
    }
}
