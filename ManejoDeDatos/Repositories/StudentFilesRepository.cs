using ManejoDeDatos.Interfaces;
using ManejoDeDatos.Modelos;
using Newtonsoft.Json;

namespace ManejoDeDatos.Repositories;

public class StudentFilesRepository : iStudentRepository
{
    public string _filePath = Path.Combine(FileSystem.AppDataDirectory, "students.json");
    
    public bool CreateStudent(Student student)
    {
        try
        {
            string json_data = JsonConvert.SerializeObject(student);
            File.WriteAllText(_filePath, json_data);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool UpdateStudent(Student student)
    {
        throw new NotImplementedException();
    }

    public bool DeleteStudent(string id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Student> GetStudents()
    {
        throw new NotImplementedException();
    }

    public Student GetStudent(string id)
    {
        Student student = new Student();
        try
        {
            if (File.Exists(_filePath))
            {
                string json_data = File.ReadAllText(_filePath);
                student = JsonConvert.DeserializeObject<Student>(json_data);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return student;
    }
}