using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    [SerializeField]
    private float speed = 2.0F;
    [SerializeField]
    private Transform target;
	// Use this for initialization
	private void Awake () {

        if (!target) target = FindObjectOfType<Ninja>().transform;
	}
	
	// Update is called once per frame
	private void Update () {

        Vector3 position = target.position; position.z = -10.0F; position.y += 2.0F;
        transform.position = Vector3.Lerp(transform.position,position, speed * Time.deltaTime);
		
	}
}
