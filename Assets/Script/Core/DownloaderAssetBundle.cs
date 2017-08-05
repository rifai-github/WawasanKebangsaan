using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WawasanKebangsaanBase;

public class DownloaderAssetBundle : MonoBehaviour
{
    [SerializeField]
    private Text textDownload;
    private WWW assets;

	IEnumerator Start()
	{
		string url;

		if (Singleton.Instance.OnlineMode)
			url = CONTS_VAR.ONLINE_URL;
		else
			url = CONTS_VAR.OFFLINE_URL;

		url += CONTS_VAR.ASSETBUNDLE_PATH;
        Debug.Log(url);
		assets = new WWW(url);
		yield return assets;

		Singleton.Instance.assetsBundle = assets.assetBundle;
	}
	

	void Update () 
    {
        textDownload.text = (assets.progress * 100).ToString();
	}
}
