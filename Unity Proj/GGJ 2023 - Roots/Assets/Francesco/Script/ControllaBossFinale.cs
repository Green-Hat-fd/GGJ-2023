using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllaBossFinale : MonoBehaviour
{
    public GameObject bossFinale;
    public GameObject portaDaSbloccare;

    void Update()
    {
        portaDaSbloccare.SetActive(!bossFinale ? true : false);
    }
}
