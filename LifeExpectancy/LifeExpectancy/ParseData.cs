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
using MathNet.Numerics.Statistics;


namespace Project
{
    
    public class ParseData
    {
        //Structure for storing parsed data from life Expectancy file
        public struct lifeExpectancy
        {
            public string communityName;
            public string expectancy;            
        };

        //Structure for storing parsed data from Socio Economic Indicators file
        public struct SocioEconomicIndicators
        {
            public string poverty;
            public string unemployment;
            public string perCapitaIncome;
        };


            
        lifeExpectancy[] lifeExpectancyData = new lifeExpectancy[78];       
        SocioEconomicIndicators[] socioeconomicData = new SocioEconomicIndicators[78];
        

        int lifeExpectancyCnt = 0;
        long SocioEconomicIndicatorsCnt = 0;
        long bldg_num = 0;
        
        //Method for parsing the Life Expectancy File         
        public lifeExpectancy[] parselifeExpectancyData(String filePath)
        {
            int i = 0;                
                var reader = new StreamReader(File.OpenRead(@filePath));
                var line0 = reader.ReadLine();
                // Populating lifeExpectancy Data
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    lifeExpectancyData[i].communityName = values[1];
                    lifeExpectancyData[i].expectancy = values[8];                    
                    i++;
                }
                //counter for storing the number of entries in life expectancy file
                lifeExpectancyCnt = i;
                //Console.WriteLine("\n Life Expectancy Data");
                //for (int k = 0; k < lifeExpectancyCnt; k++)
                //{
                //    Console.WriteLine("{0},{1}", lifeExpectancyData[k].communityName, lifeExpectancyData[k].expectancy);
                //}
                    return lifeExpectancyData;
        }

        //Method for parsing the Socio Economic Indicators File         
        public SocioEconomicIndicators[] parsesocioEconomicData(String SocioEconomicIndicatorsFilePath)
        {
            long j = 0;
            long num = 0;                
                var reader1 = new StreamReader(File.OpenRead(SocioEconomicIndicatorsFilePath));
                var line0_new = reader1.ReadLine();
                // Populating Socio Economic Indicators Data
                while (!reader1.EndOfStream)
                {
                    var line = reader1.ReadLine();
                    var values = line.Split(',');                    
                    socioeconomicData[j].unemployment = values[4];
                    socioeconomicData[j].poverty = values[3];
                    socioeconomicData[j].perCapitaIncome = values[7];
                    j++;
                    
                }
                //counter for storing the number of entries in life expectancy file
                SocioEconomicIndicatorsCnt = j;

            //Console.WriteLine("\n Socio Economic Indicators");

            //    for (int k = 0; k < SocioEconomicIndicatorsCnt; k++)
            //    {
            //        Console.WriteLine("{0} {1} {2}", socioeconomicData[k].perCapitaIncome, socioeconomicData[k].poverty, socioeconomicData[k].unemployment);
            //    }

                    return socioeconomicData;
        }

       
        //Method for Calculating the Correlation between Life Expectancy and Socio Economic Indicators        
        public void CorrelationAnalysis(lifeExpectancy[] lifeExpectancyData, SocioEconomicIndicators[] socioEconomicData)
        {
     

            double[] expectancy = new double[78];
            double[] poverty = new double[78];
            double[] unemployment = new double[78];
            double[] perCapitaIncome = new double[78];

            for (int k = 0; k < 1; k++)
            {
                expectancy[k] = Convert.ToDouble(lifeExpectancyData[k].expectancy);
            }
            for (int k = 0; k < 1; k++)
            {
                poverty[k] = Convert.ToDouble(socioEconomicData[k].poverty);
            }
            for (int k = 0; k < socioEconomicData.Length; k++)
            {
                unemployment[k] = Convert.ToDouble(socioEconomicData[k].unemployment);
            }
            for (int k = 0; k < socioEconomicData.Length; k++)
            {
                perCapitaIncome[k] = Convert.ToDouble(socioEconomicData[k].perCapitaIncome);
            }
            //Pearson Correlation for calculating correlation
            var correlLifePoverty = Correlation.Pearson(expectancy, poverty);            
            var correlLifeUnemp = Correlation.Pearson(expectancy, unemployment);
            var correlLifePerCapita = Correlation.Pearson(expectancy, perCapitaIncome);
            Console.WriteLine("\n Correlation between Life Expectancy and Poverty is  {0} ", correlLifePoverty);
            Console.WriteLine("\n Correlation between Life Expectancy and Unemployment is {0} ", correlLifeUnemp);
            Console.WriteLine("\n Correlation between Life Expectancy and Per Capita Income is {0} ", correlLifePerCapita);
                      
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
