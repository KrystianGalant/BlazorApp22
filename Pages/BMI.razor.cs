using Microsoft.AspNetCore.Components;


namespace BlazorApp22.Pages
{
    
        
    using Microsoft.AspNetCore.Components;

    public class TicTacToeBase : ComponentBase
    {
        protected string[,] board = new string[3, 3];
        protected string currentPlayer = "X";
        protected string? winner = null;

        protected override void OnInitialized()
        {
            ResetBoard();
        }

        protected void MakeMove(int row, int col)
        {
            if (board[row, col] == null && winner == null)
            {
                board[row, col] = currentPlayer;
                if (CheckWinner())
                {
                    winner = currentPlayer;
                }
                else
                {
                    SwitchPlayer();
                }
            }
        }

        protected bool CheckWinner()
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] != null && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                {
                    return true;
                }

                if (board[0, i] != null && board[0, i] == board[1, i] && board[1, i] == board[2, i])
                {
                    return true;
                }
            }

            // Check diagonals
            if (board[0, 0] != null && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                return true;
            }

            if (board[0, 2] != null && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                return true;
            }

            return false;
        }

        protected void SwitchPlayer()
        {
            currentPlayer = currentPlayer == "X" ? "O" : "X";
        }

        protected void ResetGame()
        {
            ResetBoard();
            currentPlayer = "X";
            winner = null;
        }

        private void ResetBoard()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    board[row, col] ="";
                }
            }
        }
    }

}

