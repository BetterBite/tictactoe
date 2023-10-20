namespace tictactoe {
    public class Game {
        /// <summary>
        /// Upon game completion, checks for a winner, if true, the player whose turn it currently is wins, otherwise, it's a draw.
        /// </summary>
        public Field field;

        public Game() { 
            field = new Field();
            Console.WriteLine("Game is ready");
        }

        /// <summary>
        /// Performs a single turn of tic-tac-toe
        /// </summary>
        /// <param name="player">If 1, use naughts. If 2, use crosses.</param>
        public bool doTurn(int player) {
            Console.WriteLine(String.Format("Player ", player, "'s turn."));
            while (true){
                Console.WriteLine("Write position in form 'x,y'.");
                string? coords = Console.ReadLine();
                string[] inputs = coords.Split(',');
                if (int.TryParse(inputs[0], out int x) && int.TryParse(inputs[1], out int y) && x > 0 && x < 4 && y > 0 && y < 4) { } else { Console.WriteLine("Both values have to be numbers between 1 and 3. Try again."); continue; };
                switch (player) {
                    case 1:
                        field.updateCell(int.Parse(inputs[0]), int.Parse(inputs[1]), 'O'); break;
                    case 2:
                        field.updateCell(int.Parse(inputs[0]), int.Parse(inputs[1]), 'X'); break;
                }
                break;
            }
            return checkForWinner(player);
        }
        /// <summary>
        /// Checks for a winner
        /// </summary>
        /// <param name="player">Used to see if code should be looking for O or X</param>
        /// <returns>Returns true if someone won</returns>
        public bool checkForWinner(int player) {
            //(Thanks ChatGPT for the uneeded suggestion. Slightly altered)
            char XorO = (player == 1) ? 'O' : 'X';
            bool weHaveAWinner = true;
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    if (field.getCellAt(i, j) != XorO) weHaveAWinner = false;
                    if (field.getCellAt(j, i) != XorO) weHaveAWinner = false;
                }
                if (weHaveAWinner) return true;
            }
            //Check diagonals
            if ((field.getCellAt(0, 0) == XorO && field.getCellAt(1, 1) == XorO && field.getCellAt(2, 2) == XorO) || (field.getCellAt(0, 2) == XorO && field.getCellAt(1, 1) == XorO && field.getCellAt(2, 0) == XorO)) return true;
            
            return false; 
        }
    }
}
