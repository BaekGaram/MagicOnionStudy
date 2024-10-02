using System.Collections;
using System.Collections.Generic;
using Uitility;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviourSingletonTemplate<GameManager>
{
    void Awake()
    {
        MyLogger.Log("GameManager Awake, gamePlayer Set Active false");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ShowGamePlayer(string userName)
    {
        // GamePlayer 프리팹 로드
        GameObject gamePlayerPrefab = Resources.Load<GameObject>("GamePlayer");
        
        // Canvas를 찾음
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas == null)
        {
            Debug.LogError("Canvas 오브젝트를 찾을 수 없습니다.");
            return;
        }

        // GamePlayer 인스턴스화
        var gamePlayer = Instantiate(gamePlayerPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        // GamePlayer를 Canvas의 자식으로 설정
        gamePlayer.transform.SetParent(canvas.transform, false);

        // Canvas 하위의 TXT_UserName 오브젝트 찾기
        Transform userNameTransform = gamePlayer.transform.Find("TXT_UserName");
        
        if (userNameTransform != null)
        {
            Text usernameText = userNameTransform.GetComponent<Text>();
            if (usernameText != null)
            {
                usernameText.text = userName;
            }
            else
            {
                Debug.LogError("TXT_UserName에 Text 컴포넌트가 없습니다.");
            }
        }
        else
        {
            Debug.LogError("Canvas 하위에서 TXT_UserName 오브젝트를 찾을 수 없습니다.");
        }
    }
}