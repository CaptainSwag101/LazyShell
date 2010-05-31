using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL.Encryption
{
    public class Stamp
    {
        private bool dateStamp; public bool DateStamp { get { return this.dateStamp; } set { this.dateStamp = value; } }
        private bool published; public bool Published { get { return this.published; } set { this.published = value; } }
        private bool locked; public bool Locked { get { return this.locked; } set { this.locked = value; } }
        private string authorName; public string Name { get { return this.authorName; } set { this.authorName = value; } }
        private string authorComments; public string Comments { get { return this.authorComments; } set { this.authorComments = value; } }
        private string password; public string Password { get { return this.password; } set { this.password = value; } }
        private string date; public string Date { get { return this.date; } set { this.date = value; } }
        private bool invalidated; public bool Invalidated { get { return this.invalidated; } set { this.invalidated = value; } }
        public Stamp()
        {
            this.dateStamp = false;
            this.published = false;
            this.locked = false;
            this.authorName = "Square";
            this.authorComments = "Developer: Square\nPublisher: Nintendo\nReleased: 1996";
            this.date = "";
            this.password = "14zy5h311";
        }
        public void Invalidate()
        {
            this.Name = "Invalid Signature";
            this.Comments = "Invalid Signature";
            this.Date = "Invalid Signature";
            this.dateStamp = true;
            this.published = false;
            this.locked = false;
            this.password = null;
            this.invalidated = true;
        }
        public void Clone(Stamp stamp)
        {
            this.dateStamp = stamp.DateStamp;
            this.published = stamp.Published;
            this.locked = stamp.Locked;
            this.authorName = stamp.Name;
            this.authorComments = stamp.Comments;
            this.date = stamp.Date;
            this.password = stamp.Password;
            this.invalidated = stamp.Invalidated;
        }
        public void Clear()
        {
            this.dateStamp = false;
            this.published = false;
            this.locked = false;
            this.authorName = "Square";
            this.authorComments = "Developer: Square\nPublisher: Nintendo\nReleased: 1996";
            this.date = "";
            this.password = "14zy5h311";
        }
    }
}
