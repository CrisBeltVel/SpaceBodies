using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Gravitacion : MonoBehaviour
{

    public GameObject obj1;
    public GameObject obj2;
    public float t;
    public float g = 0;

    public float G = 6.67E-11f;
    public float dist;
    public float masaP = 5.9736E24f;
    public float masaObj = 1f;
    public float v0 = 0;
    public float RadioRelativo = 0;
    public Text distTxt;
    Vector3 RadioPl; //escala
    Vector3 RadioOb;
    Vector3 posicionOb1;
    Vector3 posicionOb2;
    public Vector3 v;
    public Vector3 fg;
    public  Vector3 a;
    public Vector3 borrar;
    public Vector3 borrar2;

    // Start is called before the first frame update
    void Start()
    {

        RadioPl.y = 6371f; RadioPl.z = 6371f; RadioPl.x = 6371f;
        obj2.GetComponent<Transform>().localScale = RadioPl;
        RadioOb=obj1.GetComponent<Transform>().localScale;

        v = new Vector3(-302821, 0, 0);

    }
   
    // Update is called once per frame
    void Update()
    {

        posicionOb1 = gameObject.GetComponent<Transform>().position;
        posicionOb2 = obj2.GetComponent<Transform>().position;

        var heading = posicionOb1 - posicionOb2;

        var headingN = posicionOb1.normalized;

        borrar = headingN;

        var headingN2 = heading / Mathf.Sqrt(heading.y * heading.y + heading.x * heading.x + heading.z * heading.z);

        borrar2 = headingN2;




        t = Time.deltaTime;
        dist = Vector3.Distance(obj1.transform.position, obj2.transform.position);

        posicionOb1 = gameObject.GetComponent<Transform>().position;
        RadioRelativo = (RadioPl.y / 2) + (RadioOb.y / 2);

        fg = -(G * masaP*masaObj / (dist * dist))* headingN2; 

        a = -(G *  masaP  / (dist * dist)) * headingN2;

        //0.17->v3 -3259.765

        v = v + a * t*t;
            posicionOb1 = posicionOb1 + v * t;
    
            gameObject.GetComponent<Transform>().position = posicionOb1;
        

     
        SetDistance();
    }

    void SetDistance()
    {
        distTxt.text = "Distancia: " + dist.ToString();
    }

}
