using Pokedex.Enums;
using Pokedex.Models;
using Pokedex.Models.Moves.Dark;
using Pokedex.Models.Moves.Electric;
using Pokedex.Models.Moves.Fire;
using Pokedex.Models.Moves.Ice;
using Pokedex.Models.Moves.Normal;
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
            Trainer student = new Trainer("Samy");

            // Create our pokemons
            PokeInstance raichu = new PokeInstance(Raichu.Instance, "Raichu", 25, Gender.Male, 0);
            PokeInstance charizard = new PokeInstance(Charizard.Instance, "Charizard", 85, Gender.Male);
            PokeInstance squirtle = new PokeInstance(Squirtle.Instance, "Squirtle", 8, Gender.Female);

            // Learn moves
            raichu.LearnMove(ThunderPunch.Instance);
            raichu.LearnMove(Headbutt.Instance);
            raichu.LearnMove(Thunderbolt.Instance);
            charizard.LearnMove(Crunch.Instance);
            charizard.LearnMove(Overheat.Instance);
            charizard.LearnMove(Rage.Instance);
            squirtle.LearnMove(Tackle.Instance);
            squirtle.LearnMove(IceBeam.Instance);
            squirtle.LearnMove(Surf.Instance);

            // Add pokemons in our inventory
            student.AddPokemon(raichu);
            student.AddPokemon(charizard);
            student.AddPokemon(squirtle);

            // Create the rival
            Trainer rival = new Trainer("Stranger");

            // Create rival's pokemons
            PokeInstance bob = new PokeInstance(Absol.Instance, "Absol", 100, Gender.Unknown, 240);
            PokeInstance nico = new PokeInstance(GiratinaAltered.Instance, "Giratina", 100, Gender.Unknown, 410);
            PokeInstance tki = new PokeInstance(Arceus.Instance, "Arceus", 100, Gender.Unknown, 350);

            // Learn moves
            bob.LearnMove(Slash.Instance);
            nico.LearnMove(Judgment.Instance);
            tki.LearnMove(Judgment.Instance);
            
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
            Console.WriteLine("The winner is {}!", winner.Name);
        }
    }
}