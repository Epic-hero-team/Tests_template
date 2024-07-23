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
                        ask = "В каком году вышла игра Brawl Stars?",
                        answers = new string[] { "2020", "2019", "2018", "2017" },
                        trueAnswer = 3
                    },
                    new AsksAndAnswers
                    {
                        ask = "Как называется первая разблокируемая бравлерка?",
                        answers = new string[] { "Кольт", "КольтШелли", "Булл", "Джесси" },
                        trueAnswer = 1
                    },
                    new AsksAndAnswers
                    {
                        ask = "Сколько очков здоровья у Шелли на первом уровне?",
                        answers = new string[] { "3600", "4000", "4200", "4400" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какого цвета иконка редкости у редких бравлеров?",
                        answers = new string[] { "Зеленая", "Синяя", "Фиолетовая", "Красная" },
                        trueAnswer = 1
                    },
                    new AsksAndAnswers
                    {
                        ask = "Как называется режим игры, где команды сражаются за кристаллы?",
                        answers = new string[] { "Захват кристаллов", "Столкновение", "Ограбление", "Осада" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Сколько игроков в одной команде в режиме 'Захват кристаллов'?",
                        answers = new string[] { "3", "4", "5", "6" },
                        trueAnswer = 1
                    },
                    new AsksAndAnswers
                    {
                        ask = "Кто является врагом в режиме игры 'Большая охота'?",
                        answers = new string[] { "Большой босс", "Робот", "Другие игроки", "Указанный игрок" },
                        trueAnswer = 1
                    },
                    new AsksAndAnswers
                    {
                        ask = "Как называется валюта, которую можно купить за реальные деньги?",
                        answers = new string[] { "Монеты", "Золото", "Бонусы", "Гемы" },
                        trueAnswer = 3
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какого цвета значок суперспособности у бравлеров?",
                        answers = new string[] { "Желтый", "Синий", "Зеленый", "Красный" },
                        trueAnswer = 1
                    },
                    new AsksAndAnswers
                    {
                        ask = "Как зовут персонажа, который стреляет из ружья?",
                        answers = new string[] { "Шелли", "Кольт", "Булл", "Рико" },
                        trueAnswer = 2
                    }
                }
            },
            new Difficulty
            {
                gameState = GameStateData.GameState.Начинающий,
                asksAndAnswers = new AsksAndAnswers[]
                {
                    new AsksAndAnswers
                    {
                        ask = "Сколько звездочек нужно собрать в режиме 'Охота' для победы?",
                        answers = new string[] { "Больше всех", "10", "20", "50" },
                        trueAnswer = 1
                    },
                    new AsksAndAnswers
                    {
                        ask = "Кто является первой эпической бравлеркой?",
                        answers = new string[] { "Пэм", "Пайпер", "Фрэнк", "Биби" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой бравлер запускает ракету в своих атаках?",
                        answers = new string[] { "Брок", "Динамайк", "Бо", "Тик" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Как называется режим, в котором нужно защищать сейф?",
                        answers = new string[] { "Осада", "Столкновение", "Захват кристаллов", "Ограбление" },
                        trueAnswer = 3
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какого бравлера можно получить из редких бравлеров?",
                        answers = new string[] { "Роза", "Эль Примо", "Барли", "По" },
                        trueAnswer = 2
                    },
                    new AsksAndAnswers
                    {
                        ask = "Как называется игровая валюта, получаемая за выполнение заданий?",
                        answers = new string[] { "Токены", "Гемы", "Монеты", "Золото" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какое максимальное количество трофеев можно получить за одно сражение?",
                        answers = new string[] { "8", "10", "12", "15" },
                        trueAnswer = 2
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой бравлер может замораживать врагов с помощью своей суперспособности?",
                        answers = new string[] { "Эмз", "Фрэнк", "Гейл", "Спайк" },
                        trueAnswer = 2
                    },
                    new AsksAndAnswers
                    {
                        ask = "Сколько нужно кристаллов для разблокировки мегаящика?",
                        answers = new string[] { "80", "100", "120", "200" },
                        trueAnswer = 1
                    },
                    new AsksAndAnswers
                    {
                        ask = "Как называется режим, в котором играют 10 игроков каждый за себя?",
                        answers = new string[] { "Столкновение", "Охота", "Ограбление", "Осада" },
                        trueAnswer = 0
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
                        ask = "Какой бравлер может лечить своих союзников?",
                        answers = new string[] { "По", "Биби", "Карл", "Макс" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какое количество гемов нужно для смены имени игрока?",
                        answers = new string[] { "50", "100", "150", "200" },
                        trueAnswer = 1
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой бравлер может запускать ракеты в своей суперспособности?",
                        answers = new string[] { "Брок", "Динамайк", "Рико", "Кольт" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какое событие дает возможность зарабатывать двойные трофеи?",
                        answers = new string[] { "Робо Рамбл", "События с билетами", "Выходные билеты", "Супер игра" },
                        trueAnswer = 1
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой бравлер может телепортироваться с помощью своей суперспособности?",
                        answers = new string[] { "Леон", "Джин", "Тара", "Мортис" },
                        trueAnswer = 2
                    },
                    new AsksAndAnswers
                    {
                        ask = "Как называется режим, в котором нужно собирать болты?",
                        answers = new string[] { "Осада", "Захват кристаллов", "Ограбление", "Столкновение" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой бравлер может замедлять противников с помощью своей суперспособности?",
                        answers = new string[] { "Тик", "Пэм", "Роза", "Эль Примо" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какое максимальное количество бравлеров в одном режиме 'События с билетами'?",
                        answers = new string[] { "4", "6", "8", "10" },
                        trueAnswer = 1
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой бравлер может контролировать поле боя с помощью своей суперспособности?",
                        answers = new string[] { "Биби", "Макс", "По", "Тара" },
                        trueAnswer = 3
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой бравлер может лечить своих союзников в радиусе своей суперспособности?",
                        answers = new string[] { "Пэм", "Джесси", "Шелли", "Кольт" },
                        trueAnswer = 0
                    }
                }
            },
            new Difficulty
            {
                gameState = GameStateData.GameState.Профессионал,
                asksAndAnswers = new AsksAndAnswers[]
                {
                    new AsksAndAnswers
                    {
                        ask = "Какой бравлер имеет способность создавать двойников?",
                        answers = new string[] { "Тара", "Леон", "Гейл", "Джин" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой бравлер имеет способность создавать огненные летающие шары?",
                        answers = new string[] { "Эмбер", "Пайпер", "Брок", "Динамайк" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой бравлер имеет суперспособность, которая увеличивает скорость передвижения всей команды?",
                        answers = new string[] { "Макс", "По", "Пэм", "Тик" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой бравлер может использовать ловушки для того, чтобы замедлять противников?",
                        answers = new string[] { "Тик", "Рико", "Динамайк", "По" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой бравлер может прыгать через стены и преграды?",
                        answers = new string[] { "Рико", "Леон", "Спайк", "Биби" },
                        trueAnswer = 2
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой бравлер использует мощный лазер в своей атаке?",
                        answers = new string[] { "Дэрил", "Брок", "Бо", "Сэнди" },
                        trueAnswer = 3
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой бравлер обладает способностью лечить всех своих союзников в радиусе действия?",
                        answers = new string[] { "Пэм", "Шелли", "Карл", "По" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой бравлер может создавать огромные области с замедлением для противников?",
                        answers = new string[] { "Эмбер", "Тара", "Биби", "Макс" },
                        trueAnswer = 1
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой бравлер использует молнии для атаки?",
                        answers = new string[] { "Фрэнк", "Спайк", "Эмз", "Биби" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой бравлер может оглушать противников в своей суперспособности?",
                        answers = new string[] { "Фрэнк", "Шелли", "Тара", "Динамайк" },
                        trueAnswer = 0
                    }
                }
            },
            new Difficulty
            {
                gameState = GameStateData.GameState.Эксперт,
                asksAndAnswers = new AsksAndAnswers[]
                {
                    new AsksAndAnswers
                    {
                        ask = "Какой бравлер способен переключаться между двумя формами для усиления своих атак?",
                        answers = new string[] { "Мортис", "Леон", "Биби", "Сэнди" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой бравлер имеет способность управлять огнем и взрывать его?",
                        answers = new string[] { "Эмбер", "Динамайк", "Тик", "Брок" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой бравлер может перемещаться в невидимости и наносить урон из-за спины?",
                        answers = new string[] { "Леон", "Тара", "Гейл", "Пайпер" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой бравлер обладает способностью привлекать противников в определенную область?",
                        answers = new string[] { "Джин", "Спайк", "Фрэнк", "Макс" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой бравлер имеет способность бросать множество гранат одновременно?",
                        answers = new string[] { "Тик", "По", "Рико", "Карл" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой бравлер может быстро перемещаться по карте и атаковать с большого расстояния?",
                        answers = new string[] { "Макс", "Рико", "Динамайк", "Биби" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой бравлер имеет способность лечить себя и союзников, когда получает урон?",
                        answers = new string[] { "Пэм", "Роза", "Шелли", "Джесси" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой бравлер обладает способностью замораживать врагов и препятствовать их движению?",
                        answers = new string[] { "Гейл", "Тара", "Фрэнк", "Эмбер" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой бравлер может превращаться в большие черные дыры, чтобы поглощать противников?",
                        answers = new string[] { "Тара", "Леон", "Джин", "Тик" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой бравлер может создавать мощные волны атаки, наносящие урон на большом расстоянии?",
                        answers = new string[] { "Эмбер", "Спайк", "Гейл", "Динамайк" },
                        trueAnswer = 1
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
