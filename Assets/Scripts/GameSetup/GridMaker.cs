using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMaker : MonoBehaviour
{
    public GameObject policko;
    public GameObject tileFloor;
    public GameObject tileFull;

    public float width, height;
    public float Startx, Starty;

    public Vector2 rozmeryObr;

    float polickaNaVysku = 5;
    float polickaNaSirku = 10;
    public Vector2 rozmerPolicek;


    void Start()
    {
        rozmeryObr = GameObject.Find("Background").transform.lossyScale;

        width = rozmeryObr.x;
        height = rozmeryObr.y;

        rozmerPolicek.x = (GameObject.Find("Background").transform.lossyScale.x / (polickaNaSirku + 1));
        rozmerPolicek.y = (GameObject.Find("Background").transform.lossyScale.y / (polickaNaVysku + 1));

        Startx = -width/2 + 3;
        Starty = height/2 - rozmerPolicek.y;

        float rescalex = 1 / (polickaNaVysku + 1);
        float rescaley = 1 / (polickaNaSirku + 1);

        for (float i = 0; i < polickaNaVysku; i++)
        {
            for (float j = 0;j < 10; j++)
            {
                GameObject pol = Instantiate(policko, new Vector2(Startx + (j * rozmerPolicek.x), Starty - (i * rozmerPolicek.y)), Quaternion.identity, (GameObject.Find("Background").transform));
                GameObject child1 = Instantiate(tileFloor, pol.transform.position, Quaternion.identity, pol.transform);
                GameObject child2 = Instantiate(tileFull, pol.transform.position, Quaternion.identity, pol.transform);

                pol.transform.name = policko.name + i + j;
                child1.transform.name = tileFloor.name + i + j;
                child2.transform.name = tileFull.name + i + j;



                pol.transform.localScale = new Vector2(rescaley, rescalex);
                
            }
        }
    }

}
