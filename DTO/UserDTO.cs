namespace DTO
{
    public class UserDTO
    {
        public long tgid { get; set; }
        public string username { get; set; }
        public string displayname { get; set; }
        public bool isActive { get; set; } = true;
        public DateTime atCreated { get; set; }
    }
}
