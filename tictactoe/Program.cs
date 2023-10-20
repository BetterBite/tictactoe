namespace tictactoe {
    internal class Program {
        static void Main(string[] args) {
            Game game = new Game();
            int? winningPlayer = null;
            for (int turn = 1; turn < 10; turn++) {
                int player = turn % 2 == 0 ? 2 : 1;
                game.field.showField();
                Console.WriteLine(String.Format("Player ", player, "'s turn."));
                if (game.doTurn(player)) { winningPlayer = player; break; }
            }
            game.field.showField();
            if (winningPlayer != null) Console.WriteLine(String.Format("We have a winner! Player ", winningPlayer, " has won!"));
            else Console.WriteLine("It's a draw!");
            Console.WriteLine("Press ENTER to exit.");
            Console.ReadLine();
        }
    }
}