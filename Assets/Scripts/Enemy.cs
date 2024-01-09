using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _enemySpeed = 4f;

    private Player _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);


        if (transform.position.y <= -5f)
        {
            float Randomx = Random.Range(-9f, 9f);
            transform.position = new Vector3(Randomx, 9f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {

            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }

            Destroy(this.gameObject);
        }

        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            //Add 10 to score
            if (_player != null)
            {
                _player.AddScore();
            }
            Destroy(this.gameObject);
        }
    }
}
