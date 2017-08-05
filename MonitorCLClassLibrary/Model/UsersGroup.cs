namespace MonitorCLClassLibrary.Model
{
    public class UsersGroup
    {
        public int UsersGroupId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public UsersGroup Parent { get; set; }
    }
}
