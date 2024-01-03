using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMaker : MonoBehaviour
{
    public GameObject policko;
    public GameObject tileFloor;
    public GameObject tileFull;
    public GameObject bgrSquare;

    public float width, height;
    public float Startx, Starty;

    public Vector2 rozmeryObr;

    float polickaNaVysku = 5f;
    float polickaNaSirku = 9f;
    public Vector2 rozmerPolicek;


    void Start()
    {
        rozmeryObr = bgrSquare.transform.lossyScale;

        width = rozmeryObr.x;
        height = rozmeryObr.y;

        rozmerPolicek.x = width / polickaNaSirku;
        rozmerPolicek.y = height / polickaNaVysku;

        //Startx = -width/2 + 3;
        //Starty = height/2 - rozmerPolicek.y;

        Startx = 3f -width/2;
        Starty = -3f + height/2;

        float rescaley = 1f / (polickaNaVysku);
        float rescalex = 1f / (polickaNaSirku);

        for (float i = 0; i < polickaNaVysku; i++)
        {
            for (float j = 0;j < 9; j++)
            {
                GameObject pol = Instantiate(policko, new Vector2(Startx + (j * rozmerPolicek.x), Starty - (i * rozmerPolicek.y)), Quaternion.identity, bgrSquare.transform);
                GameObject child1 = Instantiate(tileFloor, pol.transform.position, Quaternion.identity, pol.transform);
                GameObject child2 = Instantiate(tileFull, pol.transform.position, Quaternion.identity, pol.transform);

                pol.transform.name = policko.name + i + j;
                child1.transform.name = tileFloor.name + i + j;
                child2.transform.name = tileFull.name + i + j;



                pol.transform.localScale = new Vector2(rescalex, rescaley);

            }
        }
    }

}
