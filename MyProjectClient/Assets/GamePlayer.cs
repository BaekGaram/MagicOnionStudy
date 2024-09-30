using Uitility;
using UnityEngine.UI;

public class GamePlayer : MonoBehaviourSingletonTemplate<GamePlayer>
{
    public Text UserName;
    public Text Message;

    // Start is called before the first frame update
    void Start()
    {
        UserName.text = "";
        Message.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}