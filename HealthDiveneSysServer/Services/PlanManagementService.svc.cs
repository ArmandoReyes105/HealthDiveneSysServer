using HealthDiveneSysServer.Converters;
using HealthDiveneSysServer.Entities;
using HealthDiveneSysServer.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace HealthDiveneSysServer
{
    public class PlanManagementService : IPlanManagementService
    {
        public int AddNewMealPlan(MealPlan plan)
        {
            int result = 0;

            using (var context = new HealthDivineEntities())
            {
                try
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            MealPlans dbMealPlan = EntityToDBEntity.ConvertMealPlan(plan); 
                            context.MealPlans.Add(dbMealPlan);
                            context.SaveChanges(); 

                            foreach (var meal in plan.Meals)
                            {
                                Meals dbMeal = EntityToDBEntity.ConvertMeal(meal);
                                dbMeal.IdMealPlan = dbMealPlan.IdMealPlan; 
                                context.Meals.Add(dbMeal);
                                context.SaveChanges(); 
                            }

                            context.SaveChanges();

                            result = 1;
                            transaction.Commit();

                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine("Ocurrio un error: " + ex.ToString());
                            transaction.Rollback();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Ocurrio un error: " + ex.ToString());
                }
            }

            return result;
        }

        public int UpdateMeal(Meal meal)
        {
            int result = 0;

            using (var context = new HealthDivineEntities())
            {
                try
                {
                    var dbMeal = context.Meals.Where(d => d.IdMeal == meal.IdMeal).FirstOrDefault();

                    dbMeal.Equivalences = meal.Equivalences; 
                    dbMeal.MealExamples = meal.MealExamples;
                    dbMeal.MealType = meal.MealType;

                    result = context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            }

            return result;
        }

        public int UpdateMealPlan(MealPlan mealPlan)
        {
            int result = 0;

            using (var context = new HealthDivineEntities())
            {
                try
                {
                    var dbMealPlan = context.MealPlans.Where(d => d.IdMealPlan == mealPlan.IdMealPlan).FirstOrDefault();

                    dbMealPlan.PlanDescription = mealPlan.PlanDescription;
                    dbMealPlan.Recommendations = mealPlan.Recommendations;
                    dbMealPlan.Comments = mealPlan.Comments; 

                    result = context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            }

            return result;
        }

        public MealPlan GetLastMealPlan(int patientId)
        {
            MealPlan mealPlan = null;

            using (var context = new HealthDivineEntities())
            {
                try
                {
                    var dbPlan = context.MealPlans.Where(e => e.IdPatient == patientId).OrderByDescending(e => e.PlanDate).FirstOrDefault();

                    if (dbPlan != null)
                    {
                        var meals = context.Meals.Where(d => d.IdMealPlan == dbPlan.IdMealPlan);
                        List<Meal> mealList = new List<Meal>();

                        foreach (Meals meal in meals)
                        {
                            mealList.Add(DBEntityToEntity.ConvertMeal(meal)); 
                        }

                        mealPlan = DBEntityToEntity.ConvertMealPlan(dbPlan, mealList);
                    }
                    else
                    {
                        mealPlan = new MealPlan();
                        mealPlan.IdMealPlan = 0;
                        mealPlan.Comments = "Not found";
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            }

            return mealPlan;
        }
    }
}
