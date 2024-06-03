using HealthDiveneSysServer.Entities;
using System.ServiceModel;

namespace HealthDiveneSysServer
{
    [ServiceContract]
    public interface IPlanManagementService
    {
        [OperationContract]
        int AddNewMealPlan(MealPlan plan);

        [OperationContract]
        int UpdateMeal(Meal meal);

        [OperationContract]
        int UpdateMealPlan(MealPlan mealplan); 

        [OperationContract]
        MealPlan GetLastMealPlan(int patientId); 
    }
}
