using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
  
    public GameObject ScaleDistance; //�Ÿ��� ���� ������ ��ȭ�� ���� ������Ʈ ���
    public GameObject RayResult; //�浹�ϴ� ��ġ�� ����� ���

    [SerializeField] private GameObject _person;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        float distance = Vector3.Distance(_person.transform.position, transform.position);
        //����ĳ���� ��������� hit��� �̸����� ���Ѵ�.

        Vector3 direction = _person.transform.position - transform.position;
        direction = direction.normalized;

        RaycastHit hit;

        //// ������ forward�� �ƴ϶� player�� ���ϰԲ�

        //����ĳ��Ʈ ��� ��ġ, ����, �����, �ִ��νİŸ�
        if(Physics.Raycast(transform.position, direction, out hit, float.MaxValue))
        {
            Debug.Log("_player Found");
            transform.localScale = new Vector3(1, 1, distance);
            transform.rotation = Quaternion.LookRotation(direction);
        }

        //�Ÿ��� ���� ������ ������ ��ȭ
        // ScaleDistance.transform.localScale = new Vector3(1, distance, 1);
        //// z���� distance�� �־���ߴ�.


        //����ĳ��Ʈ�� ���� ���� ������Ʈ�� �ű��.
        //// ���� RayResult.transform.position = hit.point;

        //�ش��ϴ� ������Ʈ�� ȸ������ ���� ������ ��ֹ���� ��ġ��Ų��.
        //// ���� RayResult.transform.rotation = Quaternion.LookRotation(hit.normal);
    }
}
