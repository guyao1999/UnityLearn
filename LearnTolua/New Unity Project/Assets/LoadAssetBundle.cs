using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAssetBundle : MonoBehaviour
{
    public string url;
    public string assetName;
    // Start is called before the first frame update
    IEnumerator Start()   //使用协程来加载
    {
        WWW www = new WWW(url);   //进行资源的下载
        yield return www;
        if(www.error!=null){   //存在错误
            Debug.LogError("网络错误");
        }
        else{
            AssetBundle bundle = www.assetBundle;
            Object obj=bundle.LoadAsset(assetName);
            Instantiate(obj);       

            bundle.Unload(true);  //true把加载来的所有资源都卸载   false表示只卸载用过的资源
        }
        www.Dispose();   //进行资源的释放
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
