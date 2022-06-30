--这里写逻辑，最后使用c#来调用



Controller={}   --创建Controller对象
local this=Controller

require("Music")   --加载music模块

local Gameobject=UnityEngine.GameObject   
local Input=UnityEngine.Input
local Rigidbody=UnityEngine.Rigidbody
local Color=UnityEngine.Color
local AudioSource=UnityEngine.AudioSource

local Sphere
local rigi
local force

function this.Start()  
   Sphere = Gameobject.Find("Sphere")
   Sphere : GetComponent("Renderer").material.color= Color(1,0.1,1)   --给这个Sphere添加颜色
   Sphere : AddComponent(typeof(Rigidbody))                           --给这个Sphere添加刚体

   --给Sphere添加音乐Component
   Sphere :AddComponent(typeof(AudioSource))
   coroutine.start(Music.PlaySong) --开启协程 调用Music中的PlaySong函数
   -- 
   
   rigi = Sphere:GetComponent("Rigidbody")             

   force=5
end

function this.Update()
   local h=Input.GetAxis("Horizontal")      --得到水平的值
   local v=Input.GetAxis("Vertical")        --得到垂直的值
   rigi:AddForce(Vector3(h,0,v)*force)      --给Sphere的刚体增加要给力
end