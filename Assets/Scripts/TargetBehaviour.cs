using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{
    [SerializeField] string[] _tags;
    [SerializeField] Sprite[] _sprites;

    Vector3 _playerPos;
    private void Start()
    {
        int randIndex = Random.Range(0, _tags.Length);
        tag = _tags[randIndex];
        GetComponent<SpriteRenderer>().sprite = _sprites[randIndex];

        var players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].transform.position.x > 0 && transform.position.x > 0 ||
                players[i].transform.position.x <= 0 && transform.position.x <= 0)
            {
                _playerPos = players[i].transform.position;
                break;
            }
        }
    }
    private void Update()
    {
        if (GameManager.Single.GameActive)
        {
            transform.position = Vector2.MoveTowards(transform.position, _playerPos, Time.deltaTime * GameManager.Single.Speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tag))
        {
            GameManager.Single.Score++;
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Player"))
        {
            GameManager.Single.LostLive();
        }
    }
}
