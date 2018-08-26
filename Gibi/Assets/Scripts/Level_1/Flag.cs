using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flag : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Unit unit = collision.GetComponent<Unit>();


        if (unit && unit is Ninja)
        {
            SceneManager.LoadScene("Scene_2");
        }


    }
}
