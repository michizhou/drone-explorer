using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionscript : MonoBehaviour {

    public GameObject explosion;
    public Vector3 explosionOffset;
    public GameObject smoke;
    public int maximumSmokes;
    public float destroyDelay;
    public float minForce;
    public float maxForce;
    public float radius;


    
    public void Explode() {

        int smokeCounter = 0;

        if (explosion != null)
        {
            GameObject explosionFx = Instantiate(explosion, transform.position + explosionOffset, Quaternion.identity) as GameObject;
            Destroy(explosionFx, 5);
        }

        foreach (Transform t in transform)
        {
            var rb = t.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(Random.Range(minForce, maxForce), transform.position, radius);
            }

            if (smoke != null && smokeCounter < maximumSmokes) {
                if(Random.Range(1, 4) == 1) {
                    GameObject smokeFx = Instantiate(smoke, t.transform) as GameObject;
                    Destroy(smokeFx, 5);
                }
            }

            Destroy(t.gameObject, destroyDelay);
        }
    }
}
