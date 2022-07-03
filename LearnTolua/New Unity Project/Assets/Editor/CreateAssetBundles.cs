using UnityEditor;
using System.IO;

public class CreateAssetBundles                //属于编辑器的扩展，不需要作为组件存在，也就不用继承自MonoBehaviour
{
    [MenuItem("Assets/Build AssetBundles")]    //进行编辑器的修改，在Asset下面会多出一个Build AssetBundles的按钮
    static void BuildAllAssetBundles()
    {
        string assetBundleDirectory = "Assets/AssetBundles";  //将打包后的AssetBundles存放到这个文件下
        if(!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }       
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
    }
}