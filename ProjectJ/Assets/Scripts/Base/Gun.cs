using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float interval;//射击间隔时间
    protected float timer;//计时器

    public float aggressivity;//攻击力

    public GameObject bulletPrefab;//子弹
    public GameObject shellPrefab;//弹壳
    protected Transform muzzlePos;//枪口位置
    protected Transform shellPos;//弹夹位置
    protected Vector2 mousePos;//敌人位置
    protected Vector2 direction;//发射方向
    protected float flipY;
    protected Animator animator;//动画器

    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        muzzlePos = transform.Find("Muzzle");       //枪口位置
        shellPos = transform.Find("BulletShell");   //弹夹位置
        flipY = transform.localScale.y;
    }
    protected virtual void Update()
    {
        mousePos = GetEnemy();
        //翻转枪的朝向
        if (mousePos.x < transform.position.x)
            transform.localScale = new Vector3(flipY, -flipY, 1);
        else
            transform.localScale = new Vector3(flipY, flipY, 1);
        Shoot();
    }
    //射击，或者挥刀
    protected virtual void Shoot()
    {
        //direction = (mousePos - new Vector2(transform.position.x, transform.position.y)).normalized;
        //transform.right = direction;
        float intervalNow = interval * DataManager.Data.player.GetComponent<PlayerMovement>().fireSpeed;
        if (timer != 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
                timer = 0;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            if (timer == 0)
            {
                Debug.Log("发射子弹");
                timer = intervalNow;
                Fire();
            }
        }
    }
    //正式开火，近战武器，或者特殊轨道武器改写
    protected virtual void Fire()
    {
        //animator.SetTrigger("Shoot");
        // 子弹生成;
        GameObject bullet = ObjectPool.Instance.GetObject(bulletPrefab);
        bullet.transform.position = muzzlePos.position;
        bullet.transform.rotation = muzzlePos.rotation;
        bullet.GetComponent<Bullet>().aggressivity = aggressivity + DataManager.Data.player.GetComponent<PlayerMovement>().aggressivity;//赋予攻击力
        //设置子弹移动方向

        //Vector2 enemyPosition = GetEnemy();  //这个位置是错误的
        //Vector2 enemyPosition =  transform.position;


        //direction = new Vector2(enemyPosition.x - bullet.transform.position.x, enemyPosition.y - bullet.transform.position.y);
        


        Debug.Log("fire  ++++++");
        Vector2 lookDirection = new Vector2();
        // Vector2 move = new Vector2();
        // move.x=DataManager.DataManager.Data.player.transform.position.x;
        // move.y=DataManager.DataManager.Data.player.transform.position.y;
        Vector2 input = new Vector2();
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        lookDirection.Set(input.x, input.y);  //设置方向  
        lookDirection.Normalize();          

        float angel = Random.Range(-5f, 5f);//子弹偏移角度

        bullet.GetComponent<Bullet>().SetSpeed(Quaternion.AngleAxis(angel, Vector3.forward) * lookDirection);//设置移动方向
       
       
       
        // 弹壳生成;
        //GameObject shell = ObjectPool.Instance.GetObject(shellPrefab);
        //shell.transform.position = shellPos.position;
        //shell.transform.rotation = shellPos.rotation;
    }




    //获取最近敌人位置
    protected virtual Vector2 GetEnemy()   
    {
        return new Vector2(0, 0);
    }
}
