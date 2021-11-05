using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Events : MonoBehaviour
{
    public int NumHits;
    public GameObject SpawnedPlayerWeapon;
    public GameObject BossWeapon;
    public Vector2 XBounds;
    public float YSpawn;
    public float TimeEnd;
    public float Timer;
    public float PlayerWeaponTimer;
    public GameObject[] SetUnactive;
    // Update is called once per frame
    void Update()
    {
        this.Timer -= Time.deltaTime;
        this.PlayerWeaponTimer -= Time.deltaTime;
        if(this.Timer <= 0)
        {
            if(this.NumHits == 0)
            {
                for(int i = 0; i<3; i++){
                    var BossWeapon = Instantiate(
                    this.BossWeapon,
                    new Vector3(Random.Range(this.XBounds.x, this.XBounds.y), 
                    this.YSpawn, this.gameObject.transform.position.z), 
                    Quaternion.identity);
                }
            }
            else if(this.NumHits == 1)
            {
                for(int i = 0; i<5; i++){
                    var BossWeapon = Instantiate(
                    this.BossWeapon,
                    new Vector3(Random.Range(this.XBounds.x, this.XBounds.y), 
                    this.YSpawn, this.gameObject.transform.position.z), 
                    Quaternion.identity);
                }
            }
            else if(this.NumHits == 2)
            {
                for(int i = 0; i<7; i++){
                    var BossWeapon = Instantiate(
                    this.BossWeapon,
                    new Vector3(Random.Range(this.XBounds.x, this.XBounds.y), 
                    this.YSpawn, this.gameObject.transform.position.z), 
                    Quaternion.identity);
                }
            }
            else if(this.NumHits >= 3)
            {
                for(int i = 0; i < this.SetUnactive.Length; i++)
                {
                    this.SetUnactive[i].SetActive(false);
                }
                Destroy(this.gameObject);
            }
            this.Timer = this.TimeEnd;
        }

        if(this.PlayerWeaponTimer <= -this.TimeEnd)
        {
            var UserWeapon = Instantiate(
                this.SpawnedPlayerWeapon, 
                new Vector3(Random.Range(this.XBounds.x, this.XBounds.y), 
                8, this.gameObject.transform.position.z), 
                Quaternion.identity);
            this.PlayerWeaponTimer = this.TimeEnd;
        }
        
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Weapon"))
        {
            this.NumHits++;
            this.Timer = 2.0f;
            this.PlayerWeaponTimer = 2.0f;
        }
    }
}
