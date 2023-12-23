using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace DemoProject.Models
{
    public class Businesslayer
    {
        DataLayer dtl = new DataLayer();

        public bool Contact(ContactModal contactModal)
        {
            dtl.Contact(contactModal);
            return true;
        }

        public ContactModal getcontactus()
        {
            DataTable dt = dtl.contactus("getcontactus");
            List<ContactModal> contactus = new List<ContactModal>();

            foreach (DataRow row in dt.Rows) {
            
            ContactModal allcontact = new ContactModal();
                allcontact.ID = Convert.ToInt32(row["ID"]);
                allcontact.Name= row["Name"].ToString();
                allcontact.Email= row["Email"].ToString();
                allcontact.Subject= row["Subject"].ToString();
                allcontact.Message= row["Message"].ToString();
                allcontact.DateTime =row["DateTime"].ToString();
                contactus.Add(allcontact);
            
            }

            ContactModal obj = new ContactModal();
            obj.contactslist = contactus;

            return obj;


        }

    }
}