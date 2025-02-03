using UnityEngine;

public class ClassicEnemy : MonoBehaviour
{
    [SerializeField] private ClasicSystem _system;

    private int _enemySpinCount = 3;
    private int _spined;

    public void EnemyThink(int spinCnt)
    {
        _spined = spinCnt;
        _system.PlayAnimation("EnemyGrabGun");
        if (ThinkSpin(spinCnt))
        {
            _system.SpinCnt = 0;
            _spined = 0;
            print("cylinder Spined.");
        }
        //조준사격
        _system.SpinCnt++;
    }

    private bool ThinkSpin(int spinCnt)
    {
        if (_enemySpinCount <= 0) return false;
        if (spinCnt >= 6) return true;
        int spinPercent;
        int percentMultiply = 1;
        spinPercent = Random.Range(spinCnt, 7);

        if (spinPercent == 6)
        {
            return true;
        }
        if (Random.Range(0, 2) == 1)
        {
            ThinkSpin(spinCnt);
        }
        return false;
    }
}
