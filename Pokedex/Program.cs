using Pokedex.Enums;
using Pokedex.Models;
using Pokedex.Models.Moves.Dark;
using Pokedex.Models.Moves.Dragon;
using Pokedex.Models.Moves.Electric;
using Pokedex.Models.Moves.Fighting;
using Pokedex.Models.Moves.Fire;
using Pokedex.Models.Moves.Grass;
using Pokedex.Models.Moves.Ground;
using Pokedex.Models.Moves.Ice;
using Pokedex.Models.Moves.Normal;
using Pokedex.Models.Moves.Steel;
using Pokedex.Models.Moves.Water;
using Pokedex.Models.Pokemons.Dark;
using Pokedex.Models.Pokemons.Electric;
using Pokedex.Models.Pokemons.Fire;
using Pokedex.Models.Pokemons.Ghost;
using Pokedex.Models.Pokemons.Normal;
using Pokedex.Models.Pokemons.Water;
using Pokedex.Models.Weathers;

namespace Pokedex
{
    class Program
    {
        static void Main(String[] args)
        {
            // Create our trainer
            Trainer student = new Trainer("Chuka");

            // Create our pokemons
            PokeInstance arcanine = new PokeInstance(Arcanine.Instance, "Arcanine", 25, Gender.Male);
            PokeInstance eevee = new PokeInstance(Eevee.Instance, "Eevee", 85, Gender.Female);
            PokeInstance luxray = new PokeInstance(Luxray.Instance, "Luxray", 8, Gender.Male);

            // Learn moves
            arcanine.LearnMove(FlameCharge.Instance);
            arcanine.LearnMove(Incinerate.Instance);
            arcanine.LearnMove(GigaImpact.Instance);
            eevee.LearnMove(IronTail.Instance);
            eevee.LearnMove(DoubleKick.Instance);
            eevee.LearnMove(TakeDown.Instance);
            luxray.LearnMove(Thunderbolt.Instance);
            luxray.LearnMove(Spark.Instance);
            luxray.LearnMove(RisingVoltage.Instance);

            // Add pokemons in our inventory
            student.AddPokemon(arcanine);
            student.AddPokemon(eevee);
            student.AddPokemon(luxray);

            // Create the rival
            Trainer rival = new Trainer("Samy");

            // Create rival's pokemons
            PokeInstance bob = new PokeInstance(Charizard.Instance, "Charizard", 100, Gender.Unknown,80);
            PokeInstance nico = new PokeInstance(Kyogre.Instance, "Kyogre", 100, Gender.Unknown,188);
            PokeInstance tki = new PokeInstance(Typhlosion.Instance, "Typhlosion", 100, Gender.Unknown,30);

            // Learn moves
            bob.LearnMove(Overheat.Instance);
            bob.LearnMove(MysticalFire.Instance);
            bob.LearnMove(Inferno.Instance);
            nico.LearnMove(Liquidation.Instance);
            nico.LearnMove(IronHead.Instance);
            nico.LearnMove(HiddenPower.Instance);
            tki.LearnMove(SolarBeam.Instance);
            tki.LearnMove(FlameCharge.Instance);
            tki.LearnMove(StompingTantrum.Instance);

            // Add pokemons to rival inventory
            rival.AddPokemon(bob);
            rival.AddPokemon(nico);
            rival.AddPokemon(tki);

            // Annouce the fight!
            string Annoucement = $"{rival.Name} challenged {student.Name} to a Pokemon duel!\n\n";
            Console.SetCursorPosition((Console.WindowWidth - Annoucement.Length) / 2, Console.CursorTop);
            Console.WriteLine(Annoucement);
            

            // Create the fight instance
            Fight challenge = new Fight(student, rival);

			// Enter the octogon
			Trainer winner = challenge.DoCombat();

			// Annouce the winner
            Console.WriteLine("The winner is {0}!", winner.Name);
        }
    }
}