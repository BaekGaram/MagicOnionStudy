using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;
    
    private bool _isConnected = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public async void Connect()
    {
        if (_isConnected)
        {
            Debug.LogError("Already connected to MagicOnion Hub");
            return;
        }
        await HubClient.Instance.Connect("http://localhost:5001");
        _isConnected = true;
        
        Debug.LogError("Connected to MagicOnion Hub");
    }
}