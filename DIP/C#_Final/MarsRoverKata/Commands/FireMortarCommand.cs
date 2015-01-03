namespace MarsRoverKata.Commands
{
    public class FireMortarCommand : ICommand
    {
        private Rover Rover { get; set; }

        public FireMortarCommand(Rover rover)
        {
            Rover = rover;
        }

        public bool Execute()
        {
            return Rover.FireMortar();// Projectile(typeof(Mortar));
        }
    }
}
