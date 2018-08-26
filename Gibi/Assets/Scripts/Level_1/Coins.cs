using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Unit unit = collision.GetComponent<Unit>();


        if (unit && unit is Ninja)
        {
            Score.scoreAmount += 1;
            Score_2.scoreAmount_2 += 1;
            Destroy(gameObject);
        }


    }
}
