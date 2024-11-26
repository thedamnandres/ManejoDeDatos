using ManejoDeDatos.Modelos;
namespace ManejoDeDatos.Interfaces;

public interface iStudentRepository
{
    bool CreateStudent(Student student);
    bool UpdateStudent(Student student);
    bool DeleteStudent(string id);
    IEnumerable<Student> GetStudents();
    Student GetStudent(string id);
}