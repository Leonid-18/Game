using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesBar : MonoBehaviour {

    private Transform[] hearts = new Transform[3];
    private Ninja ninja;
    private void Awake()
    {
        ninja = FindObjectOfType<Ninja>();
        for (int i = 0; i < hearts.Length;i++)
        {
            hearts[i] = transform.GetChild(i);
        }
    }
    public void Refresh ()
    {
        for (int i = 0; i < hearts.Length;i++)
        {
            if (i < ninja.Lives) hearts[i].gameObject.SetActive(true);
            else hearts[i].gameObject.SetActive(false);
        }
    }
}
