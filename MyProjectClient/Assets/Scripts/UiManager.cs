using UnityEngine;

public class UiManager : MonoBehaviour
{
    private bool _isConnected = false;
    
    public GameObject cubePrefab; // 생성할 큐브 프리팹

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
        
        Debug.LogError("Connected to MagicOnion Hub");
    }

    public async void CreatePlayer()
    {
        // 큐브를 생성할 위치를 현재 위치 기준으로 설정 (필요에 따라 수정 가능)
        Vector3 spawnPosition = new Vector3(0, 0, 0); 

        // 큐브 오브젝트를 생성 (Instantiate)
        GameObject newCube = Instantiate(cubePrefab, spawnPosition, Quaternion.identity);
        // 생성된 큐브의 이름을 "New Cube"로 설정
        newCube.name = "New Cube";
        newCube.SetActive(true);
        // 콘솔에 메시지 출력
        Debug.Log("Cube created at position: " + spawnPosition);
        
        await HubClient.Instance.Connect()
        
    }
}