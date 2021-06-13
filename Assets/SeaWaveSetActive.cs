using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaWaveSetActive : MonoBehaviour
{
    [SerializeField] Transform targetTr;
    [SerializeField] float activeDelay = 0.35f;
    IEnumerator Start()
    {
        targetTr = transform.Find("SeaWavePosition2");

        targetTr.gameObject.SetActive(false);
        yield return new WaitForSeconds(activeDelay);
        targetTr.gameObject.SetActive(true);
    }
}
