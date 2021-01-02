using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScript : MonoBehaviour {

    public GameObject fireObject;
	
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag=="zemin")
        {
            GameObject fireClone = Instantiate(fireObject, this.transform.position, Quaternion.identity);
            Destroy(fireClone, 3);
            Destroy(this.gameObject);            
        }

        if (col.gameObject.tag=="dusman")
        {
            GameObject fireClone = Instantiate(fireObject, this.transform.position, Quaternion.identity);
            Destroy(fireClone, 3);
            Destroy(col.gameObject);           
        }       
    }
}
