using System.ComponentModel;
using UnityEngine;
using UnityEngine.Audio;

public class FirstLoad : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _output;

    private AudioSource _audio;

    [Header("--Resources--")]
    [SerializeField] private AudioResource _spin;
    [SerializeField] private AudioResource _close;
    [SerializeField] private AudioResource _bulletInsert;
    [SerializeField] private AudioResource _hammerTic;
    [SerializeField] private AudioResource _hammerCock;
    [SerializeField] private AudioResource _gunFireSound;
    [SerializeField] private AudioResource _spinAndClose;
    [Header("Bullet")]
    [SerializeField] private AudioResource _bulletBounce;
    [SerializeField] private AudioResource _bulletLay;
    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _audio.outputAudioMixerGroup = _output;
    }
    public void PlayBulletInsert()
    {
        PlayAudio(_bulletInsert);
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

    public void PlayHammerTic()
    {
        PlayAudio(_hammerTic);
    }

    public void PlayGunShot()
    {
        PlayAudio(_gunFireSound);
    }

    public void PlaySpinAndClose()
    {
        PlayAudio(_spinAndClose);
    }

    public void PlayHammerCocked()
    {
        PlayAudio(_hammerCock);
    }

    private void PlayAudio(AudioResource audio) 
    {
        _audio.resource = audio;
        _audio.Play();
    }

//깃허브 모바일로 편집됨. 2025-1-26-02:03
}
