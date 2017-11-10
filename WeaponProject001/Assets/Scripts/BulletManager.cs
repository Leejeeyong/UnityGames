using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour {
     static int enemyHP;
     int atk;
     public int Weaponnum;
    

	// Use this for initialization
	void Start () {
        enemyHP = PlayerPrefs.GetInt("ENEMYHP");
        if (Weaponnum==1)
        {
            atk = PlayerPrefs.GetInt("W1ATK");
        }
        else if (Weaponnum == 2)
        {
            atk = PlayerPrefs.GetInt("W2ATK");
        }
        else if (Weaponnum == 3)
        {
            atk = PlayerPrefs.GetInt("W3ATK");
        }
        else if (Weaponnum == 4)
        {
            atk = PlayerPrefs.GetInt("W4ATK");
        }
        Debug.Log("atk" + atk);

    }
	
	// Update is called once per frame
	void Update () {
        this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(6.0f,0f,0f) , 0.3f);

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        //부딪힌 객체의 태그를 비교해서 적인지 판단합니다.
        {
            enemyHP = enemyHP - atk;
            Destroy(this.gameObject);
            PlayerPrefs.SetInt("ENEMYHP", enemyHP);
            //자신을 파괴합니다.
        }
    }

}
