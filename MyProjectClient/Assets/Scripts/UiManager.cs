using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    private bool _isConnected = false;
    
    public GameObject cubePrefab; // 생성할 큐브 프리팹
    public InputField MessageField;
    public InputField NameField;

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
        await HubClient.Instance.Connect("http://localhost:5000");
        _isConnected = true;
        
        Debug.Log("Connected to MagicOnion Hub");
    }
    
    public async void Join()
    {
        var userName = NameField.text;
        Debug.Log("Join userName : " + userName);
        
        HubClient.Instance.Join(userName);
    }
    
    public async void SendMessage()
    {
        var userName = NameField.text;
        var message = MessageField.text;
        
        Debug.Log("Send Message userName : " + userName);
        Debug.Log("Send Message message : " + message);
        
        HubClient.Instance.SendMessage(userName, message);
    }
}