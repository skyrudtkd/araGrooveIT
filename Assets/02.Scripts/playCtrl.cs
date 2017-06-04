using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playCtrl : MonoBehaviour
{

    private Transform tr;
    private Animator anim;
    private NavMeshAgent nv;

    public float damping = 3.0f;
    public float speed = 5.0f;

    private Ray ray;
    private RaycastHit hit;
    private int floorLayer;

    public Vector3 movePos = Vector3.zero;

    private Quaternion rot;


    // Use this for initialization
    void Start()
    {
        tr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        nv = GetComponent<NavMeshAgent>();
        floorLayer = LayerMask.NameToLayer("FLOOR"); // 1<<8 이거랑 똑같이 레이어 마스크 하는거임.

        movePos = tr.position;

        

    }

    // Update is called once per frame
    void Update()
    {
        tr.Translate(Vector3.forward * Time.deltaTime * speed);
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButton(0) && Physics.Raycast(ray, out hit, 100.0f, 1 << floorLayer))
        {
            movePos = hit.point;
            //Debug.Log(movePos);
            rot = Quaternion.LookRotation(movePos - tr.position); //도깨비무사 위치 로부터 클릭한장소까지 거리 백터.
        }
        if ((movePos - tr.position).sqrMagnitude>= 0.1f)
        {
            //Quaternion rot = Quaternion.LookRotation(movePos - tr.position); //도깨비무사 위치 로부터 클릭한장소까지 거리 백터.
            tr.rotation = Quaternion.Slerp(tr.rotation, rot, Time.deltaTime * damping);
            //tr.Translate(Vector3.forward * Time.deltaTime * speed);
            anim.SetBool("isRun", true);
        }
        else
        {
            anim.SetBool("isRun", false);
        }
    }
}

