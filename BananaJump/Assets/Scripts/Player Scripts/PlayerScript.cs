using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    private Rigidbody2D myBody;

    public float move_Speed = 2f;

    public float normal_Push = 10f;
    public float extra_Push = 14f;

    private bool initial_Push;

    private int push_Count;

    private bool player_Died;

    
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

 
    void Update()
    {
    
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "ExtraPush")
        {
            if(!initial_Push)
            {
                initial_Push = true;
                myBody.velocity = new Vector2(myBody.velocity.x, 18f);
                target.gameObject.SetActive(false);

                //SoundManager

                return;
            }
        }
    }

   
        
    
}
