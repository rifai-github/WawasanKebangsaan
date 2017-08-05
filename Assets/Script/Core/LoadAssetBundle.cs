using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WawasanKebangsaanBase;

public class LoadAssetBundle : MonoBehaviour 
{
	public static LoadAssetBundle GetAssetBundle()
	{
		GameObject go = new GameObject("AssetBundleLoader");
		go.AddComponent<LoadAssetBundle>();

		LoadAssetBundle assetBundle = go.GetComponent<LoadAssetBundle>() as LoadAssetBundle;

		return assetBundle;
	}

    public void Get3D(E3DType name)//, GameObject go)
	{
		GameObject obj = Singleton.Instance.assetsBundle.LoadAsset(StaticFunction.Path3DFormAssetBundle(name)) as GameObject;
        //obj.transform.chi
    }
}
