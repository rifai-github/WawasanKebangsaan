using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WawasanKebangsaanBase;
using UnityEngine.SceneManagement;

public class DownloaderAssetBundle : MonoBehaviour
{
    [SerializeField]
    private Image _ProgressDownloadImage;
    [SerializeField]
    private Text _ProgressDownloadText;
    private WWW assets;
    private AsyncOperation AsyncOP;
	private string _URL;
    private bool AssetBundleExist;

	IEnumerator Start()
	{
        AssetBundleExist = File.Exists(Application.persistentDataPath + "/assetsbundle");
        _URL = AssetBundleExist ?
               CONTS_VAR.OFFLINE_URL + CONTS_VAR.ASSETBUNDLE_PATH :
               CONTS_VAR.URL_ASSETBUNDLE;

        yield return StartCoroutine(DownloadAsset());

        AsyncOP = SceneManager.LoadSceneAsync("WawasanKebangsaan");
	}

    IEnumerator DownloadAsset()
    {
        assets = new WWW(_URL);
        yield return assets;

        Singleton.Instance.assetsBundle = assets.assetBundle;

        if (!AssetBundleExist)
            File.WriteAllBytes(Application.persistentDataPath + "/assetsbundle", assets.bytes);
    }

	void Update () 
    {
        _ProgressDownloadImage.transform.localScale = new Vector3(assets.progress, 1);
        _ProgressDownloadText.text = (assets.progress * 100).ToString("F2") + " %";
	}
}
