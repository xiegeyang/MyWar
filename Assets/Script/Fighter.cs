using UnityEngine;
using System.Collections;

public class Fighter : MonoBehaviour {

    public GameObject opponent;
    public AnimationClip attack;
    public AnimationClip die;
    private Animation anim;
    public int damage;
    public double impactTime;
    public bool impacted;
    public float range;
    public int health;
    bool started;
    bool ended;
    
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(health);
        
        
        if (Input.GetKey(KeyCode.Alpha1))
        {            
            anim.Play(attack.name);
            ClickToMove.attack = true;
            if (opponent != null)
            {
                transform.LookAt(opponent.transform.position);
            }
        }
        if (anim[attack.name].time > 0.9 * anim[attack.name].length)
        {
            ClickToMove.attack = false;
            impacted = false;
        }
        impact();                      
        dieMethod();        
}

    void impact()
    {
        if (opponent != null && anim.IsPlaying(attack.name) && !impacted && inRange())
        {
            if (anim[attack.name].time > anim[attack.name].length * impactTime && anim[attack.name].time<0.9*anim[attack.name].length)
            {
                opponent.GetComponent<Mob>().getHit(damage);
                impacted = true;
            }
        }
    }

    bool inRange()
    {
        if (Vector3.Distance(opponent.transform.position, transform.position) <= range)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void getHit(int damage)
    {
        health = health - damage;
        if(health < 0)
        {
            health = 0;
        }
    }

    bool isDead()
    {
        return health <= 0;
    }

    void dieMethod()
    {        
        if(isDead() && !ended)
        {
            if (!started)
            {
                ClickToMove.die = true;
                anim.Play(die.name);
                started = true;
            }
            if(started && !anim.IsPlaying(die.name))
            {
                Debug.Log("You have dead!");                
                ended = true;
                //health = 100;
                //started = false;
                //ClickToMove.die = false;              
            }
        }
    }
}
