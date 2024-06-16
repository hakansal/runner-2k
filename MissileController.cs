using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
     GameObject target;
    public Rigidbody rocetrg;
    public float turnspeed = 1;
    public float rocetspeed = 1;
    public ParticleSystem rocetfire;
    public ParticleSystem rocetsmoke;
    public ParticleSystem exp;
    public ParticleSystem expsmoke;

    private Transform rocettrrans;
    private void Start()
    {
        rocettrrans = GetComponent<Transform>();
        target = GameObject.FindGameObjectWithTag("barels");
        StartCoroutine(destroy());
    }
    IEnumerator destroy()
    {
        yield return new WaitForSeconds(10);
        transform.gameObject.SetActive(false);
    }
    private void FixedUpdate()
    {
        rocetfire.Play();
        rocetsmoke.Play();
        rocetrg.velocity = rocettrrans.forward * rocetspeed;
        var rot = Quaternion.LookRotation(target.transform.position - rocettrrans.position);
        rocetrg.MoveRotation(Quaternion.RotateTowards(rocettrrans.rotation, rot, turnspeed));
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("barels"))
        {
            exp.transform.position = transform.position;
            expsmoke.transform.position = transform.position;
            exp.Play();
            expsmoke.Play();
            transform.gameObject.SetActive(false);
            target.SetActive(false);
        } if (other.gameObject.CompareTag("ground"))
        {
            exp.transform.position = transform.position;
            expsmoke.transform.position = transform.position;
            exp.Play();
            expsmoke.Play();
            transform.gameObject.SetActive(false);
            
        }
    }

}