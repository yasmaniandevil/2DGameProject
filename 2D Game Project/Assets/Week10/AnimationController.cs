using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator characterAnimator;
    public Animator playerAnimator;

    private Queue<string> targetMoves = new Queue<string>();
    private Queue<string> playerMoves = new Queue<string>();

    private List<string> avaiableMoves = new List<string> {"LeftArmUp", "LeftArmDown", "RightArmUp",
    "RightArmDown", "LeftKick", "RightKick"};

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("hit space");
            AddRandomTargetMove();
            Debug.Log("randomtargetmove");
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            RegisterMove("LeftArmUp");
            
            Debug.Log("Left Arm Up + Q");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            RegisterMove("LeftArmDown");
            
            Debug.Log("LeftArmDown A");
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            RegisterMove("RightArmUp");
            
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            RegisterMove("RightArmDown");
            
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            RegisterMove("LeftKick");
            
        }

        if(Input.GetKeyDown(KeyCode.X))
        {
            RegisterMove("RightKick");
            
        }

        CheckPlayerMove();
    }

    private void AddRandomTargetMove()
    {
        int randomIndex = Random.Range(0, avaiableMoves.Count);
        string randomMove = avaiableMoves[randomIndex];

        targetMoves.Enqueue(randomMove);
        characterAnimator.SetTrigger(randomMove);
        

        Debug.Log("Character Played: " + randomMove);
    }

    void RegisterMove(string move)
    {
        playerMoves.Enqueue(move);

        Debug.Log("Current Player Moves: " + string.Join(", ", playerMoves.ToArray()));


        playerAnimator.SetTrigger(move);


    }

    void CheckPlayerMove()
    {
        if(playerMoves.Count > targetMoves.Count)
        return;

        //string[] playerArray = playerMoves.ToArray();
        //or
        var playerArray = playerMoves.ToArray();
        var targetArray = targetMoves.ToArray();

        Debug.Log("Player Moves:  " + string.Join(", ", playerArray));
        //Debug.Log("Target Moves: " + string.Join(",", targetArray));

        for(int i = 0; i < playerMoves.Count; i++)
        {
            if (playerArray[i] != targetArray[i])
            {
                Debug.Log("WRONG- Reset player moves");
                playerMoves.Clear();
                return;
            }
        }

        if(playerMoves.Count == targetMoves.Count)
        {
            //Debug.Log("Match");
            playerMoves.Clear();
        }
        
    }
}
