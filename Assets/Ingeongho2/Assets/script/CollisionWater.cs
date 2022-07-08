using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWater : MonoBehaviour
{
    [SerializeField] Raycasting raycasting;
    void OnTriggerEnter(Collider collision) // ���� �浹
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            raycasting.iswater = true;
            raycasting.collidedObject = collision.gameObject;
            raycasting.StartLaserCoroutine();
        }
    }
    void OnTriggerExit(Collider collision) // ������ ���
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            raycasting.iswater = false;
            raycasting.collidedObject = null;
            raycasting.StopLaserCoroutine();
        }
    }
}
