using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStat : MonoBehaviour
{
    public int health = 3;
    public int lives = 3;
    public TextMeshProUGUI scoreUI;
    private float flickerTime = 0f;
    public float flickerDuration = 0.1f;
    public static int score = 0;
    private SpriteRenderer sr;

    public bool isImmune = false;
    private float immunityTime = 0f;
    public float immunityDuration = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isImmune == true){
            SpriteFlicker();
            immunityTime = immunityTime + Time.deltaTime;
            if(immunityTime >= immunityDuration){
                isImmune = false;
                sr.enabled = true;
            }
        }

        scoreUI.text = " " + score;
    }

 

    public void TakeDamage(int damage){
        if(isImmune == false){
            health = health - damage;
            if(health < 0)
                health = 0;
            if(lives > 0 && health == 0){
                FindObjectOfType<LevelManager>().RespawnPlayer();
                health = 3;
                lives--;
            }else if(lives == 0 && health ==0){
                Debug.Log("Gameover");
                Destroy(this.gameObject);
            }
        }

        isImmune = true;
        immunityTime = 0f;
    } 
       void SpriteFlicker(){
        if(flickerTime < flickerDuration){
            flickerTime = flickerTime + Time.deltaTime;
        } else if(flickerTime >= flickerDuration){
            sr.enabled = !(sr.enabled);
            flickerTime = 0;
        }
    }
}
