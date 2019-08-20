using System.Collections.Generic;

namespace Institution.Domain
{
    public interface IAlumnoService
    {
        AlumnoEntity Create(AlumnoEntity alumno);
        AlumnoEntity Update(AlumnoEntity alumno);
        IEnumerable<AlumnoEntity> Get();
    }
}
