using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Transform[] target;
    public float speed;
    public ParticleSystem waterPartical;
    public ParticleSystem firePartical;
    public ParticleSystem firePartical2;
    public ParticleSystem firePartical3;
    public ParticleSystem areaPartical;
    public ParticleSystem areaPartical2;
    public ParticleSystem areaPartical3;

    private int current;




    private void Start()
    {
        waterPartical = transform.Find("Water_Partical").GetComponent<ParticleSystem>();
        areaPartical.Play();
        areaPartical2.Stop();
        areaPartical3.Stop();
        waterPartical.Stop();
    }



    void FixedUpdate()
    {



        if (Input.GetMouseButton(0))
        {
            var rotation = Quaternion.LookRotation(target[current].position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * speed);

            if (transform.position != target[current].position)
            {
                Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
                Mathf.Lerp(transform.rotation.y, target[current].position.z,0.5f);
                GetComponent<Rigidbody>().MovePosition(pos);
            }
            else
            {
                current = (current + 1) % target.Length;
            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.CompareTag("Water"))
        {
            Score.score++;
            Destroy(other.gameObject);
        }


        if (other.CompareTag("FireZone"))
        {
            var sh = waterPartical.shape;
            sh.rotation = new Vector3(0f, 10f, 0f);

            
            waterPartical.Play();
            Score.score = Score.score - 6;

            StartCoroutine(WaterStop());
            StartCoroutine(FireStop());
           
        }


        if (other.CompareTag("FireZone2"))
        {
            var sh = waterPartical.shape;
            sh.rotation = new Vector3(4f, 17f, 0f);

            waterPartical.Play();
            Score.score = Score.score - 6;

            StartCoroutine(WaterStop());
            StartCoroutine(FireStop2());

        }

        if (other.CompareTag("FireZone3"))
        {
            var sh = waterPartical.shape;
            sh.rotation = new Vector3(29f,-17f, 0f);
            waterPartical.Play();
            Score.score=Score.score-6;

            StartCoroutine(WaterStop());
            StartCoroutine(FireStop3());

        }

    }



    IEnumerator FireStop()
    {
    
        yield return new WaitForSeconds(4);
        firePartical.Stop();
        areaPartical.Stop();
        areaPartical2.Play();

    }

    IEnumerator FireStop2()
    {
        yield return new WaitForSeconds(4);
        firePartical2.Stop();
        areaPartical2.Stop();
        areaPartical3.Play();
    }


    IEnumerator FireStop3()
    {
        yield return new WaitForSeconds(4);
        firePartical3.Stop();
        areaPartical3.Stop();

    }


    IEnumerator WaterStop()
    {
        yield return new WaitForSeconds(1.5f);
        waterPartical.Stop();
    }


}