using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMissile : MonoBehaviour {
    public GameObject missilePrefab;
    public int objcount = 5;
    private int cnt = 0;

    // Use this for initialization
    void Start()
    {
        StartCoroutine("Fire");
    }

    IEnumerator Fire()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3.0f, 5.0f));
            Quaternion rot = Quaternion.LookRotation(transform.forward);
            GameObject missile = Instantiate<GameObject>(missilePrefab, transform.position, rot);
            cnt++;
        } 
    }
}
