using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
public enum BombState
{
    Bomb,
    Explode

}

public class Bobm : MonoBehaviour {
    private Animator animator;

    private BombState State
    {
        get
        {
            return (BombState)animator.GetInteger("State");
        }
        set
        {
            animator.SetInteger("State", (int)value);
        }
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        Unit unit = collision.GetComponent<Unit>();


            if (unit && unit is Ninja)
            {

                State = BombState.Explode;

                 unit.ResieveDamage();
                 Destroy(gameObject,1.0F);
            }
       
       
    }
}
