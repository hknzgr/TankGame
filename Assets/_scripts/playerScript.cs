using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerScript : MonoBehaviour {

    Quaternion sol = new Quaternion(0, 180, 0, 0);
    Quaternion sag = new Quaternion(0, 0, 0, 0);
    GameObject ustNesne;
    public Text hakTxt;
    public Text gameOver;
    public GameObject enemy;
    public GameObject fire;
    public GameObject ball;
    public GameObject barIc;
    int yon=1;
    float minMag = 100;
    float maxMag = 600;
    float angle;
    float magnitute;
    Vector3 force;
    void Start ()
    {
        hakTxt.GetComponent<Text>().text = "HAK : " + menuScript.hak;
        ustNesne=this.transform.GetChild(1).gameObject;
    
	}
	
	
	void Update ()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (Camera.main.transform.position.x < 5)
            {
                Camera.main.transform.position += new Vector3(Time.deltaTime, 0, 0);
            }
            this.transform.rotation = sag;
            this.transform.position += new Vector3(Time.deltaTime, 0, 0);
            yon = 1;
            

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (Camera.main.transform.position.x>-1)
            {
                Camera.main.transform.position -= new Vector3(Time.deltaTime, 0, 0);
            }
            this.transform.rotation = sol;
            this.transform.position -= new Vector3(Time.deltaTime, 0, 0);
            yon = -1;
            

        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (ustNesne.transform.rotation.z<0.4f)
            {
                ustNesne.transform.Rotate(new Vector3(0, 0, 1));
            }
           
        }
       
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (ustNesne.transform.rotation.z>-0.4f)
            {
                ustNesne.transform.Rotate(new Vector3(0, 0, -1));
            }
            
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            magnitute = minMag;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (magnitute > maxMag)
            {
                magnitute = minMag;
            }
            else
            {
                magnitute += 5;
            }
            barIc.transform.localScale = new Vector3((1/(maxMag-minMag))*(magnitute-minMag), 1, 1);
            
        }
        if (Input.GetKeyUp(KeyCode.Space) && menuScript.hak!=0)
        {            
            ateset();
        }

        if (menuScript.hak==0)
        {
            gameOver.GetComponent<Text>().text = "KAYBETTİNİZ";
            Invoke("MenuyeDon", 2);
        }

        if (enemy.transform.childCount==0)
        {
            gameOver.GetComponent<Text>().text = "KAZANDINIZ";
            Invoke("MenuyeDon", 2);
        }




    }
   
    void ateset()
    {
        angle = ustNesne.transform.eulerAngles.z;
        GameObject ballclone = Instantiate(ball, fire.transform.position, Quaternion.identity);
        float forcex = magnitute * (Mathf.Cos(angle * Mathf.Deg2Rad))*yon;
        float forcey= magnitute * (Mathf.Sin(angle * Mathf.Deg2Rad));
        force = new Vector3(forcex, forcey, 0);
        ballclone.GetComponent<Rigidbody>().AddForce(force);
        menuScript.hak--;
        hakTxt.GetComponent<Text>().text = "HAK : " + menuScript.hak;
    }

    void MenuyeDon()
    {
        SceneManager.LoadScene(0);
    }
}
