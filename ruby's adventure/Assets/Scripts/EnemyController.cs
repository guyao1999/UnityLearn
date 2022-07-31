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

    Animator animator;

    bool broken=true;

    public ParticleSystem smokeEffect;
    void Start()
    {
        rigidbody2D=GetComponent<Rigidbody2D>();

        timer=changeTime;

        animator = GetComponent<Animator>();  //获取Animator组件
    }

    // Update is called once per frame
    void Update()
    {

        if(!broken){
            return;
        }

        timer-=Time.deltaTime;
        if(timer<0){
            direction=-direction;
            timer=changeTime;
        }
    }
    void FixedUpdate()
    {
        if(!broken){   //如果机器人是好的，就不乱动了
            return;
        }

        //Debug.Log("enter into enemyController FixedUpdate");
        //Debug.Log("speed"+speed);
        Vector2 position=rigidbody2D.position;
        if(vertical){                                    //上下移动
            position.y=position.y + Time.deltaTime*speed*direction;


            animator.SetFloat("Move X", 0);             //设置动画的参数
            animator.SetFloat("Move Y", direction);
        }
        else{                                          //左右移动
            position.x=position.x + Time.deltaTime*speed*direction;

            animator.SetFloat("Move X", direction);   //设置动画的参数
            animator.SetFloat("Move Y", 0);
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

    public void Fix()
    {
        broken=false;
        rigidbody2D.simulated=false;  //不加入到物理系统中进行物理量的计算

        animator.SetTrigger("Fixed");  //设置动画中的Fixed参数

        smokeEffect.Stop();   //停止粒子特效    不直接进行destory是为了让粒子特效看起来自然
    }
}
