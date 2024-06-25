using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NoInPutTimer : MonoBehaviour
{
    [SerializeField] GameObject timerScreen;
    [SerializeField] private float maxTime = 30f;
    //public UIManager _UIManager;
    
    private Text timerText;
    private float currentTime = 0f;
    Vector3 lastMousePosition;
    private bool isTimerScreen = false;

    //visuals
    float seconds = 10f;
    float miliseconds = 0f;
    float minutes = 0f;

    private void Start()
    {
        timerScreen.SetActive(false);
        timerText = timerScreen.GetComponent<Text>();
    }

    void Update()
    {

        if (!Input.anyKey && Input.mousePosition == lastMousePosition) //not pressed
        {
            currentTime += Time.unscaledDeltaTime;
            //Debug.Log(currentTime);
            if (currentTime >= maxTime)
            {
                if (!isTimerScreen)
                {
                    // if (_UIManager != null && _UIManager.isMenu)
                    // {
                    //     timerScreen.SetActive(false);
                    // }
                    // else
                    // {
                    //     timerScreen.SetActive(true);
                    // }
                    // isTimerScreen = true;
                }
                CountTime();
            }
        }
        else //pressed
        {
            ResetTimer();
        }
        
    }


    private void CountTime()
    {
        if (miliseconds <= 0)
        {
            if (seconds <= 0)
            {
                minutes--;

                seconds = 59;
            }
            else if (seconds >= 0)
            {
                seconds--;
            }
            if (minutes >= 0)
            {
                miliseconds = 100;
            }
            else // reach zero
            {
                seconds = 0;
                miliseconds = 0;
                minutes = 0;
                timerText.text = string.Format("no key pressed. Time to reset game : {0}:{1}:{2}", minutes, seconds, (int)miliseconds);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                TimerReachedZero();
                return;
            }
        }
        if (minutes == 0 && seconds == 10)
        {
            ScaleEffect();
        }
        miliseconds -= Time.unscaledDeltaTime * 100;
        timerText.text = string.Format("no key pressed. Time to reset game : {0}:{1}:{2}", minutes, seconds, (int)miliseconds);
    }

    private void ScaleEffect()
    {
        Sequence scale = DOTween.Sequence();
        scale.Append(timerText.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.5f));
        scale.Append(timerText.transform.DOScale(Vector3.one, 0.5f));
        scale.SetLoops(5);
    }

    public void TimerReachedZero()
    {
        if (SceneManager.GetActiveScene().name == "Start")
        {
        //     if (_UIManager.isMenu)
        //     {
        //         if (GameVariables.instance.coins > 0 || GameVariables.instance.RunsCompleted > 0)
        //         {
        //             GameVariables.instance.ResetVariables();
        //             SceneManager.LoadScene("Start");
        //         }
        //         else
        //         {
        //             ResetTimer();
        //         }
        //     }
        //     else
        //     {
        //         GameVariables.instance.ResetVariables();
        //         SceneManager.LoadScene("Start");
        //     }
        //     Debug.Log("Start");
        // }
        // else
        // {
        //     GameVariables.instance.ResetVariables();
        //     SceneManager.LoadScene("Start");
        //
        }
        
    }

    public void ResetTimer()
    {
        if (isTimerScreen)
        {
            timerScreen.SetActive(false);
            isTimerScreen = false;
        }
        seconds = 10f;
        miliseconds = 0f;
        lastMousePosition = Input.mousePosition;
        currentTime = 0f;
    }
}




