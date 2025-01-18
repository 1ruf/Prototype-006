using DG.Tweening;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ClasicSystem : MonoBehaviour
{
    [SerializeField] private GameObject _blocker;
    private void OnEnable()
    {
        _blocker.GetComponent<Image>().DOFade(0f, 10f).OnComplete(()=>_blocker.SetActive(false));
    }
}
