using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="A.I/Enemy Actions/Attack Action")]
public class EnemyAttackAction : EnemyAction
{
    public EnemyAttackAction comboAction;
    public bool canDoCombo;
    public int attackScore=3;
    public float recoveryTime=2;
    public float maximumAttackAngle=35f;
    public float minimumAttackAngle=-35f;

    public float minimumAttackDistance=0;
    public float maximumAttackDistance=3;
}
