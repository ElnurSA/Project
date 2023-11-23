using CourseApp.Controllers;

UserController userController = new();

beginning: Console.WriteLine("Please choose 1: Register, 2: GetAll, 3: Login");
string num = Console.ReadLine();


switch (num)
{
    case "1":
        userController.Register();
        goto beginning;
        break;
    case "2":
        userController.GetAll();
        goto beginning;
        break;
    case "3":
        userController.Login();
        goto beginning;
        break;
    default:
        break;
}
userController.Register();