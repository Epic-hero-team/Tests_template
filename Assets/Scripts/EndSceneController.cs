using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndSceneController : MonoBehaviour
{
    [SerializeField] private GameStateData gameStateData;
    [SerializeField] private TextMeshProUGUI text, count;

    void Start()
    {
        Debug.Log(gameStateData.countTrueAnsw);
        Debug.Log(gameStateData.countAnsw);
        var procent = 100 * gameStateData.countTrueAnsw / gameStateData.countAnsw;
        Debug.Log(procent);
        count.text = gameStateData.countTrueAnsw + $"/{gameStateData.countAnsw}";
    
        if (procent == 100) text.text = "Отлично! Вы ответили на все вопросы правильно и заслуживаете звание " +
                                                                $"{gameStateData.currentState}! В любом случае, вы можете попробовать пройти другие тесты.";
    
        else if (procent >= 75) text.text = $"Хорошо! Вы уже близки к званию {gameStateData.currentState}! Продолжайте в том же духе и можете попробовать снова!";
        else if (procent >= 45) text.text = $"Неплохо, но вам еще нужно многому научиться для получения звания {gameStateData.currentState}. " +
                                            $"Продолжайте в том же духе и попробуйте снова!";
        else text.text = $"Вы еще далеки от звания {gameStateData.currentState}! Практикуйтесь больше и попробуйте снова.";
    }

    public void NextScene()
    {
        SceneManager.LoadScene("0 Start Scene");
    }
}
