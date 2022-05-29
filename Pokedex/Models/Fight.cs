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
        private PokeInstance _pokemonA;
        private PokeInstance _pokemonB;

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


        private PokeInstance PokemonA
        {
            get
            {
                return this._pokemonA;
            }
            set
            {
                this._pokemonA = value;
            }
        }

        private PokeInstance PokemonB
        {
            get
            {
                return this._pokemonB;
            }
            set
            {
                this._pokemonB = value;
            }
        }

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
        
        public PokeInstance ChoosePokemon(Trainer trainer)
        {

            string displayPokemonChoiceA = $"{trainer.Name} choose your pokemon\n\n";
            Console.SetCursorPosition((Console.WindowWidth - displayPokemonChoiceA.Length) / 2, Console.CursorTop);
            Console.WriteLine(displayPokemonChoiceA);
            
            int count = 1;
            foreach (PokeInstance poke in trainer.Pokemons)
            {
                if(!poke.IsKo)
                {
                    Console.WriteLine("{0} -- {1}\n\n", count, poke);
                    count++;
                }
            }

            int number = 0;
            
            Console.Write("Enter pokemon number : ");
            do
            {
                if (!int.TryParse(Console.ReadLine(), out number) || number < 1 || number > count-1)
{
                    Console.Write("This is not valid input. Please enter an integer value:\n");
                    number = 0;
                    
                }
                


            } while (number == 0);

            
            
            count = 1;
            PokeInstance choosePokemon = null;
            
            foreach (PokeInstance poke in trainer.Pokemons)
            {
                if (!poke.IsKo)
                {
                    if (count == number)
                    {
                        choosePokemon = poke;
                        
                    }
                    count++;
                    
                }
            }

            string pokemonGoA = $"I choose you {choosePokemon.Pokemon.Name}, Go ! \n\n";
            Console.SetCursorPosition((Console.WindowWidth - pokemonGoA.Length) / 2, Console.CursorTop);
            Console.WriteLine(pokemonGoA);
            Console.ReadLine();
            
            string seperator = $"______________________________________________________________________________________________________________________\n\n";
            Console.SetCursorPosition((Console.WindowWidth - seperator.Length) / 2, Console.CursorTop);
            Console.WriteLine(seperator);

            return choosePokemon;
        }
        
        public void Attack(PokeInstance attacker, PokeInstance defender)
        {
            string displayPokemonAttack = $"{attacker.Pokemon.Name} choose your attack\n\n";
            Console.SetCursorPosition((Console.WindowWidth - displayPokemonAttack.Length) / 2, Console.CursorTop);
            Console.WriteLine(displayPokemonAttack);
            
            for (int i = 0; i < attacker.Moves.Count(); i++)
            {
                if (attacker.Moves[i] != null) 
                { 
                    Console.WriteLine("{0} -- {1}\n\n", i+1, attacker.Moves[i].NameEn);
                }
            }

            int moveCount = 0;
            for (int i = 0; i < 4; i++)
            {
                if (attacker.Moves[i] != null)
                {
                    moveCount++;
                }
            }

            int number = 0;

            Console.Write("Enter moves number : ");
            do
            {
                if (!int.TryParse(Console.ReadLine(), out number) || number < 1 || number > moveCount)
                {
                    Console.Write("This is not valid input. Please enter an integer value:");
                    number = 0;

                }
                
            } while (number == 0);

            

            string pokemonUseAttack = $"{attacker.Pokemon.Name} use {attacker.Moves[number-1].NameEn} ! \n\n";
            Console.SetCursorPosition((Console.WindowWidth - pokemonUseAttack.Length) / 2, Console.CursorTop);
            Console.WriteLine(pokemonUseAttack);
            Console.ReadLine();

            int damage = DamageHandler.CalcDamage(attacker, defender, attacker.Moves[number-1], this._weather);

            defender.TakeDamage(damage);
            string takeDmg = null;
            if (defender.IsKo)
            {
                takeDmg = $"{defender.Pokemon.Name} is KO ! \n\n";
            }
            else
            {
                takeDmg = $"{defender.Pokemon.Name} has {defender.Hp} HP ! \n\n";
            }
            
            Console.SetCursorPosition((Console.WindowWidth - takeDmg.Length) / 2, Console.CursorTop);
            Console.WriteLine(takeDmg);
            Console.ReadLine();

            string seperator = $"______________________________________________________________________________________________________________________\n\n";
            Console.SetCursorPosition((Console.WindowWidth - seperator.Length) / 2, Console.CursorTop);
            Console.WriteLine(seperator);
            
        }

        /// <summary>
        /// Handles the general outline of a fight
        /// </summary>
        /// <returns>The winning player</returns>
        public Trainer DoCombat()
        {
            int turn = 1;
            
            string displayWeather = $"Weather: {this._weather.Name} \n\n";
            Console.SetCursorPosition((Console.WindowWidth - displayWeather.Length) / 2, Console.CursorTop);
            Console.WriteLine(displayWeather);

            // While both players can still fight
            while (this._playerA.CanFight && this._playerB.CanFight)
            {
                if (this.PokemonA == null)
                {
                    this.PokemonA = ChoosePokemon(this._playerA);
                }
                if (this.PokemonB == null)
                {
                    this.PokemonB = ChoosePokemon(this._playerB);
                }
                 
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


            Attack(this.PokemonA, this.PokemonB);
            
            if (!this.PokemonB.IsKo)
            {
                Attack(this.PokemonB, this.PokemonA);
            }
            else
            {
                this.PokemonB = null;
            }
            if (this.PokemonA.IsKo)
            {
                this.PokemonA = null;
            }








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