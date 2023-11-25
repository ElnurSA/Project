using CourseApp.Controllers;
//add enum
//add try catch
//search to lower2
//search error message does not appear
//Capacity logic

UserController userController = new();
StudentController studentController = new();
GroupController groupController = new();

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
            groupController.Create();
            goto app;
        case ("2"):
            groupController.Delete();
            goto app;
        case ("3"):
            groupController.Edit();
            goto app;
        case ("4"):
            groupController.GetById();
            goto app;
        case ("5"):
            groupController.GetAll();
            goto app;
        case ("6"):
            groupController.Search();
            goto app;
        case ("7"):
            groupController.Sort();
            goto app;
        case ("8"):
            studentController.Create();
            goto app;
        case ("9"):
            studentController.Delete();
            goto app;
        case ("10"):
            studentController.Edit();
            goto app;
        case ("11"):
            studentController.GetById();
            goto app;
        case ("12"):
            studentController.GetAll();
            goto app;
        case ("13"):
            studentController.Filter();
            goto app;
        case ("14"):
            studentController.Search();
            goto app;
        default:
            Console.WriteLine("Wrong input try again!");
            goto app;
    }

}
else if(num == 2)
{
    userController.Register();
    goto start;
}
else
{
    Console.WriteLine("Your input must be either 1 or 2!");
    goto start;
}







