using UnityEngine;

public class ClassicEnemy : MonoBehaviour
{
    [SerializeField] private ClasicSystem _system;

    private int _enemySpinCount = 3;
    private int _spined;

    public void EnemyThink(int spinCnt)
    {
        _system.PlayAnimation("EnemyGrabGun");
    }
}
