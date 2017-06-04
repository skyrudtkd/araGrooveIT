using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour {
    public GameObject explosionPrefab;
    /*
    void OnCollisionEnter(UnityEngine.Collision coll)
    {
        if (coll.transform.tag == "Enemy")
        {
            Debug.Log("Enemy Collision");
            //Instantiate<GameObject>(missilePrefab, coll.transform.position);
            //Destroy(coll.gameObject);
        }
        else
        {
            Debug.Log("character");
        }
    }
    */
    void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag == "Enemy")
        {
            //Debug.Log("Enemy Collision");
            //Instantiate<GameObject>(missilePrefab, coll.transform.position);
            Debug.Log("before destroy");
            if (collider.transform.parent != null)
            {
                GameObject temp = collider.transform.parent.gameObject;
                collider.transform.parent = null;
                Destroy(temp); //destroy bullet
                collider.enabled = false; // collider disabled
                GameObject missile = Instantiate<GameObject>(explosionPrefab, collider.transform.position, Quaternion.EulerAngles(0,0,0));
                Destroy(collider.transform.gameObject,3.0f); // trail
                Destroy(missile, 3.0f);
            }
        }
        else
        {
            Debug.Log("character");
        }
    }

    // when anything destroy!
    void Destroy()
    {
        //Debug.Log("destroy");
    }

}
