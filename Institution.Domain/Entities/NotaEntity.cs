namespace Institution.Domain
{
    public class NotaEntity
    {
        public int Id { get; set; }
        public int IdAsignatura { get; set; }
        public int IdAlumno { get; set; }
        public float Valor { get; set; }
        public AsignaturaEntity Asignatura { get; set; }
        public AlumnoEntity Alumno { get; set; }
    }
}
