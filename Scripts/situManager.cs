using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class situManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] bedroom;
    public GameObject[] ceiling;
    public GameObject[] livingroom;
    public GameObject[] kitchen;
    public GameObject[] bathroom;
    public GameObject[] attic;
    public GameObject[] smallroom;
    public GameObject[] boxes;
    public GameObject[] Bedy;
    public GameObject paintHead;
    public GameObject windowHead;
    public GameObject cross;
    public GameObject bo;
    
    public GameObject tip;
    public moveController mc;
    public gameController gc;
    public bool eyeclosed = false;
    SpriteRenderer eye;
    Color color;
    void Awake()
    {
        eye = ceiling[0].GetComponent<SpriteRenderer>();
        color.a = 0f;
        eye.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Bedy.Length; i++)
        {
            Bedy[i].SetActive(false);
        }
        if (mc.loc == moveController.Loc.livingroom && gc.unhandledEvents.Contains("挂画令人恐惧"))
        {
            paintHead.SetActive(true);
        }
        else
        {
            paintHead.SetActive(false);
        }
        if (mc.loc == moveController.Loc.bedroom && gc.unhandledEvents.Contains("窗外有人影"))
        {
            windowHead.SetActive(true);
        }
        else
        {
            windowHead.SetActive(false);
        }
        if (gc.unhandledEvents.Contains("发现十字架"))
        {
            if(mc.loc == moveController.Loc.box1 && gc.crossPos == 0 || mc.loc == moveController.Loc.box2 && gc.crossPos == 1 || mc.loc == moveController.Loc.box3 && gc.crossPos == 2 || mc.loc == moveController.Loc.box4 && gc.crossPos == 3)
            {
                cross.SetActive(true);
            }
            else
            {
                cross.SetActive(false);
            }
        }
        else
        {
            gc.crossPos = -1;
        }
        if (gc.BedyPos!=-1)
        {
            if ((int)mc.loc == gc.BedyPos)
            {
                Bedy[gc.BedyPos].SetActive(true);
            }
            else
            {
                Bedy[gc.BedyPos].SetActive(false);
            }
        }
        if (Input.GetKey(KeyCode.Space)&&!Input.GetKey(KeyCode.E)&&!gc.diaLog.activeSelf)
        {
            //if(mc.loc != moveController.Loc.ceiling && mc.loc != moveController.Loc.attic && mc.loc != moveController.Loc.box1 && mc.loc != moveController.Loc.box2 && mc.loc != moveController.Loc.box3 && mc.loc != moveController.Loc.box4)
            //{
            //    bo.SetActive(true);
            //}
            switch (mc.loc)
            {
                case moveController.Loc.bedroom:
                    for (int i = 0; i < bedroom.Length; i++)
                    {
                        bedroom[i].SetActive(false);
                    }
                    bedroom[0].SetActive(true);
                    break;
                case moveController.Loc.bathroom:
                    for (int i = 0; i < bathroom.Length; i++)
                    {
                        bathroom[i].SetActive(false);
                    }
                    bathroom[0].SetActive(true);
                    break;
                case moveController.Loc.kitchen:
                    for (int i = 0; i < kitchen.Length; i++)
                    {
                        kitchen[i].SetActive(false);
                    }
                    kitchen[0].SetActive(true);
                    break;
                case moveController.Loc.livingroom:
                    for (int i = 0; i < livingroom.Length; i++)
                    {
                        livingroom[i].SetActive(false);
                    }
                    livingroom[0].SetActive(true);
                    break;
                case moveController.Loc.smallroom:
                    for (int i = 0; i < smallroom.Length; i++)
                    {
                        smallroom[i].SetActive(false);
                    }
                    smallroom[0].SetActive(true);
                    break;
                case moveController.Loc.ceiling:
                    if (color.a < 1f)
                    {
                        eyeclosed = false;
                        color.a += 0.0025f;
                        eye.color = color;
                    }
                    else
                    {
                        eyeclosed = true;
                    }
                    break;
            }
        }
        else if (Input.GetKey(KeyCode.E)&& !Input.GetKey(KeyCode.Space) && mc.loc==moveController.Loc.kitchen && !gc.diaLog.activeSelf)
        {
            tip.SetActive(true);
            //bo.SetActive(true);
        }
        else
        {
            //bo.SetActive(false);
            tip.SetActive(false);
            switch (mc.loc)
            {
                case moveController.Loc.bedroom:
                    for (int i = 0; i < bedroom.Length; i++)
                    {
                        bedroom[i].SetActive(false);
                    }
                    if (gc.unhandledEvents.Contains("衣柜里出现衣服"))
                    {
                        bedroom[2].SetActive(true);
                    }
                    else
                    {
                        bedroom[1].SetActive(true);
                    }
                    break;
                case moveController.Loc.bathroom:
                    for (int i = 0; i < bathroom.Length; i++)
                    {
                        bathroom[i].SetActive(false);
                    }
                    if (gc.unhandledEvents.Contains("镜子不再空无一人"))
                    {
                        bathroom[2].SetActive(true);
                    }
                    else
                    {
                        bathroom[1].SetActive(true);
                    }
                    break;
                case moveController.Loc.kitchen:
                    for (int i = 0; i < kitchen.Length; i++)
                    {
                        kitchen[i].SetActive(false);
                    }
                    if (gc.unhandledEvents.Contains("厨房令人窒息"))
                    {
                        kitchen[2].SetActive(true);
                    }
                    else
                    {
                        kitchen[1].SetActive(true);
                    }
                    break;
                case moveController.Loc.livingroom:
                    for (int i = 0; i < livingroom.Length; i++)
                    {
                        livingroom[i].SetActive(false);
                    }
                    if (gc.unhandledEvents.Contains("电视播放不正常画面"))
                    {
                        livingroom[2].SetActive(true);
                    }
                    else
                    {
                        livingroom[1].SetActive(true);
                    }
                    break;
                case moveController.Loc.smallroom:
                    for (int i = 0; i < smallroom.Length; i++)
                    {
                        smallroom[i].SetActive(false);
                    }
                    smallroom[1].SetActive(true);
                    break;
                case moveController.Loc.attic:
                    for (int i = 0; i < attic.Length; i++)
                    {
                        attic[i].SetActive(false);
                    }
                    if (gc.unhandledEvents.Contains("地上出现异常阴影"))
                    {
                        attic[0].SetActive(true);
                    }
                    else
                    {
                        attic[1].SetActive(true);
                    }
                    break;
                case moveController.Loc.box1:
                    for (int i = 0; i < boxes.Length; i++)
                    {
                        boxes[i].SetActive(false);
                    }
                    boxes[0].SetActive(true);
                    break;
                case moveController.Loc.box2:
                    for (int i = 0; i < boxes.Length; i++)
                    {
                        boxes[i].SetActive(false);
                    }
                    boxes[1].SetActive(true);
                    break;
                case moveController.Loc.box3:
                    for (int i = 0; i < boxes.Length; i++)
                    {
                        boxes[i].SetActive(false);
                    }
                    boxes[2].SetActive(true);
                    break;
                case moveController.Loc.box4:
                    for (int i = 0; i < boxes.Length; i++)
                    {
                        boxes[i].SetActive(false);
                    }
                    boxes[3].SetActive(true);
                    break;
                case moveController.Loc.ceiling:
                    eyeclosed = false;
                    color.a = 0f;
                    eye.color = color;
                    break;
            }
        }
    }
}
