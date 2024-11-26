using ManejoDeDatos.Interfaces;
using ManejoDeDatos.Modelos;
using ManejoDeDatos.Repositories;

namespace ManejoDeDatos;

public partial class MainPage : ContentPage
{

    public iStudentRepository _studentRepository;
    public Student student = new Student();
    
    public MainPage()
    {
        InitializeComponent();
        _studentRepository = new StudentFilesRepository();
        
        student = _studentRepository.GetStudent("1");
        
        BindingContext = student; 
    }
    
    private async void btn_save_Clicked(object? sender, EventArgs e)
    {
        Student student = new Student
        {
            Id = Int32.Parse(editor_id.Text),
            Name = editor_nombre.Text,
            Carrera = editor_carrera.Text
        };
        
        bool result = _studentRepository.CreateStudent(student);

        if (result)
        {
            await DisplayAlert("Exito", "Estudiante guardado", "OK");
        }
        else
        {
            await DisplayAlert("Error", "Error al guardar el estudiante", "OK");
        }
        
        Navigation.PushAsync(new MainPage());
    }
}