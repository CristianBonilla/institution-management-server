using Institution.Infrastructure;

namespace Institution.Domain
{
    public class AlumnoService
    {
        readonly IContext<InstitutionContext> context;
        readonly IRepository<AlumnoEntity> repository;

        public AlumnoService(
            IContext<InstitutionContext> context,
            IRepository<AlumnoEntity> repository)
        {
            this.context = context;
            this.repository = repository;
        }

        public AlumnoEntity Create(AlumnoEntity alumno)
        {
            AlumnoEntity created = repository.Create(alumno);
            context.Save();

            return created;
        }

        public AlumnoEntity Update(AlumnoEntity alumno)
        {
            AlumnoEntity updated = repository.Update(alumno);
            context.Save();

            return updated;
        }
    }
}
