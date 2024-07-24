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
                    },
                    // Добавим еще 27 вопросов для уровня "Нуб"
                    new AsksAndAnswers
                    {
                        ask = "Какой инструмент нужен для добычи железной руды?",
                        answers = new string[] { "Деревянная кирка", "Каменная кирка", "Золотая кирка", "Лопата" },
                        trueAnswer = 1
                    },
                    new AsksAndAnswers
                    {
                        ask = "Что нужно для создания алмазной кирки?",
                        answers = new string[] { "3 алмаза и 2 палки", "2 алмаза и 3 палки", "1 алмаз и 2 палки", "4 алмаза и 1 палка" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой моб дропает нитки?",
                        answers = new string[] { "Паук", "Скелет", "Зомби", "Курица" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какое животное дропает свинину?",
                        answers = new string[] { "Корова", "Овца", "Свинья", "Курица" },
                        trueAnswer = 2
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой инструмент нужен для добычи золота?",
                        answers = new string[] { "Железная кирка", "Каменная кирка", "Деревянная кирка", "Лопата" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой предмет нужен для создания лука?",
                        answers = new string[] { "Нитки и палки", "Палки и камень", "Железо и нитки", "Доски и нитки" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой предмет нужен для создания компаса?",
                        answers = new string[] { "Железо и красный камень", "Железо и золото", "Золото и алмаз", "Железо и алмаз" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой блок используется для выращивания растений?",
                        answers = new string[] { "Земля", "Песок", "Камень", "Глина" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой предмет нужен для приготовления пищи?",
                        answers = new string[] { "Печь", "Котел", "Ведро", "Таз" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой моб дает шерсть?",
                        answers = new string[] { "Овца", "Корова", "Свинья", "Курица" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой инструмент нужен для добычи изумрудов?",
                        answers = new string[] { "Железная кирка", "Каменная кирка", "Деревянная кирка", "Золотая кирка" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой блок нельзя сломать?",
                        answers = new string[] { "Бедрок", "Обсидиан", "Алмазный блок", "Железный блок" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой инструмент нужен для добычи камня?",
                        answers = new string[] { "Деревянная кирка", "Каменная кирка", "Железная кирка", "Золотая кирка" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой ресурс нужен для создания железной кирки?",
                        answers = new string[] { "Железо", "Золото", "Алмазы", "Изумруды" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой блок можно найти в Нижнем мире?",
                        answers = new string[] { "Нефритовый блок", "Незеритовый блок", "Алмазный блок", "Золотой блок" },
                        trueAnswer = 1
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой предмет нужен для создания карты?",
                        answers = new string[] { "Бумага и компас", "Бумага и алмаз", "Бумага и железо", "Бумага и золото" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой блок можно создать из пшеницы?",
                        answers = new string[] { "Хлеб", "Блок сена", "Мука", "Торт" },
                        trueAnswer = 1
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой предмет нужен для создания заборов?",
                        answers = new string[] { "Палки и доски", "Железо и доски", "Камень и доски", "Золото и доски" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой блок нужен для выращивания растений в Нижнем мире?",
                        answers = new string[] { "Душевая земля", "Земля", "Песок", "Гравий" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой предмет нужен для создания лодки?",
                        answers = new string[] { "Доски", "Палки", "Железо", "Камень" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой предмет нужен для создания кровати?",
                        answers = new string[] { "Доски и шерсть", "Железо и шерсть", "Камень и шерсть", "Золото и шерсть" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой предмет нужен для создания брони?",
                        answers = new string[] { "Железо", "Золото", "Алмазы", "Все ответы верны" },
                        trueAnswer = 3
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой предмет нужен для создания зелья исцеления?",
                        answers = new string[] { "Слеза гаста", "Светопыль", "Глаз паука", "Золотая морковь" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой инструмент нужен для добычи кварца в Нижнем мире?",
                        answers = new string[] { "Железная кирка", "Каменная кирка", "Деревянная кирка", "Золотая кирка" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой предмет нужен для создания лианы?",
                        answers = new string[] { "Палки", "Нить", "Доски", "Камень" },
                        trueAnswer = 1
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой блок нужен для создания маяка?",
                        answers = new string[] { "Обсидиан", "Звезда Незера", "Стекло", "Все ответы верны" },
                        trueAnswer = 3
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой предмет нужен для создания алмазного меча?",
                        answers = new string[] { "2 алмаза и палка", "1 алмаз и 2 палки", "2 алмаза и 2 палки", "3 алмаза и палка" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой блок используется для создания зельеварки?",
                        answers = new string[] { "Адский камень", "Булыжник", "Обсидиан", "Кварц" },
                        trueAnswer = 1
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой инструмент нужен для добычи изумрудов?",
                        answers = new string[] { "Железная кирка", "Каменная кирка", "Деревянная кирка", "Золотая кирка" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой предмет нужен для создания светильника Джека?",
                        answers = new string[] { "Тыква и факел", "Тыква и уголь", "Тыква и палка", "Тыква и красный камень" },
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
                    },
                    // Добавим еще 27 вопросов для уровня "Продвинутый"
                    new AsksAndAnswers
                    {
                        ask = "Какой предмет нужен для создания наблюдателя?",
                        answers = new string[] { "Красный камень", "Кварц", "Камень", "Все ответы верны" },
                        trueAnswer = 3
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой блок используется для создания зелий?",
                        answers = new string[] { "Котел", "Зельеварка", "Печь", "Воронка" },
                        trueAnswer = 1
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой моб дропает гнилая плоть?",
                        answers = new string[] { "Зомби", "Скелет", "Паук", "Курица" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой блок нужен для создания портала в Край?",
                        answers = new string[] { "Око Эндера", "Рамка портала", "Жемчуг Эндера", "Все ответы верны" },
                        trueAnswer = 3
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой инструмент нужен для добычи лазурита?",
                        answers = new string[] { "Каменная кирка", "Железная кирка", "Деревянная кирка", "Золотая кирка" },
                        trueAnswer = 1
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой предмет нужен для создания компаса?",
                        answers = new string[] { "Железо и красный камень", "Железо и золото", "Золото и алмаз", "Железо и алмаз" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой блок можно найти в пустыне?",
                        answers = new string[] { "Песок", "Глина", "Земля", "Лед" },
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
                        ask = "Какой предмет нужен для создания лианы?",
                        answers = new string[] { "Палки", "Нить", "Доски", "Камень" },
                        trueAnswer = 1
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой блок используется для создания зельеварки?",
                        answers = new string[] { "Адский камень", "Булыжник", "Обсидиан", "Кварц" },
                        trueAnswer = 1
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой инструмент нужен для добычи кварца в Нижнем мире?",
                        answers = new string[] { "Железная кирка", "Каменная кирка", "Деревянная кирка", "Золотая кирка" },
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
                        ask = "Какой предмет нужен для создания зелья исцеления?",
                        answers = new string[] { "Слеза гаста", "Светопыль", "Глаз паука", "Золотая морковь" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой предмет нужен для создания алмазного меча?",
                        answers = new string[] { "2 алмаза и палка", "1 алмаз и 2 палки", "2 алмаза и 2 палки", "3 алмаза и палка" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой блок используется для создания зельеварки?",
                        answers = new string[] { "Адский камень", "Булыжник", "Обсидиан", "Кварц" },
                        trueAnswer = 1
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой инструмент нужен для добычи изумрудов?",
                        answers = new string[] { "Железная кирка", "Каменная кирка", "Деревянная кирка", "Золотая кирка" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой предмет нужен для создания светильника Джека?",
                        answers = new string[] { "Тыква и факел", "Тыква и уголь", "Тыква и палка", "Тыква и красный камень" },
                        trueAnswer = 0
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
                    },
                    // Добавим еще 27 вопросов для уровня "Про"
                    new AsksAndAnswers
                    {
                        ask = "Какой предмет нужен для создания брони?",
                        answers = new string[] { "Железо", "Золото", "Алмазы", "Все ответы верны" },
                        trueAnswer = 3
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой предмет нужен для создания зелья исцеления?",
                        answers = new string[] { "Слеза гаста", "Светопыль", "Глаз паука", "Золотая морковь" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой инструмент нужен для добычи кварца в Нижнем мире?",
                        answers = new string[] { "Железная кирка", "Каменная кирка", "Деревянная кирка", "Золотая кирка" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой предмет нужен для создания лианы?",
                        answers = new string[] { "Палки", "Нить", "Доски", "Камень" },
                        trueAnswer = 1
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой блок нужен для создания маяка?",
                        answers = new string[] { "Обсидиан", "Звезда Незера", "Стекло", "Все ответы верны" },
                        trueAnswer = 3
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой предмет нужен для создания алмазного меча?",
                        answers = new string[] { "2 алмаза и палка", "1 алмаз и 2 палки", "2 алмаза и 2 палки", "3 алмаза и палка" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой блок используется для создания зелий?",
                        answers = new string[] { "Котел", "Зельеварка", "Печь", "Воронка" },
                        trueAnswer = 1
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой моб дропает гнилая плоть?",
                        answers = new string[] { "Зомби", "Скелет", "Паук", "Курица" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой блок нужен для создания портала в Край?",
                        answers = new string[] { "Око Эндера", "Рамка портала", "Жемчуг Эндера", "Все ответы верны" },
                        trueAnswer = 3
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой инструмент нужен для добычи лазурита?",
                        answers = new string[] { "Каменная кирка", "Железная кирка", "Деревянная кирка", "Золотая кирка" },
                        trueAnswer = 1
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой предмет нужен для создания компаса?",
                        answers = new string[] { "Железо и красный камень", "Железо и золото", "Золото и алмаз", "Железо и алмаз" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой блок можно найти в пустыне?",
                        answers = new string[] { "Песок", "Глина", "Земля", "Лед" },
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
                        ask = "Какой предмет нужен для создания лианы?",
                        answers = new string[] { "Палки", "Нить", "Доски", "Камень" },
                        trueAnswer = 1
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой блок используется для создания зельеварки?",
                        answers = new string[] { "Адский камень", "Булыжник", "Обсидиан", "Кварц" },
                        trueAnswer = 1
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой инструмент нужен для добычи изумрудов?",
                        answers = new string[] { "Железная кирка", "Каменная кирка", "Деревянная кирка", "Золотая кирка" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой предмет нужен для создания светильника Джека?",
                        answers = new string[] { "Тыква и факел", "Тыква и уголь", "Тыква и палка", "Тыква и красный камень" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой предмет нужен для создания зелья исцеления?",
                        answers = new string[] { "Слеза гаста", "Светопыль", "Глаз паука", "Золотая морковь" },
                        trueAnswer = 0
                    },
                    new AsksAndAnswers
                    {
                        ask = "Какой предмет нужен для создания зелья силы?",
                        answers = new string[] { "Светопыль", "Порох", "Сахар", "Красный камень" },
                        trueAnswer = 0
                    }
                }
            }
        };
        
        gameStateInt = (int)gameStateData.currentState;
        gameState.text = "Уровень сложности: " + gameStateData.currentState;
        gameStateData.countAnsw = asksList[gameStateInt].asksAndAnswers.Length;
        ChangeButtonsText();
    }

    void Update()
    {
        askText.text = asksList[gameStateInt].asksAndAnswers[countInt].ask;
        countTxt.text = countInt + 1 + $"/{asksList[gameStateInt].asksAndAnswers.Length}";
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
