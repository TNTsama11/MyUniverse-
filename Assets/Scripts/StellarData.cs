using System;

[Serializable]
public class StellarData 
{
    public string starName = "未知"; //名称
    public string stellarClassification = "O"; //恒星类型
    public int temperature = 52000; //温度(K)
    public int age = 400; //年龄(万年)
    public int metalAmount = 1; //原行星盘金属量(1,2,3) 1最多    
}
