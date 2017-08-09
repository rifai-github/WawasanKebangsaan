using UnityEngine;

public class Singleton : MonoBehaviour
{
    [SerializeField]
    private bool _bOnlineMode;

    public AssetBundle assetsBundle { get; set; }
    public bool OnlineMode { get { return _bOnlineMode; } }
    public bool MacBookMode { get; set; }
    public GameObjectProvinsiVariable Get3DProvinsi { get; set; }

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
