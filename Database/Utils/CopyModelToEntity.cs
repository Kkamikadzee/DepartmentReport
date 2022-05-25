namespace Database.Utils
{
    public static class CopyModelToEntity
    {
        public static void Copy(ReportGenerator.Model.Teacher model, Model.Teacher entity)
        {
            entity.ScienceDegree = model.ScienceDegree;
            entity.JobVacancy = model.JobVacancy;
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.Patronymic = model.Patronymic;
        }
    }
}