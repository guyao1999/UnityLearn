using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;//速度
    public float aggressivity;//攻击力
    public GameObject explosionPrefab;//爆炸特效
    new private Rigidbody2D rigidbody;//

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

    }
    //设置子弹方向
    public void SetSpeed(Vector2 direction)
    {
        rigidbody.velocity = direction * speed;
    }
    //子弹碰撞
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (true) {
            //通过图层判断是玩家or敌人，调用伤害函数
        }
        //爆炸特效
        //GameObject exp = ObjectPool.Instance.GetObject(explosionPrefab);
        //exp.transform.position = transform.position;

        // Destroy(gameObject);
        ObjectPool.Instance.PushObject(gameObject);  //放进去干嘛 直接销毁掉不是更好
    }
}
