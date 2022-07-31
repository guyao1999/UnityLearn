using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Door 
{
    public GameObject go;
    public GameObject doorOpen;
    public GameObject doorClose;
    public bool isOpne;
    public string name;

    public void openDoor(){
        doorOpen.SetActive(true);
        doorClose.SetActive(false);
        isOpne=true;
    }
    public void closeDoor(){
        doorClose.SetActive(true);
        doorOpen.SetActive(false);
        isOpne=false;
    }
    public string getName()
    {
        return name;
    }
}
public class DoorController : MonoBehaviour
{

    private List<Door> doorsList = new List<Door>();
    private int doorCount=0;

    void Start()
    {
        doorCount=gameObject.transform.childCount;

        Debug.Log("the count of door in the scene is:"+doorCount);
        for(int i=0;i<doorCount;i++){
            Door tempDoor = new Door();
            tempDoor.go=gameObject.transform.GetChild(i).gameObject;  //这里需要修改
           
            tempDoor.name=tempDoor.go.name;

            tempDoor.doorOpen=tempDoor.go.transform.Find("DoorOpen").gameObject;
            tempDoor.doorClose=tempDoor.go.transform.Find("DoorClose").gameObject;
            
             tempDoor.openDoor();
            //tempDoor.closeDoor();

            doorsList.Add(tempDoor);
        }
         for(int i=0;i<doorCount;i++){
            Debug.Log(doorsList[i].name);
        }
    }
    // public bool OpneDoorByIndex(int index)
    // {
    //     if(index<0 || index>=doorCount){
    //         return false;
    //     }
    //     else{
    //         doorsList[index].transform.Find("DoorOpen").gameObject.SetActive(true);
    //         doorsList[index].transform.Find("DoorClose").gameObject.SetActive(false);
    //         return true;
    //     }
    // }
    // public bool CloseDoorByIndex(int index)
    // {
    //     if(index<0 || index>=doorCount){
    //         return false;
    //     }
    //     else{
    //         doorsList[index].transform.Find("DoorOpen").gameObject.SetActive(false);
    //         doorsList[index].transform.Find("DoorClose").gameObject.SetActive(true);
    //         return true;
    //     }
    // }



    // public bool CloseDoorByName(string name){

    // }



    // Update is called once per frame
    void Update()
    {
        
    }
}
