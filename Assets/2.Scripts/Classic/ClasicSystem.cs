using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ClasicSystem : MonoBehaviour
{
    [SerializeField] private GameObject _blocker;
    [Header("Setting")]
    [SerializeField] private float _introFadeTime;
    private void OnEnable()
    {
        StartCoroutine(Fadeout(1f));
    }

    private IEnumerator Fadeout(float time)
    {
        yield return new WaitForSeconds(time);
        _blocker.GetComponent<Image>().DOFade(0f, _introFadeTime).OnComplete(() => _blocker.SetActive(false));
    }
}
