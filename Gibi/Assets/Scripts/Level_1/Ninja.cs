using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class Ninja : Unit {

    [SerializeField]
    private int lives = 3;
    [SerializeField]
    private float speed = 3.0F;
    [SerializeField]
    private float jump = 15.0F;
    float reloadTimer = 0.5f;
    new private Rigidbody2D rigid;
    private Animator animator;
    private SpriteRenderer sprite;
    private float NomenalTimeForReloading = 0.5f;
    [SerializeField]
    private Fireball fireball;
    private bool isGround = false;
    private bool bShooting = false;
    public int Lives 
    {
        get { return lives; }
        set { if(value<3)lives = value;
            livesbar.Refresh();
        }
    }
    private LivesBar livesbar;

    private NinjaState State 
    {
        get
        {
            return (NinjaState)animator.GetInteger("State");
        }
        set
        {
            animator.SetInteger("State",(int)value);
        }
    }




    private void Awake()
    {
        livesbar = FindObjectOfType<LivesBar>();
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        fireball = Resources.Load<Fireball>("Fireball");
    }

    private void FixedUpdate()
    {
        ChekGround();
    }
    private void Update()
    {
        if (isGround) State = NinjaState.Idol;
        reloadTimer -= Time.deltaTime;
        if (Input.GetButton("Fire1") && reloadTimer <= 0)bShooting=true;
        if (bShooting) { Shoot(); bShooting = false; reloadTimer = NomenalTimeForReloading; }
        if (Input.GetButton("Horizontal")) Run();
       // if (Input.GetButton("Vertical"))SitDowm();
        if (isGround && Input.GetButtonDown("Jump")) Jump();
    }
   
    private void Run () 
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

        sprite.flipX = direction.x < 0.0F;

        if(isGround) State = NinjaState.Run;
    }


    private void Jump () 
    {
        
        rigid.AddForce(transform.up*jump,ForceMode2D.Impulse);
       
    }
    private void SitDowm()
    {
        //transform.position = new Vector3(0.0F, transform.position.y - 0.000000001F);
        
    }
    private void Shoot () 
    {
       
        Vector3 position = transform.position; position.y += 1.0F; position.x -= 2.0F;
        Fireball newFireball = Instantiate(fireball, position, fireball.transform.rotation) as Fireball;
        newFireball.Parent = gameObject;
        newFireball.Direction = newFireball.transform.right * (sprite.flipX ? -1.0F : +1.0F);

     
    }
   
   
    private void ChekGround () 
    {
        Collider2D [] coll = Physics2D.OverlapCircleAll(transform.position, 0.3F);
        isGround = coll.Length > 1;
        if (!isGround) State = NinjaState.Jump;

    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.gameObject.GetComponent<Unit>();
        MonsterMove monsterMove = collider.gameObject.GetComponent<MonsterMove>();
        Monster monster = collider.gameObject.GetComponent<Monster>();
        if(unit && !monster && !monsterMove)
        {
            ResieveDamage();
        }
    }
    public override void ResieveDamage ()
    {
        Lives--;
        Debug.Log(lives);
        if (lives == 0) Die();
    }

}
