using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ClasicSystem : MonoBehaviour
{
    [SerializeField] private GameObject _blocker;
    [SerializeField] private Animator _cutsceneAnimator;
    [SerializeField] private GameObject _revolver;
    [Header("Setting")]
    [SerializeField] private float _introFadeTime;

    private int _currentTurn; //0 = plr, 1 = bot
    private void OnEnable()
    {
        StartCoroutine(Fadeout(1f));
    }

    private IEnumerator Fadeout(float time)
    {
        yield return new WaitForSeconds(time);
        _blocker.GetComponent<Image>().DOFade(0f, _introFadeTime).OnComplete(() => _blocker.SetActive(false));
        yield return new WaitForSeconds(5.5f);
        ChooseTure();
    }

    private void ChooseTure()
    {
        int starter = Random.Range(0, 2);
        _currentTurn = starter;
        if (starter == 0)
        {
            _cutsceneAnimator.Play("Starter_PLAYER");
        }
        else
        {
            _cutsceneAnimator.Play("Starter_BOT");
        }
        StartCoroutine(SetAnimator(_cutsceneAnimator, false, 4.5f));
    }

    private IEnumerator SetAnimator(Animator animator,bool value, float time = 0)
    {
        yield return new WaitForSeconds(time);
        animator.enabled = value;
    }
}
