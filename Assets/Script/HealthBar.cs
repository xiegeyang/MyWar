using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

    public GameObject healthBar;
    public GameObject self;    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        setHeathBar();
        
	}

    void setHeathBar()
    {
        healthBar.transform.localScale = new Vector3(self.GetComponent<Mob>().currHealth / self.GetComponent<Mob>().maxHealth, 1f, 1f);
    }

    
}
