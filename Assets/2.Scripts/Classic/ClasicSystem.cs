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
    [SerializeField] private TextMeshProUGUI _spinCounter;
    [SerializeField] private Button _spinBtn;
    [SerializeField] private TextMeshProUGUI _orderTMP;
    [Header("Setting")]
    [SerializeField] private float _introFadeTime;

    public int SpinCnt; //���� ���� ���� ���� Ƚ��

    public int CurrentTurn; //0 = plr, 1 = bot

    private int _bulletPosition; // 1 ~ 6
    private int _currentCylinder;

    private int _resetCount = 3;
    private void OnEnable()
    {
        _orderTMP.text = "";
        StartCoroutine(Fadeout(1f));
        RandomSetBullet();
        _orderTMP.text = "";
        StartCoroutine(SetGunClick(false));
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
        print($"���� �Ǹ���:{_currentCylinder},�Ѿ� ��ġ:{_bulletPosition}");
        SpinCnt = 0;
    }

    public void ChooseTurn()
    {
        int starter = Random.Range(0, 2);
        CurrentTurn = starter;
        if (starter == 0)
        {
            PlayAnimation("Starter_PLAYER");
        }
        else
        {
            PlayAnimation("Starter_BOT");
        }
        CheckTurn(4.5f);
    }

    private IEnumerator CheckTurnCoroutine(float time)
    {
        print("�� üũ �ڷ�ƾ");
        yield return new WaitForSeconds(time);
        if (CurrentTurn == 0)
        {
            PlayerTurn();
        }
        else
        {
            _orderTMP.text = "";
            StartCoroutine(SetGunClick(false));
            EnemyTurn();
        }
    }

    public void CheckTurn(float time = 0)
    {
        StartCoroutine(CheckTurnCoroutine(time));
    }
    public bool CheckBullet()
    {
        if (_bulletPosition == _currentCylinder) return true;
        return false;
    }

    public void PlayerTurn()
    {
        print("�÷��̾���");
        _orderTMP.text = "Grab the gun";
        _spinCounter.text = $"x{_resetCount}";
        StartCoroutine(SetGunClick(true));
    }
    public void PlayerChoose()
    {
        _orderTMP.text = "";
        PlayAnimation("ChooseWay");
        StartCoroutine(SetEnableDelay(ChooseUI, true, 2f));

        //������ ���� �����ϴ� ui ����

        //�ڽ��� �����ϴ� �ִϸ��̼� ����. ����Ҹ�,ȣ��Ҹ� �߰�
    }
    public void PlayerTriggerPulled()
    {
        if (CheckBullet()) //ź�� ������?
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
        CurrentTurn = 1;//1 == enemy
    }
    public void AimmingBtnClicked()
    {
        ChooseUI.SetActive(false);
        PlayAnimation("AimmingSelf");
        StartCoroutine(SetEnableDelay(ButtonManager_Cla.Instance._btnB, true, 2f));
    }

    public void SpinBtnClicked()
    {
        if (_resetCount <= 0) return;
        ChooseUI.SetActive(false);
        PlayAnimation("PlayerSpin");
        _resetCount--;
        RandomSetBullet();
        StartCoroutine(SetEnableDelay(ChooseUI, true, 3.2f));
        if(_resetCount <= 0) _spinBtn.enabled = false;
        _spinCounter.text = $"x {_resetCount}";
    }

    public void EnemyTurn()
    {
        _orderTMP.text = "";
        StartCoroutine(SetGunClick(false));
        _enemy.EnemyThink(SpinCnt);
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

