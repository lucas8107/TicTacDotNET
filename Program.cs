using System;
using System.Collections.Generic;

namespace TicTacDotNET
{
    class Program
    {
        static void Main(string[] args)
        {
            Game g = new Game();
            Console.Read();
            g.Run();
        }
    }

    class Game
    {
        List<Player> players = new List<Player>();
        char[] board = {' ',' ',' ',' ',' ',' ',' ',' ',' ',};
        int turn = 0;

        public void Run()
        {
            players.Add(new Player("Lucas", 'X'));
            players.Add(new Player("Keiros", 'O'));
            
            DrawBoard();

            while(!IsTerminal())
            {
                Console.WriteLine($"Turn of {players[turn].GetName()}:");

                string move = Console.ReadLine();

                if(!ValidMove(move))
                {
                    continue;
                }
                
                board[(move[0] - '1') * 3 + (move[1] - '1')] = players[turn].GetToken();

                DrawBoard();

                turn = (turn + 1) % 2;
            }
            
        }

        private bool IsTerminal()
        {
            for(int i = 0; i < 3; i++)
            {
                if(board[3 * i] == board[3 * i + 1] && board[3 * i + 1] == board[3 * i + 2] && board[3 * i] != ' ')
                {
                    return true;
                }
                if(board[i] == board[i + 3] && board[i + 3] == board[i + 6] && board[i] != ' ')
                {
                    return true;
                }
            }
            if(board[0] == board[4] && board[4] == board[8] && board[0] != ' ')
            {
                return true;
            }
            if(board[2] == board[4] && board[4] == board[6] && board[2] != ' ')
            {
                return true;
            }
            return false;
        }

        private bool ValidMove(string move)
        {
            if(move.Length == 2)
            {
                if(move[0] >= '1' && move[0] <= '3' && move[1] >= '1' && move[1] <= '3')
                {
                    if(board[(move[0] - '1') * 3 + (move[1] - '1')] == ' ')
                    {
                        return true;
                    }
                }
            }
            Console.WriteLine("Invalid move! Try another:");
            DrawBoard();
            return false;
        }

        private void DrawBoard()
        {
            Console.WriteLine($"{board[0]}|{board[1]}|{board[2]}");
            Console.WriteLine($"-+-+-");
            Console.WriteLine($"{board[3]}|{board[4]}|{board[5]}");
            Console.WriteLine($"-+-+-");
            Console.WriteLine($"{board[6]}|{board[7]}|{board[8]}");
        }
    }

    class Player
    {
        private string name;
        private char token;

        public Player(string name, char token)
        {
            this.name = name;
            this.token = token;
        }

        
        public string GetName()
        {
            return this.name;
        }

        public char GetToken()
        {
            return this.token;
        }

    }
}
