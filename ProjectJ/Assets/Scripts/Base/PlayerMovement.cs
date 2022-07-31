using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public bool playerKey;//角色控制锁，眩晕之类的使用

    public GameObject[] guns;//武器库
    private int gunNum;//当前使用的武器

    public float speed;//速度
    public float bloodMax;//血量上限
    public float energyMax;//能量上限
    public float bloodNow;//血量
    public float energyNow;//能量
    public float fireSpeed;//攻击速度，武器攻击间隔*攻击速度，
    public float aggressivity;//攻击力
    public float armor;//护甲

    //private Vector2 mousePos;
    private Animator animator;
    private Rigidbody2D rigidbody2d;
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();


        guns[0].SetActive(true);
        DataManager.Data.player = gameObject;
    }

    void Update()
    {
        if (playerKey == true)
        {
            SwitchGun();
            Move();
            Stunt();
        }
        //mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //if (mousePos.x > transform.position.x)
        //{
        //    transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        //}
        //else
        //{
        //    transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        //}


    }
    //移动------------------------------------------------
    void Move()
    {
        Vector2 input;
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        rigidbody2d.velocity = input.normalized * speed;
        if (input != Vector2.zero)
            animator.SetBool("isMoving", true);
        else
            animator.SetBool("isMoving", false);
    }
    //q，e切换武器------------------------------------
    void SwitchGun()   //直接设置gameObject为true? gun的位置呢
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            guns[gunNum].SetActive(false);
            if (--gunNum < 0)
            {
                gunNum = guns.Length - 1;
            }
            guns[gunNum].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            guns[gunNum].SetActive(false);
            if (++gunNum > guns.Length - 1)
            {
                gunNum = 0;
            }
            guns[gunNum].SetActive(true);
        }
    }
    //按k大招
    protected virtual void  Stunt()
    {
        if (Input.GetKeyDown(KeyCode.K) && energyNow + 0.001f >= energyMax)
        {

        }
    }
    //血量改变。伤害=blood-armor。死亡判断。恢复加成。格挡，免疫，减伤
    public void BloodChang(float blood)
    {

    }
    //能量改变。能量恢复加成。
    public void EnergyChange(float energy)
    {

    }
    //死亡
    public void Dead()
    {

    }

}
