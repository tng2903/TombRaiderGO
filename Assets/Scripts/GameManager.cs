using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public List<GameObject> enemies;
    public Phase gamePhase = Phase.INPUT;
    private InputManager inputManager;
    private TouchCommand command;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        inputManager = GetComponent<InputManager>();
    }

    /// <summary>
    /// The update methods follows the flow of:
    /// Input (user enters input (swipe,touch))
    /// Player character processes input
    /// Non-player characters process input
    /// </summary>

    public void Update()
    {
        switch (gamePhase)
        {
            case Phase.INPUT:
                {

                    if(inputManager.TouchListener(out command))
                    {
                        gamePhase = Phase.PLAYER;
                    }
                    break;
                }
            case Phase.PLAYER:
                {
                    player.GetComponent<Player>().PhaseBehavior(command);
                    gamePhase = Phase.ENEMY;
                    break;
                }
            case Phase.ENEMY:
                {
                    foreach(GameObject e in enemies)
                    {
                        e.GetComponent<Enemy>().PhaseBehavior(command);
                    }
                    gamePhase = Phase.INPUT;
                    break;
                }
        }
    }

    public void removeFromEnemies(GameObject enemy)
    {
        enemies.Remove(enemy);
    }
}
