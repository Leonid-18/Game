using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MonsterMove : Monster {

    [SerializeField]
    private float speed = 0.5F;
  
    private SpriteRenderer sprite;
    private Vector3 direction;
    protected override void Awake ()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();

       
    }
    protected override void Start ()
    {
        direction = transform.right;
    }
    protected override void Update()
    {
        Move();
    }
	// Update is called once per frame

    private void Move()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position+transform.up*(-1.5F) + transform.right*direction.x*0.2F,0.001F);
        if(colliders.Length == 0 && colliders.All(x=>!x.GetComponent<Ninja>())) direction *= -1.0F;
       
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

    }
}
