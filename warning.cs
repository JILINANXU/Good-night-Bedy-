using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class warning : MonoBehaviour
{
    public SpriteRenderer black;
    Color color = new Color(0f, 0f, 0f, 1f);
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Warn());
    }

    // Update is called once per frame
    void Update()
    {
        if (color.a > 0f)
        {
            color.a -= 0.005f;
            black.color = color;
        }
    }
    IEnumerator Warn()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("mainMenu");
    }
}
