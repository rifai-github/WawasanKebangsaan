using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WawasanKebangsaanBase;

public class coba : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        LoadAssetBundle.GetAssetBundle().StartGettingAssetBundle(EAssetsBundle.AssetsBundle3D, E3DType.BARONG);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
