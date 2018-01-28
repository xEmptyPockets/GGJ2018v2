using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaySpace_Controller : MonoBehaviour {
    public int round_num = -1;

    public int asteroids_per_round_coefficient = 25;
    public float asteroid_min_size_coefficient = 0.5f;
    public float asteroid_max_size_coefficient = 2.0f;
    public float asteroid_max_speed_coefficient = 10.0f;

    public GameObject asteroid;
    public GameObject destination;

    public Text roundText;

	// Use this for initialization
	void Awake () {
        roundText = GameObject.Find("roundText").GetComponent<Text>();
        Next_Round();
    }
	
	// Update is called once per frame
	void Update () {
    }

    public void Next_Round(){
        //Increments the round number, then calls the destination generator, then calls the asteroid generator
        round_num++;
        roundText.text = round_num.ToString();
        Generate_Destination();
        Generate_Asteroids();
    }

    void Generate_Destination(){
        //This assumes that your destination (planet) scale's X and Y are the same
        //If they're not, change them

        int x_pos = 0;
        int y_pos = 0;
        float destination_scale;

        for (int i = 0; i < 1; i++){
            destination_scale = destination.transform.localScale.x;

            x_pos = (int)(Random.Range(-1.0f, 1.0f) * (1920 - (destination_scale*destination.GetComponent<CircleCollider2D>().radius*2))/2);
            y_pos = (int)(Random.Range(-1.0f, 1.0f) * (1080 - (destination_scale*destination.GetComponent<CircleCollider2D>().radius*2))/2);

            if (Physics2D.OverlapCircle(new Vector2(x_pos, y_pos), destination_scale/2) == null){
                Instantiate(destination, new Vector3(x_pos, y_pos, 0), Quaternion.identity);
            }
            else{
                i--;
                continue;
            }
        }
    }

    void Generate_Asteroids (){
        //This assumes an asteroid scale, both X and Y, of 1
        //Seriously, if your asteroid prefab's scale is not 1, change it

        int x_pos = 0;
        int y_pos = 0;
        float asteroid_scale;
        float asteroid_speed_x;
        float asteroid_speed_y;

        GameObject new_asteroid;

        for(int i = 0; i < asteroids_per_round_coefficient * round_num; i++){
            asteroid_scale = Random.Range(asteroid_min_size_coefficient * round_num, asteroid_max_size_coefficient * round_num);
            asteroid_speed_x = Random.Range(-(asteroid_max_speed_coefficient*round_num), asteroid_max_speed_coefficient*round_num);
            asteroid_speed_y = Random.Range(-(asteroid_max_speed_coefficient*round_num), asteroid_max_speed_coefficient*round_num);

            x_pos = (int)(Random.Range(-1.0f, 1.0f) * (1920 - (asteroid_scale*asteroid.transform.localScale.x*asteroid.GetComponent<CircleCollider2D>().radius*2))/2);
            y_pos = (int)(Random.Range(-1.0f, 1.0f) * (1080 - (asteroid_scale*asteroid.transform.localScale.y*asteroid.GetComponent<CircleCollider2D>().radius*2))/2);

            if (Physics2D.OverlapCircle(new Vector2(x_pos, y_pos), (asteroid_scale*asteroid.transform.localScale.x)/2) == null){
                new_asteroid = Instantiate(asteroid, new Vector3(x_pos, y_pos, 0), Quaternion.identity);
                new_asteroid.transform.localScale = new Vector3(asteroid.transform.localScale.x * asteroid_scale, asteroid.transform.localScale.y * asteroid_scale, asteroid.transform.localScale.z);
                new_asteroid.GetComponent<Rigidbody2D>().velocity = new Vector2(asteroid_speed_x, asteroid_speed_y);
            }
            else{
                i--;
                continue;
            }
        }
    }
}
