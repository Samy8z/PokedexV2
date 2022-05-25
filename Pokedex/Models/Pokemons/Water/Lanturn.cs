// https://www.pokemon.com/us/pokedex/171

using Pokedex.Models.Moves.Normal;
using Pokedex.Models.Moves.Water;
using Pokedex.Models.Moves.Ice;
using Pokedex.Models.Moves.Electric;
using Pokedex.Models.Moves.Bug;
using Pokedex.Models.Moves.Flying;
using Pokedex.Models.Moves.Dark;
using Pokedex.Models.Moves.Fairy;
using Pokedex.Models.Types;

namespace Pokedex.Models.Pokemons.Water
{
    internal class Lanturn : Pokemon
    {
        #region Variables
        private static Pokemon? _instance = null;
        #endregion

        #region Getters + Setters
        public static Pokemon Instance
        {
            get { return _instance ?? (_instance = new Lanturn()); }
        }
        #endregion
        
        #region Constructors
        private Lanturn()
            : base(
                171,
                "Lanturn",
                "Lanturn",
                TypeWater.Instance,
                TypeElectric.Instance,
                12,
                225,
                "Light Pokémon",
                "Pokémon Lumière",
                "This Pokémon flashes a bright light that blinds its prey. This creates an opening for it to deliver an electrical attack.",
                "Il dégage une vive lumière pour éblouir ses proies, puis leur inflige un choc électrique bien senti.",
                125,
                58,
                58,
                76,
                76,
                67
            )
        { }
        #endregion

        #region Methods
        /// <summary>
        /// Implementation of the parent method
        /// </summary>
        /// <seealso cref="Pokemon.InitMoveList"/>
        public override void InitMoveList()
        {
            this._moveList = new List<PokeMove>();
            this._moveList.Add(TakeDown.Instance);
            this._moveList.Add(DoubleEdge.Instance);
            this._moveList.Add(WaterGun.Instance);
            this._moveList.Add(HydroPump.Instance);
            this._moveList.Add(Surf.Instance);
            this._moveList.Add(IceBeam.Instance);
            this._moveList.Add(Blizzard.Instance);
            this._moveList.Add(BubbleBeam.Instance);
            this._moveList.Add(HyperBeam.Instance);
            this._moveList.Add(Thunderbolt.Instance);
            this._moveList.Add(Thunder.Instance);
            this._moveList.Add(Waterfall.Instance);
            this._moveList.Add(Bubble.Instance);
            this._moveList.Add(Snore.Instance);
            this._moveList.Add(ZapCannon.Instance);
            this._moveList.Add(IcyWind.Instance);
            this._moveList.Add(Spark.Instance);
            this._moveList.Add(HiddenPower.Instance);
            this._moveList.Add(Whirlpool.Instance);
            this._moveList.Add(Facade.Instance);
            this._moveList.Add(SecretPower.Instance);
            this._moveList.Add(Dive.Instance);
            this._moveList.Add(SignalBeam.Instance);
            this._moveList.Add(Bounce.Instance);
            this._moveList.Add(WaterPulse.Instance);
            this._moveList.Add(Brine.Instance);
            this._moveList.Add(SuckerPunch.Instance);
            this._moveList.Add(AquaTail.Instance);
            this._moveList.Add(GigaImpact.Instance);
            this._moveList.Add(Discharge.Instance);
            this._moveList.Add(ChargeBeam.Instance);
            this._moveList.Add(Round.Instance);
            this._moveList.Add(Scald.Instance);
            this._moveList.Add(VoltSwitch.Instance);
            this._moveList.Add(WildCharge.Instance);
            this._moveList.Add(DazzlingGleam.Instance);
            this._moveList.Add(RisingVoltage.Instance);
        }
        #endregion
    }
}