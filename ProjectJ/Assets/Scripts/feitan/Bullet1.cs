using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    // public static void new()
    // {

    // }
    public float aggressivity;//攻击力
    private Rigidbody2D rigidbody2D;


     
    void Awake()
    {
        rigidbody2D=GetComponent<Rigidbody2D>();
        
    }
    void Update()
    {
        if(transform.position.magnitude>1000.0f)  //距离离世界中心大于1000时，销毁对象
        {
            Destroy(gameObject);
        }
    }

    public void Launch(Vector2 direction,float force)  //direction这里为向量
    {
        rigidbody2D.AddForce(direction * force); //在这个方向上添加一个力

    }
    void OnCollisionEnter2D(Collision2D other)  //和其他物体相撞之后，飞弹消失
    {
        Debug.Log("Projectile Collision with " + other.gameObject);
        Destroy(gameObject);
    }
}
