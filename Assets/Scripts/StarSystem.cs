using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LibNoise;
using System;
using System.Net.NetworkInformation;

public class StarSystem : MonoBehaviour
{
    public int _id;
    public string systemName = "未知";
    public int range = 5;
    public int planetCount =5;
    public GameObject planetPfb;
    public Stellar stellar;

    private void Start()
    {
        CreateStellar();
    }

    /// <summary>
    /// 生成星系恒星
    /// </summary>
    public void CreateStellar()
    {        
        int origin = GameManager.instance.randomNum;
        //生成本星系用种子
        int mySeed = Convert.ToInt32(System.Math.Ceiling(GameManager.instance.GetRandomNum((origin + 33 + _id).ToString()) * 1000));
        var myArray = Mathf.Abs(mySeed).ToArray_t();
        int type = myArray[myArray.Length - 2];
        if (type == 0)
        {
            stellar.data.stellarClassification = "M";
        }
        stellar.data.stellarClassification = Enum.GetName(typeof(StellarClassification), type);       
        Debug.Log(mySeed);
        var sc = (StellarClassification)type;
        switch (sc) 
        {
            case StellarClassification.O:
                stellar.data.temperature = GameManager.instance.GetRandomRange(30000, 52000, mySeed); //不同类型不同温度
                break;
            case StellarClassification.B:
                stellar.data.temperature = GameManager.instance.GetRandomRange(10000, 30000, mySeed);
                break;
            case StellarClassification.A:
                stellar.data.temperature = GameManager.instance.GetRandomRange(7500, 10000, mySeed);
                break;
            case StellarClassification.F:
                stellar.data.temperature = GameManager.instance.GetRandomRange(6000, 7500, mySeed);
                break;
            case StellarClassification.G:
                stellar.data.temperature = GameManager.instance.GetRandomRange(5200, 6000, mySeed);
                break;
            case StellarClassification.K:
                stellar.data.temperature = GameManager.instance.GetRandomRange(3700, 5200, mySeed);
                break;
            case StellarClassification.M:
                stellar.data.temperature = GameManager.instance.GetRandomRange(2400, 3700, mySeed);
                break;
            case StellarClassification.L:
                stellar.data.temperature = GameManager.instance.GetRandomRange(1300, 2400, mySeed);
                break;
            case StellarClassification.T:
                stellar.data.temperature = GameManager.instance.GetRandomRange(550, 1300, mySeed);
                break;
            default:
                stellar.data.temperature = GameManager.instance.GetRandomRange(2400, 3700, mySeed);
                break;
        }
    }

    /// <summary>
    /// 生成星系行星
    /// </summary>
    private void CreatePlanet(int num)
    {
        int origin = num;
        for (int i = 0; i < planetCount ; i++)
        {
            int originX = origin;
            int originY = Convert.ToInt32(System.Math.Ceiling(GameManager.instance.GetRandomNum(originX.ToString()) * 1000));
            int originZ = Convert.ToInt32(System.Math.Ceiling(GameManager.instance.GetRandomNum(originY.ToString()) * 1000));
            origin = Convert.ToInt32(System.Math.Ceiling(GameManager.instance.GetRandomNum(originZ.ToString()) * 1000)); ;
            Debug.Log(new Vector3Int(originX, originY, originZ));
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, range);
    }
}
