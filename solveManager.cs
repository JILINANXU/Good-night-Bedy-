using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class solveManager : MonoBehaviour
{
    public gameController gc;
    public situManager sm;
    public moveController mc;
    private bool solveing = false;
    private float timer = 0f;
    public float solveTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!solveing)
        {
            timer = 0f;
        }
        solveing = false;
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit.collider != null)
            {
                if (gc.solve_rule.ContainsKey("找到不听话的贝蒂熊"))
                {
                    if (gc.unhandledEvents.Contains(gc.solve_rule["找到不听话的贝蒂熊"]))
                    {
                        gc.cdEvents.Add(gc.solve_rule["找到不听话的贝蒂熊"]);
                        gc.unhandledEvents.Remove(gc.solve_rule["找到不听话的贝蒂熊"]);
                        gc.BedyPos = -1;
                    }
                }
            }
        }
        if (gc.solve_rule.ContainsKey("仰望")&&gc.unhandledEvents.Contains(gc.solve_rule["仰望"]))
        {
            if (mc.loc == moveController.Loc.ceiling && !sm.eyeclosed)
            {
                solveing = true;
                timer += Time.deltaTime;
                if (timer >= solveTime)
                {
                    gc.cdEvents.Add(gc.solve_rule["仰望"]);
                    gc.unhandledEvents.Remove(gc.solve_rule["仰望"]);
                    solveing = false;
                }
            }
            
        }
        if (gc.solve_rule.ContainsKey("熄灭幽暗之光") && gc.unhandledEvents.Contains(gc.solve_rule["熄灭幽暗之光"]))
        {
            if (mc.loc == moveController.Loc.livingroom && Input.GetKey(KeyCode.Space))
            {
                solveing = true;
                timer += Time.deltaTime;
                if (timer >= solveTime)
                {
                    gc.cdEvents.Add(gc.solve_rule["熄灭幽暗之光"]);
                    gc.unhandledEvents.Remove(gc.solve_rule["熄灭幽暗之光"]);
                    solveing = false;
                }
            }
        }
        if (gc.solve_rule.ContainsKey("在黑暗中祈祷") && gc.unhandledEvents.Contains(gc.solve_rule["在黑暗中祈祷"]))
        {
            if (mc.loc == moveController.Loc.bathroom && Input.GetKey(KeyCode.Space))
            {
                solveing = true;
                timer += Time.deltaTime;
                if (timer >= solveTime)
                {
                    gc.cdEvents.Add(gc.solve_rule["在黑暗中祈祷"]);
                    gc.unhandledEvents.Remove(gc.solve_rule["在黑暗中祈祷"]);
                    solveing = false;
                }
            }
        }
        if (gc.solve_rule.ContainsKey("切断与内部的连接") && gc.unhandledEvents.Contains(gc.solve_rule["切断与内部的连接"]))
        {
            if (mc.loc == moveController.Loc.bedroom && Input.GetKey(KeyCode.Space))
            {
                solveing = true;
                timer += Time.deltaTime;
                if (timer >= solveTime)
                {
                    gc.cdEvents.Add(gc.solve_rule["切断与内部的连接"]);
                    gc.unhandledEvents.Remove(gc.solve_rule["切断与内部的连接"]);
                    solveing = false;
                }
            }
        }
        if (gc.solve_rule.ContainsKey("点燃生命之火") && gc.unhandledEvents.Contains(gc.solve_rule["点燃生命之火"]))
        {
            if (mc.loc == moveController.Loc.kitchen && Input.GetKey(KeyCode.Space))
            {
                solveing = true;
                timer += Time.deltaTime;
                if (timer >= solveTime)
                {
                    gc.cdEvents.Add(gc.solve_rule["点燃生命之火"]);
                    gc.unhandledEvents.Remove(gc.solve_rule["点燃生命之火"]);
                    solveing = false;
                }
            }
        }
        if (gc.solve_rule.ContainsKey("直面扭曲的法则") && gc.unhandledEvents.Contains(gc.solve_rule["直面扭曲的法则"]))
        {
            if (mc.loc == moveController.Loc.kitchen && Input.GetKey(KeyCode.E))
            {
                solveing = true;
                timer += Time.deltaTime;
                if (timer >= solveTime)
                {
                    gc.cdEvents.Add(gc.solve_rule["直面扭曲的法则"]);
                    gc.unhandledEvents.Remove(gc.solve_rule["直面扭曲的法则"]);
                    solveing = false;
                }
            }
        }
        if (gc.solve_rule.ContainsKey("阅读真理之书") && gc.unhandledEvents.Contains(gc.solve_rule["阅读真理之书"]))
        {
            if (mc.loc == moveController.Loc.smallroom && Input.GetKey(KeyCode.Space))
            {
                solveing = true;
                timer += Time.deltaTime;
                if (timer >= solveTime)
                {
                    gc.cdEvents.Add(gc.solve_rule["阅读真理之书"]);
                    gc.unhandledEvents.Remove(gc.solve_rule["阅读真理之书"]);
                    solveing = false;
                }
            }
        }
    }
}
