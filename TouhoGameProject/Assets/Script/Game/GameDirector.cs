using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    [SerializeField]
    private float ereaDamage = 1.0f;

    private string changeScene;

    // Start is called before the first frame update
    void Start()
    {
        changeScene = "Shop";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(changeScene);
    }

    public void GameOver()
    {
        Debug.Log("game over");
    }

    public float Damage
    {
        get { return ereaDamage; }
    }
}
