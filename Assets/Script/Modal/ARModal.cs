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
    private GameObject[] _Model3DVideo;
    [SerializeField]
    private GameObject[] _MarkerAR;
    [SerializeField]
    private Transform[] _OnTrackObject;
    [SerializeField]
    private Transform _OnLostTrackObject;

    private string _NameObjectFound;
    private float _Speed = 8;
    private bool _bFirstLoad;

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

    public override void OpenModal()
    {
        _bFirstLoad = true;
        base.OpenModal();
    }

    public void OnClose3D()
    {
        for (int i = 0; i < _Model3DVideo.Length; i++)
        {
            _Model3DVideo[i].SetActive(false);
        }
    }

    public void FoundObject()
    {
        for (int i = 0; i < _MarkerAR.Length; i++)
        {
            if (_MarkerAR[i].activeSelf)
            {
                
                if (_bFirstLoad)
                {
                    _Model3DVideo[i].SetActive(false);
                    _Close3D.gameObject.SetActive(false); // nanti di hide pake scale anim aja
                    _bFirstLoad = false;
                }
                else
                {
                    _Model3DVideo[i].SetActive(true);
                    _Close3D.gameObject.SetActive(true);
                }
                _NameObjectFound = _MarkerAR[i].name;
                _Model3DVideo[i].transform.position = Vector3.Lerp(_Model3DVideo[i].transform.position, _OnTrackObject[i].position, _Speed * Time.deltaTime);
                _Model3DVideo[i].transform.rotation = Quaternion.Lerp(_Model3DVideo[i].transform.rotation, _OnTrackObject[i].rotation, _Speed * Time.deltaTime);
            }
            else
            {
                _Model3DVideo[i].transform.position = Vector3.Lerp(_Model3DVideo[i].transform.position, _OnLostTrackObject.position, _Speed * Time.deltaTime);
                _Model3DVideo[i].transform.rotation = Quaternion.Lerp(_Model3DVideo[i].transform.rotation, _OnLostTrackObject.rotation, _Speed * Time.deltaTime);
            }
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
