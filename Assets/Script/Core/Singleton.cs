using UnityEngine;

public class Singleton : MonoBehaviour
{
    [SerializeField]
    private bool _bOnlineMode;
    [SerializeField]
    private bool _bMacBookMode;
    [SerializeField]
    private GameObject _Camera;
    [SerializeField]
    private GameObject _ARCamera;
    [SerializeField]
    private GameObjectProvinsiVariable _3DProvinsi;

    public bool OnlineMode { get { return _bOnlineMode; } }
    public bool MacBookMode { get { return _bMacBookMode; } }
    public GameObjectProvinsiVariable Get3DProvinsi { get { return _3DProvinsi; } }

    public static Singleton Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            if (Instance == null)
            {
                Instantiate(Instance);
                StaticFunction.WKMessageError("error when trying to create singleton");
            }
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
//#if UNITY_EDITOR
//        if (_bMacBookMode)
//        {
//            Destroy(_ARCamera);
//        }
//        else
//        {
//            Destroy(_Camera);
//		}
//#elif UNITY_ANDROID
//		Destroy(_Camera);
//#endif

        if (_bMacBookMode)
        {
            Destroy(_ARCamera);
        }
        else
        {
            Destroy(_Camera);
        }
	}
}
