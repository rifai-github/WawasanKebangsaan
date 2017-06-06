using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using WawasanKebangsaanBase;

public class HomeModal : BaseModal 
{
    [SerializeField]
    private Button _Start;

    private HomeAnimateVarGatherer _Animate;

    private static HomeModal _Instance;

    public static HomeModal Instance()
    {
        if (_Instance == null)
        {
            _Instance = GameObject.FindObjectOfType<HomeModal>();

            if (_Instance == null)
            {
                WKStaticFunction.WKMessageError("there is no HomeModal in the system");
            }
        }
        return _Instance;
    }

    public override void OpenModal()
    {
        _Animate = ModalPanel.GetComponent<HomeAnimateVarGatherer>();

        foreach (Animator anim in _Animate.GetAnimator)
        {
            anim.SetBool("Enter", true);
            anim.SetBool("Leave", false);
        }

        base.OpenModal();
    }
        
    public void OnRegisterModal(UnityAction OnStartAction)
    {
        _Start.onClick.AddListener(OnStartAction);
    }

    private void UnRegisterModal()
    {
        _Start.onClick.RemoveAllListeners();
    }

    private IEnumerator CloseModalCourotine()
    {
        foreach (Animator anim in _Animate.GetAnimator)
        {
            anim.SetBool("Leave", true);
            anim.SetBool("Enter", false);
        }

        yield return new WaitForSeconds(3.8f);
        UnRegisterModal();
        base.CloseModal();
    }

    public override void CloseModal()
    {
        StartCoroutine(CloseModalCourotine());
    }
}
