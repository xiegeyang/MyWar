using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public Texture2D frame;
    public Rect framPosition;

    public Texture2D healthBar;
    public Rect healthBarPosition;

    public Texture2D healthBar2;
    public Rect healthBarPosition2;

    public Texture2D Bar;
    public Rect Position;

    public Texture2D Bar2;
    public Rect Position2;

    public GameObject player;


	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        drawFrame();
        drawBar();
        
    }

    void drawFrame()
    {
        GUI.DrawTexture(framPosition, frame);
        GUI.DrawTexture(healthBarPosition, healthBar);
        GUI.DrawTexture(healthBarPosition2, healthBar2);
    }

    void drawBar()
    {
        Position.width = 282 * player.GetComponent<Fighter>().health / 100;
        GUI.DrawTexture(Position, Bar);
        GUI.DrawTexture(Position2, Bar2);
    }
}
