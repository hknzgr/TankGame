using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour {

    float zaman = 0;
    int yon = 1;
    public float donmeSuresi;
	void Start ()
    {
		
	}
	
	
	void Update ()
    {
        zaman += Time.deltaTime;
        if (zaman>donmeSuresi)
        {
            yon *= -1;
            this.transform.Rotate( new Vector3(0, 180, 0));
            zaman = 0;
        }
        this.transform.position += new Vector3(-yon*Time.deltaTime, 0, 0);
	}
}
