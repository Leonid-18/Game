using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Buttons : MonoBehaviour {
   
    private void OnMouseDown()
    {
     
            transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
    }
    private void OnMouseUp()
    {
        
       transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }
    private void OnMouseUpAsButton()
    {
                    
                
        switch(gameObject.name)
        {
            case "Play" : SceneManager.LoadScene("Scene_1");
                break;
        }

    }
}
