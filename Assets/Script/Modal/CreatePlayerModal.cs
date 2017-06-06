using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using WawasanKebangsaanBase;

public class CreatePlayerModal : BaseModal
{
    [SerializeField]
    private InputField _PlayerName;
    [SerializeField]
    private Button _ButtonSubmit;
    
    private static CreatePlayerModal _Instance;

    public static CreatePlayerModal Instance()
    {
        if (_Instance == null)
        {
            _Instance = GameObject.FindObjectOfType<CreatePlayerModal>();

            if (_Instance == null)
            {
                WKStaticFunction.WKMessageError("there is no CreatePlayerModal in the system");
            }
        }
        return _Instance;
    }

    public override void OpenModal()
    {
        RegisterModal();
        base.OpenModal();
    }

    private void RegisterModal()
    {
        _ButtonSubmit.onClick.AddListener(OnSubmitAction);
    }

    private void OnSubmitAction()
    {
        WKSigleton.Instance.GetPlayerName = _PlayerName.text;

        JSONGetter jsonGetter = JSONGetter.GetJSON();
        jsonGetter._CreateName.name = _PlayerName.text;
        jsonGetter.StartParsing(EJSONType.JSON_PLAYERNAME, JSONAction);

    }

    private void JSONAction(string jsonString)
    {
        Debug.Log("asyjdhfguoyasdvfyuavsfajhsdvftauyvsdftgasdfbabwfyuasdbfhjbsdbbbbbbbb");
        WKStaticFunction.WKMessageLog(jsonString);

    }

    private void UnRegisterModal()
    {
        _ButtonSubmit.onClick.RemoveAllListeners();
    }

    public override void CloseModal()
    {
        UnRegisterModal();
        base.CloseModal();
    }
}
