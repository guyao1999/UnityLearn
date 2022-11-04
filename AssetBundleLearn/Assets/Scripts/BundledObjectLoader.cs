using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BundledObjectLoader : MonoBehaviour
{

    public string assetName = "BundledSpriteObject";
    public string bundleName = "testbundle";

    void Start()
    {
        LoadAssetBundleSync();
    }
    
    //同步
    void LoadAssetBundleSync()
    {
        //得到一个AssetBundle
        AssetBundle localAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, bundleName));
        if (localAssetBundle == null) {
	        Debug.LogError("Failed to load AssetBundle!");
	        return;
        }
        
        //从AssetBundle中加载到这个GameObject
        GameObject asset = localAssetBundle.LoadAsset<GameObject>(assetName);  

        //实例化这个GameObject
        Instantiate(asset);
        localAssetBundle.Unload(false);

    }

}
