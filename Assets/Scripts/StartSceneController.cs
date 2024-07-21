using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StartSceneController : MonoBehaviour
{
    [SerializeField] private GameStateData gameStateData;
    [SerializeField] private TextMeshProUGUI buttonText;
    
    void Start()
    {
        SetGameState(GameStateData.GameState.Noob);
        gameStateData.countTrueAnsw = 0;
    }

    void SetGameState(GameStateData.GameState newState)
    {
        gameStateData.currentState = newState;
        buttonText.text = "Start test as " + newState;
        Debug.Log(newState);
    }

    public void NextScene()
    {
        SceneManager.LoadScene("1 Game Scene");
    }
    
    public void SetGameStateFromInt(int newStateIndex)
    {
        GameStateData.GameState newState = (GameStateData.GameState)newStateIndex;
        SetGameState(newState);
    }
}
