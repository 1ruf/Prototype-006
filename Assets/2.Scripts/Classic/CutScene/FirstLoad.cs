using UnityEngine;
using UnityEngine.Audio;

public class FirstLoad : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _output;

    private AudioSource _audio;

    [Header("Resources")]
    [SerializeField] private AudioResource _spin;
    [SerializeField] private AudioResource _close;
    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _audio.outputAudioMixerGroup = _output;
    }
    public void PlaySpinSFX()
    {
        _audio.resource = _spin;
        _audio.Play();
    }

    public void PlayCloseSFX()
    {
        _audio.resource = _close;
        _audio.Play();
    }
}
