using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoProject.Models
{
    public class ContactModal
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string DateTime { get; set; }
        public int IsActive { get; set; }
        public string Password { get; set; }
            

        public List<ContactModal> contactslist {  get; set; }   
       
    }
}