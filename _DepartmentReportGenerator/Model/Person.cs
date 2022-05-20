using System;

namespace DepartmentReportGenerator.Model
{
    public partial class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }

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