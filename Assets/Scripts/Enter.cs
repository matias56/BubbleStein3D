using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enter : MonoBehaviour
{
    public Image cred;
    public float timer = 5;

    // Start is called before the first frame update
    void Start()
    {
        cred.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(cred.enabled == true)
        {
            timer -= Time.deltaTime;

            if(timer <= 0)
            {
                cred.enabled = false;
                timer = 5;
            }
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Credits()
    {
        cred.enabled = true;
    }
}
