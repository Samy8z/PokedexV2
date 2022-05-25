namespace Pokedex.Models
{
    internal class Trainer
    {
        #region Variables
        private String _name;
        private List<PokeInstance> _pokemons;
        #endregion

        #region Getters + Setters
        /// <summary>
        /// Trainer's has at least one pokemon not KO
        /// </summary>
        public bool CanFight
        {
            get
            {
                bool canFight = false;
                foreach (PokeInstance pokemon in this._pokemons)
                {
                    if (!pokemon.IsKo)
                        canFight = true;
                }
                return canFight;

                // Same query with LINQ
                /* return this._pokemons
                 *     .Any(pokemon => !pokemon.IsKo);
				 */
            }
        }

        /// <summary>
        /// Trainer's name
        /// </summary>
        public String Name
        {
            get { return this._name; }
        }

        /// <summary>
        /// Trainer's Pokemon
        /// </summary>
        public List<PokeInstance> Pokemons
        {
            get { return this._pokemons; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="name">Trainer's name</param>
        public Trainer(
            String name
        )
        {
            this._name = name;

            // Init pokemon list
            this._pokemons = new List<PokeInstance>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Add pokemon to inventory
        /// </summary>
        /// <param name="pokemon">Pokemon to add</param>
        /// <returns>True if okay, otherwise false</returns>
        public bool AddPokemon(PokeInstance pokemon)
        {
            // If there are less than 6 pokemons, it's possible to add one more
            if (this._pokemons.Count < 6)
            {
                this._pokemons.Add(pokemon);

                return true;
            }
            return false;
        }

        #endregion
    }
}
