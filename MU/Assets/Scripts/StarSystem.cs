using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSystem : MonoBehaviour
{
    public float range = 5;
    public GameObject stellarPfb;

    public void CreateStellar()
    {
        GameObject go = Instantiate(stellarPfb, transform);
        Stellar stellar = go.GetComponent<Stellar>();
        Random.InitState();
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, range);
    }
}
