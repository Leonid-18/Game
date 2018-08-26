using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableMonster : Monster
{

    [SerializeField]
    private float rate = 2.0F;
    private Fireball fireball;
    Balls balls;
    private SpriteRenderer sprite;
    protected override void  Awake()
	{
        balls = Resources.Load<Balls>("Balls");
        sprite = GetComponentInChildren<SpriteRenderer>();
	}
	protected override void Start()
	{
        InvokeRepeating("Shoot", rate, rate);
	}
	protected override void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();
        Fireball fireball = collider.GetComponent<Fireball>();
        if (fireball && !balls) ResieveDamage();
        if (unit is Ninja)
        {
            if (Mathf.Abs(unit.transform.position.x - transform.position.x) < 1.5F) ResieveDamage();
            else unit.ResieveDamage();
        }
    }
	private void Shoot()
    {
        Vector3 position = transform.position; position.y += 0.5F;
        Balls newBalls = Instantiate(balls, position, balls.transform.rotation) as Balls;

        newBalls.Parent = gameObject;
        newBalls.Direction = newBalls.transform.right * (sprite.flipX ? 1.0F : -1.0F);
    }
}