using System.Collections;
using Uitility;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GamePlayer : MonoBehaviourSingletonTemplate<GamePlayer>
{
    public Text UserName;
    public Text Message;
    
    public float MoveSpeed = 50.0f;

    void Awake()
    {
        if (UserName == null)
        {
            UserName = GameObject.Find("TXT_UserName").GetComponent<Text>();
        }

        if (Message == null)
        {
            Message = GameObject.Find("TXT_Message").GetComponent<Text>();
        }

        MyLogger.Log("GamePlayer Awake");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * (MoveSpeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * (MoveSpeed * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * (MoveSpeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * (MoveSpeed * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector3.up * (MoveSpeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.Z))
        {
            transform.Translate(Vector3.down * (MoveSpeed * Time.deltaTime));
        } 
    }
    
    void Start()
    {
        
    }
    
    public IEnumerator ShowMessage(string message)
    {
        Message.text = message;
        yield return new WaitForSeconds(3);
        Message.text = "";
    }
}