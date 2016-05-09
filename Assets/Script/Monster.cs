using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {

    GameObject player;
    float speed= 0.25f;
    bool start = false;
    Vector3 PlayerMovementTarget;
    Vector3[] MovementTarget = new Vector3[100];
    int movement = 0;
    int movementMax = 0;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PLAYER");
    }

    void Update()
    {
       
        if (start != false)
        {
            Monster_Move();
            ArrayMaxCheck();
        }
    }
    void ArrayMaxCheck() 
    {
        if(movementMax>= 30)
        {
            movementMax = 0;
        }
        if (movement >= 30)
        {
            movement = 0;
        }
    }
    void Monster_Move()
    {
        float dist=0;

        Vector3 Direction = (MovementTarget[movement] - this.transform.position);
        dist = Vector3.Distance(this.transform.position, MovementTarget[movement]);
        if (dist < 1f)
        {
                movement++;
                Debug.Log(movement);
        }
        else if(movement == movementMax)
        {
            
            PlayerMovementTarget = player.transform.position;
            Direction = (PlayerMovementTarget - this.transform.position);
            Direction.Normalize();
            this.transform.Translate(Direction * speed * Time.deltaTime);
        }
        else
        {
            dist = Vector3.Distance(this.transform.position, player.transform.position);
            if (dist > 5f)
            {
                speed += 0.01f;
            }
            else if (dist < 4f)
            {
                speed = 0.25f;
            }
            Direction.Normalize();
            this.transform.Translate(Direction * speed * Time.deltaTime);

        }
    }

    public void MonsterTargetPoint(Vector3 position)
    {
        start = true;
        MovementTarget[movementMax] = position;
        movementMax++;
    }

}


