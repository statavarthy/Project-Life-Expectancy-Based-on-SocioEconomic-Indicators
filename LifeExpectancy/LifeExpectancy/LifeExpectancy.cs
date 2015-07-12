///////////////////////////////////////////////////////////////////////
// LifeExpectancy.cs - Program for calculating Life Expectancy       //
// Language:    C#, .Net Framework 4.0                               //
// Application: Open Source Computing, Project, Summer 2015          //
// Author:      SMRUTI TATAVARTHY, COMP 412, Loyola University       //
//              statavarthy@luc.edu                                  //
///////////////////////////////////////////////////////////////////////
/*Summary
 * 
 * The aim of this project is to find the correlation between Life Expectancy
 * and socioeconomic Indicators like Poverty, Unemployment, Per Capita Income.
 * By finding correlation between these statistics, it is possbiel to determine
 * if unemployment, poverty and the per capita income of houselholds affects
 * life Expectancy.
 * 

 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project
{

    public class LifeExpectancy
    {
        
        static void Main(string[] args)
        {
            string filePath = "..\\..\\data\\" + "actualData" + "\\";
            int size = 0;
            string groceryFilePath=filePath+ "Grocery_Stores_2013.csv";
            string foodInspFilePath = filePath + "Food_Inspections_2013.csv";
            string buildingViolationPath = filePath + "Building_Violations.csv";

            Console.WriteLine("\n\n Please wait...It may take a few minutes for the data to load");
            
            ParseData pd = new ParseData();
            // Function call to parse grocery file
            Project.ParseData.Grocery[] groceryStoresData = pd.parseGroceryData(groceryFilePath);
            
            // Function call to parse Food Inspection file
            Project.ParseData.FoodInspection[] foodInspectionData = pd.parseFoodInspection(foodInspFilePath);
            
            // Function call to parse Building Violations file
            Project.ParseData.BuildingViolation[] buildingViolationData = pd.parseBuildingInspection(buildingViolationPath);
            
            //Function call to Analyze data
            Project.ParseData.FinalAnalysis[] finalAnalysis = pd.analysisGroceryFood(groceryStoresData, foodInspectionData, buildingViolationData, ref size);
            pd.displayData(finalAnalysis, ref size);
            
        }
    }
}
