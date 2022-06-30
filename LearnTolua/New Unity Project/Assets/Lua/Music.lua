--这里写逻辑，最后使用c#来调用
Music={}   --创建Controller对象
local this=Music
local AudioSource=UnityEngine.AudioSource


function this.PlaySong()  
   local oudio = UnityEngine.GameObject.Find("Sphere"):GetComponent("AudioSource")  --先创建音乐都对象

   --下载音乐
   local mp3=UnityEngine.WWW("http://m10.music.126.net/20220630233732/fb13f18580cefe9e1ea837bdf27faf59/ymusic/01a4/48b0/028e/7a0e8a904bdd9c30c94d2777fb6b5059.mp3")         
   --协程
   coroutine.www(mp3)

   oudio.clip=mp3:GetAudioClip() --播放音乐
   oudio:play()
end