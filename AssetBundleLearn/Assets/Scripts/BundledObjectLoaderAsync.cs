using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class BundledObjectLoaderAsync : MonoBehaviour
{
    public string assetName = "BundledSpriteObject";
    public string bundleName = "testbundle";

    IEnumerator Start()
    {
        //异步加载得到AssetBundle
        AssetBundleCreateRequest asyncBundleRequest = AssetBundle.LoadFromFileAsync(Path.Combine(Application.streamingAssetsPath, bundleName));
        yield return asyncBundleRequest;

        AssetBundle localAssetBundle = asyncBundleRequest.assetBundle;

        if (localAssetBundle == null) {
	        Debug.LogError("Failed to load AssetBundle!");
	        yield break;
        }
        
        //异步加载得到AssetBundle中的gameObject
        AssetBundleRequest assetRequest = localAssetBundle.LoadAssetAsync<GameObject>(assetName);
        yield return assetRequest;

        GameObject prefab = assetRequest.asset as GameObject;
        Instantiate(prefab);

        localAssetBundle.Unload(false);
    }
}
