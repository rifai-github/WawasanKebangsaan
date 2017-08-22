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
	private Transform _Name;
	[SerializeField]
	private Transform _FormName;
	[SerializeField]
	private Transform _ToName;
    [SerializeField]
    private Button _ExitPopupInfo;
    [SerializeField]
    private Button _ExitPopupConfirm;
    [SerializeField]
    private Button _YesButton;

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

    public override void OpenModal()
	{
        _ColorPopup = new Color(0, 0, 0, 0.8f);
        DefaultMode();
		base.OpenModal();
		_Name.position = _FormName.position;
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

        _Name.position = Vector3.Lerp(_Name.position, _ToName.position, Time.deltaTime * 5);

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
