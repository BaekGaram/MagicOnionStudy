using Uitility;
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
        InitFields();
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    private void InitFields()
    {
        if (MessageField == null)
        {
            MessageField = GameObject.Find("IF_Message").GetComponent<InputField>();
        }

        if (NameField == null)
        {
            NameField = GameObject.Find("Input_UserName").GetComponent<InputField>();
        }
    }

    public async void Connect()
    {
        if (_isConnected)
        {
            MyLogger.Log("Already connected to MagicOnion Hub");
            return;
        }
        
        _isConnected = await HubClient.Instance.Connect("http://localhost:5000");
        
        MyLogger.Log($"Connected to MagicOnion Hub : {_isConnected}");
    }

    public async void Join()
    {
        if (_isConnected == false)
        {
            MyLogger.Log("Not connected to MagicOnion Hub");
            return;
        }

        var userName = NameField.text;
        MyLogger.Log("Joining hub with userName: " + userName);
        
        await HubClient.Instance.Join(userName);
        MyLogger.Log("Join complete");

        GamePlayer.Instance.UserName.text = userName;
    }

    public async void SendMessage()
    {
        var userName = NameField.text;
        var message = MessageField.text;

        await HubClient.Instance.SendMessage(userName, message);
        // 메시지 표시  
        StartCoroutine(GamePlayer.Instance.ShowMessage(message));
    }
    
    public async void Dispose()
    {
        if (_isConnected == false)
        {
            MyLogger.Log("Not connected to MagicOnion Hub");
            return;
        }

        _isConnected = false;
        
        await HubClient.Instance.DisposeAsync();
    }
}