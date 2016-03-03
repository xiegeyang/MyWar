using UnityEngine;
using System.Collections;

public class Mob : MonoBehaviour {
    public float speed;    
    public float lookRange = 8;
    public float chaseRange = 6;
    public float attackRange = 1;
    public CharacterController controller;
    private Fighter opponent;
    public Transform player;
    public AnimationClip run;
    public AnimationClip idle;
    public AnimationClip attack;
    public AnimationClip die;
    private Animation ani;    
    public float maxHealth;
    public float currHealth;
    public double impactTime = 0.36;
    private bool impacted;
    public int damage;

	// Use this for initialization
	void Start () {
        ani = GetComponent<Animation>();
        currHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        if (!isDead())
        {
            chase();
            //Debug.Log(health);
        }
        else
        {
            dieMethod();
        }           
	}    

    void chase()
    {
        //Chase player
        if(Vector3.Distance(transform.position, player.position) < chaseRange && Vector3.Distance(transform.position, player.position) > attackRange)
        {
            lookAt();
            controller.SimpleMove(transform.forward * speed);
            ani.CrossFade(run.name);
        //look at player
        }else if(Vector3.Distance(transform.position, player.position) < lookRange && Vector3.Distance(transform.position, player.position) > chaseRange)
        {
            lookAt();
            ani.CrossFade(idle.name);
        }
        //idle
        else if(Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            opponent = player.GetComponent<Fighter>();            
            ani.CrossFade(attack.name);
            attackMethod();
            if (ani[attack.name].time > 0.9 * ani[attack.name].length)
            {               
                impacted = false;
            }
        }
        else
        {
            ani.CrossFade(idle.name);
        }             
    }

    void lookAt()
    {
        transform.LookAt(player.position);
    }

    void OnMouseOver()
    {
        player.GetComponent<Fighter>().opponent = gameObject;
    }

    public void getHit(int damage)
    {
        currHealth = currHealth - damage;  
        if(currHealth < 0)
        {
            currHealth = 0;
        }      
    }

    bool isDead()
    {
        if (currHealth <= 0)
        {            
            return true;
        }
        else{
            return false;
        }
    }

    void dieMethod()
    {
        ani.Play(die.name);
        if (ani[die.name].time > ani[die.name].length * 0.9)
        {
            Destroy(gameObject);
        }
    }

    void attackMethod()
    {
        if(ani[attack.name].time>impactTime * ani[attack.name].length && !impacted && ani[attack.name].time < 0.9 * ani[attack.name].length)
        {
            opponent.getHit(damage);
            impacted = true;
        }
    }
}
