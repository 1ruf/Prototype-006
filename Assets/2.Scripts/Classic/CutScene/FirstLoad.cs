using Script.UIs;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Audio;

public class FirstLoad : MonoBehaviour
{
    [SerializeField] private EventChannelSO uiEvent;

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

    //07/14/2025 지금보니 코드가 개판이지만 완성까지만 한다...


    public void GameOver_P()
    {
        CallGameover(false);
    }
    public void GameOver_E()
    {
        CallGameover(true);
    }
    private void CallGameover(bool Res)
    {
        GameOverEvent evt = UiEvents.GameOverEvent;
        evt.Result = Res;
        uiEvent.InvokeEvent(evt);
    }
}
