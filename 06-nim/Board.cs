using System;
using System.Collections.Generic;

namespace _06_nim
{
    /// <summary>
    /// Keeps track of all of the pieces in play.
    /// 
    /// Stereotype:
    ///     Information Holder
    /// </summary>
    class Board
    {
        // TODO: Declare any member variables here.
        private List<int> _piles = new List<int>();

        /// <summary>
        /// Initialize the Board
        /// </summary>
        public Board()
        {
            Prepare();
        }

        /// <summary>
        /// A helper method that sets up the board in a new random state.
        /// This could be called by the constructor, or if it is desired
        /// to play again.
        /// 
        /// It should have 2-5 piles with 1-9 stones in each.
        /// </summary>
        private void Prepare()
        {
            _piles.Clear();

            Random randNum = new Random();
            int numPiles = randNum.Next(2, 5);
            
            for (int i = 0; i < numPiles; i++)
            {
                int numStones = randNum.Next(1, 9);

                _piles.Add(numStones);
            }
        }

        /// <summary>
        /// Applies this move by removing the number of stones
        /// from the pile specified in the move.
        /// </summary>
        /// <param name="move">Contains the pile and the number of stones</param>
        public void Apply(Move move)
        {
            _piles[move.GetPile()] = _piles[move.GetPile()] - move.GetStones();            
        }

        /// <summary>
        /// Indicates if the board is empty (no more stones)
        /// </summary>
        /// <returns>True, if there are no more stones</returns>
        public bool IsEmpty()
        {
            bool emptyCheck = false;

            for (int i = 0; i < _piles.Count; i++)
            {
                if (_piles[i] <= 0)
                {
                    emptyCheck = true;
                }
                else
                {
                    emptyCheck = false;
                    break;
                }
            }

            return emptyCheck;
        }

        /// <summary>
        /// Get's a string representation of the board in the format:
        /// 
        /// --------------------
        /// 0: O O O O O O 
        /// 1: O O O O O O O
        /// 2: O O O O O O O O 
        /// 3: O O O O 
        /// --------------------
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            string boardString = "\n"
                               + "--------------------\n";

            for (int i = 0; i < _piles.Count; i++)
            {
                string row = $"{i}: ";

                for (int j = 0; j < _piles[i]; j++)
                {
                    row = string.Concat(row, "O");
                }

                row = string.Concat(row, "\n");

                boardString = string.Concat(boardString, row);
            }

            boardString = string.Concat(boardString, "--------------------\n");

            return boardString;
        }

        /// <summary>
        /// A helper function that is used by the general ToString method.
        /// This one gets the text for a specific pile in the format:
        /// 
        /// 2: O O O O O O O O 
        /// 
        /// </summary>
        /// <param name="pileNumber">The pile number to display at the front of the line.</param>
        /// <param name="stones">The number of stones in the pile</param>
        /// <returns></returns>
        private string GetTextForPile(int pileNumber, int stones)
        {
            throw new NotImplementedException();
        }
    }
}
