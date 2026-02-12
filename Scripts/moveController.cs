using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveController : MonoBehaviour
{
    // Start is called before the first frame update
    public enum Loc
    {
        bedroom,
        ceiling,
        livingroom,
        bathroom,
        kitchen,
        attic,
        box1,
        box2,
        box3,
        box4,
        smallroom
    }
    public Loc loc;
    public SpriteRenderer moveBlack;
    Color color = new Color(0f, 0f, 0f, 0f);
    public bool moveLock = false;
    [Header("³¡¾°")]
    public GameObject[] locObjects;
    void Awake()
    {
        loc = Loc.bedroom;
        moveBlack.color = color;
    }
    public gameController gc;
    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < locObjects.Length; i++)
        {
            if (i == (int)loc)
            {
                locObjects[i].SetActive(true);
            }
            else
            {
                locObjects[i].SetActive(false);
            }
        }
        if (!Input.GetKey(KeyCode.Space)&&!Input.GetKey(KeyCode.E)&&!gc.diaLog.activeSelf&&!moveLock)
        {
            switch (loc)
            {
                case Loc.bedroom:
                    if (Input.GetKeyDown(KeyCode.W))
                    {
                        StartCoroutine(GetMove(Loc.livingroom));
                    }
                    else if (Input.GetKeyDown(KeyCode.S))
                    {
                        StartCoroutine(GetMove(Loc.ceiling));
                    }
                    break;
                case Loc.ceiling:
                    if (Input.GetKeyDown(KeyCode.W))
                    {
                        StartCoroutine(GetMove(Loc.bedroom));
                    }
                    break;
                case Loc.livingroom:
                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        StartCoroutine(GetMove(Loc.kitchen));
                    }
                    else if (Input.GetKeyDown(KeyCode.D))
                    {
                        StartCoroutine(GetMove(Loc.bathroom));
                    }
                    else if (Input.GetKeyDown(KeyCode.W))
                    {
                        StartCoroutine(GetMove(Loc.attic));
                    }
                    else if (Input.GetKeyDown(KeyCode.S))
                    {
                        StartCoroutine(GetMove(Loc.bedroom));
                    }
                    break;
                case Loc.kitchen:
                    if (Input.GetKeyDown(KeyCode.D))
                    {
                        StartCoroutine(GetMove(Loc.livingroom));
                    }
                    break;
                case Loc.bathroom:
                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        StartCoroutine(GetMove(Loc.livingroom));
                    }
                    break;
                case Loc.attic:
                    if (Input.GetKeyDown(KeyCode.S))
                    {
                        StartCoroutine(GetMove(Loc.livingroom));
                    }
                    else if (Input.GetKeyDown(KeyCode.A))
                    {
                        StartCoroutine(GetMove(Loc.box2));
                    }
                    else if (Input.GetKeyDown(KeyCode.D))
                    {
                        StartCoroutine(GetMove(Loc.box3));
                    }
                    else if (Input.GetKeyDown(KeyCode.W))
                    {
                        StartCoroutine(GetMove(Loc.smallroom));
                    }
                    break;
                case Loc.box2:
                    if (Input.GetKeyDown(KeyCode.D))
                    {
                        StartCoroutine(GetMove(Loc.attic));
                    }
                    else if (Input.GetKeyDown(KeyCode.A))
                    {
                        StartCoroutine(GetMove(Loc.box1));
                    }
                    break;
                case Loc.box3:
                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        StartCoroutine(GetMove(Loc.attic));
                    }
                    else if (Input.GetKeyDown(KeyCode.D))
                    {
                        StartCoroutine(GetMove(Loc.box4));
                    }
                    break;
                case Loc.box1:
                    if (Input.GetKeyDown(KeyCode.D))
                    {
                        StartCoroutine(GetMove(Loc.box2));
                    }
                    break;
                case Loc.box4:
                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        StartCoroutine(GetMove(Loc.box3));
                    }
                    break;
                case Loc.smallroom:
                    if (Input.GetKeyDown(KeyCode.S))
                    {
                        StartCoroutine(GetMove(Loc.attic));
                    }
                    break;
            }
        }
        
    }
    IEnumerator GetMove(Loc target)
    {
        moveLock = true;
        while (color.a < 1f)
        {
            color.a += 0.05f;
            moveBlack.color = color;
            yield return new WaitForSeconds(0.01f);
        }
        loc = target;
        while (color.a > 0f)
        {
            color.a -= 0.05f;
            moveBlack.color = color;
            yield return new WaitForSeconds(0.01f);
        }
        moveLock = false;
    }
}
