using UnityEditor;
using UnityEngine;
using System.IO;

public class CreateAssetBundles
{

    //可以看作为编辑器的扩展 将这个脚本放在Editor文佳夹下就会自动执行
	[MenuItem("Assets/Build AssetBundles")]
	static void BuildAllAssetBundles()
	{
  	string assetBundleDirectory = "Assets/StreamingAssets";
  	if (!Directory.Exists(Application.streamingAssetsPath))
  	{
    	Directory.CreateDirectory(assetBundleDirectory);
  	}
    
  	BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);
	}
}