using System;
using UnityEngine;

namespace RockPaperScissor
{
    /// <summary>
    ///  Class to manage the player choice on Rock Paper Scissor game
    /// </summary>
    public class PlayerChoiceRPS : MonoBehaviour
    {
        #region Private Attributes

        [SerializeField] private RockPaperScissorEnum _playerChoice;

        private bool _playerCanSelect;
        
        #endregion

        #region Properties

        public RockPaperScissorEnum PlayerChoice => _playerChoice;
        
        #endregion

        #region Events

        public static event Action OnPlayerChoiceChanged;
        
        #endregion

        #region Methods

        /// <summary>
        /// Enable the player to select a choice
        /// </summary>
        public void EnablePlayerSelection()
        {
            _playerCanSelect = true;
            _playerChoice = RockPaperScissorEnum.None;
        }

        /// <summary>
        /// Set the player choice to the given choice. If the choice is invalid, it logs an error.
        /// Used by the UI to set the player choice on the buttons.
        /// </summary>
        /// <param name="choice"></param>
        public void SetPlayerChoice(string choice)
        {
            // Try to parse the choice string to the RockPaperScissorEnum
            if (Enum.TryParse(choice, true, out RockPaperScissorEnum parsedChoice))
            {
                // If the parsing was successful, set the player choice
                Debug.Log("Player choice: " + parsedChoice);
                _playerChoice = parsedChoice;
                _playerCanSelect = false;
                OnPlayerChoiceChanged?.Invoke();
            }
            // If the parsing was not successful, log an error
            else
            {
                Debug.LogError("Invalid choice: " + choice);
            }
        }
        
        #endregion
    }
}
