using System.Linq;
using System.Collections.Generic;
using Institution.Infrastructure;

namespace Institution.Domain
{
    public class AlumnoService : IAlumnoService
    {
        readonly IContext<InstitutionContext> context;
        readonly IRepository<InstitutionContext, AlumnoEntity> repository;

        public AlumnoService(
            IContext<InstitutionContext> context,
            IRepository<InstitutionContext, AlumnoEntity> repository)
        {
            this.context = context;
            this.repository = repository;
        }

        public IEnumerable<AlumnoEntity> Get() => repository.Get(orderBy: o => o.OrderBy(b => b.Apellido));

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
