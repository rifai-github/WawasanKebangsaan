using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using WawasanKebangsaanBase;
using System.IO;

public class HomeModal : BaseModal 
{
    [SerializeField]
	private RectTransform _Title;
	[SerializeField]
	private RectTransform _TitlePosition;
    [SerializeField]
    private Button _StartButton;
    [SerializeField]
	private Button _InfoButton;
	[SerializeField]
	private Transform _PanelInfo;
    [SerializeField]
    private Transform _ExitConfirm;
    [SerializeField]
	private Image _BackgroundPopup;
    [SerializeField]
    private Button _ExitPopupInfo;
    [SerializeField]
    private Button _ExitPopupConfirm;
    [SerializeField]
	private Button _YesButton;
	[SerializeField]
	private Image _SequenceImage;
	[SerializeField]
	private Image _Landscape;
    [SerializeField]
	private Image _Sky;
	[SerializeField]
	private Image _Balon;
	[SerializeField]
	private List<Image> _Awan;

	private bool _bShowInfoPanel;
    private bool _bShowExitConfirm;
    private Color _ColorPopup;

    private static HomeModal _Instance;

    public static HomeModal Instance()
    {
        if (_Instance == null)
        {
            _Instance = GameObject.FindObjectOfType<HomeModal>();

            if (_Instance == null)
            {
                StaticFunction.WKMessageError("there is no HomeModal in the system");
            }
        }
        return _Instance;
    }

    protected override void LoadAssets()
    {
        foreach (Image awan in _Awan)
        {
            awan.sprite = StaticFunction.TextureToSprite(Singleton.Instance.assetsBundle.LoadAsset(StaticFunction.PathSpriteFormAssetBundle(eSpriteName.AWAN)) as Texture2D);
        }
		_Sky.sprite = StaticFunction.TextureToSprite(Singleton.Instance.assetsBundle.LoadAsset(StaticFunction.PathSpriteFormAssetBundle(eSpriteName.LANGIT)) as Texture2D);
		_Balon.sprite = StaticFunction.TextureToSprite(Singleton.Instance.assetsBundle.LoadAsset(StaticFunction.PathSpriteFormAssetBundle(eSpriteName.BALON)) as Texture2D);
		_Landscape.sprite = StaticFunction.TextureToSprite(Singleton.Instance.assetsBundle.LoadAsset(StaticFunction.PathSpriteFormAssetBundle(eSpriteName.LANDSCAPE)) as Texture2D);
		_PanelInfo.GetComponent<Image>().sprite = StaticFunction.TextureToSprite(Singleton.Instance.assetsBundle.LoadAsset(StaticFunction.PathSpriteFormAssetBundle(eSpriteName.POPUP_INFO)) as Texture2D);
		_ExitConfirm.GetComponent<Image>().sprite = StaticFunction.TextureToSprite(Singleton.Instance.assetsBundle.LoadAsset(StaticFunction.PathSpriteFormAssetBundle(eSpriteName.POPUP_EXIT)) as Texture2D);
        StartCoroutine(LoopSquence());
        base.LoadAssets();
    }

    public override void OpenModal()
	{
		base.OpenModal();
        _Title.position = new Vector3(_Title.position.x, 1200, _Title.position.z);
        _ColorPopup = new Color(0, 0, 0, 0.8f);
        DefaultMode();
    }

    private IEnumerator LoopSquence()
    {
        coba:
        for (int i = 0; i <= 53; i++)
        {
            string pathImage = StaticFunction.PathSpriteFormAssetBundle(eSpriteName.SQUENCE) + i.ToString("D5");
            Sprite newSprite = StaticFunction.TextureToSprite(Singleton.Instance.assetsBundle.LoadAsset(pathImage) as Texture2D);
            _SequenceImage.sprite = newSprite;
            yield return new WaitForSeconds(1 / 30f);
        }
        goto coba;
    }

    private void ShowInfoPanel()
    {
        _PanelInfo.gameObject.SetActive((true));
        _PanelInfo.localScale = Vector3.zero;
        _bShowInfoPanel = true;
    }

    private void ShowExitConfirm()
	{
		_ExitConfirm.gameObject.SetActive((true));
		_ExitConfirm.localScale = Vector3.zero;
		_bShowExitConfirm = true;
    }

    private void YesExit()
    {
        Application.Quit();
    }

    private void DefaultMode()
	{
		_PanelInfo.gameObject.SetActive(false);
		_ExitConfirm.gameObject.SetActive(false);
		_BackgroundPopup.color = Color.clear;
        _BackgroundPopup.gameObject.SetActive(false);
        _bShowInfoPanel = false;
        _bShowExitConfirm = false;
    }

    public void OnRegisterModal(UnityAction OnStartAction)
    {
        _StartButton.onClick.AddListener(OnStartAction);
        _InfoButton.onClick.AddListener(ShowInfoPanel);
		_ExitPopupInfo.onClick.AddListener(DefaultMode);
		_ExitPopupConfirm.onClick.AddListener(DefaultMode);
        _YesButton.onClick.AddListener(YesExit);
    }

    protected override void Tick(float deltaTime)
	{
		
        base.Tick(deltaTime);

        _Title.position = Vector3.Lerp(_Title.position, _TitlePosition.position, Time.deltaTime * 5F);

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (_bShowInfoPanel || _bShowExitConfirm)
            {
                DefaultMode();
                return;
            }
            if (!_bShowInfoPanel)
                ShowExitConfirm();
        }

        if (_bShowInfoPanel)
		{
			_BackgroundPopup.gameObject.SetActive(true);
            _BackgroundPopup.color = Color.Lerp(_BackgroundPopup.color, _ColorPopup, Time.deltaTime * 10);
            _PanelInfo.localScale = Vector3.Lerp(_PanelInfo.localScale, Vector3.one, Time.deltaTime * 10);
        }

        if (_bShowExitConfirm)
        {
			_BackgroundPopup.gameObject.SetActive(true);
			_BackgroundPopup.color = Color.Lerp(_BackgroundPopup.color, _ColorPopup, Time.deltaTime * 10);
            _ExitConfirm.localScale = Vector3.Lerp(_ExitConfirm.localScale, Vector3.one, Time.deltaTime * 10);
        }
    }

    public void UnRegisterModal()
    {
        _StartButton.onClick.RemoveAllListeners();
        _InfoButton.onClick.RemoveAllListeners();
		_ExitPopupInfo.onClick.RemoveAllListeners();
		_ExitPopupConfirm.onClick.RemoveAllListeners();
        _YesButton.onClick.RemoveAllListeners();
    }
}
