using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;
using Pokedex.Models.Weathers;

namespace Pokedex.Models
{
	/// <summary>
	/// Represents a Pokemon between two Trainers
	/// </summary>
	/// <see cref="Trainer"/>
    class Fight
    {
        #region Variables
        private Trainer _playerA;
        private Trainer _playerB;

        private Weather _weather;
        #endregion

        #region Getters + Setters
		/// <summary>
		/// The first player
		/// </summary>
        public Trainer PlayerA
        { get { return this._playerA; } }
        
		/// <summary>
		/// The second player
		/// </summary>
		/// <value></value>
		public Trainer PlayerB
        { get { return this._playerB; } }

		/// <summary>
		/// The current weather effect active
		/// </summary>
        public Weather Weather
        {
            get { return this._weather; }
            set
			{ 
				this._weather.OnExit();
				this._weather = value;
				this._weather.OnEnter();
			}
        }
        #endregion

        #region Constructors
        /// <summary>
		/// The default constructor
		/// </summary>
		/// <param name="playerA">The first player</param>
		/// <param name="playerB">The second player</param>
		public Fight
        (
            Trainer playerA,
            Trainer playerB
        )
        {
            this._playerA = playerA;
            this._playerB = playerB;

            this._weather = WeatherClear.Instance;
        }
		
		/// <summary>
		/// Superseeds the default constructor with a Weather paramater
		/// </summary>
		/// <param name="weather"></param>
		/// <inheritdoc cref="Fight(Trainer, Trainer)"/>
		public Fight
		(
			Trainer playerA,
			Trainer playerB,
			Weather weather
		) : this(playerA, playerB)
		{
			this._weather = weather;
		}
        #endregion

        #region Methods
        
        
        public void Display()
        {
            
            string displayWeather = $"Weather: {this._weather.Name} \n\n";
            Console.SetCursorPosition((Console.WindowWidth - displayWeather.Length) / 2, Console.CursorTop);
            Console.WriteLine(displayWeather);

            string displayPokemonChoiceA = $"{this._playerA.Name} choose your pokemon\n\n";
            Console.SetCursorPosition((Console.WindowWidth - displayPokemonChoiceA.Length) / 2, Console.CursorTop);
            Console.WriteLine(displayPokemonChoiceA);
            
            Console.WriteLine("0 -- {0}\n\n", this._playerA.Pokemons[0].ToString());
            Console.WriteLine("1 -- {0}\n\n", this._playerA.Pokemons[1].ToString());
            Console.WriteLine("2 -- {0}\n\n", this._playerA.Pokemons[2].ToString());
            string pokeChoiceA = Console.ReadLine();
            int numberA = Convert.ToInt32(pokeChoiceA);
            
            Console.WriteLine("Press enter to continue\n\n");
            Console.ReadLine();
            string pokemonGoA = $"{this._playerA.Pokemons[numberA].Nickname}, Go ! \n\n";
            Console.SetCursorPosition((Console.WindowWidth - pokemonGoA.Length) / 2, Console.CursorTop);
            Console.WriteLine(pokemonGoA);



            string displayPokemonChoiceB = $"{this._playerB.Name} choose your pokemon\n\n";
            Console.SetCursorPosition((Console.WindowWidth - displayPokemonChoiceB.Length) / 2, Console.CursorTop);
            Console.WriteLine(displayPokemonChoiceB);

            Console.WriteLine("0 -- {0}\n\n", this._playerB.Pokemons[0].ToString());
            Console.WriteLine("1 -- {0}\n\n", this._playerB.Pokemons[1].ToString());
            Console.WriteLine("2 -- {0}\n\n", this._playerB.Pokemons[2].ToString());
            string pokeChoiceB = Console.ReadLine();
            int numberB = Convert.ToInt32(pokeChoiceA);

            Console.WriteLine("Press enter to continue\n\n");
            Console.ReadLine();
            Console.WriteLine($"{this._playerB.Pokemons[numberB].Nickname}, Go ! \n\n");
        }
        /// <summary>
        /// Handles the general outline of a fight
        /// </summary>
        /// <returns>The winning player</returns>
        public Trainer DoCombat()
        {
            int turn = 1;
            Display();
            

            // While both players can still fight
            while (this._playerA.CanFight
				   && this._playerB.CanFight)
            {
                this.DoTurn(turn);
                
                turn++;

            }
            
            return this._playerA.CanFight
                   ? this._playerA
                   : this._playerB;

            
            /* cond ? if_true : if_false */
            
            /* if (this._playerA.CanFight)
             *     return this._playerA;
             * return this._playerB;
             */
        }

		/// <summary>
		/// Handles the finer workings of a singular turn
		/// </summary>
		/// <see cref="DamageHandler.CalcDamage(PokeInstance, PokeInstance, PokeMove, Weather)"/>
		/// <see cref="Trainer.CanFight"/>
		/// <see cref="PokeInstance.TakeDamage(int)"/>
		/// <see cref="Fight.Weather"/>
        private void DoTurn(int turn)
        {
			this._weather.OnTurnStart(this);

            Console.WriteLine("Turn " + turn);
            Console.ReadLine();
            



            /*Console.WriteLine("Player 2: " + this._playerB.Name);
            Console.WriteLine("Weather: " + this._weather.Name);*/




            // Code to implement for project
            
            // To calc damage, use DamageHandler.CalcDamage(attacker, defender, move, this._weather);

            // To apply damage, use defender.TakeDamage(damage);
            // To apply damage, use pokemonInstance.TakeDamage(damage)
            // To get trainer pokemons, use trainer.Pokemons
            // To check if a trainer has at least on pokemon fit for combat, use trainer.CanFight


            // You can simulate each trainer turn, or develop a simple AI to simulate the second trainer's turn
            
            // (simple means not like Arthur, okay ?)

            // Change the weather:
            // this.Weather = newWeather.Instance;

            this._weather.OnTurnEnd(this);
        }
        #endregion
    }
}