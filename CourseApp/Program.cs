using CourseApp.Controllers;
using Service.Helpers.Enums;
//add enum

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
    string optionStr = Console.ReadLine();
    int option;
    bool isOptionInt = int.TryParse(optionStr, out option);

    switch (option)
    {
        case (int)OperationTypes.CreateGroup:
            groupController.Create();
            goto app;
        case (int)OperationTypes.DeleteGroup:
            groupController.Delete();
            goto app;
        case (int)OperationTypes.EditGroup:
            groupController.Edit();
            goto app;
        case (int)OperationTypes.GetByIdGroup:
            groupController.GetById();
            goto app;
        case (int)OperationTypes.GetAllGroup:
            groupController.GetAll();
            goto app;
        case (int)OperationTypes.SearchGroup:
            groupController.Search();
            goto app;
        case (int)OperationTypes.SortingGroup:
            groupController.Sort();
            goto app;
        case (int)OperationTypes.CreateStudent:
            studentController.Create();
            goto app;
        case (int)OperationTypes.DeleteStudent:
            studentController.Delete();
            goto app;
        case (int)OperationTypes.EditStudent:
            studentController.Edit();
            goto app;
        case (int)OperationTypes.GetByIdStudent:
            studentController.GetById();
            goto app;
        case (int)OperationTypes.GetAllStudent:
            studentController.GetAll();
            goto app;
        case (int)OperationTypes.FilterStudent:
            studentController.Filter();
            goto app;
        case (int)OperationTypes.SearchStudent:
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







