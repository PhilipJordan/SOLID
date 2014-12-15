namespace MarsRoverKata.Commands
{
    public class FireMissileCommand : ICommand
    {
        private Rover Rover { get; set; }

        public FireMissileCommand(Rover rover)
        {
            Rover = rover;
        }

        public bool Execute()
        {
            return Rover.FireMissle(); //Projectile(typeof(Missile));
        }
    }
}
