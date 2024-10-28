using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    //refrences to the animator components
    public Animator characterAnimator;
    public Animator playerAnimator;

    //holding sequence of moves
    //queue is used because first in first out data structure
    private Queue<string> targetMoves = new Queue<string>();
    private Queue<string> playerMoves = new Queue<string>();

    //list of all available moves for the character
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

        
    }

    /*private void AddRandomTargetMove()
    {
        //sets a randomindex of available moves
        int randomIndex = Random.Range(0, avaiableMoves.Count);
        string randomMove = avaiableMoves[randomIndex];

        //added to target moves queue
        targetMoves.Enqueue(randomMove);
        //starts character animation for that move
        characterAnimator.SetTrigger(randomMove);
        //Debug.Log("Character Played: " + randomMove);
    }*/

    private void AddRandomTargetMove()
    {
        //choose a random number of moves 2 or 3
        int numberOfMoves = Random.Range(2, 4);

        //for loop to enque each of these random moves to targetMoves and sets the trigger
        for (int i = 0; i < numberOfMoves; i++)
        {
            int randomIndex = Random.Range(0, avaiableMoves.Count);
            string randomMove = avaiableMoves[randomIndex];

            targetMoves.Enqueue(randomMove);
            characterAnimator.SetTrigger(randomMove);

            Debug.Log("Charachter added random move: " + randomMove);
        }

        Debug.Log("Character sequence added: " + string.Join(", ", targetMoves.ToArray()));
    }

    void RegisterMove(string move)
    {
        //move is added to player moves
        playerMoves.Enqueue(move);

        //Debug.Log("Current Player Moves: " + string.Join(", ", playerMoves.ToArray()));

        //triggers the animation
        playerAnimator.SetTrigger(move);

        CheckPlayerMove();


    }

    void CheckPlayerMove()
    {
        //check if player has entered more moves than target by comparing queue lengths, if so exits early
        if(playerMoves.Count > targetMoves.Count)
        {
            playerMoves.Clear();
            Debug.Log("error: player has more moves than target");
            return;
        }
        

        //converts playermoves and targetmoves to arrays to compare them step by step
        //string[] playerArray = playerMoves.ToArray();
        //or
        var playerArray = playerMoves.ToArray();
        var targetArray = targetMoves.ToArray();

        //Debug.Log("Player Moves:  " + string.Join(", ", playerArray));
        //Debug.Log("Target Moves: " + string.Join(",", targetArray));

        //compare each move in the player sequence with the target sequence
        for(int i = 0; i < playerMoves.Count; i++)
        {
            if (playerArray[i] != targetArray[i])
            {
                //if a move does not matcg, clear playerMoves queue and return
                Debug.Log("WRONG- Reset player moves");
                playerMoves.Clear();
                targetMoves.Clear();
                return;
            }
        }

        //if player moves fully match target moves, reset playerMoves and targetMoves to start fresh
        if(playerMoves.Count == targetMoves.Count)
        {
            Debug.Log("Match");
            playerMoves.Clear();
            targetMoves.Clear();
        }
        
    }
}
