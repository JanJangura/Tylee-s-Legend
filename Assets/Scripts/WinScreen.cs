using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public Monster monster;
    // Start is called before the first frame update
    void Start()
    {
        monster = GetComponent<Monster>();
    }

    // Update is called once per frame
    void Update()
    {
        if(monster.maxHealth <= 0)
        {
            Invoke("loadScene", 2);
        }
    }

    void loadScene()
    {
        SceneManager.LoadScene("Winner");
    }
}
