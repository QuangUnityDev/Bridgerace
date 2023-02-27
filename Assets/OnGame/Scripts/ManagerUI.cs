using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerUI : SingletonObject<ManagerUI>
{
    [SerializeField] private Button bt_Start;
    private float countStart;
    public GameObject panelStart;
    public GameObject panelWin;
    public GameObject panelLost;

    void GameStart() 
    {
        countStart++;
        if(countStart == 2)
        {
            panelStart.SetActive(false);
            GameManager.GetInstance().isStartGame = true;
        }
    }
    void OnInit() 
    {
        panelWin.gameObject.SetActive(false);
        panelLost.gameObject.SetActive(false);
        panelStart.gameObject.SetActive(true);
        bt_Start.onClick.AddListener(GameStart);
    }
    public void Win()
    {
        panelWin.gameObject.SetActive(true);
    }
    public void Lost()
    {
        panelLost.gameObject.SetActive(true);
    }
    private void Awake()
    {
        OnInit();
    }
    void Start()
    {
        panelStart.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
