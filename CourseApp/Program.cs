using CourseApp.Controllers;
//add enum
//add try catch
UserController userController = new();
StudentController studentController = new();

start:  beginning: Console.WriteLine("Please choose 1: Login, 2: Register");
string numStr = Console.ReadLine();
int num;
bool isTrueNum = int.TryParse(numStr, out num);

if(num == 1)
{
    userController.Login();
    Console.WriteLine("Welcome to our application");
    app:  Console.WriteLine("Please select one option: Group operations: 1-Create, 2-Delete, 3-Edit," +
           " 4-GetById, 5-GetAll, 6-Search, 7-Sorting | Student operations : 8-Create, 9-Delete," +
           " 10-Edit, 11-GetById, 12-GetAll, 13 - Filter, 14 - Search");
    string option = Console.ReadLine();

    switch (option)
    {
        case ("1"):
            break;
        case ("2"):
            break;
        case ("3"):
            break;
        case ("4"):
            break;
        case ("5"):
            break;
        case ("6"):
            break;
        case ("7"):
            break;
        case ("8"):
            studentController.Create();
            goto app;
            break;
        case ("9"):
            studentController.Delete();
            goto app;
            break;
        case ("10"):
           
            break;
        case ("11"):
            studentController.GetById();
            goto app;
            break;
        case ("12"):
            studentController.GetAll();
            goto app;
            break;
        case ("13"):
            studentController.Filter();
            goto app;
            break;
        case ("14"):
            studentController.Search();
            goto app;
            break;
        default:
            break;
    }

}
else if(num == 2)
{
    userController.Register();
    goto start;
}







