using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class dieColider : MonoBehaviour {
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {

        Unit unit = collision.GetComponent<Unit>();


        if (unit && unit is Ninja)
        {
            SceneManager.LoadScene("Scene_1");
        }


    }
}
