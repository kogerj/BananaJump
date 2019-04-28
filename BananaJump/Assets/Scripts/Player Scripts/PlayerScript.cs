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

 
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (player_Died)
            return;

        if (Input.acceleration.x > 0.1)
        {
            myBody.velocity = new Vector2(move_Speed, myBody.velocity.y);
        }
        else if (Input.acceleration.x < -0.1)
        {
            myBody.velocity = new Vector2(-move_Speed, myBody.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (player_Died)
            return;

        if (target.tag == "ExtraPush")
        {
            if (!initial_Push)
            {
                initial_Push = true;
                myBody.velocity = new Vector2(myBody.velocity.x, 18f);
                target.gameObject.SetActive(false);

                SoundManager.instance.JumpSoundFX();

                return;
            }
        }
        if (target.tag == "NormalPush")
        {
            myBody.velocity = new Vector2(myBody.velocity.x, normal_Push);
            target.gameObject.SetActive(false);
            push_Count++;
            SoundManager.instance.JumpSoundFX();
        }

        if (target.tag == "ExtraPush")
        {
            myBody.velocity = new Vector2(myBody.velocity.x, extra_Push);
            target.gameObject.SetActive(false);
            push_Count++;
            SoundManager.instance.JumpSoundFX();

        }

        if(push_Count == 2)
        {
            push_Count = 0;
            PlatformSpawner.instance.SpawnPlatforms();
        }

        if(target.tag == "FallDown" || target.tag == "Bird")
        {
            player_Died = true;

            GameManager.instance.RestartGame();
            SoundManager.instance.GameOverSoundFX();
        }
    }     
    
}
