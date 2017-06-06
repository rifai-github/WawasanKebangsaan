using UnityEngine;

public abstract class BaseModal : MonoBehaviour
{
    private bool _bBaseModalOpened = false;

    public bool IsModalOpened { get { return ModalPanel.activeSelf; } }

    public GameObject ModalPanel;
    public Transform _OpenModal;
    public Transform _CloseModal;

    void Awake()
    {
        CloseModal();
    }

    public virtual void OpenModal()
    {
        if (ModalPanel != null)
            ModalPanel.transform.position = _OpenModal.position;
        _bBaseModalOpened = true;
    }

    void Update()
    {
        Tick(Time.deltaTime);
    }

    protected virtual void Tick(float deltaTime) 
    { 

    }

    public virtual void CloseModal()
    {
        if (ModalPanel != null)
            ModalPanel.transform.position = _CloseModal.position;
        _bBaseModalOpened = false;
    }
}


