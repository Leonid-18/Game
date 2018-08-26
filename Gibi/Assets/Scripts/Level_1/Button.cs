using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Button : MonoBehaviour
{

    private void OnMouseDown()
    {

        transform.localScale = new Vector3(19.0f, 19.0f, 19.0f);
    }
    private void OnMouseUp()
    {

        transform.localScale = new Vector3(18.0f, 18.0f, 18.0f);
    }
    private void OnMouseUpAsButton()
    {


        switch (gameObject.name)
        {
            case "Button_Reset":
                SceneManager.LoadScene("Scene_1");
                break;
            case "Button_Menu":
                SceneManager.LoadScene("Menu");
                break;
                
        }

    }
}