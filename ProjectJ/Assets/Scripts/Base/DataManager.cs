using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    private static DataManager dataManager;//访问接口

    public GameObject player;//玩家
    public List<GameObject> enemyList = new List<GameObject>();//地图上敌人列表
    public static DataManager Data
    {
        get
        {
            if (dataManager == null)
            {
                dataManager = new DataManager();
            }
            return dataManager;
        }
    }
}
