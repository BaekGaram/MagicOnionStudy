using Uitility;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayer : MonoBehaviourSingletonTemplate<GamePlayer>
{
    public Text UserName;
    public Text Message;

    // Start is called before the first frame update
    void Start()
    {
        UserName = GameObject.Find("TXT_UserName").GetComponent<Text>();
        Message = GameObject.Find("TXT_Message").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}