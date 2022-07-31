using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool playerKey;//角色控制锁，眩晕之类的使用

    public GameObject[] guns;
    private int gunNum;
    public Gun[] gunList; 
    public Gun currentGun; 

    public Transform weaponPos1;
    public Transform weaponPos2;

    //public Buff[] BuffList;

    public float speed=3.0f;        //速度
    public float bloodMax;     //血量上限
    public float energyMax;    //能量上限
    public float bloodNow;     //血量
    public float energyNow;    //能量
    public float fireSpeed;    //攻击速度，武器攻击间隔*攻击速度，
    public float aggressivity; //攻击力
    public float armor;        //护甲
    private Animator animator;
    private Rigidbody2D rigidbody2d;

    public GameObject weapon1Prefab;
    public GameObject weapon2Prefab;
    void Start()
    {
        // animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        // weapon1=transform.Find("Gun01").gameObject;
        // weapon1.SetActive(true);
        // DataManager.Data.player = this;
        playerKey=true;
        GameObject weapon1 = Instantiate(weapon1Prefab,weaponPos1.position,Quaternion.identity,transform);  //创建出来的gun不属于任何人，属于世界场景
        //gun.SetActive(true);
    }

    void Update()
    {
        if (playerKey == true)
        {
            //SwitchGun();
            Move();
            //Stunt();
            attack();
        }
    }
    //移动------------------------------------------------
    void Move()
    {
        Vector2 input;
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        rigidbody2d.velocity = input.normalized * speed;
    }
    //q，e切换武器------------------------------------
    // void SwitchGun()
    // {
    //     if (Input.GetKeyDown(KeyCode.Q))
    //     {
    //         guns[gunNum].SetActive(false);
    //         if (--gunNum < 0)
    //         {
    //             gunNum = guns.Length - 1;
    //         }
    //         guns[gunNum].SetActive(true);
    //     }
    //     if (Input.GetKeyDown(KeyCode.E))
    //     {
    //         guns[gunNum].SetActive(false);
    //         if (++gunNum > guns.Length - 1)
    //         {
    //             gunNum = 0;
    //         }
    //         guns[gunNum].SetActive(true);
    //     }
    // }
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
    //攻击
    public void attack()
    {
        if(Input.GetKeyDown(KeyCode.C))   //按c键，投射飞镖
        {
            // currentGun.fire();
        }
    }
}
