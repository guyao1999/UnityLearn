using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;
public class BundleWebLoader : MonoBehaviour
{
    //这个URL给出的资源需要是可以访问下载的
    public string bundleUrl = "http://localhost:81/StreamingAssets/testbundle";
    public string assetName = "BundledSpriteObject";
    IEnumerator Start()
    {
        using (WWW web = new WWW(bundleUrl))
        {
            if(1==0)
            {
                //2019版本之前的旧方法
                yield return web;
                //得到web端的AssetBundle
                print(Application.streamingAssetsPath);
                print(web.url+"nice");
                AssetBundle remoteAssetBundle = web.assetBundle;
                if (remoteAssetBundle == null) {
                    Debug.LogError("Failed to download AssetBundle!");
                    yield break;
                }
                //从AssetBundle中加载需要的资源成一个gameObject
                //将加载得到的gameObject实例化
                Instantiate(remoteAssetBundle.LoadAsset(assetName));
                remoteAssetBundle.Unload(false);
            }

            if (1==1)
            {
                //2022之后的版本的新的加载方法
                UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(bundleUrl);
                yield return www.SendWebRequest();
                if (www.result != UnityWebRequest.Result.Success) {
                    Debug.Log(www.error);
                }
                else {

                    //将www得到的内容解压为一个AssetBundle
                    AssetBundle remoteAssetBundle = DownloadHandlerAssetBundle.GetContent(www);
                    if (remoteAssetBundle == null) {
                        Debug.LogError("Failed to download AssetBundle!");
                        yield break;
                    }
                    print(remoteAssetBundle);
                    Instantiate(remoteAssetBundle.LoadAsset(assetName));
                    remoteAssetBundle.Unload(false);
                }
            }

        }
    }
}
