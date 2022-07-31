using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun1 : MonoBehaviour
{
    public float interval;       //射击间隔时间
    public int bulletNum;        //子弹数量
    public float aggressivity;   //攻击力 or 伤害
    protected Vector2 direction; //发射方向

    protected float timer;       //计时器
    protected float flipY;

    public GameObject bulletPrefab;        //子弹预制体

    public void initComponent()//得到child gameobject 和component
    {
        flipY = transform.localScale.y;
        GameObject bulletGo =transform.Find("bullet").gameObject;
        // bullet=bulletGo.transform.GetComponent("bullet");
        bulletNum=80;
    }

    protected virtual void Start()
    {
        initComponent();
    }

    protected virtual void Update()
    {
        Shoot();
    }
    //射击，或者挥刀
    protected virtual void Shoot()
    {
        float intervalNow = interval * 3.0f;//  3.0f=fireSpeed;
        if (timer != 0)
        {
            timer -= Time.deltaTime;  //更新计时器
            if (timer <= 0)
                timer = 0;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            if (timer == 0)
            {
                timer = intervalNow;
                Fire();
            }
        }
    }
    protected  void Fire()
    {
        // bullet.transform.rotation = transform.rotation;  //子弹方向和手枪方向保持一致
        // //设置子弹移动方向
        // Vector2 enemyPosition = GetEnemy(); //这是一个方向
        // direction = new Vector2(enemyPosition.x - bullet.transform.position.x, enemyPosition.y - bullet.transform.position.y);
        // float angel = Random.Range(-5f, 5f);//子弹偏移角度
        // bullet.SetSpeed(Quaternion.AngleAxis(angel, Vector3.forward) * direction);//设置移动方向

        // GameObject bullet = Instantiate(bulletPrefab,weaponPos1.position,Quaternion.identity,transform);  //创建出来的gun不属于任何人，属于世界场景
    }
}
