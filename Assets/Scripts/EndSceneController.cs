using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndSceneController : MonoBehaviour
{
    [SerializeField] private GameStateData gameStateData;
    [SerializeField] private TextMeshProUGUI text, count;

    void Start()
    {
        count.text = gameStateData.countTrueAnsw + "/20";
        
        if (gameStateData.countTrueAnsw == 20) text.text = "Great! You answered all the questions correctly and deserve the title " +
                                                           $"of {gameStateData.currentState}! In any case, you can try to take other tests.";
        
        else if (gameStateData.countTrueAnsw > 15) text.text = $"Good! You're already close to being a {gameStateData.currentState}! Keep up the good work and you can try again!";
        else if (gameStateData.countTrueAnsw > 5) text.text = $"Not bad, but you still have a lot to learn for the title of {gameStateData.currentState}. " +
                                                              $"Keep up the good work and you can try again!";
        else text.text = $"You are still a long way from becoming a {gameStateData.currentState}! Practice more and try again.";
    }
    
    public void NextScene()
    {
        SceneManager.LoadScene("0 Start Scene");
    }
}
