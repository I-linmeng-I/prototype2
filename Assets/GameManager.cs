using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Net.Component;
public class GameManager :MonoBehaviour
{
    static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
                if(_instance == null)
                {
                    GameObject go = new GameObject("GameManager");
                    _instance = go.AddComponent<GameManager>();
                }
            }
            return _instance;
        }
    }
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

}
