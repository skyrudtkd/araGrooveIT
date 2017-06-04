using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {
    private Transform tr;
    private Transform playerTr;

    public float damping = 1.0f; // 궤적을 크게, 작게 표현 가능.
    public float speed = 5.0f;
	// Use this for initialization
	void Start () {
        tr = GetComponent<Transform>();
        playerTr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	void LateUpdate()
    {
        Vector3 direction = playerTr.position - tr.position;
        direction = new Vector3(direction.x, 0, direction.z);
        Quaternion rot = Quaternion.LookRotation(direction);
        tr.rotation = Quaternion.Slerp(tr.rotation, rot, Time.deltaTime * damping); //a각도부터 b각도까지 스무스하게 움직인다.(시작,끝, 시간).

        tr.Translate(Vector3.forward * Time.deltaTime * speed); 
    }
}
