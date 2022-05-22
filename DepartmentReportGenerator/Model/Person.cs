using System;
using System.Runtime.Serialization;

namespace ReportGenerator.Model
{
    public partial class Person
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Patronymic { get; set; }

        [IgnoreDataMember]
        public string FullName
        {
            get
            {
                if (string.IsNullOrEmpty(FirstName))
                {
                    throw new NullReferenceException("FirstName null or empty");
                }
                if (string.IsNullOrEmpty(LastName))
                {
                    throw new NullReferenceException("LastName null or empty");
                }

                return string.IsNullOrEmpty(Patronymic)
                    ? $"{LastName} {FirstName}"
                    : $"{LastName} {FirstName} {Patronymic}";
            }
        }

        [IgnoreDataMember]
        public string ShortNameWithFirstInitials
        {
            get
            {
                if (string.IsNullOrEmpty(FirstName))
                {
                    throw new NullReferenceException("FirstName is null or empty");
                }
                if (string.IsNullOrEmpty(LastName))
                {
                    throw new NullReferenceException("LastName is null or empty");
                }

                return string.IsNullOrEmpty(Patronymic)
                    ? $"{FirstName[0]}. {LastName}"
                    : $"{FirstName[0]}.{Patronymic[0]}. {LastName}";
            }        
        }

        [IgnoreDataMember]
        public string ShortNameWithFirstLastName
        {
            get
            {
                if (string.IsNullOrEmpty(FirstName))
                {
                    throw new NullReferenceException("FirstName is null or empty");
                }
                if (string.IsNullOrEmpty(LastName))
                {
                    throw new NullReferenceException("LastName is null or empty");
                }

                return string.IsNullOrEmpty(Patronymic)
                    ? $"{LastName} {FirstName[0]}."
                    : $"{LastName} {FirstName[0]}.{Patronymic[0]}.";
            }    
        }
    }
}