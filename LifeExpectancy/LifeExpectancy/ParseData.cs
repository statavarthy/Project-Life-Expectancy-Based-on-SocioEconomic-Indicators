////////////////////////////////////////////////////////////////////////
// ParseData.cs - Program for defining methods to parse different data//
//                and analyze them                                    //
// Language:    C#, .Net Framework 4.0                                //
// Application: Open Source Computing, Project, Summer 2015              //
// Author:      SMRUTI TATAVARTHY, COMP 412, Loyola University        //
//              statavarthy@luc.edu                                   //
////////////////////////////////////////////////////////////////////////
/*Summary
 * This program contain methods for parsing data.
 * The different methods help in populating the life Expectancy and 
 * and SocioEconomic Indicators
 * The Analysis method helps in identifying the correlation between 
 * the life Expectancy and SocioEconomic Indicators.
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
    public class ParseData
    {
        public struct lifeExpectancy
        {
            public string communityName;
            public string expectancy;            
        };

        public struct SocioEconomicIndicators
        {
            public string poverty;
            public string unemployment;
            public string perCapitaIncome;
        };


        public struct CorrelationAnalysis
        {
            public string communityName;
            public string storeName;
            public string storeLicenceID;
            public string addressFailedGrocery;
            public string violation;
        };

        public struct TempRecordMatch
        {
            public string status;
            public string licenseID;
            public DateTime date;
        }
            
        lifeExpectancy[] lifeExpectancyData = new lifeExpectancy[6000];
        CorrelationAnalysis[] finalCorrelationData = new CorrelationAnalysis[20000];
        SocioEconomicIndicators[] socioeconomicData = new SocioEconomicIndicators[200000];
        //TempRecordMatch[] record_match = new TempRecordMatch[1000];

        int lifeExpectancyCnt = 0;
        long SocioEconomicIndicatorsCnt = 0;
        long bldg_num = 0;
        
        //Method for parsing the Grocery Stores File         
        public lifeExpectancy[] parselifeExpectancyData(String filePath)
        {
            int i = 0;    
            // STEP - 1 : Parse the "Grocery Stores" data            
            //try
            //{


                var reader = new StreamReader(File.OpenRead(@filePath));
                var line0 = reader.ReadLine();
                // Populating groceryData
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    lifeExpectancyData[i].communityName = values[1];
                    lifeExpectancyData[i].expectancy = values[8];                    
                    i++;
                }

                lifeExpectancyCnt = i;
                Console.WriteLine("\n Life Expectancy Data");
                for (int k = 0; k < lifeExpectancyCnt; k++)
                {
                    Console.WriteLine("{0},{1}", lifeExpectancyData[k].communityName, lifeExpectancyData[k].expectancy);
                }
                    return lifeExpectancyData;
        }

        //Method for parsing the Food Inspections File         

        public SocioEconomicIndicators[] parsesocioEconomicData(String SocioEconomicIndicatorsFilePath)
        {
            long j = 0;
            long num = 0;

                // STEP - 2 : Parse the Food Inspections data
                var reader1 = new StreamReader(File.OpenRead(SocioEconomicIndicatorsFilePath));
                var line0_new = reader1.ReadLine();

                while (!reader1.EndOfStream)
                {
                    var line = reader1.ReadLine();
                    var values = line.Split(',');
                    //checking the start of each line  
                    socioeconomicData[j].unemployment = values[4];
                    socioeconomicData[j].poverty = values[3];
                    socioeconomicData[j].perCapitaIncome = values[7];
                    j++;
                    
                }
                SocioEconomicIndicatorsCnt = j;

            Console.WriteLine("\n Socio Economic Indicators");

                for (int k = 0; k < SocioEconomicIndicatorsCnt; k++)
                {
                    Console.WriteLine("{0} {1} {2}", socioeconomicData[k].perCapitaIncome, socioeconomicData[k].poverty, socioeconomicData[k].unemployment);
                }

                    return socioeconomicData;
        }

       
        //Method for Analyzing the Grocery Stores. Food Inspection and Building Violations File        
        public CorrelationAnalysis[] finalCorrelationAnalysis(lifeExpectancy[] lifeExpectancyData, SocioEconomicIndicators[] socioEconomicData, ref int n)
        {
            
       
            
           return finalCorrelationData;
           
        }
        //public void displayData(FinalAnalysis[] finalAnalysis, ref int n)
        //{
        //    int i = 0;
        //    //Display records for the user by giving options about the different analysis
        //    string choice;
        //    string answer = "Y";

        //    Console.WriteLine("\n\n*************************** Chicago Grocery Stores Database*************************************************");

        //    Console.WriteLine("\n\nThe Following Database will give you information about grocery stores that have been inspected in chicago");
        //    Console.WriteLine("It will display the grocery stores that have failed food inspections,have building violations, and that have not been inspected for food.");
        //    Console.WriteLine("This database has been compiled considering the records of 2013 and shows only the FAILED records");

        //    do
        //    {
        //        Console.WriteLine("\n\n******************************************MENU*********************************************************");
        //        Console.WriteLine("\n 1. Grocery Stores that have failed the Inspection");
        //        Console.WriteLine("\n 2. Grocery Stores that have not undergone the Inspection");
        //        Console.WriteLine("\n 3. Grocery Stores with failed Food Inspection and Building Violations");
        //        Console.WriteLine("\n 4. Grocery Stores that have not undergone the Inpsection and have Building violations");
        //        Console.Write("\n Enter your choice : ");
        //        choice = Console.ReadLine();

        //        while(choice!="1"&&choice!="2"&&choice!="3"&&choice!="4")
        //        {
        //            Console.WriteLine("\n Invalid Input Entered!!!!");
        //            Console.Write(" Please reenter your choice (1-4):");
        //            choice = Console.ReadLine();
        //        } 

        //        if (choice == "1")
        //        {
        //            Console.WriteLine("Grocery Stores that have failed Food Inspection : ");
        //            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------");
        //            Console.WriteLine("{0,-15}  {1,-40}  {2,20}  ", "License ID", "Store Name", "Inspection Status");
        //            for (i = 0; i < n; i++)
        //            {
        //                if (string.Compare(finalAnalysis[i].storeInspectionStatus.ToUpper(), "FAIL") == 0)
        //                    Console.WriteLine(string.Format("{0,-15}  {1,-40}  {2,20} ", finalAnalysis[i].storeLicenceID, finalAnalysis[i].storeName, finalAnalysis[i].storeInspectionStatus));

        //            }

        //        }

        //        if (choice == "2")
        //        {
        //            Console.WriteLine("Grocery Stores that have not undergone Food Inspection : ");
        //            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------");
        //            Console.WriteLine("{0,-15}  {1,-40}  {2,20}  ", "License ID", "Store Name", "Inspection Status");
        //            for (i = 0; i < n; i++)
        //            {
        //                if (string.Compare(finalAnalysis[i].storeInspectionStatus.ToUpper(), "NOT INSPECTED") == 0)
        //                    Console.WriteLine(string.Format("{0,-15}  {1,-40}  {2,20} ", finalAnalysis[i].storeLicenceID, finalAnalysis[i].storeName, finalAnalysis[i].storeInspectionStatus));

        //            }

        //        }

        //        if (choice == "3")
        //        {
        //            Console.WriteLine("Grocery Stores that have failed Food Inspection and have building violations : ");
        //            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------");
        //            Console.WriteLine("{0,-15}  {1,-40}  {2,20} {3,40} ", "License ID", "Store Name", "Inspection Status", " Building Violation");
        //            for (i = 0; i < n; i++)
        //            {
        //                if ((string.Compare(finalAnalysis[i].storeInspectionStatus.ToUpper(), "FAIL") == 0) && (string.Compare(finalAnalysis[i].violation.ToUpper(), "NO BUILDING VIOLATION") != 0))
        //                    Console.WriteLine(string.Format("{0,-15}  {1,-40}  {2,20}  {3,40}", finalAnalysis[i].storeLicenceID, finalAnalysis[i].storeName, finalAnalysis[i].storeInspectionStatus, finalAnalysis[i].violation));
        //            }

        //        }

        //        if (choice == "4")
        //        {
        //            Console.WriteLine("Grocery Stores that have failed Food Inspection and have building violations : ");
        //            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------");
        //            Console.WriteLine("{0,-15}  {1,-40}  {2,20}  {3,40}", "License ID", "Store Name", "Inspection Status", " Building Violation");
        //            for (i = 0; i < n; i++)
        //            {
        //                if ((string.Compare(finalAnalysis[i].storeInspectionStatus.ToUpper(), "NOT INSPECTED") == 0) && (string.Compare(finalAnalysis[i].violation.ToUpper(), "NO BUILDING VIOLATION") == 1))
        //                    Console.WriteLine(string.Format("{0,-15}  {1,-40}  {2,20}  {3,40}", finalAnalysis[i].storeLicenceID, finalAnalysis[i].storeName, finalAnalysis[i].storeInspectionStatus, finalAnalysis[i].violation));
        //            }

        //        }                    
        //        Console.Write("\n Do you wish to continue ? (Y/N) : ");
        //        answer = Console.ReadLine();
        //        while(string.Compare(answer.ToUpper(), "N")!=0 &&string.Compare(answer.ToUpper(), "Y")!=0)
        //        {
        //            Console.WriteLine("\n Invalid Input Entered!!!!");
        //            Console.Write(" Please reenter your choice , Do you wish to continue (Y/N) : ");
        //            answer = Console.ReadLine();
        //        } 
                
        //    }while ((string.Compare(answer.ToUpper(), "Y") == 0));

                           
          
        //}
    }
}
