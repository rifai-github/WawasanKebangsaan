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
    private Animator _3dAnimation;
    [SerializeField]
    private GameObject _BolaDunia;
    [SerializeField]
    private GameObject _PetaIndonesia;
    [SerializeField]
    private Transform _MarkerPosition;
    [SerializeField]
    private Transform _PositionOnClick;
    [SerializeField]
    private Transform _Hide3d;
    [SerializeField]
    private Transform _DuniaShow;

    private GameObject _ProvinsiSelect;

    private bool _bProvClick;
    private bool _bEnter3d;

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
        _bEnter3d = true;
        _bProvClick = false;

        _3dAnimation.SetBool("Dunia", false);
        _3dAnimation.SetBool("Peta", false);
        _3dAnimation.SetBool("Click", false);

        base.OpenModal();
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
            StartCoroutine(EnterAnimator());

            if (_bProvClick)
            {
                _3dAnimation.SetBool("Click", true);

                _ProvinsiSelect.transform.localRotation = Quaternion.Lerp(_ProvinsiSelect.transform.localRotation, _MarkerPosition.localRotation, Time.deltaTime * 5);
                _ProvinsiSelect.transform.localPosition = Vector3.Lerp(_ProvinsiSelect.transform.localPosition, _MarkerPosition.localPosition, Time.deltaTime * 5);
                _ProvinsiSelect.transform.localScale = Vector3.Lerp(_ProvinsiSelect.transform.localScale, _MarkerPosition.localScale, Time.deltaTime * 5);
            }
        }
        else  // Lost
        {
            _bEnter3d = true;
            _bProvClick = false;

            _3dAnimation.SetBool("Dunia", false);
            _3dAnimation.SetBool("Peta", false);
            _3dAnimation.SetBool("Click", false);

            if (_ProvinsiSelect != null)
            {
                _ProvinsiSelect.transform.localScale = Vector3.Lerp(_ProvinsiSelect.transform.localScale, Vector3.zero, Time.deltaTime * 5);
                Destroy(_ProvinsiSelect, 1);
            }
        }
    }

    private IEnumerator EnterAnimator()
    {
        if(_bEnter3d)
            _3dAnimation.SetBool("Dunia", true);
        _bEnter3d = false;

        yield return new WaitForSeconds(11f);

        if (_BolaDunia.activeSelf)
        {
            _3dAnimation.SetBool("Peta", true);
            yield return new WaitForSeconds(1f);
            _3dAnimation.SetBool("Dunia", false);
        }
    }

    public void ProvinsiAction(GameObject prov, Transform pos)
    {
        if (_ProvinsiSelect != null)
            Destroy(_ProvinsiSelect);

        _bProvClick = true;
        _ProvinsiSelect = Instantiate(prov);
        ProvinsiClick provinsiClick = _ProvinsiSelect.GetComponent<ProvinsiClick>();
        Destroy(provinsiClick);

        //_ProvinsiSelect.AddComponent<>()
    }
    
    public void OnRegisterModal(UnityAction PlayVideoAction)
    {
        _PlayVideoButton.onClick.AddListener(PlayVideoAction);
    }

    public void UnRegisterModal()
    {
        _PlayVideoButton.onClick.RemoveAllListeners();
    }

    public override void CloseModal()
    {

        base.CloseModal();
    }
}
