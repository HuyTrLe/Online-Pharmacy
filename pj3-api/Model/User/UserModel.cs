﻿namespace pj3_api.Model.User
{
    public class UserModel
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; } 
        public string Address { get; set; }
        public string Password { get;set; }
        public string FileName { get; set; }
        public int RoleID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
    public class Login
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class Career
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string File { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
    }

    public class UserCareer
    {
        public UserModel User { get; set; }
        public Career Career { get; set; }
    }

    public class ChangePassword
    {
        public int UserID { get; set; }
        public string Password { get; set; }
    }
    public class UploadFile
    {
        public int UserID { get; set; }
        public string Filename { get; set; }
    }
    public class DeleteEducation
    {
        public List<string> listID { get; set; }
    }
    public class UserGet
    {
        public string UserID { get; set; }
    }
}
