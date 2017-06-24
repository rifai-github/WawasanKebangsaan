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
    private Image _LambangProv;
    [SerializeField]
    private GameObject _3dModal;
    [SerializeField]
    private Transform _BolaDunia;
    [SerializeField]
    private Transform _PetaIndonesia;
    [SerializeField]
    private Transform _MarkerTransform;

    [SerializeField]
    private Button Button1;
    [SerializeField]
    private Button Button2;
    [SerializeField]
    private GameObject GameObject1;
    [SerializeField]
    private GameObject GameObject2;

    private Vector3 _PetaStartPosition;
    private Vector3 _PetaStartScale;

    private GameObject _ProvinsiSelect;
    private Transform _ProvinsiView;
    private Animator _3DAnimate;

    private bool _bProvView;

    private bool _bMarkerDetect;
    public bool SetFoundMarker { set { _bMarkerDetect = value; } }
    
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
        base.OpenModal();

        OnRegisterModal();
        _PetaStartPosition = _PetaIndonesia.position;
        _PetaStartScale = _PetaIndonesia.localScale;
        _3DAnimate = _3dModal.GetComponent<Animator>();

        _bProvView = false;

        _3DAnimate.SetBool("Dunia", false);
        _3DAnimate.SetBool("Peta", false);

    }

    protected override void Tick(float deltaTime)
    {
        DetectObject();
        _BolaDunia.transform.Rotate(0, Time.deltaTime * 15, 0);
        
        base.Tick(deltaTime);
    }

    private void DetectObject()
    {
        if (_bMarkerDetect)
        {
            Button1.gameObject.SetActive(true);
            Button2.gameObject.SetActive(true);

            _PetaIndonesia.gameObject.SetActive(true);

            _3dModal.transform.position = Vector3.Lerp(_3dModal.transform.position, _MarkerTransform.position, Time.deltaTime * 5);
            _3dModal.transform.rotation = Quaternion.Lerp(_3dModal.transform.rotation, _MarkerTransform.rotation, Time.deltaTime * 5);

            StartCoroutine(EnterAnimator());

        }
        else  // Lost
        {
            Button1.gameObject.SetActive(false);
            Button2.gameObject.SetActive(false);

            _PetaIndonesia.gameObject.SetActive(false);
            _bProvView = false;

            _3DAnimate.SetBool("Dunia", false);
            _3DAnimate.SetBool("Peta", false);

            Destroy(_ProvinsiSelect, 1);
            _ProvinsiSelect = null;
        }

        ProvinsiView();
    }

    private IEnumerator EnterAnimator()
    {
        _3DAnimate.SetBool("Dunia", true);

        yield return new WaitForSeconds(5f);

        _3DAnimate.SetBool("Peta", true);
        yield return new WaitForSeconds(1f);
        _3DAnimate.SetBool("Dunia", false);
        
    }

    public void Action1()
    {
        ProvinsiAction(GameObject1);
    }
    public void Action2()
    {
        ProvinsiAction(GameObject2);
    }

    public void ProvinsiAction(GameObject prov)
    {
        if (_ProvinsiSelect != null)
        {
            Destroy(_ProvinsiSelect);
        }        
        _bProvView = true;

        _ProvinsiSelect = Instantiate(prov) as GameObject;
        _ProvinsiSelect.name = prov.name + " (ProvinsiSelected)";
        //_ProvinsiSelect.transform.SetParent(_3dModal.transform);
        _ProvinsiSelect.transform.localScale = prov.transform.lossyScale;

        foreach (Component comp in _ProvinsiSelect.GetComponents<Component>())
        {
            if (!(comp is Transform))
            {
                Destroy(comp);
            }
        }

        _ProvinsiView = _ProvinsiSelect.transform.GetChild(0);
    }

    public void PlayVideo(Provinsi prov)
    {
        string videoProv = "";

        switch (prov)
        {
            case Provinsi.JawaTengah:
                videoProv = "pakar.mp4";
                break;
            case Provinsi.Papua:
                videoProv = "Papua.mp4";
                break;
        }
        //manggilnya pakai JSON
        WKSigleton.Instance.PlayVideo(videoProv);
    }

    private void PlayVideoAction()
    {
        WKSigleton.Instance.PlayVideo(VideoType.VIDEO_TUTORIAL);
    }


    private void ProvinsiView()
    {

        if (_bProvView)
        {
            _3DAnimate.enabled = false;
            _ProvinsiSelect.transform.position = _MarkerTransform.position;
            _ProvinsiSelect.transform.rotation = _MarkerTransform.rotation;
            _PetaIndonesia.transform.position = Vector3.Lerp(_PetaIndonesia.transform.position, _ProvinsiView.position, Time.deltaTime * 5);
            _PetaIndonesia.transform.localScale = Vector3.Lerp(_PetaIndonesia.transform.localScale, _ProvinsiView.lossyScale, Time.deltaTime * 5);
        }
        else
        {
            _3DAnimate.enabled = true;
        }
    }

    private void OnRegisterModal()
    {
        Button1.onClick.AddListener(Action1);
        Button2.onClick.AddListener(Action2);
        _PlayVideoButton.onClick.AddListener(PlayVideoAction);
    }

    private void UnRegisterModal()
    {
        Button1.onClick.RemoveAllListeners();
        Button2.onClick.RemoveAllListeners();
        _PlayVideoButton.onClick.RemoveAllListeners();
    }

    public override void CloseModal()
    {
        UnRegisterModal();
        base.CloseModal();
    }
}
