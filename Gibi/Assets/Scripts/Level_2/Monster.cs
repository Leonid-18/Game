using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Unit {
    protected virtual void Awake(){}
    protected virtual void Start(){}
    protected virtual void Update(){}
    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();
        Fireball fireball = collider.GetComponent<Fireball>();
        if (fireball) ResieveDamage();
        if (unit is Ninja)
        {
            if (Mathf.Abs(unit.transform.position.x - transform.position.x) < 0.6F) ResieveDamage();
            else unit.ResieveDamage();
        }
    }
}
