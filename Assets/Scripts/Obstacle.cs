using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed;
    public int damage = 1;
    public GameObject effect;
    public GameObject explosionSound;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(explosionSound);
            //Player takes damage
            other.GetComponent<Player>().health -= damage;
            Debug.Log(other.GetComponent<Player>().health);
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
