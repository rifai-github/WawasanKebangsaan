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
    private GameObject _ProvinsiButton;
    [SerializeField]
    private GameObject _ProvinsiButtonPlaceHolder;
    [SerializeField]
    private Button _ShowHideProvinsiButton;
    [SerializeField]
    private Transform _PanelScroll;
    [SerializeField]
    private Transform _ShowButtonProvinsi;
    [SerializeField]
    private Transform _HideButtonProvinsi;
    
    private Vector3 _PetaStartPosition;
    private Vector3 _PetaStartScale;

    private GameObject _ProvinsiSelect;
    private Transform _ProvinsiView;
    private Animator _3DAnimate;

    private bool _bProvView;
    private bool _bButtonProvinsi;

    private bool _bMarkerDetect;
    public bool SetFoundMarker { set { _bMarkerDetect = value; } }

    private List<ItemClass> _ItemClassList;
    private List<GameObject> _ItemButtonList = new List<GameObject>();

    private static ARModal _Instance;

    public static ARModal Instance()
    {
        if (_Instance == null)
        {
            _Instance = GameObject.FindObjectOfType<ARModal>();

            if (_Instance == null)
            {
                StaticFunction.WKMessageError("there is no ARModal in the system");
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
        _bButtonProvinsi = false;

        _3DAnimate.SetBool("Dunia", false);
        _3DAnimate.SetBool("Peta", false);

        JSONGetter getJson = JSONGetter.GetJSON();
        getJson.StartParsing(TypeJSON.JSON_PROVINSI, JSONAction);

    }

    private void JSONAction(string jsonString)
    {
        StaticFunction.WKMessageLog(jsonString);

        GetPrivinsiItemJSON baseJSON = new GetPrivinsiItemJSON(jsonString);
        _ItemClassList = baseJSON.ParseJSON();

        StartCoroutine(CreateDynamicData(_ItemClassList));
    }

    private IEnumerator CreateDynamicData(List<ItemClass> itemProvinsi)
    {
        foreach (ItemClass item in itemProvinsi)
        {
            ProvinsiItemClass itemClass = item as ProvinsiItemClass;
            CreateUIForData(itemClass);
            yield return new WaitForFixedUpdate();
        }
    }

    private void CreateUIForData(ProvinsiItemClass itemClass)
    {
        GameObject item = Instantiate(_ProvinsiButton) as GameObject;
        item.transform.SetParent(_ProvinsiButtonPlaceHolder.transform);
        item.transform.localScale = Vector3.one;
        
        ProvinsiClick provinsi = StaticFunction.Get3DProvinsi(itemClass.GetID).GetComponent<ProvinsiClick>();
        ProvinsiButtonVariable ProvinsiVariable = item.GetComponent<ProvinsiButtonVariable>() as ProvinsiButtonVariable;
        ButtonProvinsiCaller provinsiCaller = item.GetComponent<ButtonProvinsiCaller>() as ButtonProvinsiCaller;

        item.SetActive(true);
        item.name = itemClass.GetName;
        
        provinsiCaller.setIDProvinsi = itemClass.GetID;
        ProvinsiVariable.GetText.text = StaticFunction.GetNameProvinsi(itemClass.GetID);

        provinsi.GetLambangPath = StaticFunction.LambangURL(itemClass.GetLambang);
        provinsi.GetSuku = itemClass.GetSuku;
        provinsi.GetVideoPath = itemClass.GetVideo;
        
        _ItemButtonList.Add(item);
    }
        
    protected override void Tick(float deltaTime)
    {
        DetectObject();
        ProvinsiView();
        ShowHideButtonProvinsi();

        _BolaDunia.transform.Rotate(0, Time.deltaTime * 15, 0);
        base.Tick(deltaTime);
    }

    private void DetectObject()
    {
        if (_bMarkerDetect)
        {
            _PetaIndonesia.gameObject.SetActive(true);

            _3dModal.transform.position = Vector3.Lerp(_3dModal.transform.position, _MarkerTransform.position, Time.deltaTime * 5);
            _3dModal.transform.rotation = Quaternion.Lerp(_3dModal.transform.rotation, _MarkerTransform.rotation, Time.deltaTime * 5);

            StartCoroutine(EnterAnimator());

        }
        else  // Lost
        {
            _PetaIndonesia.gameObject.SetActive(false);
            _bProvView = false;

            _3DAnimate.SetBool("Dunia", false);
            _3DAnimate.SetBool("Peta", false);

            Destroy(_ProvinsiSelect, 1);
            _ProvinsiSelect = null;
        }
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
    
    private void ShowHideButtonProvinsi()
    {
        if (_bButtonProvinsi)
            _PanelScroll.position = Vector2.Lerp(_PanelScroll.position, _ShowButtonProvinsi.position, Time.deltaTime * 5);
        else
            _PanelScroll.position = Vector2.Lerp(_PanelScroll.position, _HideButtonProvinsi.position, Time.deltaTime * 5);
    }


    public void ProvinsiAction(GameObject prov, Provinsi provinsi)
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
        string urlLambang = _ProvinsiSelect.GetComponent<ProvinsiClick>().GetLambangPath;

        ImageGetter image = ImageGetter.GetImage();
        image.StartGettingImage(_LambangProv, urlLambang);

        foreach (Component comp in _ProvinsiSelect.GetComponents<Component>())
        {
            if (!(comp is Transform))
            {
                Destroy(comp);
            }
        }

        _ProvinsiView = _ProvinsiSelect.transform.GetChild(0);
    }
    
    private IEnumerator EnterAnimator()
    {
        _3DAnimate.SetBool("Dunia", true);

        yield return new WaitForSeconds(5f);

        _3DAnimate.SetBool("Peta", true);
        yield return new WaitForSeconds(1f);
        _3DAnimate.SetBool("Dunia", false);

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
        VideoGetter video = VideoGetter.GetVideo();
        video.PlayVideo(videoProv);
    }

    private void PlayVideoAction()
    {
        VideoGetter video = VideoGetter.GetVideo();
        video.PlayVideo(VideoType.VIDEO_TUTORIAL);
    }

    private void ShowHideProvinsiAction()
    {
        if (_bButtonProvinsi)
            _bButtonProvinsi = false;
            //image chage
        else
            _bButtonProvinsi = true;
    }

    private void OnRegisterModal()
    {
        _ShowHideProvinsiButton.onClick.AddListener(ShowHideProvinsiAction);
        _PlayVideoButton.onClick.AddListener(PlayVideoAction);
    }

    private void UnRegisterModal()
    {
        _ShowHideProvinsiButton.onClick.RemoveAllListeners();
        _PlayVideoButton.onClick.RemoveAllListeners();
    }

    public override void CloseModal()
    {
        UnRegisterModal();
        base.CloseModal();
    }
}
