using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

   
    public bool vertical;
    Rigidbody2D rigidbody2D;

    public float changeTime=3.0f;
    public float speed=3.0f;
    float timer;
    int direction=1;
    void Start()
    {
        rigidbody2D=GetComponent<Rigidbody2D>();

        timer=changeTime;
    }

    // Update is called once per frame
    void Update()
    {

        timer-=Time.deltaTime;
        if(timer<0){
            direction=-direction;
            timer=changeTime;
        }
    }
    void FixedUpdate()
    {
        //Debug.Log("enter into enemyController FixedUpdate");
        //Debug.Log("speed"+speed);
        Vector2 position=rigidbody2D.position;
        if(vertical){
             position.y=position.y + Time.deltaTime*speed*direction;
        }
        else{
            position.x=position.x + Time.deltaTime*speed*direction;
        }
        rigidbody2D.MovePosition(position);

    }
    //
    void OnCollisionEnter2D(Collision2D other)    //Collision2D  和 Collider2D的不同
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();  //这里多了一个gameObject对象来进行调用

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }
}
