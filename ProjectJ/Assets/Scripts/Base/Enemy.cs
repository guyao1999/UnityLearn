using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool playerKey;//角色控制锁，眩晕之类的使用
    public bool fightkey;//战斗状态
    public float speed;//速度
    public float bloodMax;//血量上限
    public float bloodNow;//血量
    public float aggressivity;//攻击力
    public float armor;//护甲
    public float interval;//攻击间隔
    public float timer;//计时器
    private void OnEnable()
    {
        DataManager.Data.enemyList.Add(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //血量改变。伤害=blood-armor。死亡判断。恢复加成。格挡，免疫，减伤
    public virtual void BloodChang(float blood)
    {

    }
    //巡逻移动，在一定范围内随机移动，或者在几个点之间来回移动
    protected virtual void Move()
    {

    }
    //进入战斗状态下的移动,追击玩家
    protected virtual void FightMove()
    {

    }
    //进行攻击
    protected virtual void Fight()
    {
        
    }
    //发现玩家进入警戒范围后，进入战斗状态
    public void OnTriggerEnter2D(Collider2D col)
    {
        
    }
    //死亡，从敌人列表中删除
    protected virtual void Dead()
    {

    }


}
