using TMPro;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI askText, countTxt, gameState;
    [SerializeField] private TextMeshProUGUI[] buttonsTexts;
    [SerializeField] private Difficulty[] asksList;
    [SerializeField] private GameStateData gameStateData;
    
    private int gameStateInt, countInt, countTrueAnsw;

    void Start()
    {
        gameStateInt = (int)gameStateData.currentState;
        gameState.text = "Difficulty level: " + gameStateData.currentState;
        ChangeButtonsText();
    }

    void Update()
    {
        askText.text = asksList[gameStateInt].asksAndAnswers[countInt].ask;
        countTxt.text = countInt + 1 + "/20";
    }

    public void AnswerButton(int buttonId)
    {
        if (buttonId == asksList[gameStateInt].asksAndAnswers[countInt].trueAnswer)
        {
            gameStateData.countTrueAnsw += 1;
            countTrueAnsw += 1;
        }
        countInt += 1;

        if (countInt == 2)
            SceneManager.LoadScene("2 End Scene");
        
        ChangeButtonsText();
    }

    void ChangeButtonsText()
    {
        for (int i = 0; i < buttonsTexts.Length; i++)
        {
            buttonsTexts[i].text = asksList[gameStateInt].asksAndAnswers[countInt].answers[i];
        }
    }
}

[Serializable] public class Difficulty
{
    public GameStateData.GameState gameState;
    public AsksAndAnswers[] asksAndAnswers = new AsksAndAnswers[20];
}

[Serializable]
public class AsksAndAnswers
{
    public String ask;
    public String[] answers = new string[4];
    public int trueAnswer;
}