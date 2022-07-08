using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasting : MonoBehaviour
{
    public bool iswater = true;
    public LineRenderer lr;
    public GameObject laserEffect;
    public ParticleSystem laserParticle;
    public GameObject collidedObject;
    public LayerMask mask;


    // Start is called before the first frame update
    void Start()
    {
        laserEffect.SetActive(false);
        lr.startColor = new Color(1, 0, 0, 0.5f);
        lr.endColor = new Color(1, 0, 0, 0.5f);
    }

    public void StartLaserCoroutine()
    {
        StartCoroutine("LaserCoroutine");
    }
    public void StopLaserCoroutine()
    {
        StopCoroutine("LaserCoroutine");
        laserParticle.gameObject.SetActive(false);
        laserEffect.SetActive(false);
    }
    public IEnumerator LaserCoroutine()
    {
        if (iswater == true)
        {
            Vector3 hitPoint;
            yield return new WaitForSeconds(3f);
            if (collidedObject != null)
            {
                hitPoint = collidedObject.GetComponent<CharacterController>().center + collidedObject.transform.position;
                transform.LookAt(hitPoint);
            }
            else yield break;
            laserEffect.SetActive(true);
            float dist = Vector3.Distance(transform.position, hitPoint);
            laserEffect.transform.localScale = new Vector3(1, 1, dist);
            laserParticle.transform.position = hitPoint;
            laserParticle.gameObject.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            laserParticle.gameObject.SetActive(false);
            laserEffect.SetActive(false);
            StartLaserCoroutine();
        }
        else
        {
            laserEffect.SetActive(false);
            laserParticle.gameObject.SetActive(false);
        }

    }
}
