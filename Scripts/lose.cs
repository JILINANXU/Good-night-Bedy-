using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lose : MonoBehaviour
{
    public GameObject roof;
    public Transform headTrans;
    public Vector2 startPosition = new Vector2(0f, -9.41f);
    public Vector2 endPosition = new Vector2(0f, 0.33f);
    public float moveSpeed = 0.1f;
    private float timeElapsed = 0f;
    public SpriteRenderer blood;
    Color color = new Color(1f,0f,0f,0f);
    bool e = false;
    private float timer = 0f;
    // Start is called before the first frame update
    private void Awake()
    {
        blood.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += moveSpeed;
        headTrans.position = Vector2.Lerp(startPosition, endPosition, timeElapsed);
        if (timeElapsed >= 1f)
        {
            timeElapsed = 1f;
            timer += Time.deltaTime;
            if (timer > 0.1f)
            {
                if (color.a < 1f&&!e)
                {
                    color.a += 0.005f;
                    blood.color = color;
                }
                else
                {
                    e = true;
                    roof.SetActive(false);
                    color.a -= 0.0025f;
                    blood.color = color;
                    StartCoroutine(ReDay(5f));
                }
            }
            
        }
    }
    IEnumerator ReDay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("gap");
    }
}
