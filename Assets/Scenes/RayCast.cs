using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
  
    public GameObject ScaleDistance; //거리에 따른 스케일 변화를 위한 오브젝트 대상
    public GameObject RayResult; //충돌하는 위치에 출력할 결과

    [SerializeField] private GameObject _person;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        float distance = Vector3.Distance(_person.transform.position, transform.position);
        //레이캐스팅 결과정보를 hit라는 이름으로 정한다.

        Vector3 direction = _person.transform.position - transform.position;
        direction = direction.normalized;

        RaycastHit hit;

        //// 방향은 forward가 아니라 player를 향하게끔

        //레이캐스트 쏘는 위치, 방향, 결과값, 최대인식거리
        if(Physics.Raycast(transform.position, direction, out hit, float.MaxValue))
        {
            Debug.Log("_player Found");
            transform.localScale = new Vector3(1, 1, distance);
            transform.rotation = Quaternion.LookRotation(direction);
        }

        //거리에 따른 레이저 스케일 변화
        // ScaleDistance.transform.localScale = new Vector3(1, distance, 1);
        //// z축이 distance를 넣어야했다.


        //레이캐스트가 닿은 곳에 오브젝트를 옮긴다.
        //// 생략 RayResult.transform.position = hit.point;

        //해당하는 오브젝트의 회전값을 닿은 면적의 노멀방향와 일치시킨다.
        //// 생략 RayResult.transform.rotation = Quaternion.LookRotation(hit.normal);
    }
}
