using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndSceneController : MonoBehaviour
{
    [SerializeField] private GameStateData gameStateData;
    [SerializeField] private TextMeshProUGUI text, count;

    void Start()
    {
        count.text = gameStateData.countTrueAnsw + "/10";
    
        if (gameStateData.countTrueAnsw == 10) text.text = "Отлично! Вы ответили на все вопросы правильно и заслуживаете звание " +
                                                           $"{gameStateData.currentState}! В любом случае, вы можете попробовать пройти другие тесты.";
    
        else if (gameStateData.countTrueAnsw > 7) text.text = $"Хорошо! Вы уже близки к званию {gameStateData.currentState}! Продолжайте в том же духе и можете попробовать снова!";
        else if (gameStateData.countTrueAnsw > 4) text.text = $"Неплохо, но вам еще нужно многому научиться для получения звания {gameStateData.currentState}. " +
                                                              $"Продолжайте в том же духе и попробуйте снова!";
        else text.text = $"Вы еще далеки от звания {gameStateData.currentState}! Практикуйтесь больше и попробуйте снова.";
    }

    public void NextScene()
    {
        SceneManager.LoadScene("0 Start Scene");
    }
}
