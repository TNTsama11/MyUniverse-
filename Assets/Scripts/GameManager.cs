using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LibNoise;
using UnityEngine.UI;
using System;
using Unity.Mathematics;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int randomNum;
    public string seedStr;


    private void Awake()
    {
        instance = this;
        Begin();
    }

    private void Begin()
    {
        if (seedStr == string.Empty)
        {
            seedStr = GetSeed();
        }
        randomNum = Convert.ToInt32(System.Math.Ceiling(GetRandomNum(seedStr) * 1000)); //根据种子生成初始随机数
    }

    /// <summary>
    /// 生成初始种子
    /// </summary>
    private string GetSeed()
    {
        string uuid = System.Guid.NewGuid().ToString();
        string seed = uuid.GetHashCode_t().ToString();
        return seed;
    }

    /// <summary>
    /// 获取伪随机数
    /// </summary>
    public double GetRandomNum(string seed)
    {
        int s = seed.GetHashCode_t();
        // Debug.Log(s);
        int x = s % 10;
        int y = Mathf.Abs(x) * x;
        int z = y + x;
        FastNoise fastNoise = new FastNoise(Mathf.Abs(s));
        var n = fastNoise.GetValue(x, y, z);
       // Debug.Log(n);
        return n;
    }

    public int GetRandomRange(int min,int max,int seed)
    {
        TNTRandomGenerator randomGenerator = new TNTRandomGenerator(seed);
        int temp = (int)randomGenerator.Next(max - min);
        return temp + min;
    }

}

public enum StellarClassification
{
    O=1,
    B=2,
    A=3,
    F=4,
    G=5,
    K=6,
    M=7,
    L=8,
    T=9
}
