using System.Collections.Generic;
using UnityEngine;

namespace RockPaperScissor
{
    /// <summary>
    /// Class to manage the Rock Paper Scissor game
    /// </summary>
    public class RockPaperScissorManager : MonoBehaviour
    {
        #region Private Attributes

        [SerializeField] private PlayerChoiceRPS _playerChoiceRPS;
        
        private AIRockPaperScissor _aiRockPaperScissor;

        private RockPaperScissorEnum _playerChoice;
        private RockPaperScissorEnum _aiChoice;

        private static readonly Dictionary<(RockPaperScissorEnum, RockPaperScissorEnum), GameResults> outcomes;

        // Static constructor to initialize the dictionary
        static RockPaperScissorManager()
        {
            outcomes = new Dictionary<(RockPaperScissorEnum, RockPaperScissorEnum), GameResults>
            {
                {(RockPaperScissorEnum.Rock, RockPaperScissorEnum.Rock), GameResults.Tie},
                {(RockPaperScissorEnum.Rock, RockPaperScissorEnum.Paper), GameResults.AIWins},
                {(RockPaperScissorEnum.Rock, RockPaperScissorEnum.Scissor), GameResults.PlayerWins},
                {(RockPaperScissorEnum.Paper, RockPaperScissorEnum.Rock), GameResults.PlayerWins},
                {(RockPaperScissorEnum.Paper, RockPaperScissorEnum.Paper), GameResults.Tie},
                {(RockPaperScissorEnum.Paper, RockPaperScissorEnum.Scissor), GameResults.AIWins},
                {(RockPaperScissorEnum.Scissor, RockPaperScissorEnum.Rock), GameResults.AIWins},
                {(RockPaperScissorEnum.Scissor, RockPaperScissorEnum.Paper), GameResults.PlayerWins},
                {(RockPaperScissorEnum.Scissor, RockPaperScissorEnum.Scissor), GameResults.Tie}
            };
        }
        
        #endregion

        #region MonoBehaviour Methods

        private void Start() 
        {
            _playerChoiceRPS.EnablePlayerSelection();
            _aiRockPaperScissor = new AIRockPaperScissor();
        }

        private void OnEnable()
        {
            PlayerChoiceRPS.OnPlayerChoiceChanged += HandlePlayerChoiceChanged;
        }

        private void OnDisable()
        {
            PlayerChoiceRPS.OnPlayerChoiceChanged -= HandlePlayerChoiceChanged;
        }
        
        #endregion

        #region Methods

        private void HandlePlayerChoiceChanged()
        {
            Debug.Log("Player choice has been set. Proceeding with game flow.");
            
            // Get the player choice
            _playerChoice = _playerChoiceRPS.PlayerChoice;
            
            // Get the AI choice
            _aiChoice = _aiRockPaperScissor.GetRandomChoice();
            Debug.Log("AI choice: " + _aiChoice);

            // Determine the winner
            DetermineWinner();
        }

        private void DetermineWinner()
        {
            Debug.Log("Determining the winner...");

            // Get the result from the dictionary
            if (outcomes.TryGetValue((_playerChoice, _aiChoice), out GameResults result))
            {
                Debug.Log(result);
            }
            else
            {
                Debug.LogError("Invalid choices detected.");
            }
        }

        #endregion
    }
}