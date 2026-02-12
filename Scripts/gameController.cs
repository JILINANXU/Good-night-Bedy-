using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    // Start is called before the first frame update
    public int gameType;
    public GameObject[] music;
    public AudioSource[] msas;
    bool bmsas = false;
    public Transform bar;
    public situManager sm;
    public moveController mc;
    public Text rules;
    float barscale = 0f;
    float barspeed = 0.001f;
    private string real_string = "";
    private string fake_string = "";
    public int ruleNum;
    public int crossPos = -1;
    public int BedyPos = -1;
    public GameObject diaLog;
    public int textFileId = 0;
    string[] all_rules = new string[]
    {
        "衣柜里出现衣服","电视播放不正常画面","挂画令人恐惧",
        "镜子不再空无一人","厨房令人窒息","发现十字架",
        "窗外有人影","地上出现异常阴影"
    };
    string[] all_solves = new string[]
    {
        "找到不听话的贝蒂熊","熄灭幽暗之光","在黑暗中祈祷",
        "切断与内部的连接","点燃生命之火","直面扭曲的法则",
        "仰望","阅读真理之书"
    };
    public List<string> active_rules = new List<string>();
    public List<string> active_solves = new List<string>();
    private List<string> fake_rules = new List<string>();
    private List<string> fake_solves = new List<string>();
    public List<string> unhandledEvents = new List<string>();
    public List<string> cdEvents = new List<string>();
    private int cd = 0;
    public Dictionary<string, string> rule_solve = new Dictionary<string, string>();
    public Dictionary<string, string> solve_rule = new Dictionary<string, string>();
    public Dictionary<string, int> unhandleCnt = new Dictionary<string, int>();

    private void Awake()
    {
        bar.localScale = new Vector3(bar.localScale.x,barscale,bar.localScale.z);
        crossPos = -1;
        BedyPos = -1;
        gameType = PlayerPrefs.GetInt("day", 0);
    }
    void Start()
    {

        if (gameType == 0)
        {
            music[0].SetActive(true);
            diaLog.SetActive(true);
            ruleNum = 1;
            barspeed = 0.01f;
            active_rules.Add("镜子不再空无一人");
            active_solves.Add("在黑暗中祈祷");
            for (int i = 0; i < ruleNum; i++)
            {
                real_string += "如果" + active_rules[i] + "，请" + active_solves[i] + "。\n";
                //fake_string += "如果" + fake_rules[i] + "，请" + fake_solves[i] + "。\n";
                rule_solve.Add(active_rules[i], active_solves[i]);
                solve_rule.Add(active_solves[i], active_rules[i]);
                unhandleCnt.Add(active_rules[i], 0);
            }
            rules.text = real_string;
            unhandledEvents.Add(active_rules[0]);
            active_rules.RemoveAt(0);
            StartCoroutine(EventTriggerCoroutine(5f,1000));
        }
        else
        {
            music[1].SetActive(true);
            music[2].SetActive(true);
            double startTime = AudioSettings.dspTime + msas[0].clip.length;
            msas[1].PlayScheduled(startTime);
            barspeed = 0.001f;
            ruleNum = gameType;
            active_rules = GetRandomEvents(all_rules, ruleNum, 0);
            active_solves = GetRandomEvents(all_solves, ruleNum, 1);
            fake_rules = GetRandomEvents(all_rules, ruleNum, 0);
            fake_solves = GetRandomEvents(all_solves, ruleNum, 1);

            for (int i = 0; i < ruleNum; i++)
            {
                real_string += "如果" + active_rules[i] + "，请" + active_solves[i] + "。\n";
                fake_string += "如果" + fake_rules[i] + "，请" + fake_solves[i] + "。\n";
                rule_solve.Add(active_rules[i], active_solves[i]);
                solve_rule.Add(active_solves[i], active_rules[i]);
                unhandleCnt.Add(active_rules[i], 0);
            }
            rules.text = real_string;

            //foreach(var i in all_rules)//记得删
            //{
            //    unhandledEvents.Add(i);
            //}
            //crossPos = UnityEngine.Random.Range(0, 4);//删到这里
            //BedyPos = UnityEngine.Random.Range(0, 11);

            StartCoroutine(ChangeRuleAfterDelay(60f));
            StartCoroutine(EventTriggerCoroutine(5f,10));
            //记得解封上面的
        }
    }

    IEnumerator ChangeRuleAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        rules.text = fake_string;
    }
    IEnumerator EventTriggerCoroutine(float delay, int deadLine)
    {
        while (true)
        {
            foreach(var i in cdEvents)
            {
                unhandleCnt[i] = 0;
            }
            if (cdEvents.Count>0)
            {
                cd++;
                if (cd >= 3)
                {
                    active_rules.Add(cdEvents[0]);
                    cdEvents.RemoveAt(0);
                    cd = 0;
                }
            }
            foreach(var i in unhandledEvents)
            {
                unhandleCnt[i]++;
                if (unhandleCnt[i] > deadLine && sm.eyeclosed)
                {
                    SceneManager.LoadScene("Defeat");
                }
            }
            for(int i=0;i<active_rules.Count;i++)
            {
                int r = UnityEngine.Random.Range(0, 10);
                if (r == 0)
                {
                    unhandledEvents.Add(active_rules[i]);
                    if (active_rules[i] == "发现十字架")
                    {
                        crossPos = UnityEngine.Random.Range(0, 4);
                    }
                    if (rule_solve[active_rules[i]] == "找到不听话的贝蒂熊")
                    {
                        BedyPos = UnityEngine.Random.Range(0, 11);
                    }
                    active_rules.RemoveAt(i);
                    break;
                }
            }
            yield return new WaitForSeconds(delay);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameType == 0)
        {
            switch (textFileId)
            {
                case 0:
                    if (mc.loc == moveController.Loc.kitchen && Input.GetKeyUp(KeyCode.E))
                    {
                        textFileId++;
                        diaLog.SetActive(true);
                    }
                    break;
                case 1:
                    if (mc.loc == moveController.Loc.bathroom)
                    {
                        textFileId++;
                        diaLog.SetActive(true);
                    }
                    break;
                case 2:
                    if (mc.loc == moveController.Loc.bathroom && !unhandledEvents.Contains("镜子不再空无一人"))
                    {
                        textFileId++;
                        diaLog.SetActive(true);
                    }
                    break;
            }
        }
    }
    void FixedUpdate()
    {
        if (sm.eyeclosed)
        {
            if (barscale < 8f)
            {
                barscale += barspeed;
                bar.localScale = new Vector3(bar.localScale.x, barscale, bar.localScale.z);
            }
            else
            {
                SceneManager.LoadScene("Victory");
            }
        }
    }
    List<string> GetRandomEvents(string[] events, int n, int mode)
    {
        List<string> eventList = new List<string>(events);
        List<string> selectedEvents = new List<string>();

        // 确保n不超过事件总数
        n = Mathf.Min(n, events.Length);
        if (mode == 0)
        {
            for (int i = 0; i < n; i++)
            {
                int randomIndex = UnityEngine.Random.Range(0, eventList.Count);
                selectedEvents.Add(eventList[randomIndex]);
                eventList.RemoveAt(randomIndex);
            }
        }
        else
        {
            n--;
            selectedEvents.Add(eventList[0]);
            for (int i = 0; i < n; i++)
            {
                int randomIndex = UnityEngine.Random.Range(1, eventList.Count);
                selectedEvents.Add(eventList[randomIndex]);
                eventList.RemoveAt(randomIndex);
            }
        }
        return selectedEvents;
    }
}
