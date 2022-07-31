using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2D=GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
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
        //我们还增加了调试日志来了解飞弹触碰到的对象
        Debug.Log("Projectile Collision with " + other.gameObject);
        Destroy(gameObject);

        EnemyController e=other.collider.GetComponent<EnemyController>();  //other碰撞的2D框，other.collider为这个碰撞框的挂载对象
        if(e!=null){             //如果这个机器人的存在，就将这个机器人修复
            e.Fix();
        }
        Destroy(gameObject);
    }
}
