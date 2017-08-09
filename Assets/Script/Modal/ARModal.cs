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

    [SerializeField]
    private GameObject _PanelSuku;
    [SerializeField]
    private GameObject _SukuPlaceHolder;
    [SerializeField]
    private GameObject _VideoButton;
    [SerializeField]
    private GameObject _VideoPlaceHolder;

	[SerializeField]
	private Swipe _Swipe;

    [SerializeField]
    private Image _Frame;

	private Vector3 _PetaStartScale;

    private GameObject _ProvinsiSelect;
    private Transform _ProvinsiView;
    private Animator _3DAnimate;
    private GameObject _LastSelectProv;
    private Transform _Object;

    private bool _bProvView;
    private bool _bButtonProvinsi;
    public bool ShowProvinsi { get { return _bButtonProvinsi; } set { _bButtonProvinsi = value; } }

    private bool _bMarkerDetect;
    public bool SetFoundMarker { set { _bMarkerDetect = value; } }

    private List<ItemClass> _ItemClassList;
    private List<GameObject> _ItemButtonList = new List<GameObject>();
    private List<GameObject> _ItemSukuList = new List<GameObject>();
    private List<GameObject> _ItemVideoList = new List<GameObject>();

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


    protected override void LoadAssets()
    {
        base.LoadAssets();

		_Frame.sprite = StaticFunction.TextureToSprite(Singleton.Instance.assetsBundle.LoadAsset(StaticFunction.PathSpriteFormAssetBundle(eSpriteName.FRAME_AR)) as Texture2D);

	}

    public override void OpenModal()
    {
        base.OpenModal();

        if (Singleton.Instance.MacBookMode)
        {
            _MarkerTransform.parent.GetComponent<EasyAR.EasyImageTargetBehaviour>().enabled = false;
            _bMarkerDetect = true;
        }
        
        OnRegisterModal();
        _PetaStartScale = _PetaIndonesia.lossyScale;
        _3DAnimate = _3dModal.GetComponent<Animator>();
        
        JSONGetter getJson = JSONGetter.GetJSON();
        getJson.StartParsing(TypeJSON.JSON_PROVINSI, JSONAction);

    }

    private void JSONAction(string jsonString)
    {                           
        StaticFunction.WKMessageLog(jsonString);

        GetPrivinsiItemJSON baseJSON = new GetPrivinsiItemJSON(jsonString);
        _ItemClassList = baseJSON.ParseJSON();

        StartCoroutine(CreateDynamicDataProvinsi(_ItemClassList));
    }

    private IEnumerator CreateDynamicDataProvinsi(List<ItemClass> itemProvinsi)
    {
        foreach (ItemClass item in itemProvinsi)
        {
            ProvinsiItemClass itemClass = item as ProvinsiItemClass;
            CreateUIForDataProvinsi(itemClass);
            yield return new WaitForFixedUpdate();
        }
    }

    private void CreateUIForDataProvinsi(ProvinsiItemClass itemClass)
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

        provinsi.GetLambangPath = itemClass.GetLambang;
        provinsi.GetSuku = itemClass.GetSuku;
        provinsi.GetVideoPath = itemClass.GetVideo;
        
        _ItemButtonList.Add(item);
    }
        
    protected override void Tick(float deltaTime)
    {   if (ModalPanel.activeSelf)
        {
            DetectObject();
            ProvinsiView();
            ShowHideButtonProvinsi();

            _BolaDunia.transform.Rotate(0, Time.deltaTime * 15, 0);
        }
        base.Tick(deltaTime);
    }

    private void DetectObject()
    {
        if (_bMarkerDetect)
        {
            _PanelScroll.gameObject.SetActive(true);
            _PetaIndonesia.gameObject.SetActive(true);

            //_3dModal.transform.position = Vector3.Lerp(_3dModal.transform.position, _MarkerTransform.position, Time.deltaTime * 5);
            //_3dModal.transform.rotation = Quaternion.Lerp(_3dModal.transform.rotation, _MarkerTransform.rotation, Time.deltaTime * 5);

            StartCoroutine(EnterAnimator());

        }
        else  // Lost
        {
            _PanelScroll.gameObject.SetActive(false);
            _PetaIndonesia.gameObject.SetActive(false);
            _bProvView = false;
            _bButtonProvinsi = false;
            _Swipe.enabled = false;
            _3DAnimate.enabled = true;
            _ShowHideProvinsiButton.interactable = false;
            _3DAnimate.SetBool("Dunia", false);
			_3DAnimate.SetBool("Peta", false);

            if (_ProvinsiSelect != null)
			{
				_Object.localScale = Vector3.zero;
				Destroy(_Object.gameObject);
				Destroy(_ProvinsiSelect, 1);
				_LastSelectProv.GetComponent<Renderer>().material.color = Color.green;
				_PetaIndonesia.transform.localScale = new Vector3(_PetaStartScale.x, _PetaStartScale.y, _PetaStartScale.z);
            }
        }
    }

    private void ProvinsiView()
    {
        if (_bProvView)
        {
            _LambangProv.gameObject.SetActive(true);
            _3DAnimate.enabled = false;
            _ProvinsiSelect.transform.position = _MarkerTransform.position;
            _ProvinsiSelect.transform.rotation = _MarkerTransform.rotation;
            _PetaIndonesia.position = Vector3.Lerp(_PetaIndonesia.position, _ProvinsiView.position, Time.deltaTime * 5);
            _PetaIndonesia.localScale = Vector3.Lerp(_PetaIndonesia.localScale, _ProvinsiView.localScale, Time.deltaTime * 5);
            _Object.position = _MarkerTransform.position;
            _Object.rotation = _MarkerTransform.rotation;

            if(_Object != null)
            {
                _Object.localScale = Vector3.Lerp(_Object.localScale, Vector3.one, Time.deltaTime * 8);
            }

            if (Input.GetKey(KeyCode.Escape))
            {
                Destroy(_ProvinsiSelect, 1);
                _bProvView = false;
                return;
            }
        }
        else
        {
            _LambangProv.gameObject.SetActive(false);
            DestroySukuVideo();
            if (!_3DAnimate.enabled)
            {
                _PetaIndonesia.position = Vector3.Lerp(_PetaIndonesia.position, _MarkerTransform.position, Time.deltaTime * 5);
                _PetaIndonesia.localScale = Vector3.Lerp(_PetaIndonesia.localScale, _PetaStartScale, Time.deltaTime * 5);
            }
        }
    }
    
    private void ShowHideButtonProvinsi()
    {
        if (_bButtonProvinsi)
            _PanelScroll.position = Vector2.Lerp(_PanelScroll.position, _ShowButtonProvinsi.position, Time.deltaTime * 5);
        else
            _PanelScroll.position = Vector2.Lerp(_PanelScroll.position, _HideButtonProvinsi.position, Time.deltaTime * 5);
    }

    public void ProvinsiAction(GameObject prov, Transform obj)
    {
        if (_ProvinsiSelect != null)
        {
            _Object.localScale = Vector3.zero;
            Destroy(_Object.gameObject);
            _LastSelectProv.GetComponent<Renderer>().material.color = Color.green;
            Destroy(_ProvinsiSelect);
        }
        _Object = Instantiate(obj);
        _Object.SetParent(_3dModal.transform);
        prov.GetComponent<Renderer>().material.color = Color.red;
		_LastSelectProv = prov;
        _bProvView = true;
        _bButtonProvinsi = false;

        _ProvinsiSelect = Instantiate(prov) as GameObject;
        _ProvinsiSelect.name = prov.name + " (ProvinsiSelected)";
        _ProvinsiSelect.transform.SetParent(_3dModal.transform);

        foreach (Component comp in _ProvinsiSelect.GetComponents<Component>())
        {
            if (!(comp is Transform) && !(comp is ProvinsiClick))
            {
                Destroy(comp);
            }
        }

        string urlLambang = _ProvinsiSelect.GetComponent<ProvinsiClick>().GetLambangPath;
        string[] suku = _ProvinsiSelect.GetComponent<ProvinsiClick>().GetSuku;
        string[] video = _ProvinsiSelect.GetComponent<ProvinsiClick>().GetVideoPath;                             
        StartCoroutine(CreateDynamicDataSelect(suku, video));
        Debug.Log(urlLambang);
		_LambangProv.sprite = StaticFunction.TextureToSprite(Singleton.Instance.assetsBundle.LoadAsset(urlLambang) as Texture2D);


		//ImageGetter image = ImageGetter.GetImage();
        //image.StartGettingImage(_LambangProv, urlLambang);

        _ProvinsiView = _ProvinsiSelect.transform.GetChild(0);
        _ProvinsiSelect.transform.localScale = _ProvinsiView.localScale;
    }

    private IEnumerator CreateDynamicDataSelect(string[] suku, string[] video)
    {
        DestroySukuVideo();         

        for (int i = 0; i < suku.Length; i++)
        {
            GameObject itemSuku = Instantiate(_PanelSuku) as GameObject;
            itemSuku.transform.SetParent(_SukuPlaceHolder.transform);
            itemSuku.transform.localScale = Vector3.one;
            itemSuku.name = suku[i];
            itemSuku.SetActive(true);

            itemSuku.GetComponent<NamaSukuVariable>().GetSukuText.text = suku[i];

            _ItemSukuList.Add(itemSuku);

            yield return new WaitForFixedUpdate();
        }

        for (int i = 0; i < video.Length; i++)
        {
            GameObject itemVideo = Instantiate(_VideoButton) as GameObject;
            itemVideo.transform.SetParent(_VideoPlaceHolder.transform);
            itemVideo.transform.localScale = Vector3.one;
            itemVideo.name = video[i];
            itemVideo.SetActive(true);

            itemVideo.GetComponent<VideoVariable>().GetVideoName.text = video[i];
            itemVideo.GetComponent<PlayVideo>().VideoName = video[i];

            _ItemVideoList.Add(itemVideo);

            yield return new WaitForFixedUpdate();
        }
    }

    
    private IEnumerator EnterAnimator()
    {
        _3DAnimate.SetBool("Dunia", true);

        yield return new WaitForSeconds(13f);

        _3DAnimate.SetBool("Peta", true);
        yield return new WaitForSeconds(1f);
        _3DAnimate.SetBool("Dunia", false);

        _Swipe.enabled = true;
        _ShowHideProvinsiButton.interactable = true;

    }
                   
    private void PlayVideoAction()
    {
        VideoGetter video = new VideoGetter();
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

    private void DestroySukuVideo()
    {
        foreach (GameObject go in _ItemSukuList)
        {
            Destroy(go);
        }

        foreach (GameObject go in _ItemVideoList)
        {
            Destroy(go);
        }
    }

    private void DestroyButtonProvinsi()
    {
        foreach (GameObject item in _ItemButtonList)
        {
            Destroy(item);
        }
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
        if (_ItemButtonList != null)
            _ItemButtonList.Clear();

        DestroyButtonProvinsi();
        UnRegisterModal();
        _bMarkerDetect = false;

        base.CloseModal();
    }
}
