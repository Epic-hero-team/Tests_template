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
        // Загрузка данных вопросов для всех уровней сложности
        asksList = new Difficulty[]
        {
            new Difficulty
            {
                gameState = GameStateData.GameState.Нуб,
                asksAndAnswers = new AsksAndAnswers[]
                {
                    new AsksAndAnswers
                    {
                        ask = "Что нужно для создания верстака?",
                        answers = new string[] { "4 доски", "1 доска", "4 палки", "1 камень" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой моб не агрессивен к игроку?",
                        answers = new string[] { "Скелет", "Крипер", "Зомби", "Корова" },
                        trueAnswer = 3
                    },
                    new AsksAndAnswers
                    {
                        ask = "Что используется для создания кирпича?",
                        answers = new string[] { "Глина", "Земля", "Песок", "Гравий" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой предмет нужен для сбора пшеницы?",
                        answers = new string[] { "Лопата", "Кирка", "Мотыга", "Меч" },
                        trueAnswer = 2
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какого цвета овца дает белую шерсть?",
                        answers = new string[] { "Белая", "Черная", "Синяя", "Красная" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Как называется верхний слой мира?",
                        answers = new string[] { "Нижний мир", "Рай", "Поверхность", "Край" },
                        trueAnswer = 2
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой предмет нужен для добычи обсидиана?",
                        answers = new string[] { "Железная кирка", "Каменная кирка", "Золотая кирка", "Алмазная кирка" },
                        trueAnswer = 3
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой ресурс не используется для создания факела?",
                        answers = new string[] { "Уголь", "Дерево", "Палка", "Железо" },
                        trueAnswer = 3
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой инструмент нужен для добычи алмазов?",
                        answers = new string[] { "Каменная кирка", "Деревянная кирка", "Железная кирка", "Золотая кирка" },
                        trueAnswer = 2
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какое животное можно приручить?",
                        answers = new string[] { "Свинья", "Курица", "Корова", "Волк" },
                        trueAnswer = 3
                    }
                }
            },
            new Difficulty
            {
                gameState = GameStateData.GameState.Продвинутый,
                asksAndAnswers = new AsksAndAnswers[]
                {
                    new AsksAndAnswers
                    {
                        ask = "Какой блок используется для портала в Нижний мир?",
                        answers = new string[] { "Обсидиан", "Алмазный блок", "Золотой блок", "Железный блок" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какого цвета стекло можно сделать?",
                        answers = new string[] { "Красное", "Зеленое", "Синее", "Любого цвета" },
                        trueAnswer = 3
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой моб появляется только ночью?",
                        answers = new string[] { "Скелет", "Курица", "Корова", "Свинья" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой блок нельзя сломать киркой?",
                        answers = new string[] { "Бедрок", "Древесина", "Камень", "Земля" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой предмет нужен для зажигания портала в Нижний мир?",
                        answers = new string[] { "Спички", "Зажигалка", "Кремень и сталь", "Огниво" },
                        trueAnswer = 2
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какое животное дропает кожу?",
                        answers = new string[] { "Свинья", "Корова", "Курица", "Овца" },
                        trueAnswer = 1
                    },
                    new AsksAndAnswers
                    {
                        ask = "Что нужно для создания железного блока?",
                        answers = new string[] { "9 железных слитков", "1 железный слиток", "4 железных слитка", "9 железных руд" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой предмет нужен для приручения кота?",
                        answers = new string[] { "Мясо", "Косточка", "Рыба", "Зерна" },
                        trueAnswer = 2
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какого моба можно найти в Нижнем мире?",
                        answers = new string[] { "Скелет", "Зомби", "Гаст", "Паук" },
                        trueAnswer = 2
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой предмет не используется для создания железной кирки?",
                        answers = new string[] { "Палка", "Железный слиток", "Каменный блок", "Дерево" },
                        trueAnswer = 2
                    }
                }
            },
            new Difficulty
            {
                gameState = GameStateData.GameState.Про,
                asksAndAnswers = new AsksAndAnswers[]
                {
                    new AsksAndAnswers
                    {
                        ask = "Какой инструмент нужен для добычи шалкера?",
                        answers = new string[] { "Алмазная кирка", "Железная кирка", "Каменная кирка", "Деревянная кирка" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой эффект дает зачарование 'Шипы' на броне?",
                        answers = new string[] { "Уменьшает урон", "Отбрасывает врагов", "Наносит урон атакующим", "Увеличивает прочность" },
                        trueAnswer = 2
                    },
                    new AsksAndAnswers
                    {
                        ask = "Что происходит, если ударить пиглина в Нижнем мире?",
                        answers = new string[] { "Они убегают", "Они начинают атаковать", "Они дают золото", "Они начинают следовать за игроком" },
                        trueAnswer = 1
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой предмет нужен для создания зелья невидимости?",
                        answers = new string[] { "Золотая морковь", "Светопыль", "Чешуйка фрита", "Паучий глаз" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой блок может создать игрок, чтобы защититься от взрыва крипера?",
                        answers = new string[] { "Стекло", "Земля", "Камень", "Обсидиан" },
                        trueAnswer = 3
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой моб дает эффект 'Иссушение'?",
                        answers = new string[] { "Скелет", "Гаст", "Иссушитель", "Дракон" },
                        trueAnswer = 2
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой предмет нужен для создания маяка?",
                        answers = new string[] { "Алмаз", "Изумруд", "Звезда ада", "Слиток железа" },
                        trueAnswer = 2
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой блок не используется для создания портала в Край?",
                        answers = new string[] { "Обсидиан", "Око Эндера", "Рамка портала", "Жемчуг Эндера" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой предмет нужен для создания карты?",
                        answers = new string[] { "Бумага и компас", "Бумага и алмаз", "Бумага и железо", "Бумага и золото" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой эффект дает зелье силы?",
                        answers = new string[] { "Увеличивает урон", "Уменьшает урон", "Восстанавливает здоровье", "Увеличивает скорость" },
                        trueAnswer = 0
                    }
                }
            }
        };
        
        gameStateInt = (int)gameStateData.currentState;
        gameState.text = "Уровень сложности: " + gameStateData.currentState;
        ChangeButtonsText();
    }

    void Update()
    {
        askText.text = asksList[gameStateInt].asksAndAnswers[countInt].ask;
        countTxt.text = countInt + 1 + "/10";
    }

    public void AnswerButton(int buttonId)
    {
        if (buttonId == asksList[gameStateInt].asksAndAnswers[countInt].trueAnswer)
        {
            gameStateData.countTrueAnsw += 1;
            Debug.Log(gameStateData.countTrueAnsw);
            countTrueAnsw += 1;
        }
        countInt += 1;
        
        if (countInt == asksList[gameStateInt].asksAndAnswers.Length)
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
