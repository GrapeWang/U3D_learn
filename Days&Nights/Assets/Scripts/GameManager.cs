using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public PlayerAim playerAim;
    public static GameManager instance;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        playerAim.onShoot += PlayerAim_onShoot;
    }

    private void PlayerAim_onShoot(object sender, PlayerAim.onShootEventArgs e)
    {
        Debug.Log("Shoot!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
