using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {
    [SerializeField]
    protected float speed = 10.0F;
    protected GameObject parent;
    public GameObject Parent { set { parent = value; }}
    protected Vector3 direction;
    protected SpriteRenderer sprite;
    public Vector3 Direction { set { direction = value; }}
    protected void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
    protected void Start()
    {
        Destroy(gameObject,1.4F);
    }
    protected void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        sprite.flipX = direction.x < 0.0F;
    }
    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();
        if(unit && unit.gameObject != parent)
        {
            unit.ResieveDamage();
            Destroy(gameObject);
        }
    }
}
