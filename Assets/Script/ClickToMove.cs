using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour {


    public float speed;
    public CharacterController controller;
    private Vector3 position;
    private Animation anim;

    public AnimationClip run;
    public AnimationClip idle;
    public static bool attack;
    public static bool die;
    // Use this for initialization
    void Start () {
        position = transform.position;
        anim = GetComponent<Animation>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!attack && !die)
        {
            if (Input.GetMouseButton(0))
            {
                locatePosition();
            }

            moveToPosition();
        }
        else
        {

        }
        
	}

    void locatePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray,out hit, 1000))
        {
            if(hit.collider.tag != "Player" && hit.collider.tag != "Enemy")
            {
                position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            }
            
            //Debug.Log(position);
        }
    }

    void moveToPosition()
    {
        //Game object is moving
        if (Vector3.Distance(transform.position, position) > 1)
        {
            Quaternion newRotation = Quaternion.LookRotation(position - transform.position, Vector3.forward);

            newRotation.x = 0f;
            newRotation.z = 0f;

            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10);
            controller.SimpleMove(transform.forward * speed);

            anim.CrossFade(run.name);
        }
        //Game object is not moving
        else
        {
            anim.CrossFade(idle.name);            
        }

    }
}
