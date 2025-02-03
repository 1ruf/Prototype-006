using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class ClasicSystem : MonoBehaviour
{
    [SerializeField] private ClassicEnemy _enemy;
    [SerializeField] private GameObject ChooseUI;
    [SerializeField] private GameObject _blocker;
    [SerializeField] private Animator _cutsceneAnimator;
    [SerializeField] private GameObject _revolver;
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI _orderTMP;
    [Header("Setting")]
    [SerializeField] private float _introFadeTime;

    public int SpinCnt; //���� ���� ���� ���� Ƚ��

    private int _currentTurn; //0 = plr, 1 = bot

    private int _bulletPosition; // 1 ~ 6
    private int _currentCylinder;
    private void OnEnable()
    {
        _orderTMP.text = "";
        StartCoroutine(Fadeout(1f));
        RandomSetBullet();
    }

    private IEnumerator Fadeout(float time)
    {
        yield return new WaitForSeconds(time);
        _blocker.GetComponent<Image>().DOFade(0f, _introFadeTime).OnComplete(() => _blocker.SetActive(false));
        yield return new WaitForSeconds(5.5f);

        ButtonManager_Cla.Instance.CurrentA = ButtonMode_A.ChooseTurn;
        ButtonManager_Cla.Instance.SetBtn_A(true);
    }

    private void SetBullet(int num)
    {
        _currentCylinder = num;
        if (_currentCylinder > 6) _currentCylinder = 1;
        SpinCnt++;
        print(SpinCnt);
    }

    private void RandomSetBullet()
    {
        _bulletPosition = Random.Range(1, 7);
        _currentCylinder = Random.Range(1, 7);
        SpinCnt = 0;
    }

    public void ChooseTurn()
    {
        int starter = Random.Range(0, 2);
        _currentTurn = starter;
        if (starter == 0)
        {
            PlayAnimation("Starter_PLAYER");
        }
        else
        {
            PlayAnimation("Starter_BOT");
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
        PlayAnimation("ChooseWay");
        StartCoroutine(SetEnableDelay(ChooseUI, true, 2f));

        //������ ���� �����ϴ� ui ����

        //�ڽ��� �����ϴ� �ִϸ��̼� ����. ����Ҹ�,ȣ��Ҹ� �߰�
    }
    public void PlayerTriggerPulled()
    {
        if (_currentCylinder == _bulletPosition) //ź�� ������?
        {
            print("���!");
            PlayAnimation("PlayerDie");
        }
        else
        {
            PlayAnimation("PullTrigger");
            SetBullet(_currentCylinder + 1);
            StartCoroutine(CheckTurnDelay(3.6f));
        }
        _currentTurn = 1;//1 == enemy
    }
    public void AimmingBtnClicked()
    {
        ChooseUI.SetActive(false);
        PlayAnimation("AimmingSelf");
        StartCoroutine(SetEnableDelay(ButtonManager_Cla.Instance._btnB, true, 2f));
    }

    public void SpinBtnClicked()
    {
        ChooseUI.SetActive(false);
        PlayAnimation("PlayerSpin");
        //���� Ƚ�� ���̱�
        RandomSetBullet();
        StartCoroutine(SetEnableDelay(ChooseUI, true, 3.2f));
    }

    public void EnemyTurn()
    {
        print("��� �� �Դϴ�.");
        _enemy.EnemyThink(SpinCnt);


        _currentTurn = 0;//0 == player
        //������vvv
        CheckTurn();
    }

    public void PlayAnimation(string name)
    {
        _cutsceneAnimator.Play(name);
    }

    private IEnumerator CheckTurnDelay(float time)
    {
        yield return new WaitForSeconds(time);
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

