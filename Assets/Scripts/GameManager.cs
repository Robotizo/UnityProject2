using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText; 
    [SerializeField] private InputManager inputManager; 
    [SerializeField] private GameObject pinGroupPrefab; 
    [SerializeField] private Transform pinAnchor; 
    [SerializeField] private BallController ball; 

    private GameObject pinObjects;
    private FallTrigger[] pins;

    private void Start()
    {
        inputManager.OnResetPressed.AddListener(HandleReset); 
        SetPins();
    }

    private void SetPins()
    {
   
        if (pinObjects != null) Destroy(pinObjects);


        pinObjects = Instantiate(pinGroupPrefab, pinAnchor.position, Quaternion.identity);

  
        pins = pinObjects.GetComponentsInChildren<FallTrigger>();


        foreach (FallTrigger pin in pins)
        {
            pin.OnPinFall.AddListener(IncrementScore);
            Debug.Log("Listening for fall event on: " + pin.gameObject.name);
        }


        ResetScore();
    }

    private void HandleReset()
    {
        ball.ResetBall(); 
        SetPins();        
    }

    private void IncrementScore()
    {
        score++;
        UpdateScoreText();
    }

    private void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = $"Score: {score}";
    }
}
