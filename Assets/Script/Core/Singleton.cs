using UnityEngine;

public class Singleton : MonoBehaviour
{
    [SerializeField]
    private bool _bOnlineMode;
    private bool _bNoCamera;

	private GameObject _Camera;
	private GameObject _ARCamera;
	private GameObjectProvinsiVariable _3DProvinsi;

    public bool OnlineMode { get { return _bOnlineMode; } }
    public bool NoCameraMode { get { return _bNoCamera; } set { _bNoCamera = value; } }
    public GameObjectProvinsiVariable Get3DProvinsi { get { return _3DProvinsi; } set { _3DProvinsi = value; }}

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
	}
}
