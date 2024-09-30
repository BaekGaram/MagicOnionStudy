using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    private bool _isConnected = false;
    
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
        if (_isConnected == false)
        {
            Debug.Log("Not connected to MagicOnion Hub");
            return;
        }
        
        var userName = NameField.text;
        
        await HubClient.Instance.Join(userName);

        // userName 초기화 
        GamePlayer.Instance.UserName.text = userName;
    }
    
    public async void SendMessage()
    {
        var userName = NameField.text;
        var message = MessageField.text;
        
        await HubClient.Instance.SendMessage(userName, message);
        
        // 메시지 
        GamePlayer.Instance.Message.text = message;
    }
}