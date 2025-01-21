using UnityEngine;
using UnityEngine.Audio;

public class FirstLoad : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _output;

    private AudioSource _audio;

    [Header("--Resources--")]
    [SerializeField] private AudioResource _spin;
    [SerializeField] private AudioResource _close;
    [Header("Bullet")]
    [SerializeField] private AudioResource _bulletBounce;
    [SerializeField] private AudioResource _bulletLay;
    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _audio.outputAudioMixerGroup = _output;
    }
    public void PlaySpinSFX()
    {
        PlayAudio(_spin);
    }

    public void PlayCloseSFX()
    {
        PlayAudio(_close);
    }

    public void PlayBulletBounce()
    {
        PlayAudio(_bulletBounce);
    }

    public void PlayBulletLay()
    {
        PlayAudio(_bulletLay);
    }

    private void PlayAudio(AudioResource audio) 
    {
        _audio.resource = audio;
        _audio.Play();
    }
}
