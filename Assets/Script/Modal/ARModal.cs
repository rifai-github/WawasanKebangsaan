using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using WawasanKebangsaanBase;

public class ARModal : BaseModal
{
    [SerializeField]
    private Button _PlayVideoButton;
    [SerializeField]
    private GameObject _BolaDunia;
    [SerializeField]
    private GameObject _PetaIndonesia;
    [SerializeField]
    private GameObject _3DModal;
    [SerializeField]
    private GameObject _MarkerWawasanKebangsaan;
    [SerializeField]
    private Transform _Hide3D;

    [SerializeField]
    private List<Transform> _Provinsi;

    private Transform _PositionSelect;
    private GameObject _ProvinsiSelect;

    private bool _3dClick;
    private string _NameObjectFound;
    public string GetNameObjectFound { get { return _NameObjectFound; } }
    
    private static ARModal _Instance;

    public static ARModal Instance()
    {
        if (_Instance == null)
        {
            _Instance = GameObject.FindObjectOfType<ARModal>();

            if (_Instance == null)
            {
                WKStaticFunction.WKMessageError("there is no ARModal in the system");
            }
        }
        return _Instance;
    }

    protected override void Tick(float deltaTime)
    {
        _BolaDunia.transform.Rotate(0, Time.deltaTime * 10, 0);
        if (_ProvinsiSelect != null)
        {
            if (_3dClick)
            {
                foreach (Transform prov in _Provinsi)
                {
                    if (prov != _ProvinsiSelect.transform)
                    {
                        float hide = Mathf.Lerp(_ProvinsiSelect.transform.position.y, _Hide3D.position.y, Time.deltaTime);
                        prov.Translate(prov.position.x, hide, prov.position.z);
                    }
                }


                //_ProvinsiSelect.transform.position = Vector3.Lerp(_ProvinsiSelect.transform.position, _PositionSelect.position, Time.deltaTime * 5);
                //_PetaIndonesia.transform.position = Vector3.Lerp(_PetaIndonesia.transform.position, _Hide3D.position, Time.deltaTime);
                if (_PetaIndonesia.transform.position == _Hide3D.position)
                    _3dClick = false;
            }
        }
        base.Tick(deltaTime);
    }

    public void ProvinsiAction(GameObject prov, Transform pos)
    {
        _3dClick = true;
        _ProvinsiSelect = prov;
    }

    public void TrackingObject()
    {
        


        //int _iMarker = 0;

        //if (_MarkerAR[_iMarker].activeSelf)
        //{
        //    _Model3DVideo.SetActive(true);
        //    _NameObjectFound = _MarkerAR[_iMarker].name;
        //    _Model3DVideo.transform.position = Vector3.Lerp(_Model3DVideo.transform.position, _OnTrackObject[_iMarker].position, _Speed * Time.deltaTime);
        //    _Model3DVideo.transform.rotation = Quaternion.Lerp(_Model3DVideo.transform.rotation, _OnTrackObject[_iMarker].rotation, _Speed * Time.deltaTime);
        //    _iMarker += 1;
        //}
        ////else if (_MarkerAR[_iMarker].activeSelf)
        ////{
        ////    _VideoModel3D.transform.position = Vector3.Lerp(_VideoModel3D.transform.position, _OnTrackObject[1].position, _Speed * Time.deltaTime);
        ////    _VideoModel3D.transform.rotation = Quaternion.Lerp(_VideoModel3D.transform.rotation, _OnTrackObject[1].rotation, _Speed * Time.deltaTime);
        ////    _iMarker += 1;
        ////}
        //else
        //{
        //    _Model3DVideo.transform.position = Vector3.Lerp(_Model3DVideo.transform.position, _OnLostTrackObject.position, _Speed * Time.deltaTime);
        //    _Model3DVideo.transform.rotation = Quaternion.Lerp(_Model3DVideo.transform.rotation, _OnLostTrackObject.rotation, _Speed * Time.deltaTime);
        //}
    }

    public void OnRegisterModal(UnityAction PlayVideoAction)
    {
        _PlayVideoButton.onClick.AddListener(PlayVideoAction);
    }

    public void UnRegisterModal()
    {
        _PlayVideoButton.onClick.RemoveAllListeners();
    }
}
