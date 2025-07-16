using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ClassicEnemy : MonoBehaviour
{
    [SerializeField] private ClasicSystem _system;

    private int _enemySpinCount = 3;
    private int _spined;

    public void EnemyThink(int spinCnt)
    {
        StartCoroutine(EnemyThinkCo(spinCnt));
        
    }

    private IEnumerator EnemyThinkCo(int spinCnt)
    {
        print("Enemy가 생각하는SpinCnt:" + spinCnt);
        _spined = spinCnt;
        _system.PlayAnimation("EnemyGrabGun");
        yield return new WaitForSeconds(Random.Range(4f, 5f));
        if (ThinkSpin(spinCnt))
        {
            _system.SpinCnt = 0;
            _spined = 0;
        }
        yield return new WaitForSeconds(Random.Range(4f, 5f));
        _system.PlayAnimation("EnemyAimmingSelf");
        yield return new WaitForSeconds(Random.Range(4f, 5f));
        StartCoroutine(PullTrigger());
    }

    public IEnumerator PullTrigger()
    {
        _system.SpinCnt++;
        if (_system.CheckBullet())
        {
            _system.PlayAnimation("EnemyDie");
        }
        else
        {
            _system.PlayAnimation("EnemyPullTrigger");
            yield return new WaitForSeconds(0.7f);
            _system.PlayAnimation("EnemyGetDownGun");
            yield return new WaitForSeconds(2.5f);
            _system.CurrentTurn = 0;
            _system.CheckTurn();
        }   
    }

    private bool ThinkSpin(int spinCnt)
    {
        if (_enemySpinCount <= 0) return false;
        if (spinCnt >= 6) return true;
        int spinPercent;
        spinPercent = Random.Range(spinCnt, 7);

        print("spinPercent:" + spinPercent);

        if (spinPercent >= 6)
        {
            _system.PlayAnimation("EnemyGunSpin");
            return true;
        }
        return false;
    }
}
