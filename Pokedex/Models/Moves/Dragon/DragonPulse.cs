using Pokedex.Enums;
using Pokedex.Models.Types;

namespace Pokedex.Models.Moves.Dragon
{
    internal class DragonPulse : PokeMove
    {
        #region Variables
        /// <summary>
        /// Nullable variable (use of ? after type)
        /// </summary>
        private static PokeMove? _instance = null;
        #endregion

        #region Getters + Setters
        /// <summary>
        /// If no instance, create it
        /// </summary>
        public static PokeMove Instance
        {
            get { return _instance ?? (_instance = new DragonPulse()); }
        }
        #endregion
        
        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        private DragonPulse()
            : base(
                406,
                "Dragon Pulse",
                "Draco-Choc",
                "The target is attacked with a shock wave generated by the user’s gaping mouth.",
                "Le lanceur ouvre la bouche pour envoyer une onde de choc qui frappe l’ennemi.",
                85,
                100,
                DamageClass.Special,
                TypeDragon.Instance
            ) { }
        #endregion
    }
}