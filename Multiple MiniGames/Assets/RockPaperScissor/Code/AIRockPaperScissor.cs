using UnityEngine;

namespace RockPaperScissor
{
    /// <summary>
    /// Class to manage AI choice on Rock Paper Scissor game
    /// </summary>
    public class AIRockPaperScissor
    {
        public RockPaperScissorEnum GetRandomChoice()
        {
            return (RockPaperScissorEnum)Random.Range(0, 3);
        }
    }
}