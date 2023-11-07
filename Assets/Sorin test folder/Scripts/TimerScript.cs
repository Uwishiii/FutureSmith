using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TimerScript : MonoBehaviour
{
    [SerializeField]
    private float timeRemaining = 300; 
    [SerializeField]
    private TextMeshProUGUI timerText;
    [SerializeField]
    private GameObject playerSpawnPoint;
    [SerializeField]
    private GameObject player;

    [SerializeField] GameObject roboHandLeft;
    [SerializeField] GameObject roboHandRight;
    [SerializeField] GameObject humHandLeft;
    [SerializeField] GameObject humHandRight;
    [SerializeField] GameObject roboHandMenu;

    private bool timerExpired = false;

    private void FixedUpdate()
    {
        if (timeRemaining > 0 && !timerExpired)
        {
            timeRemaining -= Time.fixedDeltaTime; 
            UpdateTimerDisplay();
        }
        else if (!timerExpired)
        {
            timerExpired = true;
            timeRemaining = 0; 
            TeleportPlayerToSpawn();
        }
    }

    private void UpdateTimerDisplay()
    {
       
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }

    private void TeleportPlayerToSpawn()
    {
        player.transform.position = playerSpawnPoint.transform.position;
        timeRemaining = 300f;

        roboHandLeft.SetActive(false);
        roboHandRight.SetActive(false);
        roboHandMenu.SetActive(false);

        humHandLeft.SetActive(true);
        humHandRight.SetActive(true);

        gameObject.SetActive(false);
    }
}
