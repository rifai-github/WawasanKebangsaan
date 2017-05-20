using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using WawasanKebangsaanBase;

public class ARModal : BaseModal
{
    [SerializeField]
    private Button _PlayButton;
    [SerializeField]
    private Button _Close3D;
    [SerializeField]
    private GameObject _Model3DVideo;
    [SerializeField]
    private GameObject[] _MarkerAR;
    [SerializeField]
    private Transform[] _OnTrackObject;
    [SerializeField]
    private Transform _OnLostTrackObject;

    private string _NameObjectFound;
    private float _Speed = 8;

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

    public void TrackingObject()
    {
        int _iMarker = 0;

        if (_MarkerAR[_iMarker].activeSelf)
        {
            _Model3DVideo.SetActive(true);
            _NameObjectFound = _MarkerAR[_iMarker].name;
            _Model3DVideo.transform.position = Vector3.Lerp(_Model3DVideo.transform.position, _OnTrackObject[_iMarker].position, _Speed * Time.deltaTime);
            _Model3DVideo.transform.rotation = Quaternion.Lerp(_Model3DVideo.transform.rotation, _OnTrackObject[_iMarker].rotation, _Speed * Time.deltaTime);
            _iMarker += 1;
        }
        //else if (_MarkerAR[_iMarker].activeSelf)
        //{
        //    _VideoModel3D.transform.position = Vector3.Lerp(_VideoModel3D.transform.position, _OnTrackObject[1].position, _Speed * Time.deltaTime);
        //    _VideoModel3D.transform.rotation = Quaternion.Lerp(_VideoModel3D.transform.rotation, _OnTrackObject[1].rotation, _Speed * Time.deltaTime);
        //    _iMarker += 1;
        //}
        else
        {
            _Model3DVideo.transform.position = Vector3.Lerp(_Model3DVideo.transform.position, _OnLostTrackObject.position, _Speed * Time.deltaTime);
            _Model3DVideo.transform.rotation = Quaternion.Lerp(_Model3DVideo.transform.rotation, _OnLostTrackObject.rotation, _Speed * Time.deltaTime);
        }
    }

    public void OnRegisterModal(UnityAction OnStartAction, UnityAction On3DCloseAction)
    {
        _PlayButton.onClick.AddListener(OnStartAction);
        _Close3D.onClick.AddListener(On3DCloseAction);
    }

    public void UnRegisterModal()
    {
        _PlayButton.onClick.RemoveAllListeners();
        _Close3D.onClick.RemoveAllListeners();
    }
}
