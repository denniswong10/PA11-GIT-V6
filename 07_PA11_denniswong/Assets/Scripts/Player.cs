using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player thisScript;

    public float speed;

    public Text Score;
    private int score = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        thisScript = this;
        Score.text = "Score : " + score;
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        transform.position = transform.position + new Vector3(0 , verticalInput * speed * Time.deltaTime, 0);

        float yPos = Mathf.Clamp(transform.position.y, -3.84f, 3.84f);
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
    }

    public void UpdateScore()
    {
        score++;
        Score.text = "Score : " + score;
    }
}
