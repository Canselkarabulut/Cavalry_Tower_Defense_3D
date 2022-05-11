using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] public static int money;
    [SerializeField] public  int startMoney = 400;

    public static int Lives;
    public int startLives = 20;
    Bullet _bullet;
    void Start()
    {
        money = startMoney;
        Lives = startLives;
    }
  
}
