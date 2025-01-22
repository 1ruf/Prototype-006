using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class ClasicSystem : MonoBehaviour
{
    [SerializeField] private GameObject ChooseUI;
    [SerializeField] private GameObject _blocker;
    [SerializeField] private Animator _cutsceneAnimator;
    [SerializeField] private GameObject _revolver;
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI _orderTMP;
    [Header("Setting")]
    [SerializeField] private float _introFadeTime;

    private int _currentTurn; //0 = plr, 1 = bot
    private void OnEnable()
    {
        _orderTMP.text = "";
        StartCoroutine(Fadeout(1f));
    }

    private IEnumerator Fadeout(float time)
    {
        yield return new WaitForSeconds(time);
        _blocker.GetComponent<Image>().DOFade(0f, _introFadeTime).OnComplete(() => _blocker.SetActive(false));
        yield return new WaitForSeconds(5.5f);

        ButtonManager_Cla.Instance.CurrentA = ButtonMode_A.ChooseTurn;
        ButtonManager_Cla.Instance.SetBtn_A(true);
    }

    public void ChooseTure()
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
        CheckTurn(4.5f);
    }

    private void CheckTurn(float time = 0)
    {
        StartCoroutine(CheckTurnCoroutine(time));
    }
    private IEnumerator CheckTurnCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
        if (_currentTurn == 0)
        {
            PlayerTurn();
        }
        else
        {
            EnemyTurn();
        }
    }

    public void PlayerTurn()
    {
        _orderTMP.text = "Grab the gun";
        StartCoroutine(SetGunClick(true));
    }
    public void PlayerChoose()
    {
        _orderTMP.text = "";
        StartCoroutine(SetAnimator(_cutsceneAnimator, true));
        _cutsceneAnimator.Play("ChooseWay");
        StartCoroutine(SetEnableDelay(ChooseUI, true, 2f));

        //돌릴지 쏠지 결정하는 ui 띄우기

        //자신을 조준하는 애니메이션 실행. 심장소리,호흡소리 추가
        _currentTurn = 1;//1 == enemy
    }
    public void AimmingBtnClicked()
    {
        ChooseUI.SetActive(false);
        _cutsceneAnimator.Play("AimmingSelf");
    }


    public void EnemyTurn()
    {
        print("상대 턴 입니다.");



        _currentTurn = 0;//0 == player

        //디버깅용vvv
        CheckTurn();
    }




    private IEnumerator SetAnimator(Animator animator,bool value, float time = 0)
    {
        yield return new WaitForSeconds(time);
        animator.enabled = value;
    }

    private IEnumerator SetGunClick(bool value, float time = 0)
    {
        yield return new WaitForSeconds(time);
        _revolver.GetComponentInChildren<Gun>().SetGunClick(value);
    }

    private IEnumerator SetEnableDelay(GameObject gameObject, bool value, float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(value);
    }
}

