using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dieCollider_2 : dieColider {

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {

        Unit unit = collision.GetComponent<Unit>();


        if (unit && unit is Ninja)
        {
            SceneManager.LoadScene("Scene_2");
        }


    }
}
