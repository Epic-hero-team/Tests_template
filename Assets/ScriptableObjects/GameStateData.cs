using UnityEngine;

[CreateAssetMenu(fileName = "GameStateData", menuName = "ScriptableObjects/GameStateData", order = 1)]
public class GameStateData : ScriptableObject
{
    public GameState currentState;
    public int countTrueAnsw;
    
    public enum GameState
    {
        Noob,
        Beginner,
        Advanced,
        Professional,
        Expert
    }
}