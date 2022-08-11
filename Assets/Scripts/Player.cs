using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Player : MonoBehaviour
{

    private Vector2 targetPos;
    public float yincrement;
    public float speed;
    public float maxHeight;
    public float minHeight;
    public int health = 3;
    public GameObject effect;
    public Text healthDisplay;
    public GameObject gameover;
    public GameObject moveSound;
    public GameObject scoreCounter;
    public GameObject spawner;
    public GameObject bgMusic;
    public GameObject lossMusic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthDisplay.text = health.ToString();

        if (health <= 0)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            gameover.SetActive(true);
            scoreCounter.SetActive(false);
            spawner.SetActive(false);
            bgMusic.SetActive(false);
            lossMusic.SetActive(true); 
            Destroy(gameObject);
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed*Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
        {
            Instantiate(moveSound);
            Instantiate(effect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y + yincrement);

        }

        else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight)
        {
            Instantiate(moveSound);
            Instantiate(effect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y - yincrement);

        }
    }
}
