namespace UserService.Entities
{
    public partial class Departments
    {
        public int Departmentid { get; set; }
        public string Name { get; set; }
        public string ImapUsername { get; set; }
        public string Email { get; set; }
        public bool EmailFromHeader { get; set; }
        public string Host { get; set; }
        public string Password { get; set; }
        public string Encryption { get; set; }
        public int DeleteAfterImport { get; set; }
        public string CalendarId { get; set; }
        public bool Hidefromclient { get; set; }
    }
}
