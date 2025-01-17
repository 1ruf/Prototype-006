using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

public class UISfx_M : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private AudioMixerGroup _sfxGroup;

    [Header("AudioResources")]
    [SerializeField] private AudioResource _btnTic;
    [SerializeField] private AudioResource _cinematicImpact;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.outputAudioMixerGroup = _sfxGroup;
    }

    public void PlaySound_Tic()
    {
        _audioSource.resource = _btnTic;
        _audioSource.Play();
    }

    public void PlaySound_Impact()
    {
        _audioSource.resource = _cinematicImpact;
        _audioSource.Play();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        PlaySound_Tic();
    }
}
