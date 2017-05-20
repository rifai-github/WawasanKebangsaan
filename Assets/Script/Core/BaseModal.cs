using UnityEngine;

public abstract class BaseModal : MonoBehaviour
{
    private bool _bBaseModalOpened = false;

    public bool IsModalOpened { get { return ModalPanel.activeSelf; } }

    public GameObject ModalPanel;

    void Awake()
    {
        CloseModal();
    }

    void Update()
    {
        Tick(Time.deltaTime);
    }

    protected virtual void Tick(float deltaTime) { }

    public virtual void CloseModal()
    {
        if (ModalPanel != null)
            ModalPanel.SetActive(false);
        _bBaseModalOpened = false;
    }

    public virtual void OpenModal()
    {
        if (ModalPanel != null)
            ModalPanel.SetActive(true);
        _bBaseModalOpened = true;
    }

    public virtual void SlideIn()
    {
        if (ModalPanel != null)
        {

        }

    }

    public virtual void SlideOut()
    {
        if (ModalPanel != null)
        {

        }

    }
}


