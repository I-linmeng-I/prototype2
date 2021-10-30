using Net.Component;
using Net.Server;
using Net.Share;
using UnityEngine;
using UnityEngine.UI;

public class UIController : SingleCase<UITest>
{
    [SerializeField]private Text text;
    [SerializeField] private GameObject startButton;
    [SerializeField] private Text playernum;
    [SerializeField] private Button loginButton;
    // Start is called before the first frame update
    void Start()
    {
        ClientManager.Instance.client.OnPingCallback += (delay) => {
            text.text = "网络延迟:" + delay + "ms";
        };
        loginButton.onClick.AddListener(() => {
            ClientManager.Instance.SendRT("Login");
        });
        startButton.GetComponent<Button>().onClick.AddListener(() => {
            ClientManager.AddOperation(new Net.Share.Operation(GameCommand.startGame));
        });
        ClientManager.Instance.client.AddRpcHandle(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [Rpc]
    void LoginCallback(string str)
    {
        Debug.Log(str);
        startButton.SetActive(true);
    }
    [Rpc]
    void PlayerNumChangeCallback(string str)
    {
        playernum.text = "当前在线人数："+str;
    }


}
