using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WawasanKebangsaanBase;

public class LoadAssetBundle : MonoBehaviour 
{
    WWW asset;

	public static LoadAssetBundle GetAssetBundle()
	{
		GameObject go = new GameObject("AssetBundleLoader");
		go.AddComponent<LoadAssetBundle>();

		LoadAssetBundle assetBundle = go.GetComponent<LoadAssetBundle>() as LoadAssetBundle;

		return assetBundle;
	}

    public void StartGettingAssetBundle(EAssetsBundle bundle, E3DType name)
    {
        StartCoroutine(GetAssetBundle(bundle,name));
    }

    private IEnumerator GetAssetBundle(EAssetsBundle bundle, E3DType name)
	{
        Debug.Log(StaticFunction.URLAssetBundle(bundle));
        asset = new WWW(StaticFunction.URLAssetBundle(bundle));
        yield return asset;

        AssetBundle assetBundle = asset.assetBundle;

		GameObject go = assetBundle.LoadAsset(StaticFunction.Path3DFormAssetBundle(name)) as GameObject;
		go.transform.localScale = Vector3.one * 3;
        Instantiate(go);
        Destroy(this.gameObject);
    }

    private void Update()
    {
        Debug.Log(asset.progress * 100);
    }
}
