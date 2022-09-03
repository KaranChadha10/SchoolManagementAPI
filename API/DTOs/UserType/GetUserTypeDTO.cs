namespace API.DTOs.UserType
{
    public class GetUserTypeDTO
    {
        public long Id { get; set; }
        public string  Type { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
